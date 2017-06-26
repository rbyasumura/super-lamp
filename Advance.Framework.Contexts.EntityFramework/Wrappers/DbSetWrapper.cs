using Advance.Framework.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers
{
    internal sealed class DbSetWrapper : IEntitySet
    {
        private DbSet set;

        public DbSetWrapper(DbSet set)
        {
            this.set = set;
        }

        public TEntity Add<TEntity>(TEntity entity)
        {
            return (TEntity)set.Add(entity);
        }

        public IEnumerable<TEntity> ListAll<TEntity, TProperty>(Expression<Func<TEntity, TProperty>>[] includes) where TEntity : class
        {
            var queryable = set.Cast<TEntity>().AsQueryable();
            foreach (var include in includes)
            {
                queryable = queryable.Include(include);
            }
            return queryable.ToArray();
        }

        public TEntity Remove<TEntity>(TEntity entity)
        {
            return (TEntity)set.Remove(entity);
        }
    }
}
