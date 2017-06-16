using System;

namespace Advance.Framework.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();

        TRepository GetRepository<TRepository>();
    }
}
