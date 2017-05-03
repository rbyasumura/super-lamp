﻿using Advance.Framework.ContactModule.Repositories.EntityFramework;
using Advance.Framework.ContactModule.Entities;
using AutoMapper;
using NUnit.Framework;
using System;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Test
{
    [TestFixture]
    public class PersonRepositoryTests
    {
        private static readonly Guid PersonId = new Guid("5d6711e0-4be6-4758-a778-e5936bafbc15");

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
                FirstName = $"Bobby{DateTime.Now.Ticks}",
                LastName = $"Yasumura{DateTime.Now.Ticks}",
                DateOfBirth = new DateTime(1981, 12, 11),
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
                PersonId = PersonId,
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
            var id = PersonId;

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
                PersonId = PersonId,
            };

            /// Act
            new PersonRepository().Delete(person);

            /// Assert
        }
    }
}
