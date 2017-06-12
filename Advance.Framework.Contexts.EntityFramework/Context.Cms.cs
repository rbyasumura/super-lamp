using Advance.Framework.Modules.Cms.Entities;
using System.Data.Entity;

namespace Advance.Framework.Contexts.EntityFramework
{
    partial class Context
    {
        private void ConfigureCms(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebPage>()
                ;
        }
    }
}
