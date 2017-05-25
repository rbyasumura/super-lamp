using Advance.Framework.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    public class Repository<TEntity> : ReadOnlyRepository<TEntity>
        , IRepository<TEntity>
        where TEntity : class
    {
        public Repository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
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
    }
}
