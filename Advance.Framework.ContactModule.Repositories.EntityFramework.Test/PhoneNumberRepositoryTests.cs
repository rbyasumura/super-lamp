using Advance.Framework.ContactModule.Repositories.EntityFramework;
using Advance.Framework.ContactModule.Entities;
using AutoMapper;
using NUnit.Framework;
using System;
using Advance.Framework.DependencyInjection.Unity;
using System.Linq;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Test
{
    [TestFixture]
    public class PhoneNumberRepositoryTests
    {
        private static readonly Guid PhoneNumberId = new Guid("5d6711e0-4be6-4758-a778-e5936bafbc15");

        [TestCase]
        public void ListAll()
        {
            /// Arrange
            /// Act
            var result = new PersonRepository().ListAll();

            /// Asset
        }

        [TestCase]
        public void Add()
        {
            /// Arrange
            using (var unitOfWork = GetUnitOfWork())
            {
                var personRepository = GetPersonRepository();
                var person = personRepository.ListAll().FirstOrDefault();
                var phoneNumber = new PhoneNumber
                {
                    Number = "4164528685",
                    Type = PhoneNumberType.Home,
                    Person = person,
                };

                /// Act
                new PhoneNumberRepository().Add(phoneNumber);
                unitOfWork.Commit();
            }

            /// Assert
        }

        private static IPersonRepository GetPersonRepository()
        {
            return Container.Instance.Resolve<IPersonRepository>();
        }

        private static IUnitOfWork GetUnitOfWork()
        {
            return Container.Instance.Resolve<IUnitOfWork>();
        }

        [TestCase]
        public void Update()
        {
            /// Arrange
            var person = new Person
            {
                PersonId = PhoneNumberId,
                FirstName = $"Bobby{DateTime.Now.Ticks}",
                LastName = $"Yasumura{DateTime.Now.Ticks}",
            };
            Mapper.Initialize(config =>
            {
                config.CreateMap<Person, Person>();
            });

            /// Act
            new PersonRepository().Update(person);

            /// Assert
        }

        [TestCase]
        public void GetById()
        {
            /// Arrange
            var id = PhoneNumberId;

            /// Act
            var result = new PersonRepository().GetById(id);

            /// Assert
            Assert.NotNull(result);
        }

        [TestCase]
        public void Delete()
        {
            /// Arrange
            var person = new Person
            {
                PersonId = PhoneNumberId,
            };

            /// Act
            new PersonRepository().Delete(person);

            /// Assert
        }
    }
}
