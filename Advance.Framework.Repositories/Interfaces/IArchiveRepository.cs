using Advance.Framework.Interfaces.Entities;
using System.Collections.Generic;

namespace Advance.Framework.Repositories.Interfaces
{
    internal interface IArchiveRepository<TEntity> : IRepository<TEntity>
        where TEntity : ISoftDeletableEntity
    {
        void Undelete(TEntity entity);

        IEnumerable<TEntity> ListAll(bool includeDeleted = false);
    }
}
