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

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
        }
    }
}
