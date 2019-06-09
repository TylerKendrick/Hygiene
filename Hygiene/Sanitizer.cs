using System;
using System.Threading.Tasks;

namespace Hygiene
{
    /// <summary>
    /// Provides a variety of factory methods for generating sanitizer instances.
    /// </summary>
    public static class Sanitizer
    {
        /// <summary>
        /// Creates a new instance of an <see cref="ISanitizer{T}"/> with the provided configuration.
        /// </summary>
        /// <typeparam name="T">The type to sanitize.</typeparam>
        /// <param name="typeConfig">The custom builder configuration.</param>
        /// <returns>A new instance of an <see cref="ISanitizer{T}"/></returns>
        public static ISanitizer<T> Create<T>(Action<ISanitizerTypeBuilder<T>> typeConfig)
            => new SanitizerConfigurationProvider(
                config => config.ForType(typeConfig))
                .CreateSanitizer<T>();

        /// <summary>
        /// Creates a new instance of an <see cref="ISanitizer{T}"/> with the provided configuration.
        /// </summary>
        /// <typeparam name="T">The type to sanitize.</typeparam>
        /// <param name="visitor">The custom builder configuration.</param>
        /// <returns>A new instance of an <see cref="ISanitizer{T}"/></returns>
        public static ISanitizer<T> Create<T>(Visitor<T> visitor)
            => Create<T>((ISanitizerTypeBuilder<T> builder)
                => builder.Transform(visitor));

        /// <summary>
        /// Creates a new instance of an <see cref="ISanitizer{T}"/> with the provided configuration.
        /// </summary>
        /// <typeparam name="T">The type to sanitize.</typeparam>
        /// <param name="visitor">The custom builder configuration.</param>
        /// <returns>A new instance of an <see cref="ISanitizer{T}"/></returns>
        public static ISanitizer<T> Create<T>(AsyncVisitor<T> visitor)
            => Create<T>((ISanitizerTypeBuilder<T> builder)
                => builder.Transform(visitor));

        /// <summary>
        /// Creates a new instance of an <see cref="ISanitizer{T}"/> with the provided configuration.
        /// </summary>
        /// <typeparam name="T">The type to sanitize.</typeparam>
        /// <param name="mutator">The custom builder configuration.</param>
        /// <returns>A new instance of an <see cref="ISanitizer{T}"/></returns>
        public static ISanitizer<T> Create<T>(Func<T, T> mutator)
            => Create<T>((ISanitizerTypeBuilder<T> builder)
                => builder.Transform(mutator));

        /// <summary>
        /// Creates a new instance of an <see cref="ISanitizer{T}"/> with the provided configuration.
        /// </summary>
        /// <typeparam name="T">The type to sanitize.</typeparam>
        /// <param name="mutator">The custom builder configuration.</param>
        /// <returns>A new instance of an <see cref="ISanitizer{T}"/></returns>
        public static ISanitizer<T> Create<T>(Func<T, Task<T>> mutator)
            => Create<T>((ISanitizerTypeBuilder<T> builder)
                => builder.Transform(mutator));

        /// <summary>
        /// Creates a sanitizer without an implementation.  Useful for testing and stubbing code.
        /// </summary>
        /// <typeparam name="T">The type for sanitization.</typeparam>
        /// <returns>A new instance of an <see cref="ISanitizer{T}"/></returns>
        public static ISanitizer<T> NoOp<T>()
            => new DelegateSanitizer<T>(delegate { return Task.CompletedTask; });
    }
}