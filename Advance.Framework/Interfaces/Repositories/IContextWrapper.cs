using System;

namespace Advance.Framework.Interfaces.Repositories
{
    public interface IContextWrapper : IDisposable
    {
        TEntity Add<TEntity>(TEntity entity) where TEntity : class;

        TEntity Delete<TEntity>(TEntity entity) where TEntity : class;

        TEntity Update<TEntity>(TEntity entity) where TEntity : class;
    }
}
