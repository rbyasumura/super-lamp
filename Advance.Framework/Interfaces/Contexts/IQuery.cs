using System;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.Interfaces.Repositories
{
    public interface IQuery<TEntity> : IQueryable<TEntity>
    {
        IQuery<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> path);
    }
}
