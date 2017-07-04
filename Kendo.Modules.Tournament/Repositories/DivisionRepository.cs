using Advance.Framework.Repositories;
using Kendo.Modules.Tournaments.Entities;
using Kendo.Modules.Tournaments.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Modules.Tournaments.Repositories
{
    public class DivisionRepository : RepositoryBase<Division>
            , IDivisionRepository
    {
        public DivisionRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Division> ListByTournamentId(Guid tournamentId)
        {
            return GetQuery().Where(i => i.Tournament.TournamentId == tournamentId)
                .ToArray();
        }
    }
}
