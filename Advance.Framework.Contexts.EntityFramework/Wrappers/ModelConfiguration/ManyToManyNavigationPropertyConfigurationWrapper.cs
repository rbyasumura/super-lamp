using Advance.Framework.Interfaces.Contexts.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers.ModelConfiguration
{
    internal class ManyToManyNavigationPropertyConfigurationWrapper<TEntity, TTargetEntity> : IManyToManyNavigationPropertyConfiguration
        where TEntity : class
        where TTargetEntity : class
    {
        private ManyToManyNavigationPropertyConfiguration<TEntity, TTargetEntity> manyToManyNavigationPropertyConfiguration;

        public ManyToManyNavigationPropertyConfigurationWrapper(ManyToManyNavigationPropertyConfiguration<TEntity, TTargetEntity> manyToManyNavigationPropertyConfiguration)
        {
            this.manyToManyNavigationPropertyConfiguration = manyToManyNavigationPropertyConfiguration;
        }
    }
}
