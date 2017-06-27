using System;
using Advance.Framework.Modules.Contacts.Entities;

namespace Kendo.Entities
{
    public class Club
    {
        public Guid ClubId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
