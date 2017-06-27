﻿using System.Collections.Generic;
using System.Configuration;
using Advance.Framework.Contexts.EntityFramework;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Modules.Cms;
using Advance.Framework.Modules.Contacts;
using Advance.Framework.Modules.Security;

namespace Kendo.Contexts.EntityFramework
{
    public class Context : EntityFrameworkContextBase
    {
        public Context()
            : base(ConfigurationManager.ConnectionStrings["Default"].ConnectionString)
        {
        }

        protected override void RegisterModels(ICollection<IModelDefinition> modelDefinitions)
        {
            modelDefinitions.Add(new CmsModelDefinition());
            modelDefinitions.Add(new ContactModelDefinition());
            modelDefinitions.Add(new SecurityModelDefinition());
            modelDefinitions.Add(new KendoModelDefinition());
        }
    }
}
