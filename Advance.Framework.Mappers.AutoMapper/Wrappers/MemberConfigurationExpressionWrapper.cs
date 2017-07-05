using Advance.Framework.Mappers.Interfaces;
using System;
using System.Linq.Expressions;
using AM = AutoMapper;

namespace Advance.Framework.Mappers.AutoMapper.Wrappers
{
    internal class MemberConfigurationExpressionWrapper<TSource, TDestination, TMember> : MemberConfigurationExpressionBase<TSource, TDestination, TMember>
    {
        private AM.IMemberConfigurationExpression<TSource, TDestination, TMember> memberConfigurationExpression;

        public MemberConfigurationExpressionWrapper(AM.IMemberConfigurationExpression<TSource, TDestination, TMember> memberConfigurationExpression)
        {
            this.memberConfigurationExpression = memberConfigurationExpression;
        }

        public override void MapFrom<TSourceMember>(Expression<Func<TSource, TSourceMember>> sourceMember)
        {
            memberConfigurationExpression.MapFrom(sourceMember);
        }

        public override void Ignore()
        {
            memberConfigurationExpression.Ignore();
        }

        public override void ResolveUsing<TResult>(Func<TSource, TDestination, TMember, IResolutionContext, TResult> resolver)
        {
            memberConfigurationExpression.ResolveUsing((src, dest, member, context) => resolver(src, dest, member, new ResolutionContextWrapper(context)));
        }

        public override void ResolveUsing<TResult>(Func<TSource, TResult> resolver)
        {
            memberConfigurationExpression.ResolveUsing(src => resolver(src));
        }
    }
}
