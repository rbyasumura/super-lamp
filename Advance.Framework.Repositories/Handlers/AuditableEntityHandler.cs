using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Interfaces.Repositories.Handlers;
using System.Collections.Generic;

namespace Advance.Framework.Repositories.Handlers
{
    internal class AuditableEntityHandler : IChangeHandler
    {
        public void Handle(IEnumerable<IEntityEntry> changedEntries)
        {
            /// TODO
            //foreach (var entry in changedEntries.Where(i => typeof(IAuditableEntity).IsAssignableFrom(i.Entity.GetType())))
            //{
            //    var auditableEntity = (IAuditableEntity)entry.Entity;
            //    (i.State == EntityState.Added || i.State == EntityState.Modified)
            //   &&
            //    auditableEntity
            //    softDeletableEntity.DeletedAt = DateTimeOffset.Now;
            //}
        }
    }
}
