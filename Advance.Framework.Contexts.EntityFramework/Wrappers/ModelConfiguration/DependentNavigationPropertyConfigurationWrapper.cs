using Advance.Framework.Interfaces.Repositories;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers
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
