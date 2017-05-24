using System;
using System.ComponentModel.DataAnnotations;

namespace Advance.Framework.ContactModule.Entities
{
    public class PhoneNumber
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
    }
}
