using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Repositories.Interfaces;
using Kendo.Modules.Tournaments.Entities;
using Kendo.Modules.Tournaments.Interfaces.Repositories;
using NUnit.Framework;
using System.Linq;

namespace Kendo.Modules.Tournaments.UnitTests.Repositories
{
    [TestFixture]
    internal class DivisionRepositoryTests
    {
        [TestCase]
        public void Add()
        {
            /// Arrange
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var tournamentRepository = unitOfWork.GetRepository<ITournamentRepository>();
                var tournament = tournamentRepository.ListAll().Single();

                var repository = unitOfWork.GetRepository<IDivisionRepository>();

                /// Act
                repository.Add(new Division
                {
                    Name = "Bogu",
                    Tournament = tournament,
                });
                repository.Add(new Division
                {
                    Name = "Non-Bogu",
                    Tournament = tournament,
                });

                unitOfWork.SaveChanges();

                /// Assert
            }
        }
    }
}
