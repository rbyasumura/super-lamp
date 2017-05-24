using System;
using System.Collections.Generic;

namespace Advance.Framework.ContactModule.Entities
{
    public class Person
    {
        public Person()
        {
            PersonId = Guid.NewGuid();
        }

        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
