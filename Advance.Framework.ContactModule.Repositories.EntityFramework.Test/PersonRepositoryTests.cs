using Advance.Framework.ContactModule.Entities;
using NUnit.Framework;
using System;
using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Repositories;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Test
{
    [TestFixture]
    public class PersonRepositoryTests
    {
        private static readonly Guid DeletePersonId = new Guid("a57c8320-5432-4f4b-bb77-53d4a00fa0fd");
        private readonly Guid GetByIdPersonId = new Guid("c838ecbb-907d-4478-ab05-982f08372900");

        [TestCase]
        public void ListAll()
        {
            /// Arrange
            /// Act
            using (var unitOfWork = GetUnitOfWork())
            {
                var result = GetPersonRepository(unitOfWork).ListAll();
            }

            /// Asset
        }

        private static IPersonRepository GetPersonRepository(IUnitOfWork unitOfWork)
        {
            return unitOfWork.GetRepository<IPersonRepository>();
        }

        private static IUnitOfWork GetUnitOfWork()
        {
            return Container.Instance.Resolve<IUnitOfWork>();
        }

        [TestCase]
        public void Add()
        {
            /// Arrange
            var person = new Person
            {
                FirstName = $"Bobby{DateTime.Now.Ticks}",
                LastName = $"Yasumura{DateTime.Now.Ticks}",
                DateOfBirth = new DateTime(1981, 12, 11),
            };

            /// Act
            using (var unitOfWork = GetUnitOfWork())
            {
                GetPersonRepository(unitOfWork).Add(person);

                unitOfWork.Commit();
            }

            /// Assert
        }

        [TestCase]
        public void Update()
        {
            /// Arrange
            var person = new Person
            {
                PersonId = GetByIdPersonId,
                FirstName = $"Bobby{DateTime.Now.Ticks}",
                LastName = $"Yasumura{DateTime.Now.Ticks}",
            };

            /// Act
            using (var unitOfWork = GetUnitOfWork())
            {
                GetPersonRepository(unitOfWork).Update(person);
                unitOfWork.Commit();
            }

            /// Assert
        }

        [TestCase]
        public void GetById()
        {
            /// Arrange
            var id = GetByIdPersonId;

            /// Act
            using (var unitOfWork = GetUnitOfWork())
            {
                var result = unitOfWork.GetRepository<IPersonRepository>().GetById(id);

                /// Assert
                Assert.NotNull(result);
            }
        }

        [TestCase]
        public void Delete()
        {
            /// Arrange
            var person = new Person
            {
                PersonId = DeletePersonId,
            };

            /// Act
            using (var unitOfWork = GetUnitOfWork())
            {
                var personRepository = GetPersonRepository(unitOfWork);
                if (personRepository.Exists(person.PersonId))
                {
                    personRepository.Delete(person);
                }
                unitOfWork.Commit();
            }

            /// Assert
        }
    }
}
