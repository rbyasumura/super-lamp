using Advance.Framework.ContactModule.Entities;
using NUnit.Framework;
using System;
using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Repositories;
using System.Linq;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Test
{
    [TestFixture]
    public class PersonRepositoryTests
    {
        private static readonly Guid DeletePersonId = new Guid("a57c8320-5432-4f4b-bb77-53d4a00fa0fd");
        private readonly Guid GetByIdPersonId = new Guid("017bde02-e0fa-485e-ab26-359e7730aad5");

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
                //PhoneNumbers = new PhoneNumber[]
                //{
                //    new PhoneNumber
                //    {
                //        Number = "11111",
                //        Type = PhoneNumberType.Home,
                //    },
                //},
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
            var person = default(Person);
            using (var unitOfWork = GetUnitOfWork())
            {
                var personRepository = GetPersonRepository(unitOfWork);
                person = personRepository
                    .ListAll(/*i => i.PhoneNumbers*/)
                    //.Where(i => i.PhoneNumbers.Count > 0)
                    .FirstOrDefault();

                //person.PhoneNumbers.Clear();
                personRepository.Update(person);
                unitOfWork.Commit();
            }

            //person.FirstName = $"Bobby{DateTime.Now.Ticks}";
            //person.LastName = $"Yasumura{DateTime.Now.Ticks}";
            //person.DateOfBirth = DateTime.Now.AddYears(-35).Date;
            //person.PhoneNumbers = new PhoneNumber[]
            //{
            //        new PhoneNumber
            //        {
            //            Number = "1111111",
            //            Type = PhoneNumberType.Home,
            //        },
            //        new PhoneNumber
            //        {
            //            Number = "2222",
            //            Type = PhoneNumberType.Mobile,
            //        },
            //};

            ///// Act
            //using (var unitOfWork = GetUnitOfWork())
            //{
            //    GetPersonRepository(unitOfWork).Update(person);
            //    unitOfWork.Commit();
            //}

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
            using (var unitOfWork = GetUnitOfWork())
            {
                var personRepository = GetPersonRepository(unitOfWork);
                personRepository.Add(new Person
                {
                });
                unitOfWork.Commit();

                var person = personRepository
                    .ListAll(/*i => i.PhoneNumbers*/)
                    //.Where(i => i.PhoneNumbers.Any() == false)
                    .OrderBy(i => i.CreatedAt)
                    .First();

                /// Act
                personRepository.Delete(person);

                unitOfWork.Commit();
            }

            /// Assert
        }
    }
}
