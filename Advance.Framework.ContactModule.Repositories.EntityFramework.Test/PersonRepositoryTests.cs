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
                DateOfBirth = DateTime.Now.AddYears(-35).Date,
                PhoneNumbers = new PhoneNumber[]
                {
                    new PhoneNumber
                    {
                        Number = "1111111",
                        Type = PhoneNumberType.Home,
                    },
                    new PhoneNumber
                    {
                        Number = "2222",
                        Type = PhoneNumberType.Mobile,
                    },
                },
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
        public void AddUpdateDeletePhoneNumber()
        {
            var person = new Person
            {
                FirstName = "NoPhoneNumber",
                LastName = "Blah",
            };
            var personId = person.PersonId;

            using (var unitOfWork = GetUnitOfWork())
            {
                var personRepository = GetPersonRepository(unitOfWork);
                personRepository.Add(person);

                unitOfWork.Commit();
            }

            var updatePerson = new Person
            {
                PersonId = personId,
                FirstName = "AddPhoneNumber",
                LastName = "Foo",
            };
            const string phoneNumber1 = "1111111";
            PhoneNumber phoneNumber = new PhoneNumber
            {
                Number = phoneNumber1,
                Type = PhoneNumberType.Home,
            };
            var phoneNumberId = phoneNumber.PhoneNumberId;
            updatePerson.PhoneNumbers.Add(phoneNumber);

            using (var unitOfWork = GetUnitOfWork())
            {
                var personRepository = GetPersonRepository(unitOfWork);
                personRepository.Update(updatePerson);

                unitOfWork.Commit();
            }

            updatePerson = new Person
            {
                PersonId = personId,
                FirstName = "AddAnotherNumber",
                LastName = "",
                PhoneNumbers = new PhoneNumber[]
                {
                    new PhoneNumber{
                        PhoneNumberId=phoneNumberId,
                        Number=phoneNumber1,
                        Type = PhoneNumberType.Home,
                    },
                    new PhoneNumber
                    {
                        Number = "2222",
                        Type = PhoneNumberType.Mobile,
                    }
                },
            };

            using (var unitOfWork = GetUnitOfWork())
            {
                var personRepository = GetPersonRepository(unitOfWork);
                personRepository.Update(updatePerson);

                //unitOfWork.Commit();
            }
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
