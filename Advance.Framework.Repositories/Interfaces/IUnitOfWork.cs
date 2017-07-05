using System;

namespace Advance.Framework.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();

        TRepository GetRepository<TRepository>();
    }
}
