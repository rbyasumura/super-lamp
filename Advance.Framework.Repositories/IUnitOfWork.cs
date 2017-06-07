using System;

namespace Advance.Framework.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        #region Public Methods

        void Commit();

        TRepository GetRepository<TRepository>();

        #endregion Public Methods
    }
}