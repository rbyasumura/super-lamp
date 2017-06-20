using System;

namespace Advance.Framework.Interfaces.Repositories
{
    public interface IContext : IDisposable
    {
        //IEnumerable<IEntityEntry> GetEntries();

        //int SaveChanges();

        //IEntityEntry GetEntry<TEntity>(TEntity entity) where TEntity : class;

        //IEntitySet GetSet(Type type);

        //IEntitySet<TEntity> GetSet<TEntity>() where TEntity : class;

        //TEntity Add<TEntity>(TEntity entity) where TEntity : class;

        //TEntity Delete<TEntity>(TEntity entity) where TEntity : class;

        //TEntity Update<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }
}
