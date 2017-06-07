using Advance.Framework.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.Repositories.EntityFramework
{
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        public ReadOnlyRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        internal DbSet<TEntity> Entities
        {
            get
            {
                return UnitOfWork.Set<TEntity>();
            }
        }

        protected IUnitOfWork UnitOfWork
        {
            get;
        }

        private DbQuery<TEntity> ReadOnlyEntities
        {
            get
            {
                return Entities.AsNoTracking();
            }
        }

        public bool Exists(Guid id)
        {
            var expression = GetIdExpression(id);
            return ReadOnlyEntities.Any(expression);
        }

        public TEntity GetById(Guid id)
        {
            var expression = GetIdExpression(id);
            return ReadOnlyEntities.SingleOrDefault(expression);
        }

        public IEnumerable<TEntity> ListAll<TProperty>(params Expression<Func<TEntity, TProperty>>[] includes)
        {
            var entities = (IQueryable<TEntity>)ReadOnlyEntities;
            foreach (var include in includes)
            {
                entities = entities.Include(include);
            }

            return entities.ToArray();
        }

        public IEnumerable<TEntity> ListAll()
        {
            return ListAll<object>();
        }

        internal static Expression<Func<TEntity, bool>> GetIdExpression(Guid id)
        {
            var parameterExpression = Expression.Parameter(typeof(TEntity));
            return Expression.Lambda<Func<TEntity, bool>>(
                Expression.Equal(
                    Expression.PropertyOrField(parameterExpression, EntityUtility.GetIdPropertyName(typeof(TEntity))),
                    Expression.Constant(id, typeof(Guid)))
                , parameterExpression
            );
        }
    }
}