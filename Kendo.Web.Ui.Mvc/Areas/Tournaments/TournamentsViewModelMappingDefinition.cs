using Advance.Framework.Interfaces.Mappers;
using Kendo.Modules.Tournaments.Dtos;
using Kendo.Web.Ui.Mvc.Areas.Tournaments.Models;
using System;
using System.Linq;

namespace Kendo.Web.Ui.Mvc.Areas.Tournaments
{
    public class TournamentsViewModelMappingDefinition : IMappingDefinition
    {
        public void Initialize(IMapperConfiguration config)
        {
            config.CreateMap<TournamentDto, IndexViewModel>();
            config.CreateMap<TournamentDto, GetDetailViewModel>();
        }
    }
}
