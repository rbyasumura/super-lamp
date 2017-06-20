using Advance.Framework.Interfaces.Repositories;
using System;
using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers
{
    internal class DbSetWrapper : IEntitySet
    {
        private DbSet set;

        public DbSetWrapper(DbSet set)
        {
            this.set = set;
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            return set.Cast<TEntity>().Add(entity);
        }

        public TEntity Remove<TEntity>(TEntity delete)
        {
            throw new NotImplementedException();
        }
    }
}
