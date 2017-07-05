using System;
using System.Collections.Generic;

namespace Advance.Framework.Interfaces.Contexts.Infrastructure
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
        IEnumerable<ITrackedEntry> Collections { get; }
        object Entity { get; }
        IPropertyValues OriginalValues { get; }
        IEnumerable<ITrackedEntry> References { get; }
        EntityState State { get; set; }
    }

    public interface ITrackedEntry<TEntity> : ITrackedEntry
    {
        new TEntity Entity { get; }
    }
}
