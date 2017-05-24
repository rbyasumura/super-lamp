using Advance.Framework.ContactModule.Entities;
using AutoMapper;

namespace Advance.Framework.ContactModule.Mappers.AutoMapper
{
    internal class ContactModuleProfile : Profile
    {
        public ContactModuleProfile()
        {
            CreateMap<Person, Person>()
                //.ForMember(dest => dest.PhoneNumbers, opt => opt.MapFrom(src => src.PhoneNumbers))
                ;
            CreateMap<PhoneNumber, PhoneNumber>()
                //.ForMember(dest => dest.Person, opt => opt.ResolveUsing<Resolver>())
                //.ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
                ;
        }
    }
}
