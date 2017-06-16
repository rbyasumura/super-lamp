using Advance.Framework.Contexts.EntityFramework.Wrappers;
using Advance.Framework.Interfaces.Repositories;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;

namespace Advance.Framework.Contexts.EntityFramework
{
    public partial class Context : DbContext
        , IContext
    {
        internal Context() : base(ConfigurationManager.ConnectionStrings["Default"].ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public ITransaction Transaction
        {
            get
            {
                if (Database.CurrentTransaction == null)
                {
                    Database.BeginTransaction();
                }
                return new DbContextTransactionWrapper(Database.CurrentTransaction);
            }
        }

        public IEnumerable<IChangedEntry> GetChangedEntries()
        {
            return ChangeTracker.Entries()
                .Select(i => new DbEntityEntryWrapper(i));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigureContact(modelBuilder);
            ConfigureSecurity(modelBuilder);
            ConfigureCms(modelBuilder);
        }
    }
}
