namespace Advance.Framework.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
    {
        TEntity Add(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}
