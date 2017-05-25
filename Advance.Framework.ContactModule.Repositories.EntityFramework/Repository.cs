using Advance.Framework.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    public class Repository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        private static readonly string IdPropertyName = GetIdPropertyName(typeof(TEntity));

        private static string GetIdPropertyName(Type type)
        {
            return $"{type.Name}Id";
        }

        private UnitOfWork _UnitOfWork;

        public Repository(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public Repository()
        {
            throw new NotImplementedException();
        }

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

        private static Guid GetId(object entity)
        {
            Type type = entity.GetType();
            return (Guid)type
                .GetProperty(GetIdPropertyName(type))
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

            CopyValues(entity, currentEntity);

            UnitOfWork.SaveChanges();
        }

        private void CopyValues(object source, object destination)
        {
            Type type = source.GetType();
            foreach (var property in type.GetProperties().Where(i => i.CanRead && i.CanWrite && i.Name != GetIdPropertyName(type)))
            {
                var propertyType = property.PropertyType;
                if (IsCopyable(propertyType))
                {
                    property.SetValue(destination, property.GetValue(source));
                }
                else if (typeof(IEnumerable).IsAssignableFrom(propertyType))
                {
                    UnitOfWork.EagerLoadCollection(destination, property.Name);
                    var currentChildren = (IList)property.GetValue(destination);
                    var entityChildren = ((IEnumerable)property.GetValue(source)).Cast<object>();
                    foreach (var currentChild in currentChildren)
                    {
                        var entityChild = entityChildren.SingleOrDefault(i => GetId(i) == GetId(currentChild));
                        if (entityChild == null)
                        {
                            currentChildren.Remove(currentChild);
                        }
                        else
                        {
                            CopyValues(entityChild, currentChild);
                        }
                    }

                    foreach (var entityChild in entityChildren.Where(i => currentChildren.Cast<object>().Any(j => GetId(j) == GetId(i)) == false))
                    {
                        currentChildren.Add(entityChild);
                    }
                }
            }
        }

        private static bool IsCopyable(Type type)
        {
            type = Nullable.GetUnderlyingType(type) ?? type;
            return type.IsPrimitive
                || type == typeof(string)
                || type == typeof(DateTime)
                || type.IsEnum;
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
