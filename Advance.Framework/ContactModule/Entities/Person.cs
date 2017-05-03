using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Advance.Framework.ContactModule.Entities
{
    public class Person
    {
        public Guid PersonId { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; } = new Collection<PhoneNumber>();
    }
}
