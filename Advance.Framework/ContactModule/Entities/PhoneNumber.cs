using System;
using System.ComponentModel.DataAnnotations;

namespace Advance.Framework.ContactModule.Entities
{
    public class PhoneNumber
    {
        public Guid PhoneNumberId { get; set; } = Guid.NewGuid();
        public string Number { get; set; }
        public PhoneNumberType Type { get; set; }
        [Required]
        public Person Person { get; set; }
    }
}
