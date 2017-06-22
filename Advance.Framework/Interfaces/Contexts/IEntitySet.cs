namespace Advance.Framework.Interfaces.Repositories
{
    public interface IEntitySet
    {
        TEntity Add<TEntity>(TEntity entity);

        TEntity Remove<TEntity>(TEntity entity);
    }

    public interface IEntitySet<TEntity> : IEntitySet
    {
    }
}
