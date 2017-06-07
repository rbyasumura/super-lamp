using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance.Framework.Contexts.EntityFramework
{
    partial class Context : DbContext
    {
        private Context()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigureContact(modelBuilder);
            ConfigureSecurity(modelBuilder);
        }
    }
}