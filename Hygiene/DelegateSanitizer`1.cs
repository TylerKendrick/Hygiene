using System.Threading.Tasks;

namespace Hygiene
{
    internal class DelegateSanitizer<T> : ISanitizer<T>
    {
        private readonly AsyncVisitor<T> _visitor;

        internal DelegateSanitizer(AsyncVisitor<T> visitor) => _visitor = visitor;

        public Task SanitizeAsync(ref T data)
            => _visitor(ref data);

        public void Sanitize(ref T data)
            => SanitizeAsync(ref data)
            .ConfigureAwait(false)
            .GetAwaiter()
            .GetResult();
    }
}