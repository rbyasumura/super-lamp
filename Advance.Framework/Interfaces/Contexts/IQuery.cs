using System;
using System.Linq.Expressions;

namespace Advance.Framework.Interfaces.Repositories
{
    public interface IQuery<TEntity>
    {
        IQuery<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> path);
    }
}
