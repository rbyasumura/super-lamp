using Advance.Framework.Interfaces.Repositories;
using System.Collections.Generic;

namespace Advance.Framework.Repositories
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        public abstract int Commit();

        public abstract void Dispose();

        protected internal abstract IEnumerable<TEntity> Entities<TEntity>() where TEntity : class;

        public abstract TRepository GetRepository<TRepository>();

        protected internal abstract TEntity Add<TEntity>(TEntity entity) where TEntity : class;
    }
}
