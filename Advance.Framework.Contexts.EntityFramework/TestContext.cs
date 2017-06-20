using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework
{
    partial class TestContext : EntityFrameworkContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigureContact(modelBuilder);
            ConfigureSecurity(modelBuilder);
            ConfigureCms(modelBuilder);
        }
    }
}
