using System;

namespace Advance.Framework.Entities.Helpers
{
    public static class EntityUtility
    {
        public static string GetIdPropertyName(Type type)
        {
            return $"{type.Name}Id";
        }
    }
}
