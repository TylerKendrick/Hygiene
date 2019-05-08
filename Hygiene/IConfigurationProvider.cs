namespace Hygiene
{
    /// <summary>
    /// Used to provide sanitizer instances configured with a <see cref="SanitizerBuilder"/>.
    /// </summary>
    public interface IConfigurationProvider
    {
        ISanitizer<T> CreateSanitizer<T>();
    }
}