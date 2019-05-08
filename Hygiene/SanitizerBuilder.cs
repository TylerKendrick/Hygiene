using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hygiene
{
    public sealed class SanitizerBuilder
    {
        private readonly IDictionary<Type, object> _sanitizers
            = new Dictionary<Type, object>();

        internal SanitizerBuilder() { }

        public ISanitizerTypeBuilder<T> ForType<T>(Visitor<T> visitor)
            => ForType(new AsyncVisitor<T>((ref T data) =>
            {
                visitor(ref data);
                return Task.CompletedTask;
            }));

        public ISanitizerTypeBuilder<T> ForType<T>(AsyncVisitor<T> visitor)
        {
            var result = new SanitizerTypeBuilder<T>();
            result.Transform(visitor);
            _sanitizers.Add(typeof(T), result);
            return result;
        }

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