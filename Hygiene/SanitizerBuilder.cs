using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hygiene
{
    /// <summary>
    /// Provides methods to create type specific sanitizer visitors and transformations.
    /// </summary>
    public sealed class SanitizerBuilder
    {
        private readonly IDictionary<Type, object> _sanitizers
            = new Dictionary<Type, object>();

        internal SanitizerBuilder() { }

        /// <summary>
        /// Creates a specific type sanitizer configuration with the supplied visitor.
        /// </summary>
        /// <typeparam name="T">The type to configure.</typeparam>
        /// <param name="visitor">The transformations to perform on an instance.</param>
        /// <returns>The original object reference with the newly transformed values.</returns>
        public ISanitizerTypeBuilder<T> ForType<T>(Visitor<T> visitor)
            => ForType(new AsyncVisitor<T>((ref T data) =>
            {
                visitor(ref data);
                return Task.CompletedTask;
            }));

        /// <summary>
        /// Creates a specific type sanitizer configuration with the supplied visitor.
        /// </summary>
        /// <typeparam name="T">The type to configure.</typeparam>
        /// <param name="visitor">The transformations to perform on an instance.</param>
        /// <returns>The original object reference with the newly transformed values.</returns>
        public ISanitizerTypeBuilder<T> ForType<T>(AsyncVisitor<T> visitor)
        {
            var result = new SanitizerTypeBuilder<T>();
            result.Transform(visitor);
            _sanitizers.Add(typeof(T), result);
            return result;
        }

        /// <summary>
        /// Creates a specific type sanitizer configuration with the supplied visitor.
        /// </summary>
        /// <typeparam name="T">The type to configure.</typeparam>
        /// <param name="builder">The configuration for a type, given a builder.</param>
        /// <returns>The original object reference with the newly transformed values.</returns>
        public ISanitizerTypeBuilder<T> ForType<T>(Action<ISanitizerTypeBuilder<T>> builder)
        {
            var result = new SanitizerTypeBuilder<T>();
            builder(result);
            _sanitizers.Add(typeof(T), result);
            return result;
        }

        internal ISanitizer<T> BuildType<T>() =>
            _sanitizers.ContainsKey(typeof(T))
            && _sanitizers[typeof(T)] is SanitizerTypeBuilder<T> @out
                ? new DelegateSanitizer<T>(@out.BuildVisitor())
                : throw new KeyNotFoundException($"The type {typeof(T).Name} wasn't registered.");
    }
}