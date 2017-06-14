using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework
{
    public partial class Context : DbContext
    {
        public Context()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigureContact(modelBuilder);
            ConfigureSecurity(modelBuilder);
            ConfigureCms(modelBuilder);
        }
    }
}
