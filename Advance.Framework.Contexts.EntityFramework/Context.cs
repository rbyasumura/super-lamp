using Advance.Framework.Interfaces.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Advance.Framework.Contexts.EntityFramework
{
    public partial class Context : DbContext
        , IContext
    {
        public Context() : base("Default")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public int Commit()
        {
            return SaveChanges();
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
