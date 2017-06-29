using System;
using System.Linq;

namespace Kendo.Modules.Tournaments.Dtos
{
    public class DivisionDto
    {
        public Guid DivisionId { get; set; }
        public TournamentDto Tournament { get; set; }
        public string Name { get; set; }
    }
}
