using Advance.Framework.Modules.Contacts.Entities;
using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework
{
    partial class Context
    {
        private void ConfigureContact(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<PhoneNumber>();
            modelBuilder.Entity<Contact>();
        }
    }
}
