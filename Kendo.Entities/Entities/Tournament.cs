using Advance.Framework.Modules.Core.Entities;
using System;
using System.Collections.Generic;

namespace Kendo.Entities
{
    public class Tournament
    {
        public Guid TournamentId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset StartAt { get; set; }
        public DateTimeOffset? EndAt { get; set; }
        public TournamentSeries Series { get; set; }
        public Address Location { get; set; }
        public ICollection<Registrant> Registrants { get; set; }
    }
}
