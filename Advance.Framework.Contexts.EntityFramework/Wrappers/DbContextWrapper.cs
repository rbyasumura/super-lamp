using Advance.Framework.Interfaces.Contexts;
using Advance.Framework.Interfaces.Contexts.Infrastructure;
using Advance.Framework.Repositories;
using System;
using System.Linq;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers
{
    public abstract class DbContextWrapper : ContextWrapperBase
    {
        internal abstract DbEntityEntryWrapper<TEntity> GetTrackedEntryInternal<TEntity>(TEntity entity)
            where TEntity : class;
    }

    public sealed class DbContextWrapper<TContext> : DbContextWrapper
        , IDisposable
        where TContext : EntityFrameworkContextBase, new()
    {
        private TContext context;

        private TContext Context
        {
            get
            {
                if (context == null)
                {
                    context = new TContext();
                }
                return context;
            }
        }

        public override void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        internal override DbEntityEntryWrapper<TEntity> GetTrackedEntryInternal<TEntity>(TEntity entity)
        {
            return new DbEntityEntryWrapper<TEntity>(this, Context.Entry(entity));
        }

        protected override IEntitySet<TEntity> GetSet<TEntity>()
        {
            return new DbSetWrapper<TEntity>(Context.Set<TEntity>());
        }

        protected override ITrackedEntry<TEntity> GetTrackedEntry<TEntity>(TEntity entity)
        {
            return GetTrackedEntryInternal(entity);
        }

        protected override int SaveChanges()
        {
            foreach (var entry in Context.ChangeTracker.Entries().Where(i => i.State != System.Data.Entity.EntityState.Unchanged))
            {
                if (Changes.Contains(new DbEntityEntryWrapper(this, entry)) == false)
                {
                    entry.State = System.Data.Entity.EntityState.Unchanged;
                }
            }

            return Context.SaveChanges();
        }
    }
}
