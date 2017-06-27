using Advance.Framework.Interfaces.Repositories;
using Kendo.Entities;

namespace Kendo
{
    public class KendoModelDefinition : IModelDefinition
    {
        public void Build(IModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>();
            modelBuilder.Entity<Club>();
            modelBuilder.Entity<Rank>();
        }
    }
}
