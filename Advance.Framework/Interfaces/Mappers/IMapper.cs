using System.Collections;
using System.Collections.Generic;

namespace Advance.Framework.Interfaces.Mappers
{
    public interface IMapper
    {
        TDestination Map<TDestination>(object source);

        IEnumerable<TDestination> Map<TDestination>(IEnumerable source);

        void RegisterMappingDefinitions(params IMappingDefinition[] mappingDefinitions);
    }
}
