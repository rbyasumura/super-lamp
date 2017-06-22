namespace Advance.Framework.Interfaces.Repositories
{
    public interface IRequiredNavigationPropertyConfiguration<TEntity, TTargetEntity>
    {
        IDependentNavigationPropertyConfiguration<TEntity> WithMany();
    }
}
