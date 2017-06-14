using System.Collections.Generic;

namespace Advance.Framework.Repositories
{
    public class Repository
    {
        protected UnitOfWorkBase UnitOfWork;

        protected IEnumerable<TEntity> ListAll<TEntity>() where TEntity : class
        {
            return UnitOfWork.Entities<TEntity>();
        }
    }
}
