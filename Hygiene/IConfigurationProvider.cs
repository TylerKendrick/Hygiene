namespace Hygiene
{
    /// <summary>
    /// Used to provide sanitizer instances configured with a <see cref="SanitizerBuilder"/>.
    /// </summary>
    public interface IConfigurationProvider
    {
        /// <summary>
        /// Used to generate new instances of an <see cref="ISanitizer{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type to be sanitized.</typeparam>
        /// <returns>A new instance of an <see cref="ISanitizer{T}"/>.</returns>
        ISanitizer<T> CreateSanitizer<T>();
    }
}