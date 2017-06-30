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
            config.CreateMap<RegisterViewModel, RegistrationDto>()
                .BeforeMap((src, dest) =>
                {
                    src.Registrants = src.Registrants
                        .Where(i => string.IsNullOrWhiteSpace(i.FirstName) == false
                            && string.IsNullOrWhiteSpace(i.LastName) == false)
                        .ToList();
                });
            config.CreateMap<RegistrantViewModel, RegistrantDto>();
        }
    }
}
