using Advance.Framework.Entities;
using System;
using System.Collections;
using System.Reflection;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework
{
    internal class Property
    {
        private PropertyInfo propertyInfo;

        public Property(PropertyInfo propertyInfo)
        {
            this.propertyInfo = propertyInfo;
        }

        private bool IsCopyableProperty(Type type)
        {
            type = Nullable.GetUnderlyingType(type) ?? type;
            return type.IsPrimitive
                || type == typeof(string)
                || type == typeof(DateTime)
                || type.IsEnum
                || type == typeof(DateTimeOffset);
        }

        public PropertyType Type
        {
            get
            {
                var propertyType = propertyInfo.PropertyType;

                /// Explicitly update the UpdatedAt for ITimestampableEntity entities
                if (typeof(ITimestampableEntity).IsAssignableFrom(propertyInfo.DeclaringType)
                    && (propertyInfo.Name == nameof(ITimestampableEntity.CreatedAt) || propertyInfo.Name == nameof(ITimestampableEntity.UpdatedAt)))
                {
                    return PropertyType.Timestampable;
                }
                else if (IsCopyableProperty(propertyType))
                {
                    return PropertyType.Primitive;
                }
                else if (typeof(IEnumerable).IsAssignableFrom(propertyType))
                {
                    return PropertyType.Collection;
                }
                else
                {
                    return PropertyType.Reference;
                }
            }
        }
        public string Name
        {
            get
            {
                return propertyInfo.Name;
            }
        }

        internal void SetValue(object obj, object value)
        {
            propertyInfo.SetValue(obj, value);
        }

        internal object GetValue(object obj)
        {
            return propertyInfo.GetValue(obj);
        }
    }
}
