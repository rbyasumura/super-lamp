using Advance.Framework.Entities.Helpers;
using Advance.Framework.Interfaces.Entities;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Interfaces.Repositories.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advance.Framework.Repositories.Handlers
{
    internal class VersionedEntityHandler : IChangeHandler
    {
        private ContextWrapperBase context;

        internal VersionedEntityHandler(ContextWrapperBase context)
        {
            this.context = context;
        }

        public void Handle(IEnumerable<ITrackedEntry> changedEntries)
        {
            var versionId = Guid.NewGuid();
            var _changedEntries = changedEntries.Where(i => (i.State == EntityState.Added || i.State == EntityState.Modified)
                  && typeof(IVersionedEntity).IsAssignableFrom(i.Entity.GetType()))
                  .ToArray();
            foreach (var entry in _changedEntries)
            {
                var versionedEntity = (IVersionedEntity)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    versionedEntity.VersionId = Guid.NewGuid();
                }
                else if (entry.State == EntityState.Modified)
                {
                    var entityType = versionedEntity.GetType();

                    /// Clone entity
                    var originalValues = entry.OriginalValues;
                    var originalEntity = (IVersionedEntity)originalValues.ToObject();

                    /// Assign new primary key
                    var property = entityType.GetProperty(EntityUtility.GetIdPropertyName(entityType));
                    property.SetValue(originalEntity, Guid.NewGuid());

                    /// Assign version
                    originalEntity.VersionId = versionId;
                    versionedEntity.PreviousVersionId = originalEntity.VersionId;

                    context.Add(originalEntity);
                }
            }
        }
    }
}
