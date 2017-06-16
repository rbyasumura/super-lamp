using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Modules.Contacts.Entities;
using Advance.Framework.Modules.Contacts.Interfaces.Repositories;
using NUnit.Framework;
using System.Linq;

namespace Advance.Framework.Modules.Contacts.UnitTests.Repositories
{
    [TestFixture]
    internal class ContactRepositoryTests
    {
        [TestCase]
        public void Add()
        {
            /// Arrange
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var repository = unitOfWork.GetRepository<IContactRepository>();
                var entity = new Contact
                {
                    Person = new Person
                    {
                    },
                };

                /// Act
                repository.Add(entity);
                unitOfWork.SaveChanges();
            }

            /// Assert
        }

        [TestCase]
        public void Update_AddPerson()
        {
            /// Arrange
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var person = new Person
                {
                };
                var repository = unitOfWork.GetRepository<IContactRepository>();
                var entity = repository.ListAll().First();
                entity.Person = person;

                /// Act
                repository.Update(entity);
                unitOfWork.SaveChanges();
            }

            /// Assert
        }

        [TestCase]
        public void Update_UpdatePerson()
        {
            /// Arrange
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var repository = unitOfWork.GetRepository<IContactRepository>();
                var entity = repository.ListAll(i => i.Person).First();
                entity.Person.FirstName = "Update";

                /// Act
                repository.Update(entity);
                unitOfWork.SaveChanges();
            }

            /// Assert
        }
    }
}
