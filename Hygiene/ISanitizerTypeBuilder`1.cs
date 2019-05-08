using System;
using System.Linq.Expressions;

namespace Hygiene
{
    public interface ISanitizerTypeBuilder<T>
    {
        ISanitizerTypeBuilder<TProperty> Property<TProperty>(
            Expression<Func<T, TProperty>> memberExpression);

        ISanitizerTypeBuilder<T> Transform(Visitor<T> visitor);
        ISanitizerTypeBuilder<T> Transform(AsyncVisitor<T> visitor);
    }
}