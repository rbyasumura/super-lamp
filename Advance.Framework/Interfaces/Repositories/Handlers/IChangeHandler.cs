using System.Collections.Generic;

namespace Advance.Framework.Interfaces.Repositories.Handlers
{
    public interface IChangeHandler
    {
        void Handle(IEnumerable<IEntityEntry> changedEntries);
    }
}
