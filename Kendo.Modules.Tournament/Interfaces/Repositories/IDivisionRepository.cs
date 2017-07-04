using Advance.Framework.Interfaces.Repositories;
using Kendo.Modules.Tournaments.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Modules.Tournaments.Interfaces.Repositories
{
    public interface IDivisionRepository : IRepository<Division>
    {
        IEnumerable<Division> ListByTournamentId(Guid tournamentId);
    }
}
