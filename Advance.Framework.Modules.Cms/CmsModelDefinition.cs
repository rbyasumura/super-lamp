using Advance.Framework.Interfaces.Contexts;
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
