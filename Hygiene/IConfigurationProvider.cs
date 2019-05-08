namespace Hygiene
{
    public interface IConfigurationProvider
    {
        ISanitizer<T> CreateSanitizer<T>();
    }
}