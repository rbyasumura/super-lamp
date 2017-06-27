using System;
using System.Collections.Generic;
using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using Kendo.Entities;
using Kendo.Entities.Enums;
using Kendo.Interfaces.Repositories;
using NUnit.Framework;

namespace Kendo.UnitTests.Repositories
{
    [TestFixture]
    internal class MemberRepositoryTests
    {
        [TestCase]
        public void Add()
        {
            /// Arrange
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var repository = unitOfWork.GetRepository<IMemberRepository>();
                var entity = new Member
                {
                    FirstName = "Ryo",
                    LastName = "Yasumura",
                    Clubs = new List<Club>(
                        new Club[]{
                            new Club
                            {
                                Name ="Etobicoke Olympium Kendo / Iaido Club",
                            },
                        }),
                    Ranks = new Rank[]{
                        new Rank
                        {
                            RankNumber = 5,
                            Type = RankType.Dan,
                            Discipline = Discipline.Kendo,
                            ObtainedAt = new DateTime(2014, 11, 1),
                        },
                    }
                };

                /// Act
                repository.Add(entity);
                unitOfWork.SaveChanges();

                /// Assert
            }
        }
    }
}
