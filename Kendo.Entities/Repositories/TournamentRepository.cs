using Advance.Framework.Repositories;
using Kendo.Entities;
using Kendo.Interfaces.Repositories;

namespace Kendo.Repositories
{
    public class TournamentRepository : RepositoryBase<Tournament>
        , ITournamentRepository
    {
        public TournamentRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
