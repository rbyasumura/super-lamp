namespace Advance.Framework.Interfaces.Repositories
{
    public interface IModelBuilder
    {
        IEntityTypeConfiguration<TEntity> Entity<TEntity>()
            where TEntity : class;
    }
}
