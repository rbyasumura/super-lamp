namespace Advance.Framework.Repositories.EntityFramework
{
    public class Repository<TEntity> : ReadOnlyRepository<TEntity>
        , IRepository<TEntity>
        where TEntity : class
    {
        #region Public Constructors

        public Repository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion Public Constructors

        #region Public Methods

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

        #endregion Public Methods
    }
}