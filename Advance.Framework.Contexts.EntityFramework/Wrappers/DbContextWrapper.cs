using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Repositories;
using System;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers
{
    public class DbContextWrapper : ContextWrapperBase
    {
        private EntityFrameworkContext context;

        private EntityFrameworkContext Context
        {
            get
            {
                if (context == null)
                {
                    context = new EntityFrameworkContext();
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

        internal DbEntityEntryWrapper<TEntity> GetTrackedEntryInternal<TEntity>(TEntity entity) where TEntity : class
        {
            return new DbEntityEntryWrapper<TEntity>(this, Context.Entry(entity));
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
            throw new NotImplementedException();
        }
    }
}
