using Advance.Framework.Interfaces.Contexts.Infrastructure;
using Advance.Framework.Interfaces.Entities;
using Advance.Framework.Repositories.Interfaces.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advance.Framework.Repositories.Handlers
{
    internal class SoftDeletableEntityHandler : IChangeHandler
    {
        public void Handle(IEnumerable<ITrackedEntry> changedEntries)
        {
            foreach (var entry in changedEntries.Where(i => i.State == EntityState.Deleted
                && typeof(ISoftDeletableEntity).IsAssignableFrom(i.Entity.GetType())))
            {
                var softDeletableEntity = (ISoftDeletableEntity)entry.Entity;
                softDeletableEntity.DeletedAt = DateTimeOffset.Now;
            }
        }
    }
}
