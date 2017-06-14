using Advance.Framework.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advance.Framework.Repositories
{
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
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
            return UnitOfWork.Entities<TEntity>()
              .ToArray();
        }

        public IEnumerable<TEntity> ListAll<TProperty>(params System.Linq.Expressions.Expression<Func<TEntity, TProperty>>[] includes)
        {
            throw new NotImplementedException();
        }
    }
}
