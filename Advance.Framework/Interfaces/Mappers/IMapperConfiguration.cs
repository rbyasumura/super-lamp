using System;
using System.Linq;

namespace Advance.Framework.Interfaces.Mappers
{
    public interface IMapperConfiguration
    {
        IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>();
    }
}
