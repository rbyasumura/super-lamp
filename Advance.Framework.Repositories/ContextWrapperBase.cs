using Advance.Framework.Interfaces.Contexts;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Interfaces.Repositories.Handlers;
using Advance.Framework.Repositories.Handlers;
using System.Collections.Generic;
using System.Linq;

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

        public abstract void Dispose();

        internal TEntity Add<TEntity>(TEntity entity)
                    where TEntity : class
        {
            TrackChanges(GetTrackedEntry(entity));

            return GetSet<TEntity>().Add(entity);
        }

        internal TEntity Delete<TEntity>(TEntity entity)
            where TEntity : class
        {
            TrackChanges(GetTrackedEntry(entity));

            return GetSet<TEntity>().Remove(entity);
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
            return trackedEntry.Entity;
        }

        protected internal abstract IEntitySet<TEntity> GetSet<TEntity>()
            where TEntity : class;

        protected internal abstract ITrackedEntry<TEntity> GetTrackedEntry<TEntity>(TEntity entity)
                    where TEntity : class;

        protected abstract int SaveChanges();

        private void TrackChanges(ITrackedEntry trackedEntry)
        {
            if (Changes.Contains(trackedEntry))
            {
                return;
            }

            Changes.Add(trackedEntry);

            foreach (var reference in trackedEntry.References.Union(trackedEntry.Collections))
            {
                TrackChanges(reference);
            }
        }
    }
}
