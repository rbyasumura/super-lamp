using System;

namespace Advance.Framework.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        TRepository GetRepository<TRepository>();
    }
}
