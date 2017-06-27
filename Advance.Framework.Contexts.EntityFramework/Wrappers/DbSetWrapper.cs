using Advance.Framework.Interfaces.Repositories;
using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers
{
    internal sealed class DbSetWrapper<TEntity> : IEntitySet<TEntity>
        where TEntity : class
    {
        private DbSet<TEntity> set;

        public DbSetWrapper(DbSet<TEntity> set)
        {
            this.set = set;
        }

        public TEntity Add(TEntity entity)
        {
            return set.Add(entity);
        }

        public IQuery<TEntity> AsQuery()
        {
            return new DbQueryWrapper<TEntity>(set);
        }

        public TEntity Remove(TEntity entity)
        {
            return set.Remove(entity);
        }
    }
}
