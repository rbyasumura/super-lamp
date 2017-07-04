using Advance.Framework.Interfaces.Contexts.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers.ModelConfiguration
{
    internal class DependentNavigationPropertyConfigurationWrapper<TEntity> : IDependentNavigationPropertyConfiguration<TEntity>
        where TEntity : class
    {
        private DependentNavigationPropertyConfiguration<TEntity> dependentNavigationPropertyConfiguration;

        public DependentNavigationPropertyConfigurationWrapper(DependentNavigationPropertyConfiguration<TEntity> dependentNavigationPropertyConfiguration)
        {
            this.dependentNavigationPropertyConfiguration = dependentNavigationPropertyConfiguration;
        }
    }
}
