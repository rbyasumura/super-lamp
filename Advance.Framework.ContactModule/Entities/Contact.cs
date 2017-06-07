using Advance.Framework.Entities;
using System;
using System.Collections.Generic;

namespace Advance.Framework.ContactModule.Entities
{
    public class Contact : ITimestampableEntity
        , ISoftDeletableEntity
    {
        public Contact()
        {
            ContactId = Guid.NewGuid();
        }

        public Guid ContactId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public Person Person { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}