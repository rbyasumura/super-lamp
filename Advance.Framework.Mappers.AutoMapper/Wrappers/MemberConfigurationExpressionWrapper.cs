using Advance.Framework.Interfaces.Mappers;
using System;
using System.Linq;
using System.Linq.Expressions;
using AM = AutoMapper;

namespace Advance.Framework.Mappers.AutoMapper.Wrappers
{
    internal class MemberConfigurationExpressionWrapper<TSource, TDestination, TMember> : IMemberConfigurationExpression<TSource>
    {
        private AM.IMemberConfigurationExpression<TSource, TDestination, TMember> memberConfigurationExpression;

        public MemberConfigurationExpressionWrapper(AM.IMemberConfigurationExpression<TSource, TDestination, TMember> memberConfigurationExpression)
        {
            this.memberConfigurationExpression = memberConfigurationExpression;
        }

        public void MapFrom<TSourceMember>(Expression<Func<TSource, TSourceMember>> sourceMember)
        {
            memberConfigurationExpression.MapFrom(sourceMember);
        }

        public void Ignore()
        {
            memberConfigurationExpression.Ignore();
        }
    }
}
