using System;

namespace Advance.Framework.Repositories
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
}
