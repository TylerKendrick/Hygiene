using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hygiene
{
    /// <summary>
    /// Provides fluent operations to build configurations for a <see cref="ISanitizer{T}"/> instance.
    /// </summary>
    /// <typeparam name="T">The type used for generating configurations.</typeparam>
    public interface ISanitizerTypeBuilder<T>
    {
        /// <summary>
        /// Provides a new <see cref="ISanitizerTypeBuilder{T}"/> instance for the mapped property.
        /// </summary>
        /// <typeparam name="TProperty">The type to be sanitized.</typeparam>
        /// <param name="memberExpression">A member access expression to a settable property.</param>
        /// <returns>A new instance of a <see cref="ISanitizerTypeBuilder{T}"/>.</returns>
        ISanitizerTypeBuilder<TProperty> Property<TProperty>(
            Expression<Func<T, TProperty>> memberExpression);

        /// <summary>
        /// Provides the delegate used to transform and sanitize input.
        /// </summary>
        /// <param name="visitor">The delegate for sanitization.</param>
        /// <returns>The current fluent instance of the type builder.</returns>
        ISanitizerTypeBuilder<T> Transform(Visitor<T> visitor);

        /// <summary>
        /// Provides the delegate used to transform and sanitize input.
        /// </summary>
        /// <param name="visitor">The delegate for sanitization.</param>
        /// <returns>The current fluent instance of the type builder.</returns>
        ISanitizerTypeBuilder<T> Transform(AsyncVisitor<T> visitor);

        /// <summary>
        /// Provides the delegate used to transform and sanitize input.
        /// </summary>
        /// <param name="mutator">The delegate for sanitization.</param>
        /// <returns>The current fluent instance of the type builder.</returns>
        ISanitizerTypeBuilder<T> Transform(Func<T, T> mutator);

        /// <summary>
        /// Provides the delegate used to transform and sanitize input.
        /// </summary>
        /// <param name="mutator">The delegate for sanitization.</param>
        /// <returns>The current fluent instance of the type builder.</returns>
        ISanitizerTypeBuilder<T> Transform(Func<T, Task<T>> mutator);
    }
}