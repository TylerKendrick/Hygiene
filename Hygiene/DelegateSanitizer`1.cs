using System.Threading.Tasks;

namespace Hygiene
{
    /// <summary>
    /// Converts a delegate into a sanitizer instance.
    /// </summary>
    /// <typeparam name="T">The type of object to sanitize.</typeparam>
    internal class DelegateSanitizer<T> : ISanitizer<T>
    {
        private readonly AsyncVisitor<T> _visitor;

        internal DelegateSanitizer(AsyncVisitor<T> visitor)
            => _visitor = visitor;

        /// <summary>
        /// Executes the configured sanitization logic for a constructed type.
        /// </summary>
        /// <param name="data">The instance to be sanitized.</param>
        /// <returns>An awaitable task for synchronizing asynchronous operations.</returns>
        public Task SanitizeAsync(ref T data)
            => _visitor(ref data);

        /// <summary>
        /// Executes the configured sanitization logic for a constructed type.
        /// </summary>
        /// <param name="data">The instance to be sanitized.</param>
        /// <returns>An awaitable task for synchronizing asynchronous operations.</returns>
        public void Sanitize(ref T data)
            => SanitizeAsync(ref data)
            .ConfigureAwait(false)
            .GetAwaiter()
            .GetResult();
    }
}