using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advance.Framework.Modules.Core.Entities;

namespace Advance.Framework.Modules.Contacts.Entities
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public string Zip { get; set; }
    }
}
