namespace Advance.Framework.Interfaces.Contexts.ModelConfiguration
{
    public interface IManyNavigationPropertyConfiguration<TEntity, TTargetEntity>
        where TEntity : class
    {
        IDependentNavigationPropertyConfiguration<TTargetEntity> WithOptional();

        IManyToManyNavigationPropertyConfiguration WithMany();
    }
}
