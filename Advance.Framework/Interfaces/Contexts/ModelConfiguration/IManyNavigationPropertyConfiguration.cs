namespace Advance.Framework.Interfaces.Repositories
{
    public interface IManyNavigationPropertyConfiguration<TEntity, TTargetEntity>
        where TEntity : class
    {
        IDependentNavigationPropertyConfiguration<TTargetEntity> WithOptional();
    }
}
