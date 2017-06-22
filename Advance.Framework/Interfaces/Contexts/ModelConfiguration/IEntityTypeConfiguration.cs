using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Advance.Framework.Interfaces.Repositories
{
    public interface IEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        IRequiredNavigationPropertyConfiguration<TEntity, TTargetEntity> HasRequired<TTargetEntity>(Expression<Func<TEntity, TTargetEntity>> navigationPropertyExpression)
           where TTargetEntity : class;

        IManyNavigationPropertyConfiguration<TEntity, TTargetEntity> HasMany<TTargetEntity>(Expression<Func<TEntity, ICollection<TTargetEntity>>> navigationPropertyExpression)
            where TTargetEntity : class;
    }
}
