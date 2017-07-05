using Advance.Framework.Mappers.Interfaces;
using Kendo.Dtos;
using Kendo.Entities;

namespace Kendo
{
    public class KendoMappingDefinition : IMappingDefinition
    {
        public void Initialize(IMapperConfiguration config)
        {
            config.CreateMap<Club, ClubDto>();
        }
    }
}
