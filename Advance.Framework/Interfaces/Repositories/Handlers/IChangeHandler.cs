using System.Collections.Generic;

namespace Advance.Framework.Interfaces.Repositories.Handlers
{
    internal interface IChangeHandler
    {
        void Handle(IEnumerable<IChangedEntry> changedEntries);
    }
}
