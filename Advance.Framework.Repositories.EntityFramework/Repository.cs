namespace Advance.Framework.Repositories.EntityFramework
{
    public class Repository<TEntity> : ReadOnlyRepository<TEntity>
        , IRepository<TEntity>
        where TEntity : class
    {
        public Repository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
            UnitOfWork.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
            UnitOfWork.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            UnitOfWork.Attach(entity);
            UnitOfWork.SaveChanges();
        }
    }
}