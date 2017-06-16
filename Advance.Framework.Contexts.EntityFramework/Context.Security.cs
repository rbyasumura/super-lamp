using Advance.Framework.Security.Entities;
using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework
{
    partial class Context
    {
        private void ConfigureSecurity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Role>();
        }
    }
}
