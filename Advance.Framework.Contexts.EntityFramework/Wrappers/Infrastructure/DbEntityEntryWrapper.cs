using Advance.Framework.Interfaces.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers
{
    internal class DbEntityEntryWrapper : ITrackedEntry
    {
        private DbContextWrapper contextWrapper;
        private DbEntityEntry entityEntry;

        public DbEntityEntryWrapper(DbContextWrapper contextWrapper, DbEntityEntry entityEntry)
        {
            this.contextWrapper = contextWrapper;
            this.entityEntry = entityEntry;
        }

        public IEnumerable<ITrackedEntry> Collections
        {
            get
            {
                foreach (var propertyName in GetPropertyNames())
                {
                    var collectionEntry = default(DbCollectionEntry);
                    try
                    {
                        collectionEntry = EntityEntry.Collection(propertyName);
                        if (collectionEntry.CurrentValue == null)
                        {
                            continue;
                        }
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }

                    foreach (var entity in (IEnumerable)collectionEntry.CurrentValue)
                    {
                        yield return ContextWrapper.GetTrackedEntryInternal(entity);
                    }
                }
            }
        }
        public object Entity => EntityEntry.Entity;
        public IPropertyValues OriginalValues => new DbPropertyValuesWrapper(EntityEntry.OriginalValues);
        public IEnumerable<ITrackedEntry> References
        {
            get
            {
                foreach (var propertyName in GetPropertyNames())
                {
                    var reference = default(DbReferenceEntry);
                    try
                    {
                        reference = EntityEntry.Reference(propertyName);
                        if (reference.CurrentValue == null)
                        {
                            continue;
                        }
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }
                    yield return ContextWrapper.GetTrackedEntryInternal(reference.CurrentValue);
                }
            }
        }
        public EntityState State { get => (EntityState)EntityEntry.State; set => EntityEntry.State = (System.Data.Entity.EntityState)value; }
        protected DbContextWrapper ContextWrapper => contextWrapper;
        protected DbEntityEntry EntityEntry => entityEntry;

        public override bool Equals(object obj)
        {
            if (typeof(DbEntityEntryWrapper).IsAssignableFrom(obj.GetType()) == false)
            {
                return false;
            }

            var entityEntryWrapper = (DbEntityEntryWrapper)obj;
            return Entity.Equals(entityEntryWrapper.Entity);
        }

        public override int GetHashCode()
        {
            return Entity.GetHashCode();
        }

        private IEnumerable<string> GetPropertyNames()
        {
            return EntityEntry
                .Entity
                .GetType()
                .GetProperties()
                .Select(i => i.Name);
        }
    }

    internal sealed class DbEntityEntryWrapper<TEntity> : DbEntityEntryWrapper
        , ITrackedEntry<TEntity>
        where TEntity : class
    {
        public DbEntityEntryWrapper(DbContextWrapper contextWrapper, DbEntityEntry<TEntity> entityEntry)
            : base(contextWrapper, entityEntry)
        {
        }

        TEntity ITrackedEntry<TEntity>.Entity => (TEntity)Entity;
    }
}
