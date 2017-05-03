using System;

namespace Advance.Framework
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
