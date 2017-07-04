using Advance.Framework.Interfaces.Contexts;
using Kendo.Modules.Tournaments.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Modules.Tournaments
{
    public class TournamentModelDefinition : IModelDefinition
    {
        public void Build(IModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tournament>();
            modelBuilder.Entity<Registrant>()
                .HasMany(i => i.Divisions).WithMany();
            modelBuilder.Entity<TournamentSeries>();
            modelBuilder.Entity<Division>();
            modelBuilder.Entity<Registration>();
        }
    }
}
