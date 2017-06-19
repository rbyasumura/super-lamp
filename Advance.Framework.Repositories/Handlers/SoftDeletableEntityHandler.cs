using Advance.Framework.Interfaces.Entities;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Interfaces.Repositories.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advance.Framework.Repositories.Handlers
{
    internal class SoftDeletableEntityHandler : IChangeHandler
    {
        public void Handle(IEnumerable<IEntityEntry> changedEntries)
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
