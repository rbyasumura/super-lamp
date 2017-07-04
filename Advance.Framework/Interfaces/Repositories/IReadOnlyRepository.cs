using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Advance.Framework.Interfaces.Repositories
{
    public interface IReadOnlyRepository<TEntity>
    {
        bool Exists<TId>(TId id);

        TEntity GetById<TId>(TId id);

        TEntity GetById<TId, TProperty>(TId id, params Expression<Func<TEntity, TProperty>>[] includes);

        IEnumerable<TEntity> ListAll();

        IEnumerable<TEntity> ListAll<TProperty>(params Expression<Func<TEntity, TProperty>>[] includes);
    }
}
