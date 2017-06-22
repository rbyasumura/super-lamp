using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Modules.Security.Entities;

namespace Advance.Framework.Modules.Security
{
    public class SecurityModelDefinition : IModelDefinition
    {
        public void Build(IModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Role>();
        }
    }
}
