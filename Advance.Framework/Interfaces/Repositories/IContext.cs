using System;
using System.Collections.Generic;

namespace Advance.Framework.Interfaces.Repositories
{
    public interface IContext : IDisposable
    {
        ITransaction Transaction { get; }

        IEnumerable<IChangedEntry> GetChangedEntries();

        int SaveChanges();
    }
}
