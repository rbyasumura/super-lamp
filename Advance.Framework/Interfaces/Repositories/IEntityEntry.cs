﻿using System;

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

    public interface IEntityEntry
    {
        object Entity { get; }
        EntityState State { get; set; }
    }
}