using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Interfaces.Repositories.Handlers;
using Advance.Framework.Repositories.Handlers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Advance.Framework.Repositories
{
    public abstract class ContextWrapperBase : IContextWrapper
    {
        private List<IChangeHandler> changeHandlers;
        private ICollection<ITrackedEntry> changes;

        protected ContextWrapperBase()
        {
            ChangeHandlers.Add(new PrimaryKeyHandler());
            ChangeHandlers.Add(new SoftDeletableEntityHandler());
            ChangeHandlers.Add(new TimestampableEntityHandler());
            ChangeHandlers.Add(new VersionedEntityHandler(this));
            //ChangeHandlers.Add(new AuditableEntityHandler());
        }

        private IList<IChangeHandler> ChangeHandlers
        {
            get
            {
                if (changeHandlers == null)
                {
                    changeHandlers = new List<IChangeHandler>();
                }
                return changeHandlers;
            }
        }

        internal IEnumerable<TEntity> ListAll<TEntity, TProperty>(Expression<Func<TEntity, TProperty>>[] includes) where TEntity : class
        {
            return GetSet(typeof(TEntity)).ListAll(includes);
        }

        protected ICollection<ITrackedEntry> Changes
        {
            get
            {
                if (changes == null)
                {
                    changes = new HashSet<ITrackedEntry>();
                }
                return changes;
            }
        }

        public abstract void Dispose();

        internal TEntity Add<TEntity>(TEntity entity)
            where TEntity : class
        {
            TrackChanges(GetTrackedEntry(entity));

            return GetSet(entity.GetType()).Add(entity);
        }

        internal TEntity Delete<TEntity>(TEntity entity)
            where TEntity : class
        {
            TrackChanges(GetTrackedEntry(entity));

            return GetSet(entity.GetType()).Remove(entity);
        }

        internal int SaveChangesInternal()
        {
            foreach (var handler in ChangeHandlers)
            {
                handler.Handle(Changes);
            }

            return SaveChanges();
        }

        internal TEntity Update<TEntity>(TEntity entity)
            where TEntity : class
        {
            var trackedEntry = GetTrackedEntry(entity);
            TrackChanges(trackedEntry);
            return (TEntity)trackedEntry.Entity;
        }

        protected internal abstract IEntitySet GetSet(Type type);

        protected internal abstract ITrackedEntry<TEntity> GetTrackedEntry<TEntity>(TEntity entity)
            where TEntity : class;

        protected abstract int SaveChanges();

        private void TrackChanges<TEntity>(ITrackedEntry<TEntity> trackedEntry)
        {
            Changes.Add(trackedEntry);

            foreach (var reference in trackedEntry.References)
            {
                Changes.Add(reference);
            }

            foreach (var collection in trackedEntry.Collections)
            {
                Changes.Add(collection);
            }
        }
    }
}
