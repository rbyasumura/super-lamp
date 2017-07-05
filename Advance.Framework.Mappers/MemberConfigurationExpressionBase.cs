using Advance.Framework.Mappers.Interfaces;
using Advance.Framework.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Advance.Framework.Mappers
{
    public abstract class MemberConfigurationExpressionBase<TSource, TDestination, TMember> : IMemberConfigurationExpression<TSource, TDestination, TMember>
    {
        public abstract void Ignore();

        public abstract void MapFrom<TSourceMember>(Expression<Func<TSource, TSourceMember>> sourceMember);

        public void ResolveUsing<TRepository, TId>(Func<TSource, TId> id)
            where TRepository : IReadOnlyRepository<TMember>
        {
            ResolveUsing((src, dest, member, context) =>
            {
                var unitOfWork = (IUnitOfWork)context.Items[Constants.UNIT_OF_WORK];
                var repository = unitOfWork.GetRepository<TRepository>();
                return repository.GetById(id(src));
            });
        }

        public void ResolveUsing<TRepository, TElement, TId>(Func<TSource, IEnumerable<TId>> ids) where TRepository : IReadOnlyRepository<TElement>
        {
            ResolveUsing((src, dest, member, context) => ResolveUsing<TRepository, TElement, TId>(ids(src), context));
        }

        public abstract void ResolveUsing<TResult>(Func<TSource, TDestination, TMember, IResolutionContext, TResult> resolver);

        public abstract void ResolveUsing<TResult>(Func<TSource, TResult> resolver);

        private IEnumerable<TElement> ResolveUsing<TRepository, TElement, TId>(IEnumerable<TId> ids, IResolutionContext context)
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
