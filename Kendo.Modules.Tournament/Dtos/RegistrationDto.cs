using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Modules.Tournaments.Dtos
{
    public class RegistrationDto
    {
        public Guid TournamentId { get; set; }
        public Guid ClubId { get; set; }
        public IEnumerable<RegistrantDto> Registrants { get; set; }
    }
}
