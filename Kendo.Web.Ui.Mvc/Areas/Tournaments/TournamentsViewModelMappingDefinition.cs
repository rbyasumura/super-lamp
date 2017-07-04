using Advance.Framework.Interfaces.Mappers;
using Advance.Framework.Mappers;
using Kendo.Dtos;
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
                .ConvertUsing(src => Mapper.Instance.Map<RegistrationDto>(src.Registration))
                ;
            config.CreateMap<_RegistrationViewModel, RegistrationDto>()
                .BeforeMap((src, dest) =>
                {
                    src.Registrants = src.Registrants
                        .Where(i => string.IsNullOrWhiteSpace(i.FirstName) == false
                            && string.IsNullOrWhiteSpace(i.LastName) == false)
                        .ToList();
                })
                .ForMember(dest => dest.Club, opts => opts.MapFrom(src => new ClubDto
                {
                    ClubId = src.ClubId,
                }));
            ;
            config.CreateMap<_RegistrationViewModel.RegistrantViewModel, RegistrantDto>()
                .ForMember(dest => dest.Divisions, opts => opts.MapFrom(src => src.SelectedDivisionIds.Select(i => new DivisionDto
                {
                    DivisionId = i
                })))
                ;
            config.CreateMap<RegistrationDto, ConfirmViewModel>()
                .ForMember(dest => dest.ClubName, opts => opts.MapFrom(src => src.Club.Name))
                ;
            config.CreateMap<RegistrantDto, ConfirmViewModel.RegistrantViewModel>()
                .ForMember(dest => dest.DivisionName, opts => opts.MapFrom(src => src.Divisions.First().Name))
                ;
            config.CreateMap<RegistrationDto, EditViewModel>()
                .ForMember(dest => dest.Registration, opts => opts.MapFrom(src => src))
                ;
            config.CreateMap<RegistrationDto, _RegistrationViewModel>()
                ;
            config.CreateMap<RegistrantDto, _RegistrationViewModel.RegistrantViewModel>()
                ;
        }
    }
}
