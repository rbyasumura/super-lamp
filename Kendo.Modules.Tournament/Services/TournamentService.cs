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
        public TournamentDto GetById(Guid id)
        {
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var tournamentRepository = unitOfWork.GetRepository<ITournamentRepository>();
                var tournament = tournamentRepository.GetById(id);
                return Mapper.Instance.Map<TournamentDto>(tournament);
            }
        }

        public IEnumerable<TournamentDto> ListAll()
        {
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var tournamentRepository = unitOfWork.GetRepository<ITournamentRepository>();
                var tournaments = tournamentRepository.ListAll();
                return Mapper.Instance.Map<TournamentDto>(tournaments);
            }
        }

        public IEnumerable<DivisionDto> ListDivisionsByTournamentId(Guid tournamentId)
        {
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var divisionRepository = unitOfWork.GetRepository<IDivisionRepository>();
                var divisions = divisionRepository.ListByTournamentId(tournamentId);
                return Mapper.Instance.Map<DivisionDto>(divisions);
            }
        }

        public void Register(RegistrationDto registration)
        {
            var registrants = Mapper.Instance.Map<IEnumerable<Registrant>>(registration);

            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var registrantRepository = unitOfWork.GetRepository<IRegistrantRepository>();
                foreach (var registrant in registrants)
                {
                    registrantRepository.Add(registrant);
                }

                unitOfWork.SaveChanges();
            }
        }
    }
}
