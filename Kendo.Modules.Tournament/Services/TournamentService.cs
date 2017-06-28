using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Mappers;
using Kendo.Entities;
using Kendo.Interfaces.Repositories;
using Kendo.Modules.Tournaments.Dtos;
using Kendo.Modules.Tournaments.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Modules.Tournaments.Services
{
    public class TournamentService : ITournamentService
    {
        public IEnumerable<TournamentDto> ListAll()
        {
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var tournamentRepository = unitOfWork.GetRepository<ITournamentRepository>();
                var tournaments = tournamentRepository.ListAll();
                return Mapper.Instance.Map<Tournament, TournamentDto>(tournaments);
            }
        }
    }
}
