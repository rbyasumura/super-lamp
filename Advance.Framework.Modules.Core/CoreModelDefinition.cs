using System.Linq;
using System.Collections.Generic;
using System;
using Advance.Framework.Interfaces.Contexts;
using Advance.Framework.Modules.Core.Entities;

namespace Advance.Framework.Modules.Core
{
    public class CoreModelDefinition : IModelDefinition
    {
        public void Build(IModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();
        }
    }
}
