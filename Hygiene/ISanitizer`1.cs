using System.Threading.Tasks;

namespace Hygiene
{
    /// <summary>
    /// Acts as a visitor that normalizes data to an expected format.
    /// </summary>
    public interface ISanitizer<T>
    {
        /// <summary>
        /// Executes the configured sanitization logic for a constructed type.
        /// </summary>
        /// <param name="data">The instance to be sanitized.</param>
        /// <returns>An awaitable task for synchronizing asynchronous operations.</returns>
        Task SanitizeAsync(ref T data);

        /// <summary>
        /// Executes the configured sanitization logic for a constructed type.
        /// </summary>
        /// <param name="data">The instance to be sanitized.</param>
        /// <returns>An awaitable task for synchronizing asynchronous operations.</returns>
        void Sanitize(ref T data);
    }
}