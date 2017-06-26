using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Advance.Framework.Interfaces.Repositories
{
    public interface IEntitySet
    {
        TEntity Add<TEntity>(TEntity entity);

        TEntity Remove<TEntity>(TEntity entity);

        IEnumerable<TEntity> ListAll<TEntity, TProperty>(Expression<Func<TEntity, TProperty>>[] includes)
            where TEntity : class;
    }

    public interface IEntitySet<TEntity> : IEntitySet
    {
    }
}
