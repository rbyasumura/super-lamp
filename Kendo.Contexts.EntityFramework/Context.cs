using Advance.Framework.Contexts.EntityFramework;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Modules.Cms;
using Advance.Framework.Modules.Contacts;
using Advance.Framework.Modules.Security;
using System.Collections.Generic;

namespace Kendo.Contexts.EntityFramework
{
    internal class Context : EntityFrameworkContextBase
    {
        protected override void RegisterModels(ICollection<IModelDefinition> modelDefinitions)
        {
            modelDefinitions.Add(new CmsModelDefinition());
            modelDefinitions.Add(new ContactModelDefinition());
            modelDefinitions.Add(new SecurityModelDefinition());
        }
    }
}
