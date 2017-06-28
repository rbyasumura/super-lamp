using System.Linq;
using System;
using Advance.Framework.Interfaces.Mappers;
using Advance.Framework.Mappers.AutoMapper.Wrappers;
using AutoMapper;
using System.Collections.Generic;

namespace Advance.Framework.Mappers.AutoMapper
{
    public class AutoMapperMapper : Interfaces.Mappers.IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source)
        {
            return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
        }

        public void RegisterMappingDefinitions(params IMappingDefinition[] mappingDefinitions)
        {
            Mapper.Initialize(config =>
            {
                foreach (var mappingDefinition in mappingDefinitions)
                {
                    mappingDefinition.Initialize(new MapperConfigurationWrapper(config));
                }
            });
        }
    }
}
