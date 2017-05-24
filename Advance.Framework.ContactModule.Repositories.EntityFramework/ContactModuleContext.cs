using Advance.Framework.ContactModule.Entities;
using System.Data.Entity;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    class ContactModuleContext : DbContext
    {
        public ContactModuleContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneNumber>().HasRequired(i => i.Person);
        }
    }
}
