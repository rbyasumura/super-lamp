using System;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.Interfaces.Mappers
{
    public interface IMappingExpression<TSource, TDestination>
    {
        IMappingExpression<TSource, TDestination> ForMember<TMember>(Expression<Func<TDestination, TMember>> destinationMember, Action<IMemberConfigurationExpression<TSource>> memberOptions);
    }
}
