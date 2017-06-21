using Advance.Framework.Interfaces.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers
{
    //internal class DbEntityEntryWrapper : ITrackedEntry
    //{
    //    private DbEntityEntry entityEntry;
    //    private DbContextWrapper context;

    // public DbEntityEntryWrapper(DbContextWrapper context, DbEntityEntry entityEntry) {
    // this.context = context; this.entityEntry = entityEntry; }

    // public IEnumerable<DbEntityEntryWrapper> Collections { get { foreach (var propertyName in
    // GetPropertyNames()) { var collectionEntry = default(DbCollectionEntry); try { collectionEntry
    // = entityEntry.Collection(propertyName); if (collectionEntry.CurrentValue == null) { continue;
    // } } catch (ArgumentException) { continue; }

    // foreach (var entity in (IEnumerable)collectionEntry.CurrentValue) { yield return new
    // DbEntityEntryWrapper(context, context.Entry(entity)); } } } }

    // public object Entity => entityEntry.Entity;

    // public IEnumerable<DbEntityEntryWrapper> References { get { foreach (var propertyName in
    // GetPropertyNames()) { var reference = default(DbReferenceEntry); try { reference =
    // entityEntry.Reference(propertyName); if (reference.CurrentValue == null) { continue; } } catch
    // (ArgumentException) { continue; } yield return new DbEntityEntryWrapper(context,
    // context.Entry(reference.CurrentValue)); } } }

    // public EntityState State { get => (EntityState)entityEntry.State; set => entityEntry.State =
    // (System.Data.Entity.EntityState)value; }

    // public IPropertyValues OriginalValues => new DbPropertyValuesWrapper(entityEntry.OriginalValues);

    // IEnumerable<ITrackedEntry> ITrackedEntry.References => throw new NotImplementedException();

    // IEnumerable<ITrackedEntry> ITrackedEntry.Collections => throw new NotImplementedException();

    // ///
    // <summary>
    // /// If the Entity properties are equal, then the Entry is equal ///
    // </summary>
    // ///
    // <param name="obj"></param>
    // ///
    // <returns></returns>
    // public override bool Equals(object obj) { if (GetType().Equals(obj.GetType()) == false) {
    // return false; }

    // var dbEntityEntryWrapper = (DbEntityEntryWrapper)obj; return
    // Entity.Equals(dbEntityEntryWrapper.Entity); }

    // public override int GetHashCode() { return Entity.GetHashCode(); }

    //    private IEnumerable<string> GetPropertyNames()
    //    {
    //        return entityEntry.Entity.GetType().GetProperties().Select(i => i.Name);
    //    }
    //}

    internal class DbEntityEntryWrapper
    {
        private DbContextWrapper contextWrapper;
        private DbEntityEntry entityEntry;

        public DbEntityEntryWrapper(DbContextWrapper contextWrapper, DbEntityEntry entityEntry)
        {
            this.contextWrapper = contextWrapper;
            this.entityEntry = entityEntry;
        }

        protected DbContextWrapper ContextWrapper => contextWrapper;
        protected DbEntityEntry EntityEntry => entityEntry;
    }

    internal class DbEntityEntryWrapper<TEntity> : DbEntityEntryWrapper
        , ITrackedEntry<TEntity>
        where TEntity : class
    {
        public DbEntityEntryWrapper(DbContextWrapper contextWrapper, DbEntityEntry<TEntity> entityEntry)
            : base(contextWrapper, entityEntry)
        {
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

        public TEntity Entity => (TEntity)EntityEntry.Entity;

        object ITrackedEntry.Entity => EntityEntry.Entity;

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

        public EntityState State { get; set; }

        private IEnumerable<string> GetPropertyNames()
        {
            return EntityEntry
                .Entity
                .GetType()
                .GetProperties()
                .Select(i => i.Name);
        }
    }
}
