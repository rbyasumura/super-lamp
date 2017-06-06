using Advance.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public Person Person { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
