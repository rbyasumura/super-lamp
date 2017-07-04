namespace Advance.Framework.Interfaces.Contexts.ModelConfiguration
{
    public interface IRequiredNavigationPropertyConfiguration<TEntity, TTargetEntity>
    {
        IDependentNavigationPropertyConfiguration<TEntity> WithMany();
    }
}
