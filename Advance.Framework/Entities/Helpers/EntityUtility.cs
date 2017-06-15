using System;

namespace Advance.Framework.Entities.Helpers
{
    internal static class EntityUtility
    {
        internal static string GetIdPropertyName(Type type)
        {
            return $"{type.Name}Id";
        }
    }
}
