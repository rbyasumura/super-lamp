using Advance.Framework.Interfaces.Repositories;
using Kendo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Interfaces.Repositories
{
    public interface IDivisionRepository : IRepository<Division>
    {
        IEnumerable<Division> ListByTournamentId(Guid tournamentId);
    }
}
