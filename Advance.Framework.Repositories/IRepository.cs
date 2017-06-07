namespace Advance.Framework.Repositories
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
    {
        #region Public Methods

        void Add(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        #endregion Public Methods
    }
}