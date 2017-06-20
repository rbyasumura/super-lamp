using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Interfaces.Repositories.Handlers;
using Advance.Framework.Repositories.Handlers;
using System;
using System.Collections.Generic;

namespace Advance.Framework.Repositories
{
    public abstract class ContextWrapper : IContextWrapper
    {
        private IList<IChangeHandler> changeHandlers;
        private ICollection<IEntityEntry> modifiedEntries;

        protected ContextWrapper()
        {
            ChangeHandlers.Add(new PrimaryKeyHandler());
            ChangeHandlers.Add(new TimestampableEntityHandler());
            ChangeHandlers.Add(new SoftDeletableEntityHandler());
            ChangeHandlers.Add(new VersionedEntityHandler(this));
        }

        //public IContext Context
        //{
        //    get
        //    {
        //        return Container.Instance.Resolve<IContext>();
        //    }
        //}

        internal int SaveChanges()
        {
            return Context.SaveChanges();
        }

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

        protected internal abstract IEntitySet GetSet<TEntity>() where TEntity : class;

        protected abstract IContext Context { get; }

        protected abstract IEntitySet GetSet(Type type);

        public void Dispose()
        {
            Context.Dispose();
        }

        protected internal abstract IEntityEntry GetEntry<TEntity>(TEntity entity) where TEntity : class;

        internal IEnumerable<IEntityEntry> GetEntries()
        {
            throw new NotImplementedException();
        }

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

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            TrackChanges(GetEntry(entity));

            var add = GetSet(entity.GetType()).Add(entity);
            return add;
        }

        public TEntity Delete<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public TEntity Update<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        //internal IQueryable<TEntity> Entities<TEntity, TProperty>(params Expression<Func<TEntity, TProperty>>[] includes) where TEntity : class
        //{
        //    var queryable = Context.GetSet<TEntity>().AsQueryable();
        //    foreach (var include in includes)
        //    {
        //        queryable = queryable.Include(include);
        //    }
        //    return queryable;
        //}
    }
}
