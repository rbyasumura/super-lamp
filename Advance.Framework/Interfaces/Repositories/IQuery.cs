using System.Collections.Generic;
using System.Linq;

namespace Advance.Framework.Interfaces.Repositories
{
    public interface IQuery<TEntity> : IEnumerable<TEntity>
    {
        IQueryable<TEntity> Include(string path);
    }
}
