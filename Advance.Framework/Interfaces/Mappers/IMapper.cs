using System.Collections.Generic;

namespace Advance.Framework.Interfaces.Mappers
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);

        IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source);

        void RegisterMappingDefinitions(params IMappingDefinition[] mappingDefinitions);
    }
}
