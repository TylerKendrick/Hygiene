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
        ISanitizerTypeBuilder<TProperty> Property<TProperty>(
            Expression<Func<T, TProperty>> memberExpression);

        ISanitizerTypeBuilder<T> Transform(Visitor<T> visitor);
        ISanitizerTypeBuilder<T> Transform(AsyncVisitor<T> visitor);
        ISanitizerTypeBuilder<T> Transform(Func<T, T> mutator);
        ISanitizerTypeBuilder<T> Transform(Func<T, Task<T>> mutator);
    }
}