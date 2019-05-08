using System.Threading.Tasks;

namespace Hygiene
{
    /// <summary>
    /// Acts as a visitor that normalizes data to an expected format.
    /// </summary>
    public interface ISanitizer<T>
    {
        Task SanitizeAsync(ref T data);
        void Sanitize(ref T data);
    }
}