using System.Linq;
using System.Collections.Generic;
using System;
using Advance.Framework.Interfaces.Mappers;

using System.Collections.Generic;

using AM = AutoMapper;

namespace Advance.Framework.Mappers.AutoMapper.Wrappers
{
    internal class MappingOperationOptionsWrapper : IMappingOperationOptions
    {
        private AM.IMappingOperationOptions opts;

        public MappingOperationOptionsWrapper(AM.IMappingOperationOptions opts)
        {
            this.opts = opts;
        }

        public IDictionary<string, object> Items => opts.Items;
    }
}
