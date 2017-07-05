namespace Advance.Framework.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
    {
        TEntity Add(TEntity entity);

        TEntity Delete(TEntity entity);

        TEntity Update(TEntity entity);
    }
}
