using System;
using System.Collections.Generic;

namespace Advance.Framework.ContactModule.Repositories
{
    public interface IReadOnlyRepository<TEntity>
    {
        IEnumerable<TEntity> ListAll();

        TEntity GetById(Guid id);
    }
}
