using Kendo.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Modules.Tournaments.Dtos
{
    public class RegistrationDto
    {
        public Guid TournamentId { get; set; }
        public IEnumerable<RegistrantDto> Registrants { get; set; }
        public Guid RegistrationId { get; set; }
        public ClubDto Club { get; set; }
    }
}
