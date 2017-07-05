using Advance.Framework.Mappers.Interfaces;
using AM = AutoMapper;

namespace Advance.Framework.Mappers.AutoMapper.Wrappers
{
    internal class MapperConfigurationWrapper : IMapperConfiguration
    {
        private AM.IMapperConfigurationExpression config;

        public MapperConfigurationWrapper(AM.IMapperConfigurationExpression config)
        {
            this.config = config;
        }

        public IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>()
        {
            return new MappingExpressionWrapper<TSource, TDestination>(config.CreateMap<TSource, TDestination>());
        }
    }
}
