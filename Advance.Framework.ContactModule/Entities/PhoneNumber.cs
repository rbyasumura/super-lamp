using Advance.Framework.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Advance.Framework.ContactModule.Entities
{
    public class PhoneNumber : ITimestampableEntity
        , ISoftDeletableEntity
    {
        public PhoneNumber()
        {
            PhoneNumberId = Guid.NewGuid();
        }

        public Guid PhoneNumberId { get; set; }
        public string Number { get; set; }
        public PhoneNumberType Type { get; set; }
        [Required]
        public Person Person { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
