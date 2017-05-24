using Advance.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    public class Repository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        private static readonly string IdPropertyName = $"{typeof(TEntity).Name}Id";
        private UnitOfWork _UnitOfWork;

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
            UnitOfWork.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var id = GetId(entity);
            var expression = GetIdExpression(id);
            var _entity = Entities.Single(expression);
            Entities.Remove(_entity);
            UnitOfWork.SaveChanges();
        }

        private static Guid GetId(TEntity entity)
        {
            return (Guid)entity
                .GetType()
                .GetProperty(IdPropertyName)
                .GetValue(entity);
        }

        private static Expression<Func<TEntity, bool>> GetIdExpression(Guid id)
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
            var expression = GetIdExpression(id);
            var currentEntity = Entities.Single(expression);
            //var mapper = Container.Instance.Resolve<IMapper>();
            //var output = mapper.Map(entity, currentEntity);

            foreach (var property in typeof(TEntity).GetProperties()
                .Where(i => i.CanRead && i.CanWrite
                    && i.Name != IdPropertyName))
            {
                property.SetValue(currentEntity, property.GetValue(entity));
            }

            UnitOfWork.SaveChanges();
        }

        public bool Exists(Guid id)
        {
            var expression = GetIdExpression(id);
            return Entities.Any(expression);
        }

        DbSet<TEntity> Entities
        {
            get
            {
                return UnitOfWork.Set<TEntity>();
            }
        }
    }
}
