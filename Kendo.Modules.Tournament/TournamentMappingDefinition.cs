using Advance.Framework.Interfaces.Mappers;
using Kendo.Entities;
using Kendo.Modules.Tournaments.Dtos;
using System;
using System.Linq;

namespace Kendo.Modules.Tournaments
{
    public class TournamentMappingDefinition : IMappingDefinition
    {
        public void Initialize(IMapperConfiguration config)
        {
            config.CreateMap<Tournament, TournamentDto>();
        }
    }
}
