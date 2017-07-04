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

        public IMappingExpression<TSource, TDestination> BeforeMap(Action<TSource, TDestination> beforeFunction)
        {
            return new MappingExpressionWrapper<TSource, TDestination>(mappingExpression.BeforeMap((src, dest) => beforeFunction(src, dest)));
        }

        public void ConvertUsing(Func<TSource, TDestination, IResolutionContext, TDestination> mappingFunction)
        {
            mappingExpression.ConvertUsing((src, dest, context) => mappingFunction(src, dest, new ResolutionContextWrapper(context)));
        }

        public void ConvertUsing(Func<TSource, TDestination> mappingFunction)
        {
            mappingExpression.ConvertUsing(mappingFunction);
        }

        public IMappingExpression<TSource, TDestination> ForMember<TMember>(Expression<Func<TDestination, TMember>> destinationMember, Action<IMemberConfigurationExpression<TSource, TDestination, TMember>> memberOptions)
        {
            return new MappingExpressionWrapper<TSource, TDestination>(mappingExpression.ForMember(destinationMember, opt => memberOptions(new MemberConfigurationExpressionWrapper<TSource, TDestination, TMember>(opt))));
        }
    }
}
