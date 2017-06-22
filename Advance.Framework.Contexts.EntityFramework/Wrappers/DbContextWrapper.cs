using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Repositories;
using System;
using System.Linq;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers
{
    public abstract class DbContextWrapper : ContextWrapperBase
    {
        protected abstract EntityFrameworkContextBase Context { get; }

        internal DbEntityEntryWrapper<TEntity> GetTrackedEntryInternal<TEntity>(TEntity entity)
            where TEntity : class
        {
            return new DbEntityEntryWrapper<TEntity>(this, Context.Entry(entity));
        }
    }

    public sealed class DbContextWrapper<TContext> : DbContextWrapper
        where TContext : EntityFrameworkContextBase, new()
    {
        private TContext context;

        protected override EntityFrameworkContextBase Context
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

        protected override IEntitySet GetSet(Type type)
        {
            return new DbSetWrapper(Context.Set(type));
        }

        protected override ITrackedEntry<TEntity> GetTrackedEntry<TEntity>(TEntity entity)
        {
            return GetTrackedEntryInternal(entity);
        }

        protected override int SaveChanges()
        {
            foreach (var entry in context.ChangeTracker.Entries().Where(i => i.State != System.Data.Entity.EntityState.Unchanged))
            {
                if (Changes.Contains(new DbEntityEntryWrapper(this, entry)) == false)
                {
                    entry.State = System.Data.Entity.EntityState.Unchanged;
                }
            }

            return context.SaveChanges();
        }
    }
}
