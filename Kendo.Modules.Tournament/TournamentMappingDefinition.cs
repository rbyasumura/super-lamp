using Advance.Framework.Interfaces.Mappers;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Modules.Contacts.Entities;
using Advance.Framework.Modules.Core.Entities;
using Kendo.Entities;
using Kendo.Interfaces.Repositories;
using Kendo.Modules.Tournaments.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Modules.Tournaments
{
    public class TournamentMappingDefinition : IMappingDefinition
    {
        public void Initialize(IMapperConfiguration config)
        {
            config.CreateMap<Tournament, TournamentDto>();
            config.CreateMap<Division, DivisionDto>();
            config.CreateMap<RegistrationDto, IEnumerable<Registrant>>()
                .ConvertUsing((src, dest, context) => MapRegistrants(src, context));
        }

        private IEnumerable<Registrant> MapRegistrants(RegistrationDto registration, IResolutionContext context)
        {
            var unitOfWork = (IUnitOfWork)context.Items[Constants.UNIT_OF_WORK];

            var tournamentRepository = unitOfWork.GetRepository<ITournamentRepository>();
            var tournament = tournamentRepository.GetById(registration.TournamentId);

            var clubRepository = unitOfWork.GetRepository<IClubRepository>();
            var club = clubRepository.GetById(registration.ClubId);

            foreach (var registrant in registration.Registrants)
            {
                yield return new Registrant
                {
                    Tournament = tournament,
                    Club = club,
                    Contact = new Contact
                    {
                        Person = new Person
                        {
                            FirstName = registrant.FirstName,
                            LastName = registrant.LastName,
                        },
                    },
                };
            }
        }
    }
}
