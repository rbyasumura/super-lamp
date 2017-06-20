namespace Advance.Framework.Contexts.EntityFramework
{
    //public class UnitOfWork : UnitOfWorkBase
    //{
    //    private EntityFrameworkContextBase context = new EntityFrameworkContextBase();

    // protected override IContext Context => context;

    // protected override TEntity Add<TEntity>(TEntity entity) { TrackChanges(GetEntityEntry(entity));

    // var add = (TEntity)GetSet(entity.GetType()).Add(entity); return add; }

    // protected override TEntity Delete<TEntity>(TEntity entity) { TrackChanges(GetEntityEntry(entity));

    // var delete = GetSet<TEntity>().Attach(entity); return GetSet<TEntity>().Remove(delete); }

    // protected override IQueryable<TEntity> Entities<TEntity, TProperty>(params
    // Expression<Func<TEntity, TProperty>>[] includes) { var queryable =
    // GetSet<TEntity>().AsQueryable(); foreach (var include in includes) { queryable =
    // queryable.Include(include); } return queryable; }

    // protected override TEntity Update<TEntity>(TEntity entity) { var entry =
    // GetEntityEntry(entity); TrackChanges(entry);

    // return context.Entry(entity).Entity; }

    // private DbEntityEntryWrapper GetEntityEntry<TEntity>(TEntity entity) where TEntity : class {
    // return new DbEntityEntryWrapper(context, context.Entry(entity)); }

    // private DbSet GetSet(Type entityType) { return context.Set(entityType); }

    // private DbSet<TEntity> GetSet<TEntity>() where TEntity : class { return
    // GetSet(typeof(TEntity)) .Cast<TEntity>(); }

    // private void TrackChanges(DbEntityEntryWrapper entry) { ModifiedEntries.Add(entry);

    // foreach (var reference in entry.References) { ModifiedEntries.Add(reference); }

    //        foreach (var collectionEntry in entry.Collections)
    //        {
    //            ModifiedEntries.Add(collectionEntry);
    //        }
    //    }
    //}
}
