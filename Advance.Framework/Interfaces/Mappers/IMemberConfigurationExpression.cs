using System;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.Interfaces.Mappers
{
    public interface IMemberConfigurationExpression<TSource>
    {
        void MapFrom<TSourceMember>(Expression<Func<TSource, TSourceMember>> sourceMember);

        void Ignore();
    }
}
