using System;
using System.Collections.Generic;
using System.Linq;

namespace Advance.Framework.Interfaces.Mappers
{
    public interface IResolutionContext
    {
        IDictionary<string, object> Items { get; }
    }
}
