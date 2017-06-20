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
        private ICollection<IEntityEntry> modifiedEntries = new HashSet<IEntityEntry>();

        protected UnitOfWorkBase()
        {
            changeHandlers.Add(new PrimaryKeyHandler());
            changeHandlers.Add(new TimestampableEntityHandler());
            changeHandlers.Add(new SoftDeletableEntityHandler());
            changeHandlers.Add(new VersionedEntityHandler(this));
        }

        protected abstract IContext Context { get; }
        protected ICollection<IEntityEntry> ModifiedEntries { get => modifiedEntries; }

        public int SaveChanges()
        {
            var entries = Context.GetEntries();

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

            foreach (var handler in changeHandlers)
            {
                handler.Handle(entries);
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
