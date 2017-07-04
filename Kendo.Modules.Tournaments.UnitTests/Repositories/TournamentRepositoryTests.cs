using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Modules.Contacts.Entities;
using Advance.Framework.Modules.Core.Entities;
using Advance.Framework.Modules.Core.Interfaces.Repositories;
using Kendo.Entities;
using Kendo.Entities.Enums;
using Kendo.Modules.Tournaments.Entities;
using Kendo.Modules.Tournaments.Interfaces.Repositories;
using NUnit.Framework;
using System;
using System.Linq;

namespace Kendo.Modules.Tournaments.UnitTests.Repositories
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
                    TournamentId = new Guid("3c469850-6cbf-48a8-a989-f1f5f13cbf8a"),
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
                repository.Add(entity);
                unitOfWork.SaveChanges();

                /// Assert
            }
        }

        [TestCase]
        public void Update_AddRegistrant()
        {
            /// Arrange
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var repository = unitOfWork.GetRepository<ITournamentRepository>();
                var entity = repository.ListAll(
                    i => i.Registrants
                    ).First();
                entity.Registrants.Add(new Registrant
                {
                    Contact = new Contact
                    {
                        Person = new Person
                        {
                            FirstName = "Ryo",
                            LastName = "Yasumura",
                            DateOfBirth = new DateTime(1981, 12, 11),
                        },
                    },
                    //Club = new Club
                    //{
                    //    Name = "Etobicoke Olympium Kendo / Iaido Club",
                    //},
                    Rank = new Rank
                    {
                        RankNumber = 5,
                        Type = RankType.Dan,
                        Discipline = Discipline.Kendo,
                    },
                });

                /// Act
                repository.Update(entity);
                unitOfWork.SaveChanges();

                /// Assert
            }
        }
    }
}
