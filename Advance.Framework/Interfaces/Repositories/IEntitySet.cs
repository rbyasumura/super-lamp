namespace Advance.Framework.Interfaces.Repositories
{
    public interface IEntitySet<TEntity> : IQuery<TEntity>
        , IEntitySet
    {
        TEntity Attach(TEntity entity);
    }

    public interface IEntitySet
    {
        TEntity Add<TEntity>(TEntity entity) where TEntity : class;

        TEntity Remove<TEntity>(TEntity delete);
    }
}
