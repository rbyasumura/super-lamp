using System;

namespace Advance.Framework.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        TRepository GetRepository<TRepository>();
    }
}
