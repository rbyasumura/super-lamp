using Advance.Framework.Repositories;

namespace Advance.Framework.Interfaces.Repositories
{
    public interface IChangedEntry
    {
        EntityState State { get; }
        object Entity { get; }
    }
}
