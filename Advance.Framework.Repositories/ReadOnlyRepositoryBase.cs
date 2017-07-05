using Advance.Framework.Entities.Helpers;
using Advance.Framework.Interfaces.Contexts;
using Advance.Framework.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.Repositories
{
    public abstract class ReadOnlyRepositoryBase<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        protected ReadOnlyRepositoryBase(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        internal UnitOfWork UnitOfWork
        {
            get;
        }

        public bool Exists<TId>(TId id)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById<TId, TProperty>(TId id, params Expression<Func<TEntity, TProperty>>[] includes)
        {
            var query = GetQuery(includes);
            var entityType = typeof(TEntity);
            var parameter = Expression.Parameter(entityType);
            var left = Expression.Property(parameter, EntityUtility.GetIdPropertyName(entityType));
            var right = Expression.Constant(id);
            var body = Expression.Equal(left, right);
            var predicate = Expression.Lambda<Func<TEntity, bool>>(body, parameter);
            return query.SingleOrDefault(predicate);
        }

        public TEntity GetById<TId>(TId id)
        {
            return GetById<TId, object>(id);
        }

        public IEnumerable<TEntity> ListAll()
        {
            return ListAll<object>();
        }

        public IEnumerable<TEntity> ListAll<TProperty>(params Expression<Func<TEntity, TProperty>>[] includes)
        {
            var query = GetQuery(includes);
            return query.ToArray();
        }

        protected IQuery<TEntity> GetQuery()
        {
            return GetQuery<object>();
        }

        protected IQuery<TEntity> GetQuery<TProperty>(params Expression<Func<TEntity, TProperty>>[] includes)
        {
            var query = UnitOfWork.Context.GetSet<TEntity>().AsQuery();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }
    }
}
