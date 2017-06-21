using System;
using System.Collections.Generic;

namespace Advance.Framework.Interfaces.Repositories
{
    [Flags]
    public enum EntityState
    {
        Detached = 1,
        Unchanged = 2,
        Added = 4,
        Deleted = 8,
        Modified = 16
    }

    public interface ITrackedEntry
    {
        EntityState State { get; set; }
        object Entity { get; }
        IPropertyValues OriginalValues { get; }
    }

    public interface ITrackedEntry<TEntity> : ITrackedEntry
    {
        IEnumerable<ITrackedEntry> References { get; }
        IEnumerable<ITrackedEntry> Collections { get; }
        new TEntity Entity { get; }
    }
}
