using System.Threading.Tasks;

namespace Hygiene
{
    public delegate Task AsyncVisitor<T>(ref T data);
}