using Advance.Framework.Interfaces.Repositories;

namespace Advance.Framework.Repositories
{
    public abstract class Repository<TEntity> : ReadOnlyRepository<TEntity>
        , IRepository<TEntity> where TEntity : class
    {
        protected Repository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public TEntity Add(TEntity entity)
        {
            return UnitOfWork.Context.Add(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            return UnitOfWork.Context.Delete(entity);
        }

        public TEntity Update(TEntity entity)
        {
            return UnitOfWork.Context.Update(entity);
        }
    }
}
