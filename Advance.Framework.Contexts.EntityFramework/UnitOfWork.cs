using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Repositories;
using System.Collections.Generic;
using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework
{
    public class UnitOfWork : UnitOfWorkBase
    {
        private Context context = new Context();
        private ICollection<object> updatedEntities = new HashSet<object>();

        protected override IContext Context => context;

        protected override TEntity Add<TEntity>(TEntity entity)
        {
            return GetSet<TEntity>().Add(entity);
        }

        protected override TEntity Delete<TEntity>(TEntity entity)
        {
            var delete = GetSet<TEntity>().Attach(entity);
            return GetSet<TEntity>().Remove(delete);
        }

        protected override IEnumerable<TEntity> Entities<TEntity>()
        {
            //return GetSet<TEntity>().AsNoTracking();
            return GetSet<TEntity>();
        }

        protected override TEntity Update<TEntity>(TEntity entity)
        {
            //var update = GetSet<TEntity>().Attach(entity);
            //var entityEntry = context.Entry(update);
            //entityEntry.State = System.Data.Entity.EntityState.Modified;
            //return update;
            updatedEntities.Add(entity);
            return entity;
        }

        private DbSet<TEntity> GetSet<TEntity>() where TEntity : class
        {
            return context.Set<TEntity>();
        }

        public override int Commit()
        {
            foreach (var entry in context.ChangeTracker.Entries())
            {
                if (updatedEntities.Contains(entry) == false)
                {
                }
            }
            var changedEntries = Context.GetChangedEntries();
            foreach (var entity in changedEntries)
            {
                var x = 0;
            }

            return base.Commit();
        }
    }
}
