using Advance.Framework.Interfaces.Repositories;
using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers
{
    internal class DbContextTransactionWrapper : ITransaction
    {
        private DbContextTransaction contextTransaction;

        public DbContextTransactionWrapper(DbContextTransaction contextTransaction)
        {
            this.contextTransaction = contextTransaction;
        }

        public void Commit()
        {
            contextTransaction.Commit();
        }
    }
}
