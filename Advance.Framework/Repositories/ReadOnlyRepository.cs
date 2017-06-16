using Advance.Framework.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.Repositories
{
    public abstract class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        protected ReadOnlyRepository(UnitOfWorkBase unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected UnitOfWorkBase UnitOfWork { get; private set; }

        public bool Exists(Guid id)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> ListAll()
        {
            return ListAll<object>();
        }

        public IEnumerable<TEntity> ListAll<TProperty>(params Expression<Func<TEntity, TProperty>>[] includes)
        {
            return UnitOfWork.Entities(includes)
                .ToArray();
        }
    }
}
