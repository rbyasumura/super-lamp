using Advance.Framework.ContactModule.Entities;
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
        private void ConfigureContact(DbModelBuilder modelBuilder)
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