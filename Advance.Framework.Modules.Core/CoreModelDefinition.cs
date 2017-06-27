using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advance.Framework.Interfaces.Repositories;
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
