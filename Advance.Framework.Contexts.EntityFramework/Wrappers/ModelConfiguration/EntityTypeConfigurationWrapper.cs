using Advance.Framework.Interfaces.Contexts.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq.Expressions;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers.ModelConfiguration
{
    internal class EntityTypeConfigurationWrapper<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        private EntityTypeConfiguration<TEntity> entityTypeConfiguration;

        public EntityTypeConfigurationWrapper(EntityTypeConfiguration<TEntity> entityTypeConfiguration)
        {
            this.entityTypeConfiguration = entityTypeConfiguration;
        }

        public IManyNavigationPropertyConfiguration<TEntity, TTargetEntity> HasMany<TTargetEntity>(Expression<Func<TEntity, ICollection<TTargetEntity>>> navigationPropertyExpression)
            where TTargetEntity : class
        {
            return new ManyNavigationPropertyConfigurationWrapper<TEntity, TTargetEntity>(entityTypeConfiguration.HasMany(navigationPropertyExpression));
        }

        public IRequiredNavigationPropertyConfiguration<TEntity, TTargetEntity> HasRequired<TTargetEntity>(Expression<Func<TEntity, TTargetEntity>> navigationPropertyExpression)
            where TTargetEntity : class
        {
            return new RequiredNavigationPropertyConfigurationWrapper<TEntity, TTargetEntity>(entityTypeConfiguration.HasRequired(navigationPropertyExpression));
        }
    }
}
