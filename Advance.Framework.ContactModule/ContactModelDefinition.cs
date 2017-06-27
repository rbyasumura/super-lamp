using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Modules.Contacts.Entities;
using Advance.Framework.Modules.Core.Entities;

namespace Advance.Framework.Modules.Contacts
{
    public class ContactModelDefinition : IModelDefinition
    {
        public void Build(IModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneNumber>();
            var contactConfiguration = modelBuilder.Entity<Contact>();
            contactConfiguration.HasRequired(i => i.Person).WithMany();
            contactConfiguration.HasMany(i => i.PhoneNumbers).WithOptional();
        }
    }
}
