﻿using Advance.Framework;
using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Mappers.Interfaces;
using Advance.Framework.Repositories.Interfaces;
using Kendo.Modules.Tournaments.Dtos;
using Kendo.Modules.Tournaments.Entities;
using Kendo.Modules.Tournaments.Interfaces.Repositories;
using Kendo.Modules.Tournaments.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Modules.Tournaments.Services
{
    public class TournamentService : ITournamentService
    {
        private IMapper mapper;

        private IMapper Mapper
        {
            get
            {
                if (mapper == null)
                {
                    mapper = Container.Instance.Resolve<IMapper>();
                }
                return mapper;
            }
        }

        public RegistrationDto GetRegistrationById(Guid registrationId)
        {
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var registrationRepository = unitOfWork.GetRepository<IRegistrationRepository>();
                var registration = registrationRepository.GetById<Guid, object>(registrationId,
                    i => i.Club,
                    i => i.Registrants,
                    i => i.Registrants.Select(j => j.Contact),
                    i => i.Registrants.Select(j => j.Contact.Person),
                    i => i.Registrants.Select(j => j.Divisions),
                    i => i.Tournament);
                return Mapper.Map<RegistrationDto>(registration);
            }
        }

        public TournamentDto GetTournamentById(Guid tournamentId)
        {
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var tournamentRepository = unitOfWork.GetRepository<ITournamentRepository>();
                var tournament = tournamentRepository.GetById(tournamentId);
                return Mapper.Map<TournamentDto>(tournament);
            }
        }

        public IEnumerable<TournamentDto> ListAll()
        {
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var tournamentRepository = unitOfWork.GetRepository<ITournamentRepository>();
                var tournaments = tournamentRepository.ListAll();
                return Mapper.Map<TournamentDto>(tournaments);
            }
        }

        public IEnumerable<DivisionDto> ListDivisionsByTournamentId(Guid tournamentId)
        {
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var divisionRepository = unitOfWork.GetRepository<IDivisionRepository>();
                var divisions = divisionRepository.ListByTournamentId(tournamentId);
                return Mapper.Map<DivisionDto>(divisions);
            }
        }

        public Guid Register(RegistrationDto dto)
        {
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var registrationRepository = unitOfWork.GetRepository<IRegistrationRepository>();
                var registration = Mapper.Map<Registration>(dto, opts =>
                {
                    opts.Items.Add(Constants.UNIT_OF_WORK, unitOfWork);
                });
                registrationRepository.Add(registration);

                unitOfWork.SaveChanges();

                return registration.RegistrationId;
            }
        }
    }
}
