namespace Advance.Framework.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
    {
        TEntity Add(TEntity entity);

        TEntity Delete(TEntity entity);

        TEntity Update(TEntity entity);
    }
}