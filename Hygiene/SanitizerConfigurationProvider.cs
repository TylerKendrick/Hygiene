using System;

namespace Hygiene
{
    public class SanitizerConfigurationProvider : IConfigurationProvider
    {
        private readonly SanitizerBuilder _builder = new SanitizerBuilder();

        public SanitizerConfigurationProvider(
            Action<SanitizerBuilder> config)
            => config(_builder);

        public ISanitizer<T> CreateSanitizer<T>() => _builder.BuildType<T>();
    }
}