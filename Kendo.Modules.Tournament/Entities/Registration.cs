using Advance.Framework.Interfaces.Entities;
using Kendo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Modules.Tournaments.Entities
{
    public class Registration : ITimestampableEntity
    {
        public Guid RegistrationId { get; set; }
        public Tournament Tournament { get; set; }
        public Club Club { get; set; }
        public ICollection<Registrant> Registrants { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
