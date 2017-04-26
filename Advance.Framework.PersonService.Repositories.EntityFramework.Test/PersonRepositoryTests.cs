using Advance.Framework.People.Repositories.EntityFramework;
using Advance.Framework.PersonService.Entities;
using AutoMapper;
using NUnit.Framework;
using System;

namespace Advance.Framework.PersonService.Repositories.EntityFramework.Test
{
    [TestFixture]
    public class PersonRepositoryTests
    {
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
            var person = new Person
            {
                FirstName = "Bobby",
                LastName = "Yasumura",
            };

            /// Act
            new PersonRepository().Add(person);
            /// Assert
        }

        [TestCase]
        public void Update()
        {
            /// Arrange
            var person = new Person
            {
                PersonId = GetPersonId(),
                FirstName = "Bobby2",
                LastName = "Yasumura2",
            };
            Mapper.Initialize(config =>
            {
                config.CreateMap<Person, Person>();
            });

            /// Act
            new PersonRepository().Update(person);

            /// Assert
        }

        private static Guid GetPersonId()
        {
            return new Guid("92b70123-d4fb-44b3-ad22-4d0443684250");
        }

        [TestCase]
        public void GetById()
        {
            /// Arrange
            var id = GetPersonId();

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
                PersonId = Guid.Empty,
            };

            /// Act
            new PersonRepository().Delete(person);

            /// Assert
        }
    }
}
