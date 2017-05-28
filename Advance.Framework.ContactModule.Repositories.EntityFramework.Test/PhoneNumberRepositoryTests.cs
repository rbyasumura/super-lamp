using Advance.Framework.ContactModule.Entities;
using NUnit.Framework;
using System;
using Advance.Framework.DependencyInjection.Unity;
using System.Linq;
using Advance.Framework.Repositories;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Test
{
    [TestFixture]
    public class PhoneNumberRepositoryTests
    {
        private static readonly Guid DeletePhoneNumberId = new Guid("ac5766d3-8e66-4bbf-a80e-599009cb467f");
        private readonly Guid GetByIdPhoneNumberId = new Guid("00397a3e-6779-4e19-bc3e-083491b0e029");

        [TestCase]
        public void ListAll()
        {
            /// Arrange
            /// Act
            using (var unitOfWork = GetUnitOfWork())
            {
                var result = unitOfWork.GetRepository<IPersonRepository>().ListAll();
            }

            /// Asset
        }

        [TestCase]
        public void Add()
        {
            /// Arrange
            using (var unitOfWork = GetUnitOfWork())
            {
                var personRepository = GetPersonRepository(unitOfWork);
                var person = personRepository.ListAll().FirstOrDefault();
                var phoneNumber = new PhoneNumber
                {
                    Number = "4164528685",
                    Type = PhoneNumberType.Home,
                    Person = person,
                };

                /// Act
                GetPhoneNumberRepository(unitOfWork).Add(phoneNumber);
                unitOfWork.Commit();
            }

            /// Assert
        }

        private static IPhoneNumberRepository GetPhoneNumberRepository(IUnitOfWork unitOfWork)
        {
            return unitOfWork.GetRepository<IPhoneNumberRepository>();
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
        public void Update()
        {
            /// Arrange
            using (var unitOfWork = GetUnitOfWork())
            {
                var phoneNumberRepository = GetPhoneNumberRepository(unitOfWork);
                var phoneNumber = phoneNumberRepository.ListAll().First();

                /// Act
                phoneNumberRepository.Update(phoneNumber);
                unitOfWork.Commit();
            }

            /// Assert
        }

        [TestCase]
        public void GetById()
        {
            /// Arrange
            var id = GetByIdPhoneNumberId;

            /// Act
            using (var unitOfWork = GetUnitOfWork())
            {
                var result = GetPhoneNumberRepository(unitOfWork).GetById(id);

                /// Assert
                Assert.NotNull(result);
            }
        }

        [TestCase]
        public void Delete()
        {
            /// Arrange
            var phoneNumber = new PhoneNumber
            {
                PhoneNumberId = DeletePhoneNumberId,
            };

            /// Act
            using (var unitOfWork = GetUnitOfWork())
            {
                var phoneNumberRepository = GetPhoneNumberRepository(unitOfWork);
                if (phoneNumberRepository.Exists(phoneNumber.PhoneNumberId))
                {
                    phoneNumberRepository.Delete(phoneNumber);
                }
                unitOfWork.Commit();
            }

            /// Assert
        }
    }
}
