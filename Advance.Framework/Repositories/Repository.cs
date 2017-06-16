using Advance.Framework.Interfaces.Repositories;
using System;

namespace Advance.Framework.Repositories
{
    public abstract class Repository<TEntity> : ReadOnlyRepository<TEntity>
        , IRepository<TEntity> where TEntity : class
    {
        public Repository(UnitOfWorkBase unitOfWork) : base(unitOfWork)
        {
        }

        public TEntity Add(TEntity entity)
        {
            return UnitOfWork.Add(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            return UnitOfWork.Delete(entity);
        }

        public TEntity Update(TEntity entity)
        {
            return UnitOfWork.Update(entity);
        }
    }
}