namespace Advance.Framework.ContactModule.Repositories
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
