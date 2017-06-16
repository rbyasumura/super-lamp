﻿using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Interfaces.Repositories.Handlers;
using Advance.Framework.Repositories.Handlers;
using System.Collections.Generic;

namespace Advance.Framework.Repositories
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        private ICollection<IChangeHandler> changeHandlers = new List<IChangeHandler>();

        protected UnitOfWorkBase()
        {
            changeHandlers.Add(new PrimaryKeyHandler());
        }

        protected abstract IContext Context { get; }

        public virtual int Commit()
        {
            var changedEntries = Context.GetChangedEntries();
            foreach (var handler in changeHandlers)
            {
                handler.Handle(changedEntries);
            }

            return Context.Commit();
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

        protected internal abstract IEnumerable<TEntity> Entities<TEntity>() where TEntity : class;

        protected internal abstract TEntity Update<TEntity>(TEntity entity) where TEntity : class;
    }
}
