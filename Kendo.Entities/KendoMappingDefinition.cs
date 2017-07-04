using Advance.Framework.Interfaces.Mappers;
using Kendo.Dtos;
using Kendo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
