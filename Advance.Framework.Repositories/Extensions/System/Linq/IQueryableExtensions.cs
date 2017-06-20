using System;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.Repositories.Extensions.System.Linq
{
    internal static class IQueryableExtensions
    {
        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> source, Expression<Func<T, TProperty>> path)
        {
            throw new NotImplementedException();
        }
    }
}
