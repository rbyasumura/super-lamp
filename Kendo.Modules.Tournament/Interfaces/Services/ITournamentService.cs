using Kendo.Modules.Tournaments.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Modules.Tournaments.Interfaces.Services
{
    public interface ITournamentService
    {
        IEnumerable<TournamentDto> ListAll();

        TournamentDto GetById(Guid id);

        IEnumerable<DivisionDto> ListDivisionsByTournamentId(Guid tournamentId);

        void Register(RegistrationDto registration);
    }
}
