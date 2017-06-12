using Advance.Framework.Interfaces.Entities;
using System;

namespace Advance.Framework.ContactModule.Entities
{
    public class PhoneNumber : ITimestampableEntity
        , ISoftDeletableEntity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public string Number { get; set; }
        public Guid PhoneNumberId { get; set; }
        public PhoneNumberType Type { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
