using Advance.Framework.Interfaces.Repositories;
using System.Data.Entity.Infrastructure;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers
{
    internal class DbPropertyValuesWrapper : IPropertyValues
    {
        private DbPropertyValues propertyValues;

        public DbPropertyValuesWrapper(DbPropertyValues propertyValues)
        {
            this.propertyValues = propertyValues;
        }

        public object this[string propertyName] { get => propertyValues[propertyName]; set => propertyValues[propertyName] = value; }

        public object ToObject()
        {
            return propertyValues.ToObject();
        }
    }
}
