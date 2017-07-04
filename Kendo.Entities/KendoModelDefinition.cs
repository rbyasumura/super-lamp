using Advance.Framework.Interfaces.Contexts;
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
