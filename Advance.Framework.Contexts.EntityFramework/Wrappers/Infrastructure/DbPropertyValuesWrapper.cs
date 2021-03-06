﻿using Advance.Framework.Interfaces.Contexts.Infrastructure;
using System.Data.Entity.Infrastructure;

namespace Advance.Framework.Contexts.EntityFramework.Wrappers
{
    internal sealed class DbPropertyValuesWrapper : IPropertyValues
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
