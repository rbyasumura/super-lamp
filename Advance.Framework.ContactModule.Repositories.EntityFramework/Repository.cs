using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    public class Repository<TEntity>
        where TEntity : class
    {
        private static readonly string IdPropertyName = $"{typeof(TEntity).Name}Id";
        private UnitOfWork _UnitOfWork;

        public void Add(TEntity entity)
        {
            UnitOfWork.Set<TEntity>().Add(entity);
            UnitOfWork.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var id = GetId(entity);
            var expression = GetExpression(id);
            var _entity = UnitOfWork.Set<TEntity>().Single(expression);
            UnitOfWork.Set<TEntity>().Remove(_entity);
            UnitOfWork.SaveChanges();
        }

        private static Guid GetId(TEntity entity)
        {
            return (Guid)entity
                .GetType()
                .GetProperty(IdPropertyName)
                .GetValue(entity);
        }

        private static Expression<Func<TEntity, bool>> GetExpression(Guid id)
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
            var expression = GetExpression(id);
            return UnitOfWork.Set<TEntity>().SingleOrDefault(expression);
        }

        public IEnumerable<TEntity> ListAll()
        {
            return UnitOfWork.Set<TEntity>().ToArray();
        }

        private UnitOfWork UnitOfWork
        {
            get
            {
                if (_UnitOfWork == null)
                {
                    _UnitOfWork = UnitOfWork.DefaultInstance;
                }

                return _UnitOfWork;
            }
        }

        public void Update(TEntity entity)
        {
            var id = GetId(entity);
            var expression = GetExpression(id);
            var currentEntity = UnitOfWork.Set<TEntity>().Single(expression);
            Mapper.Map(entity, currentEntity);

            UnitOfWork.SaveChanges();
        }
    }
}
