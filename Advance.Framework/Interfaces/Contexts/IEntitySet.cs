namespace Advance.Framework.Interfaces.Repositories
{
    public interface IEntitySet<TEntity>
    {
        TEntity Add(TEntity entity);

        IQuery<TEntity> AsQuery();

        TEntity Remove(TEntity entity);
    }
}
