using Kendo.Modules.Tournaments.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Modules.Tournaments.Interfaces.Services
{
    public interface ITournamentService
    {
        IEnumerable<TournamentDto> ListAll();

        TournamentDto GetTournamentById(Guid id);

        IEnumerable<DivisionDto> ListDivisionsByTournamentId(Guid tournamentId);

        Guid Register(RegistrationDto registration);

        RegistrationDto GetRegistrationById(Guid registrationId);
    }
}
