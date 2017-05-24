using System;
using System.Collections.Generic;

namespace Advance.Framework.Repositories
{
    public interface IReadOnlyRepository<TEntity>
    {
        IEnumerable<TEntity> ListAll();

        TEntity GetById(Guid id);

        bool Exists(Guid id);
    }
}
