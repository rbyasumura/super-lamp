using Advance.Framework.Interfaces.Mappers;
using AutoMapper;
using System;
using System.Linq;

namespace Advance.Framework.Mappers.AutoMapper.Wrappers
{
    internal class MapperConfigurationWrapper : IMapperConfiguration
    {
        private IMapperConfigurationExpression config;

        public MapperConfigurationWrapper(IMapperConfigurationExpression config)
        {
            this.config = config;
        }

        public Interfaces.Mappers.IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>()
        {
            return new MappingExpressionWrapper<TSource, TDestination>(config.CreateMap<TSource, TDestination>());
        }
    }
}
