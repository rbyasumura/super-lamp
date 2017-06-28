using System;
using System.Linq;

namespace Advance.Framework.Interfaces.Mappers
{
    public interface IMappingDefinition
    {
        void Initialize(IMapperConfiguration config);
    }
}
