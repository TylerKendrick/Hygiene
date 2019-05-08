using System;

namespace Hygiene
{
    /// <summary>
    /// Creates sanitizer instances based on the provided builder configuration.
    /// </summary>
    public class SanitizerConfigurationProvider : IConfigurationProvider
    {
        private readonly SanitizerBuilder _builder = new SanitizerBuilder();

        public SanitizerConfigurationProvider(
            Action<SanitizerBuilder> config)
            => config(_builder);

        public ISanitizer<T> CreateSanitizer<T>() => _builder.BuildType<T>();
    }
}