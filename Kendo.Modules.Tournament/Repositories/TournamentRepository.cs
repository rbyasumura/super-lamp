using Advance.Framework.Repositories;
using Kendo.Modules.Tournaments.Entities;
using Kendo.Modules.Tournaments.Interfaces.Repositories;

namespace Kendo.Modules.Tournaments.Repositories
{
    public class TournamentRepository : RepositoryBase<Tournament>
        , ITournamentRepository
    {
        public TournamentRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
