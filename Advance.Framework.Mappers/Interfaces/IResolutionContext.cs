using System;
using System.Collections.Generic;
using System.Linq;

namespace Advance.Framework.Mappers.Interfaces
{
    public interface IResolutionContext
    {
        IDictionary<string, object> Items { get; }
    }
}
