using Advance.Framework.Interfaces.Entities;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Interfaces.Repositories.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advance.Framework.Repositories.Handlers
{
    internal class TimestampableEntityHandler : IChangeHandler
    {
        public void Handle(IEnumerable<IEntityEntry> changedEntries)
        {
            foreach (var entry in changedEntries.Where(i => (i.State == EntityState.Added || i.State == EntityState.Modified)
                && typeof(ITimestampableEntity).IsAssignableFrom(i.Entity.GetType())))
            {
                var timestampableEntity = (ITimestampableEntity)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    timestampableEntity.CreatedAt = DateTimeOffset.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    timestampableEntity.UpdatedAt = DateTimeOffset.Now;
                }
            }
        }
    }
}
