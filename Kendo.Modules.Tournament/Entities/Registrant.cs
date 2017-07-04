using Advance.Framework.Interfaces.Entities;
using Advance.Framework.Modules.Contacts.Entities;
using Kendo.Entities;
using System;
using System.Collections.Generic;

namespace Kendo.Modules.Tournaments.Entities
{
    public class Registrant : ITimestampableEntity
    {
        public Guid RegistrantId { get; set; }
        public Contact Contact { get; set; }
        public Rank Rank { get; set; }
        public ICollection<Division> Divisions { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
