using System;

namespace Advance.Framework.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        TRepository GetRepository<TRepository>();
    }
}
