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
        private static readonly string IdPropertyName = GetIdPropertyName(typeof(TEntity));

        public ReadOnlyRepository(UnitOfWork unitOfWork)
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

        internal UnitOfWork UnitOfWork
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

        protected internal static Expression<Func<TEntity, bool>> GetIdExpression(Guid id)
        {
            var parameterExpression = Expression.Parameter(typeof(TEntity));
            return Expression.Lambda<Func<TEntity, bool>>(
                Expression.Equal(
                    Expression.PropertyOrField(parameterExpression, IdPropertyName),
                    Expression.Constant(id, typeof(Guid)))
                , parameterExpression
            );
        }

        protected internal static string GetIdPropertyName(Type type)
        {
            return $"{type.Name}Id";
        }
    }
}