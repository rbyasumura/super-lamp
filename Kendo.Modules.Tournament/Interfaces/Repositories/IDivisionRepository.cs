using Advance.Framework.Repositories.Interfaces;
using Kendo.Modules.Tournaments.Entities;
using System;
using System.Collections.Generic;

namespace Kendo.Modules.Tournaments.Interfaces.Repositories
{
    public interface IDivisionRepository : IRepository<Division>
    {
        IEnumerable<Division> ListByTournamentId(Guid tournamentId);
    }
}
