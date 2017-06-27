using AutoMapper;
using System;
using System.Linq;
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
    }
}
