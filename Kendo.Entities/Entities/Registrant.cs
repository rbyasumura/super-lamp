using Advance.Framework.Interfaces.Entities;
using Advance.Framework.Modules.Contacts.Entities;
using System;

namespace Kendo.Entities
{
    public class Registrant : ITimestampableEntity
    {
        public Guid RegistrantId { get; set; }
        public Contact Contact { get; set; }
        public Club Club { get; set; }
        public Rank Rank { get; set; }
        public Division Division { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
