using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Repositories;
using System;
using System.Data.Entity.Infrastructure;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers
{
    internal class DbEntityEntryWrapper : IChangedEntry
    {
        private DbEntityEntry entityEntry;

        public DbEntityEntryWrapper(DbEntityEntry entityEntry)
        {
            this.entityEntry = entityEntry;
        }

        public object Entity => entityEntry.Entity;
        public EntityState State { get => (EntityState)entityEntry.State; set => entityEntry.State = (System.Data.Entity.EntityState)value; }

        public object ParentEntry
        {
            get
            {
                foreach (var propertyName in entityEntry.CurrentValues.PropertyNames)
                {
                    var x = entityEntry.Property(propertyName);
                }

                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// If the Entity properties are equal, then the Entry is equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (GetType().Equals(obj.GetType()) == false)
            {
                return false;
            }

            var dbEntityEntryWrapper = (DbEntityEntryWrapper)obj;
            return Entity.Equals(dbEntityEntryWrapper.Entity);
        }

        public override int GetHashCode()
        {
            return Entity.GetHashCode();
        }
    }
}
