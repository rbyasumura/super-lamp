using Advance.Framework.ContactModule.Entities;
using Advance.Framework.Security.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance.Framework.Contexts.EntityFramework
{
    partial class Context
    {
        private void ConfigureSecurity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(i => i.Roles)
                ;
            modelBuilder.Entity<Role>()
                .HasMany(i => i.Users)
                ;
        }
    }
}