using System;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.Mappers.Interfaces
{
    public interface IMappingExpression<TSource, TDestination>
    {
        IMappingExpression<TSource, TDestination> ForMember<TMember>(Expression<Func<TDestination, TMember>> destinationMember, Action<IMemberConfigurationExpression<TSource, TDestination, TMember>> memberOptions);

        void ConvertUsing(Func<TSource, TDestination> mappingFunction);

        void ConvertUsing(Func<TSource, TDestination, IResolutionContext, TDestination> mappingFunction);

        IMappingExpression<TSource, TDestination> BeforeMap(Action<TSource, TDestination> beforeFunction);
    }
}
