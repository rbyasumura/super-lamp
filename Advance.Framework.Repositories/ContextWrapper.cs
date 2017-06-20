using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Interfaces.Repositories.Handlers;
using Advance.Framework.Loggers;
using Advance.Framework.Repositories.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advance.Framework.Repositories
{
    internal abstract class ContextWrapper : IContext
    {
        private IList<IChangeHandler> changeHandlers;
        private ICollection<IEntityEntry> modifiedEntries;

        private ContextWrapper()
        {
            ChangeHandlers.Add(new PrimaryKeyHandler());
            ChangeHandlers.Add(new TimestampableEntityHandler());
            ChangeHandlers.Add(new SoftDeletableEntityHandler());
            ChangeHandlers.Add(new VersionedEntityHandler(this));
        }

        internal TEntity Update<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        internal TEntity Delete<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public abstract IContext Context { get; }

        private ICollection<IChangeHandler> ChangeHandlers
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

        private ICollection<IEntityEntry> ModifiedEntries
        {
            get
            {
                if (modifiedEntries == null)
                {
                    modifiedEntries = new HashSet<IEntityEntry>();
                }
                return modifiedEntries;
            }
        }

        internal IEntitySet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public int SaveChanges()
        {
            var entries = GetEntries();

            #region Log

            foreach (var entry in entries)
            {
                Logger.Instance.Log("{0} - {1}", entry.Entity, entry.State);
            }

            #endregion Log

            #region Discard changes that were not done by the repositories

            foreach (var entry in entries.Where(i => i.State != EntityState.Unchanged))
            {
                if (ModifiedEntries.Contains(entry) == false)
                {
                    entry.State = EntityState.Unchanged;
                }
            }

            #endregion Discard changes that were not done by the repositories

            foreach (var handler in ChangeHandlers)
            {
                handler.Handle(entries);
            }

            return Context.SaveChanges();
        }

        internal TEntity Add<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        internal abstract IEnumerable<IEntityEntry> GetEntries();

        private void TrackChanges(IEntityEntry entry)
        {
            ModifiedEntries.Add(entry);

            foreach (var reference in entry.References)
            {
                ModifiedEntries.Add(reference);
            }

            foreach (var collectionEntry in entry.Collections)
            {
                ModifiedEntries.Add(collectionEntry);
            }
        }
    }
}
