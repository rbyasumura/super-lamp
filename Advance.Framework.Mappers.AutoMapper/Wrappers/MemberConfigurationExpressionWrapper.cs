using Advance.Framework.Interfaces.Mappers;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AM = AutoMapper;

namespace Advance.Framework.Mappers.AutoMapper.Wrappers
{
    internal class MemberConfigurationExpressionWrapper<TSource, TDestination, TMember> : MemberConfigurationExpressionBase
        , IMemberConfigurationExpression<TSource, TDestination, TMember>
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

        public void ResolveUsing<TResult>(Func<TSource, TDestination, TMember, IResolutionContext, TResult> resolver)
        {
            memberConfigurationExpression.ResolveUsing((src, dest, member, context) => resolver(src, dest, member, new ResolutionContextWrapper(context)));
        }

        public void ResolveUsing<TRepository, TId>(Func<TSource, TId> id)
            where TRepository : IReadOnlyRepository<TMember>
        {
            memberConfigurationExpression.ResolveUsing((src, dest, member, context) =>
            {
                var unitOfWork = (IUnitOfWork)context.Items[Constants.UNIT_OF_WORK];
                var repository = unitOfWork.GetRepository<TRepository>();
                return repository.GetById(id(src));
            });
        }

        public void ResolveUsing<TRepository, TElement, TId>(Func<TSource, IEnumerable<TId>> ids) where TRepository : IReadOnlyRepository<TElement>
        {
            memberConfigurationExpression.ResolveUsing((src, dest, member, context) => ResolveUsing<TRepository, TElement, TId>(ids(src), context));
        }

        private IEnumerable<TElement> ResolveUsing<TRepository, TElement, TId>(IEnumerable<TId> ids, AM.ResolutionContext context)
            where TRepository : IReadOnlyRepository<TElement>
        {
            var unitOfWork = (IUnitOfWork)context.Items[Constants.UNIT_OF_WORK];
            var repository = unitOfWork.GetRepository<TRepository>();
            foreach (var id in ids)
            {
                yield return repository.GetById(id);
            }
        }
    }
}
