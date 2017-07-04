using System;
using Advance.Framework.Interfaces.Contexts.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers.ModelConfiguration
{
    internal class ManyNavigationPropertyConfigurationWrapper<TEntity, TTargetEntity> : IManyNavigationPropertyConfiguration<TEntity, TTargetEntity>
        where TEntity : class
        where TTargetEntity : class
    {
        private ManyNavigationPropertyConfiguration<TEntity, TTargetEntity> manyNavigationPropertyConfiguration;

        public ManyNavigationPropertyConfigurationWrapper(ManyNavigationPropertyConfiguration<TEntity, TTargetEntity> manyNavigationPropertyConfiguration)
        {
            this.manyNavigationPropertyConfiguration = manyNavigationPropertyConfiguration;
        }

        public IManyToManyNavigationPropertyConfiguration WithMany()
        {
            return new ManyToManyNavigationPropertyConfigurationWrapper<TEntity, TTargetEntity>(manyNavigationPropertyConfiguration.WithMany());
        }

        public IDependentNavigationPropertyConfiguration<TTargetEntity> WithOptional()
        {
            return new DependentNavigationPropertyConfigurationWrapper<TTargetEntity>(manyNavigationPropertyConfiguration.WithOptional());
        }
    }
}
