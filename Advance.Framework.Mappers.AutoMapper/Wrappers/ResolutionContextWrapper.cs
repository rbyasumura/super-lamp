﻿using Advance.Framework.Mappers.Interfaces;
using System.Collections.Generic;
using AM = AutoMapper;

namespace Advance.Framework.Mappers.AutoMapper.Wrappers
{
    internal class ResolutionContextWrapper : IResolutionContext
    {
        private AM.ResolutionContext context;

        public ResolutionContextWrapper(AM.ResolutionContext context)
        {
            this.context = context;
        }

        public IDictionary<string, object> Items => context.Items;
    }
}
