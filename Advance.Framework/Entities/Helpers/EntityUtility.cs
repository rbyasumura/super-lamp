using System;
using System.Reflection;

namespace Advance.Framework.Entities.Helpers
{
    public static class EntityUtility
    {
        public static string GetIdPropertyName(Type type)
        {
            return $"{type.Name}Id";
        }

        public static PropertyInfo GetIdProperty(Type type)
        {
            return type.GetProperty(GetIdPropertyName(type));
        }
    }
}
