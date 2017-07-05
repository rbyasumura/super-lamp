using Advance.Framework.Interfaces.Contexts.Infrastructure;
using System.Collections.Generic;

namespace Advance.Framework.Repositories.Interfaces.Handlers
{
    public interface IChangeHandler
    {
        void Handle(IEnumerable<ITrackedEntry> changedEntries);
    }
}
