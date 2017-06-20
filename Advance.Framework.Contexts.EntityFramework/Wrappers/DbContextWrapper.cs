using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Repositories;
using System;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers
{
    internal class DbContextWrapper : ContextWrapper
    {
        private EntityFrameworkContext context = new EntityFrameworkContext();

        protected override IContext Context => context;

        protected internal override IEntityEntry _GetEntry<TEntity>(TEntity entity)
        {
            return new DbEntityEntryWrapper(this, context.Entry(entity));
        }

        protected override IEntitySet GetSet(Type entityType)
        {
            return new DbSetWrapper(context.Set(entityType));
        }

        protected override IEntitySet GetSet<TEntity>()
        {
            return new DbSetWrapper(context.Set<TEntity>());
        }

        protected override IEntityEntry GetEntry<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
