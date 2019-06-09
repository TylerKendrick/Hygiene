using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Hygiene
{
    /// <summary>
    /// Provides methods to configure value transformations for specified types.
    /// </summary>
    /// <typeparam name="T">The type to construct.</typeparam>
    internal sealed class SanitizerTypeBuilder<T> : ISanitizerTypeBuilder<T>
    {
        private readonly Dictionary<PropertyInfo, Func<Delegate>> _propertyVisitors
            = new Dictionary<PropertyInfo, Func<Delegate>>();

        private readonly List<Delegate> _visitors = new List<Delegate>();

        /// <summary>
        /// Creates a new type configuration for the specified property.
        /// </summary>
        /// <typeparam name="TProperty">The type to construct.</typeparam>
        /// <param name="expression">The member expression for mutation.</param>
        /// <returns>A fluent configuration api provider for building types.</returns>
        public ISanitizerTypeBuilder<TProperty> Property<TProperty>(
            Expression<Func<T, TProperty>> expression)
        {
            if(expression.NodeType != ExpressionType.Lambda)
            {
                throw new InvalidOperationException("The expression must be a lambda expression.");
            }
            var parameter = expression.Parameters[0];
            PropertyInfo EvaluateExpressionChain(Expression localExpression)
            {
                if(localExpression.NodeType != ExpressionType.MemberAccess)
                {
                    throw new InvalidOperationException("Only member access expressions are supported.");
                }
                var memberExpression = localExpression as MemberExpression;
                var expressionBody = memberExpression.Expression;
                var propertyInfo = memberExpression.Member as PropertyInfo;
                if (propertyInfo == null)
                {
                    throw new InvalidOperationException("The member access expression must only reference properties.");
                }

                return expressionBody == null || expressionBody == parameter
                    ? propertyInfo
                    : EvaluateExpressionChain(expressionBody);
            }
            var propertyExpression = EvaluateExpressionChain(expression.Body);
            return propertyExpression.GetSetMethod() == null
                ? throw new InvalidOperationException("The property expression must have a publicly accessible setter.")
                : Property<TProperty>(propertyExpression);
        }

        private ISanitizerTypeBuilder<TProperty> Property<TProperty>(
            PropertyInfo propertyInfo)
        {
            var builder = new SanitizerTypeBuilder<TProperty>();
            _propertyVisitors.Add(propertyInfo, () => builder.BuildVisitor());
            return builder;
        }

        /// <summary>
        /// Configures a sanitizer instance to use the provided delegate for transformation.
        /// </summary>
        /// <param name="visitor">The delegate used to transform instance values.</param>
        /// <returns>A fluent configuration api provider.</returns>
        public ISanitizerTypeBuilder<T> Transform(AsyncVisitor<T> visitor)
        {
            _visitors.Add(visitor);
            return this;
        }

        /// <summary>
        /// Configures a sanitizer instance to use the provided delegate for transformation.
        /// </summary>
        /// <param name="visitor">The delegate used to transform instance values.</param>
        /// <returns>A fluent configuration api provider.</returns>
        public ISanitizerTypeBuilder<T> Transform(Visitor<T> visitor)
            => Transform((ref T data) =>
            {
                visitor(ref data);
                return Task.CompletedTask;
            });

        /// <summary>
        /// Configures a sanitizer instance to use the provided delegate for transformation.
        /// </summary>
        /// <param name="mutator">The delegate used to transform instance values.</param>
        /// <returns>A fluent configuration api provider.</returns>
        public ISanitizerTypeBuilder<T> Transform(Func<T, T> mutator)
            => Transform((ref T data) => data = mutator(data));

        /// <summary>
        /// Configures a sanitizer instance to use the provided delegate for transformation.
        /// </summary>
        /// <param name="mutator">The delegate used to transform instance values.</param>
        /// <returns>A fluent configuration api provider.</returns>
        public ISanitizerTypeBuilder<T> Transform(Func<T, Task<T>> mutator)
            => Transform((ref T data) => data = mutator(data)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult());

        internal AsyncVisitor<T> BuildVisitor()
        {
            var result = (AsyncVisitor<T>)Delegate.Combine(_visitors.ToArray());
            foreach(var propertyVisitorPair in _propertyVisitors)
            {
                var propertyInfo = propertyVisitorPair.Key;
                var visitor = propertyVisitorPair.Value();
                result += visitor is AsyncVisitor<T>
                    ? (AsyncVisitor<T>)visitor
                    : new AsyncVisitor<T>((ref T data) =>
                    {
                        var property = propertyInfo.GetValue(data);
                        var args = new[] { property };
                        visitor.DynamicInvoke(args);
                        propertyInfo.SetValue(data, args[0]);
                        return Task.CompletedTask;
                    });
            }
            return result;
        }
    }
}