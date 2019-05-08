using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Hygiene
{
    internal sealed class SanitizerTypeBuilder<T> : ISanitizerTypeBuilder<T>
    {
        private readonly Dictionary<PropertyInfo, Func<Delegate>> _propertyVisitors
            = new Dictionary<PropertyInfo, Func<Delegate>>();

        private readonly List<Delegate> _visitors = new List<Delegate>();

        public ISanitizerTypeBuilder<TProperty> Property<TProperty>(
            Expression<Func<T, TProperty>> memberExpression)
        {
            var expression = (MemberExpression)memberExpression.Body;
            var memberInfo = expression.Member;
            return Property<TProperty>(memberInfo as PropertyInfo);
        }

        private ISanitizerTypeBuilder<TProperty> Property<TProperty>(
            PropertyInfo propertyInfo)
        {
            var builder = new SanitizerTypeBuilder<TProperty>();
            _propertyVisitors.Add(propertyInfo, () => builder.BuildVisitor());
            return builder;
        }

        public ISanitizerTypeBuilder<T> Transform(Visitor<T> visitor)
            => Transform(new AsyncVisitor<T>((ref T data) =>
            {
                visitor(ref data);
                return Task.CompletedTask;
            }));

        public ISanitizerTypeBuilder<T> Transform(AsyncVisitor<T> visitor)
        {
            _visitors.Add(visitor);
            return this;
        }

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