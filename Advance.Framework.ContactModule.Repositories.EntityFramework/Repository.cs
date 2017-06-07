using Advance.Framework.Entities;
using Advance.Framework.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    public class Repository<TEntity> : ReadOnlyRepository<TEntity>
        , IRepository<TEntity>
        where TEntity : class
    {
        private readonly IDictionary<Type, IList<Guid>> UpdatedEntities = new Dictionary<Type, IList<Guid>>();

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

            if (typeof(ISoftDeletableEntity).IsAssignableFrom(entity.GetType()))
            {
                var softDeletableEntity = (ISoftDeletableEntity)_entity;
                softDeletableEntity.DeletedAt = DateTimeOffset.Now;
                Update((TEntity)softDeletableEntity);
            }
            else
            {
                Entities.Remove(_entity);
            }

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
            if (UpdatedEntities.ContainsKey(type) == false)
            {
                UpdatedEntities.Add(type, new List<Guid>());
            }

            var entityId = GetId(source);
            if (UpdatedEntities[type].Contains(entityId))
            {
                return;
            }

            UpdatedEntities[type].Add(entityId);

            foreach (var property in GetEditableProperties(type))
            {
                switch (property.Type)
                {
                    case PropertyType.Primitive:
                        property.SetValue(destination, property.GetValue(source));
                        break;

                    case PropertyType.Timestampable:
                        if (property.Name == nameof(ITimestampableEntity.UpdatedAt))
                        {
                            SetUpdatedAt(destination, updatedAt);
                        }
                        break;

                    case PropertyType.Reference:
                        UnitOfWork.EagerLoadReference(destination, property.Name);
                        var currentChild = property.GetValue(destination);
                        var entityChild = property.GetValue(source);
                        UpdateProperties(entityChild, currentChild, updatedAt);
                        break;

                    case PropertyType.Collection:
                        UpdateCollection(source, destination, updatedAt, property);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }

            return;
        }

        private void UpdateCollection(object source, object destination, DateTimeOffset updatedAt, Property property)
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
                currentChildren.Add(entityChild);
            }
        }

        private static IEnumerable<Property> GetEditableProperties(Type type)
        {
            foreach (var property in type.GetProperties().Where(i => i.CanRead && i.CanWrite && i.Name != GetIdPropertyName(type)))
            {
                yield return new Property(property);
            }
        }

        private static void SetUpdatedAt(object entity, DateTimeOffset updatedAt)
        {
            if (typeof(ITimestampableEntity).IsAssignableFrom(entity.GetType()))
            {
                var timestampableEntity = (ITimestampableEntity)entity;
                timestampableEntity.UpdatedAt = updatedAt;
            }
        }
    }
}
