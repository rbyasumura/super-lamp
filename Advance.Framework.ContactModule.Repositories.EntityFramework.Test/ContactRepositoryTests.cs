using Advance.Framework.ContactModule.Entities;
using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Repositories;
using NUnit.Framework;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Test
{
    [TestFixture]
    class ContactRepositoryTests
    {
        [TestCase]
        public void ListAll()
        {
            /// Arrange
            /// Act
            using (var unitOfWork = GetUnitOfWork())
            {
                var result = unitOfWork.GetRepository<IContactRepository>().ListAll();
            }

            /// Assert
        }

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

        private static IUnitOfWork GetUnitOfWork()
        {
            return Container.Instance.Resolve<IUnitOfWork>();
        }
    }
}
