using System;
using System.Collections.Generic;

namespace Advance.Framework.Interfaces.Repositories
{
    public interface IContext : IDisposable
    {
        IEnumerable<IChangedEntry> GetChangedEntries();

        int Commit();
    }
}
