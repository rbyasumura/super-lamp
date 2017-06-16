using Advance.Framework.Contexts.EntityFramework.Wrappers;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Repositories;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.Contexts.EntityFramework
{
    public class UnitOfWork : UnitOfWorkBase
    {
        private Context context = new Context();

        protected override IContext Context => context;

        protected override TEntity Add<TEntity>(TEntity entity)
        {
            var add = GetSet<TEntity>().Add(entity);
            return add;
        }

        protected override TEntity Delete<TEntity>(TEntity entity)
        {
            var delete = GetSet<TEntity>().Attach(entity);
            return GetSet<TEntity>().Remove(delete);
        }

        protected override IQueryable<TEntity> Entities<TEntity, TProperty>(params Expression<Func<TEntity, TProperty>>[] includes)
        {
            var queryable = GetSet<TEntity>().AsQueryable();
            foreach (var include in includes)
            {
                queryable = queryable.Include(include);
            }
            return queryable;
        }

        protected override TEntity Update<TEntity>(TEntity entity)
        {
            //var update = GetSet<TEntity>().Attach(entity);
            //var entityEntry = context.Entry(entity);
            //entityEntry.State = System.Data.Entity.EntityState.Modified;
            //return entityEntry.Entity;
            UpdatedEntities.Add(new DbEntityEntryWrapper(context.Entry(entity)));
            return context.Entry(entity).Entity;
        }

        private DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return context.Set<TEntity>();
        }
    }
}
