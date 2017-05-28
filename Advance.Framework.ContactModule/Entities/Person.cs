using Advance.Framework.Entities;
using System;
using System.Collections.Generic;

namespace Advance.Framework.ContactModule.Entities
{
    public class Person : ITimestampableEntity
    {
        public Person()
        {
            PersonId = Guid.NewGuid();
            PhoneNumbers = new List<PhoneNumber>();
        }

        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
