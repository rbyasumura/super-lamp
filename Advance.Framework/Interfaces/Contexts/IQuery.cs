using System;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.Interfaces.Contexts
{
    public interface IQuery<TEntity> : IQueryable<TEntity>
    {
        IQuery<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> path);
    }
}
