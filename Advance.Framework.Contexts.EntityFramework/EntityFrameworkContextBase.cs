using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework
{
    public partial class EntityFrameworkContext : DbContext
    // , IContext
    {
        // public EntityFrameworkContextBase() :
        // base(ConfigurationManager.ConnectionStrings["Default"].ConnectionString) {
        // Configuration.LazyLoadingEnabled = false; }

        // public IEntityEntry GetEntry<TEntity>(TEntity entity) where TEntity : class { throw new
        // NotImplementedException(); }

        // public IEnumerable<IEntityEntry> GetEntries() { return ChangeTracker.Entries() .Select(i
        // => new DbEntityEntryWrapper(this, i)); }

        // public IEntitySet GetSet(Type type) { throw new NotImplementedException(); }

        // public IEntitySet GetSet<TEntity>() where TEntity : class { throw new
        // NotImplementedException(); }

        // protected abstract override void OnModelCreating(DbModelBuilder modelBuilder);

        // IEntitySet<TEntity> IContext.GetSet<TEntity>() { throw new NotImplementedException(); }

        // public TEntity Add<TEntity>(TEntity entity) where TEntity : class { TrackChanges(Context.GetEntry(entity));

        // var add = Context.GetSet(entity.GetType()).Add(entity); return add; }

        // public TEntity Delete<TEntity>(TEntity entity) where TEntity : class { TrackChanges(Context.GetEntry(entity));

        // return Context.GetSet<TEntity>().Remove(entity); }

        // public TEntity Update<TEntity>(TEntity entity) where TEntity : class { var entry =
        // Context.GetEntry(entity); TrackChanges(entry);

        // return (TEntity)Context.GetEntry(entity).Entity; }
    }
}
