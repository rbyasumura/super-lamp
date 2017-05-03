using Advance.Framework.ContactModule.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    class ContactModuleContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneNumber>().HasRequired(i => i.Person);
        }
    }
}
