using Advance.Framework.Modules.Core.Entities;
using System;

namespace Kendo.Entities
{
    public class Club
    {
        public Guid ClubId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
