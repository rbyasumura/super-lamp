using System;
using System.Collections.Generic;
using System.Linq;

namespace Advance.Framework.Interfaces.Mappers
{
    public interface IMappingOperationOptions
    {
        IDictionary<string, object> Items { get; }
    }
}
