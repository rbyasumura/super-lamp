using Advance.Framework.Modules.Contacts.Entities;
using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework
{
    partial class TestContext
    {
        private void ConfigureContact(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<PhoneNumber>();
            var contactConfiguration = modelBuilder.Entity<Contact>();
            contactConfiguration.HasRequired(i => i.Person).WithMany();
            contactConfiguration.HasMany(i => i.PhoneNumbers).WithOptional();
        }
    }
}
