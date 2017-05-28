using Advance.Framework.Entities;
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
        private readonly IDictionary<Type, IList<Guid>> CopiedEntities = new Dictionary<Type, IList<Guid>>();

        public Repository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Add(TEntity entity)
        {
            SetCreatedAt(entity);

            Entities.Add(entity);
            UnitOfWork.SaveChanges();
        }

        private static void SetCreatedAt(object entity)
        {
            if (typeof(ITimestampableEntity).IsAssignableFrom(entity.GetType()))
            {
                var timestampableEntity = (ITimestampableEntity)entity;
                timestampableEntity.CreatedAt = DateTimeOffset.Now;
            }
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

            UpdateProperties(entity, currentEntity, DateTimeOffset.Now);

            UnitOfWork.SaveChanges();
        }

        private void UpdateProperties(object source, object destination, DateTimeOffset updatedAt)
        {
            var type = source.GetType();
            if (CopiedEntities.ContainsKey(type) == false)
            {
                CopiedEntities.Add(type, new List<Guid>());
            }

            var entityId = GetId(source);
            if (CopiedEntities[type].Contains(entityId))
            {
                return;
            }

            CopiedEntities[type].Add(entityId);

            foreach (var property in type.GetProperties().Where(i => i.CanRead && i.CanWrite && i.Name != GetIdPropertyName(type)))
            {
                var propertyType = property.PropertyType;
                if (typeof(ITimestampableEntity).IsAssignableFrom(destination.GetType())
                    && (property.Name == nameof(ITimestampableEntity.CreatedAt) || property.Name == nameof(ITimestampableEntity.UpdatedAt)))
                {
                    if (property.Name == nameof(ITimestampableEntity.UpdatedAt))
                    {
                        SetUpdatedAt(destination, updatedAt);
                    }
                }
                else if (IsCopyable(propertyType))
                {
                    property.SetValue(destination, property.GetValue(source));
                }
                else if (typeof(IEnumerable).IsAssignableFrom(propertyType))
                {
                    UnitOfWork.EagerLoadCollection(destination, property.Name);
                    var currentChildren = (IList)property.GetValue(destination);
                    var entityChildren = ((IEnumerable)property.GetValue(source)).Cast<object>();
                    foreach (var currentChild in currentChildren.Cast<object>().ToArray())
                    {
                        var entityChild = entityChildren.SingleOrDefault(i => GetId(i) == GetId(currentChild));
                        if (entityChild == null)
                        {
                            SetUpdatedAt(currentChild, updatedAt);
                            currentChildren.Remove(currentChild);
                        }
                        else
                        {
                            UpdateProperties(entityChild, currentChild, updatedAt);
                        }
                    }

                    foreach (var entityChild in entityChildren.Where(i => currentChildren.Cast<object>().Any(j => GetId(j) == GetId(i)) == false))
                    {
                        SetCreatedAt(entityChild);
                        currentChildren.Add(entityChild);
                    }
                }
                else
                {
                    UnitOfWork.EagerLoadReference(destination, property.Name);
                    var currentChild = property.GetValue(destination);
                    var entityChild = property.GetValue(source);
                    UpdateProperties(entityChild, currentChild, updatedAt);
                }
            }

            return;
        }

        private static void SetUpdatedAt(object entity, DateTimeOffset updatedAt)
        {
            if (typeof(ITimestampableEntity).IsAssignableFrom(entity.GetType()))
            {
                var timestampableEntity = (ITimestampableEntity)entity;
                timestampableEntity.UpdatedAt = updatedAt;
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
