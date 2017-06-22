using Advance.Framework.Interfaces.Repositories;
using System.Data.Entity;

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

        public TEntity Remove<TEntity>(TEntity entity)
        {
            return (TEntity)set.Remove(entity);
        }
    }
}
