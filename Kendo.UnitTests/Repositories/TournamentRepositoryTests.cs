using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Modules.Core.Entities;
using Advance.Framework.Modules.Core.Interfaces.Repositories;
using Kendo.Entities;
using Kendo.Interfaces.Repositories;
using NUnit.Framework;
using System;

namespace Kendo.UnitTests.Repositories
{
    [TestFixture]
    internal class TournamentRepositoryTests
    {
        [TestCase]
        public void Add()
        {
            /// Arrange
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var repository = unitOfWork.GetRepository<ITournamentRepository>();
                var stateRepository = unitOfWork.GetRepository<IStateRepository>();
                var state = stateRepository.GetById("CA-ON",
                    i => i.Country);

                var entity = new Tournament
                {
                    Name = "19th Canadian National Kendo Championships",
                    StartAt = new DateTimeOffset(new DateTime(2017, 8, 5), new TimeSpan(-4, 0, 0)),
                    EndAt = new DateTimeOffset(new DateTime(2017, 8, 6), new TimeSpan(-4, 0, 0)),
                    Location = new Address
                    {
                        AddressLine1 = "Markham Pan Am Centre",
                        AddressLine2 = "16 Main Street Unionville",
                        City = "Markham",
                        State = state,
                        Country = state.Country,
                        Zip = "L3R 2E4",
                    },
                };

                /// Act
                repository.Add(entity); unitOfWork.SaveChanges();

                /// Assert
            }
        }
    }
}
