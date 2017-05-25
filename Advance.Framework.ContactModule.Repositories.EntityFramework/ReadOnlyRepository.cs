using Advance.Framework.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        private readonly UnitOfWork unitOfWork;
        private static readonly string IdPropertyName = GetIdPropertyName(typeof(TEntity));

        public ReadOnlyRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected internal static string GetIdPropertyName(Type type)
        {
            return $"{type.Name}Id";
        }

        protected internal DbSet<TEntity> Entities
        {
            get
            {
                return UnitOfWork.Set<TEntity>();
            }
        }

        protected internal UnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
        }

        public bool Exists(Guid id)
        {
            var expression = GetIdExpression(id);
            return Entities.Any(expression);
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

        public TEntity GetById(Guid id)
        {
            var expression = GetIdExpression(id);
            return Entities.SingleOrDefault(expression);
        }

        public IEnumerable<TEntity> ListAll()
        {
            return Entities.ToArray();
        }
    }
}
