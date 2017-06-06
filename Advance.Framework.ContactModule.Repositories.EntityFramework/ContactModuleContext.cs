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
            modelBuilder.Entity<Person>()
                //.HasMany(i => i.PhoneNumbers).WithOptional(i => i.Person)
                ;
            modelBuilder.Entity<PhoneNumber>()
                //.HasOptional(i => i.Person)
                ;
            var contactConfiguration = modelBuilder.Entity<Contact>();
            contactConfiguration
                .HasMany(i => i.PhoneNumbers)
                ;
            contactConfiguration
                .HasRequired(i => i.Person)
                ;
        }
    }
}
