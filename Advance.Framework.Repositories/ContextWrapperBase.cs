using Advance.Framework.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Advance.Framework.Repositories
{
    public abstract class ContextWrapperBase : IContextWrapper
    {
        private ICollection<ITrackedEntry> changes;

        public ICollection<ITrackedEntry> Changes
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

        internal TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            TrackChanges(GetTrackedEntry(entity));

            return GetSet(entity.GetType()).Add(entity);
        }

        internal TEntity Delete<TEntity>(TEntity entity) where TEntity : class
        {
            TrackChanges(GetTrackedEntry(entity));

            return GetSet(entity.GetType()).Remove(entity);
        }

        internal TEntity Update<TEntity>(TEntity entity) where TEntity : class
        {
            var trackedEntry = GetTrackedEntry(entity);
            TrackChanges(trackedEntry);
            return (TEntity)trackedEntry.Entity;
        }

        protected internal abstract IEntitySet GetSet(Type type);

        protected internal abstract ITrackedEntry<TEntity> GetTrackedEntry<TEntity>(TEntity entity) where TEntity : class;

        protected internal abstract int SaveChanges();

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
