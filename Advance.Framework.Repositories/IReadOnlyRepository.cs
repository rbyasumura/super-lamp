using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Advance.Framework.Repositories
{
    public interface IReadOnlyRepository<TEntity>
    {
        IEnumerable<TEntity> ListAll();

        IEnumerable<TEntity> ListAll<TProperty>(params Expression<Func<TEntity, TProperty>>[] includes);

        TEntity GetById(Guid id);

        bool Exists(Guid id);
    }
}
