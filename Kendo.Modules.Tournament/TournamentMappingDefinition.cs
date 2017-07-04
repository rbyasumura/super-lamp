using Advance.Framework.Interfaces.Mappers;
using Advance.Framework.Modules.Contacts.Entities;
using Advance.Framework.Modules.Core.Entities;
using Kendo.Interfaces.Repositories;
using Kendo.Modules.Tournaments.Dtos;
using Kendo.Modules.Tournaments.Entities;
using Kendo.Modules.Tournaments.Interfaces.Repositories;
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
            config.CreateMap<RegistrationDto, Registration>()
                .ForMember(dest => dest.Tournament, opts => opts.ResolveUsing<ITournamentRepository, Guid>(src => src.TournamentId))
                .ForMember(dest => dest.Club, opts => opts.ResolveUsing<IClubRepository, Guid>(src => src.Club.ClubId))
                ;
            config.CreateMap<RegistrantDto, Registrant>()
                .ForMember(dest => dest.Contact, opts => opts.MapFrom(src => src))
                //.ForMember(dest => dest.Divisions, opts => opts.ResolveUsing((src, dest, member, context) => MapDivisions(src, context)))
                //.ForMember(dest => dest.Divisions, opts => opts.MapFrom(src => src.Divisions))
                .ForMember(dest => dest.Divisions, opts => opts.ResolveUsing<IDivisionRepository, Division, Guid>(src => src.Divisions.Select(i => i.DivisionId)))
                ;
            config.CreateMap<RegistrantDto, Contact>()
                .ForMember(dest => dest.Person, opts => opts.MapFrom(src => src));
            config.CreateMap<RegistrantDto, Person>();
            config.CreateMap<Registration, RegistrationDto>();
            config.CreateMap<Registrant, RegistrantDto>()
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.Contact.Person.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.Contact.Person.LastName))
                //.ForMember(dest => dest.Divisions
                .ForMember(dest => dest.DateOfBirth, opts => opts.MapFrom(src => src.Contact.Person.DateOfBirth))
                ;
        }
    }
}
