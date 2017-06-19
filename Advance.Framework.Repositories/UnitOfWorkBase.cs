using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Interfaces.Repositories.Handlers;
using Advance.Framework.Loggers;
using Advance.Framework.Repositories.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.Repositories
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        private ICollection<IChangeHandler> changeHandlers = new List<IChangeHandler>();
        private ICollection<IChangedEntry> updatedEntities = new HashSet<IChangedEntry>();

        protected UnitOfWorkBase()
        {
            changeHandlers.Add(new PrimaryKeyHandler());
        }

        protected abstract IContext Context { get; }
        protected ICollection<IChangedEntry> UpdatedEntities { get => updatedEntities; }

        public int SaveChanges()
        {
            var changedEntries = Context.GetChangedEntries();

            #region Log

            foreach (var entry in changedEntries)
            {
                Logger.Instance.Log("{0} - {1}", entry.Entity, entry.State);
            }

            #endregion Log

            foreach (var entry in changedEntries.Where(i => i.State == EntityState.Modified))
            {
                var x = entry.ParentEntry;
                if (updatedEntities.Contains(entry.Entity) == false)
                {
                    entry.State = EntityState.Unchanged;
                }
            }

            foreach (var handler in changeHandlers)
            {
                handler.Handle(changedEntries);
            }

            return Context.SaveChanges();
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

        public TRepository GetRepository<TRepository>()
        {
            return Container.Instance.Resolve<TRepository>(new Dictionary<string, object>{
                { "unitOfWork", this},
            });
        }

        protected internal abstract TEntity Add<TEntity>(TEntity entity) where TEntity : class;

        protected internal abstract TEntity Delete<TEntity>(TEntity entity) where TEntity : class;

        protected internal abstract IQueryable<TEntity> Entities<TEntity, TProperty>(params Expression<Func<TEntity, TProperty>>[] includes) where TEntity : class;

        protected internal abstract TEntity Update<TEntity>(TEntity entity) where TEntity : class;
    }
}
