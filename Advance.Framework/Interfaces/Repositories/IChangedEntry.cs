using Advance.Framework.Repositories;

namespace Advance.Framework.Interfaces.Repositories
{
    public interface IChangedEntry
    {
        EntityState State { get; set; }
        object Entity { get; }
        object ParentEntry { get; }
    }
}
