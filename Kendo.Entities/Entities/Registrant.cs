using Advance.Framework.Modules.Contacts.Entities;
using System;

namespace Kendo.Entities
{
    public class Registrant
    {
        public Guid RegistrantId { get; set; }
        public Contact Contact { get; set; }
        public Club Club { get; set; }
        public Rank Rank { get; set; }
    }
}
