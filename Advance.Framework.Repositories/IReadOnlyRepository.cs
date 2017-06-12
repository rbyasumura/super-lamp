using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Advance.Framework.Repositories
{
    public interface IReadOnlyRepository<TEntity>
    {
        bool Exists(Guid id);

        TEntity GetById(Guid id);

        IEnumerable<TEntity> ListAll();

        IEnumerable<TEntity> ListAll<TProperty>(params Expression<Func<TEntity, TProperty>>[] includes);
    }
}
