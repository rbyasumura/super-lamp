using Advance.Framework.Interfaces.Mappers;
using Advance.Framework.Mappers.AutoMapper.Wrappers;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using AM = AutoMapper;

namespace Advance.Framework.Mappers.AutoMapper
{
    public class AutoMapperMapper : IMapper
    {
        public TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts = null)
        {
            return AM.Mapper.Map<TDestination>(source, _opts => opts?.Invoke(new MappingOperationOptionsWrapper(_opts)));
        }

        public IEnumerable<TDestination> Map<TDestination>(IEnumerable source)
        {
            return AM.Mapper.Map<IEnumerable<TDestination>>(source);
        }

        public void RegisterMappingDefinitions(params IMappingDefinition[] mappingDefinitions)
        {
            AM.Mapper.Initialize(config =>
            {
                foreach (var mappingDefinition in mappingDefinitions)
                {
                    mappingDefinition.Initialize(new MapperConfigurationWrapper(config));
                }
            });
        }
    }
}
