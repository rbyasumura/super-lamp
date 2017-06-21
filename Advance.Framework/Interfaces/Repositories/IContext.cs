using System;

namespace Advance.Framework.Interfaces.Repositories
{
    public interface IContext : IDisposable
    {
        int SaveChanges();
    }
}
