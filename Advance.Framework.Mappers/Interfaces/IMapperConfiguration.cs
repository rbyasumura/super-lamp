using System;
using System.Linq;

namespace Advance.Framework.Mappers.Interfaces
{
    public interface IMapperConfiguration
    {
        IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>();
    }
}
