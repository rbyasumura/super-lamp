using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Modules.Cms.Entities;

namespace Advance.Framework.Modules.Cms
{
    public class CmsModelDefinition : IModelDefinition
    {
        public void Build(IModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebPage>();
        }
    }
}
