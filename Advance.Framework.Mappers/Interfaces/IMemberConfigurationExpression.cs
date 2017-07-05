using Advance.Framework.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Advance.Framework.Mappers.Interfaces
{
    public interface IMemberConfigurationExpression<TSource, TDestination, TMember>
    {
        void MapFrom<TSourceMember>(Expression<Func<TSource, TSourceMember>> sourceMember);

        void Ignore();

        void ResolveUsing<TResult>(Func<TSource, TDestination, TMember, IResolutionContext, TResult> resolver);

        void ResolveUsing<TRepository, TId>(Func<TSource, TId> id)
            where TRepository : IReadOnlyRepository<TMember>;

        void ResolveUsing<TRepository, TElement, TId>(Func<TSource, IEnumerable<TId>> ids)
            where TRepository : IReadOnlyRepository<TElement>;

        void ResolveUsing<TResult>(Func<TSource, TResult> resolver);
    }
}
