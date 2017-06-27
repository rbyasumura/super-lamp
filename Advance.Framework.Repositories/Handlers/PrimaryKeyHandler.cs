using Advance.Framework.Entities.Helpers;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Interfaces.Repositories.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advance.Framework.Repositories.Handlers
{
    internal class PrimaryKeyHandler : IChangeHandler
    {
        public void Handle(IEnumerable<ITrackedEntry> changedEntities)
        {
            foreach (var entityEntry in changedEntities.Where(i => i.State == EntityState.Added))
            {
                var entity = entityEntry.Entity;
                var entityType = entity.GetType();
                var property = EntityUtility.GetIdProperty(entityType);
                var value = property.GetValue(entity);
                if (value.GetType() == typeof(Guid))
                {
                    var guid = (Guid)value;
                    if (guid == Guid.Empty)
                    {
                        property.SetValue(entity, Guid.NewGuid());
                    }
                }
            }
        }
    }
}
