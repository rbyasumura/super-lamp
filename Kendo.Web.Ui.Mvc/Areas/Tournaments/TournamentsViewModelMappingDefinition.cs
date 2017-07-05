using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Mappers.Interfaces;
using Kendo.Dtos;
using Kendo.Modules.Tournaments.Dtos;
using Kendo.Web.Ui.Mvc.Areas.Tournaments.Models;
using System.Linq;

namespace Kendo.Web.Ui.Mvc.Areas.Tournaments
{
    public class TournamentsViewModelMappingDefinition : IMappingDefinition
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

        public void Initialize(IMapperConfiguration config)
        {
            config.CreateMap<TournamentDto, IndexViewModel>();
            config.CreateMap<TournamentDto, GetDetailViewModel>();
            config.CreateMap<RegisterViewModel, RegistrationDto>()
                .ConvertUsing(src => Mapper.Map<RegistrationDto>(src.Registration))
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
                .ForMember(dest => dest.ClubId, opts => opts.MapFrom(src => src.Club.ClubId))
                ;
            config.CreateMap<RegistrantDto, _RegistrationViewModel.RegistrantViewModel>()
                .ForMember(dest => dest.SelectedDivisionIds, opts => opts.ResolveUsing(src => src.Divisions.Select(i => i.DivisionId)))
                .ForMember(dest => dest.Divisions, opts => opts.Ignore())
                ;
        }
    }
}
