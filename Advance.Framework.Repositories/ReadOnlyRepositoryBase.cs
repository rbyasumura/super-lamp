using Advance.Framework.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Advance.Framework.Repositories
{
    public abstract class ReadOnlyRepositoryBase<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        private UnitOfWork unitOfWork;

        protected ReadOnlyRepositoryBase(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected UnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
        }

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
            throw new NotImplementedException();
        }
    }
}
