using Advance.Framework.Interfaces.Contexts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers
{
    internal sealed class DbQueryWrapper<TEntity> : IQuery<TEntity>
    {
        private IQueryable<TEntity> queryable;

        public DbQueryWrapper(IQueryable<TEntity> queryable)
        {
            this.queryable = queryable;
        }

        public Type ElementType => queryable.ElementType;
        public Expression Expression => queryable.Expression;
        public IQueryProvider Provider => queryable.Provider;

        public IEnumerator<TEntity> GetEnumerator()
        {
            return queryable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IQuery<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> path)
        {
            return new DbQueryWrapper<TEntity>(queryable.Include(path));
        }
    }
}
