namespace Hygiene
{
    /// <summary>
    /// Takes in data by reference with the intention of performing mutations.
    /// </summary>
    /// <typeparam name="T">The target data-type.</typeparam>
    /// <param name="data">The instance target for modification.</param>
    public delegate void Visitor<T>(ref T data);
}