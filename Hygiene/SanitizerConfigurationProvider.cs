using System;

namespace Hygiene
{
    /// <summary>
    /// Creates sanitizer instances based on the provided builder configuration.
    /// </summary>
    public class SanitizerConfigurationProvider : IConfigurationProvider
    {
        private readonly SanitizerBuilder _builder = new SanitizerBuilder();

        /// <summary>
        /// Provides a delegate for configuring the type builders.
        /// </summary>
        /// <param name="config">The delegate used for configuration.</param>
        public SanitizerConfigurationProvider(
            Action<SanitizerBuilder> config)
            => config(_builder);

        /// <summary>
        /// Uses the configured type builders to provide a new <see cref="Sanitizer"/> instance.
        /// </summary>
        /// <typeparam name="T">The type to sanitize.</typeparam>
        /// <returns>A new instance of a sanitizer.</returns>
        public ISanitizer<T> CreateSanitizer<T>() => _builder.BuildType<T>();
    }
}