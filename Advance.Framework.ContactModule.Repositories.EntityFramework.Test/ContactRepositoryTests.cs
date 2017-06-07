using Advance.Framework.ContactModule.Entities;
using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Repositories;
using NUnit.Framework;
using System;
using System.Linq;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Test
{
    [TestFixture]
    internal class ContactRepositoryTests
    {
        [TestCase]
        public void Add()
        {
            /// Arrange
            var entity = new Contact
            {
                Person = new Person
                {
                },
            };

            /// Act
            using (var unitOfWork = GetUnitOfWork())
            {
                unitOfWork.GetRepository<IContactRepository>().Add(entity);

                unitOfWork.Commit();
            }

            /// Assert
        }

        [TestCase]
        public void ListAll()
        {
            /// Arrange Act
            using (var unitOfWork = GetUnitOfWork())
            {
                var result = unitOfWork.GetRepository<IContactRepository>().ListAll();
            }

            /// Assert
        }

        [TestCase]
        public void Update()
        {
            /// Arrange Act
            using (var unitOfWork = GetUnitOfWork())
            {
                var contactRepository = unitOfWork.GetRepository<IContactRepository>();
                var contact = contactRepository.ListAll(i => i.Person).First();
                contact.Person.FirstName = string.Format("{0}", DateTime.Now);
                contactRepository.Update(contact);
            }

            /// Assert
        }

        private static IUnitOfWork GetUnitOfWork()
        {
            return Container.Instance.Resolve<IUnitOfWork>();
        }
    }
}