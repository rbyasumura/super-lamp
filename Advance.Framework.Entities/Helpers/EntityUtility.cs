using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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