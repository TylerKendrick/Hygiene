using System.Threading.Tasks;

namespace Hygiene
{
    /// <summary>    
    ///     Takes in data by reference with the intention of performing mutations.
    /// </summary>
    /// <typeparam name="T">The target data-type.</typeparam>
    /// <param name="data">The instance target for modification.</param>
    /// <returns>An awaitable task to perform async transformations.</returns>
    public delegate Task AsyncVisitor<T>(ref T data);
}