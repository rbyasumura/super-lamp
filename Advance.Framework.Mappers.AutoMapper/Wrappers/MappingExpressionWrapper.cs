using System.Linq;
using System;
using Advance.Framework.Interfaces.Mappers;

using System;

using System.Linq.Expressions;
using AM = AutoMapper;

namespace Advance.Framework.Mappers.AutoMapper.Wrappers
{
    internal class MappingExpressionWrapper<TSource, TDestination> : IMappingExpression<TSource, TDestination>
    {
        private AM.IMappingExpression<TSource, TDestination> mappingExpression;

        public MappingExpressionWrapper(AM.IMappingExpression<TSource, TDestination> mappingExpression)
        {
            this.mappingExpression = mappingExpression;
        }

        public IMappingExpression<TSource, TDestination> ForMember<TMember>(Expression<Func<TDestination, TMember>> destinationMember, Action<IMemberConfigurationExpression<TSource>> memberOptions)
        {
            return new MappingExpressionWrapper<TSource, TDestination>(mappingExpression.ForMember(destinationMember, opt => memberOptions(new MemberConfigurationExpressionWrapper<TSource, TDestination, TMember>(opt))));
        }

        public void ConvertUsing(Func<TSource, TDestination> mappingFunction)
        {
            mappingExpression.ConvertUsing(src => mappingFunction(src));
        }
    }
}
