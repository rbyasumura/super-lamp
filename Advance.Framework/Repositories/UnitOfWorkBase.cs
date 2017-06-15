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

        public int Commit()
        {
            foreach (var handler in changeHandlers)
            {
                var changedEntries = Context.GetChangedEntries();

                handler.Handle(changedEntries);
            }

            return Context.Commit();
        }

        public abstract void Dispose();

        public abstract TRepository GetRepository<TRepository>();

        protected internal abstract TEntity Add<TEntity>(TEntity entity) where TEntity : class;

        protected internal abstract IEnumerable<TEntity> Entities<TEntity>() where TEntity : class;
    }
}
