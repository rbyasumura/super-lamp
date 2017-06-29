using Advance.Framework.Interfaces.Mappers;
using Kendo.Entities;
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
                .ConvertUsing(src => ListRegistrants(src));
        }

        private IEnumerable<Registrant> ListRegistrants(RegistrationDto registration)
        {
            foreach (var registrant in registration.Registrants)
            {
                yield return new Registrant
                {
                };
            }
        }
    }
}
