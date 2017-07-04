namespace Advance.Framework.Interfaces.Contexts
{
    public interface IEntitySet<TEntity>
    {
        TEntity Add(TEntity entity);

        IQuery<TEntity> AsQuery();

        TEntity Remove(TEntity entity);
    }
}
