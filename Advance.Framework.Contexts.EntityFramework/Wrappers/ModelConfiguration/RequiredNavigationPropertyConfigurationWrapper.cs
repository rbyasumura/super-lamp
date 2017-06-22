using Advance.Framework.Interfaces.Repositories;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers
{
    internal class RequiredNavigationPropertyConfigurationWrapper<TEntity, TTargetEntity> : IRequiredNavigationPropertyConfiguration<TEntity, TTargetEntity>
        where TEntity : class
        where TTargetEntity : class
    {
        private RequiredNavigationPropertyConfiguration<TEntity, TTargetEntity> requiredNavigationPropertyConfiguration;

        public RequiredNavigationPropertyConfigurationWrapper(RequiredNavigationPropertyConfiguration<TEntity, TTargetEntity> requiredNavigationPropertyConfiguration)
        {
            this.requiredNavigationPropertyConfiguration = requiredNavigationPropertyConfiguration;
        }

        public IDependentNavigationPropertyConfiguration<TEntity> WithMany()
        {
            return new DependentNavigationPropertyConfigurationWrapper<TEntity>(requiredNavigationPropertyConfiguration.WithMany());
        }
    }
}
