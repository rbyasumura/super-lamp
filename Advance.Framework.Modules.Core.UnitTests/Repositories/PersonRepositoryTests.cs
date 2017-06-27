using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Modules.Core.Entities;
using Advance.Framework.Modules.Core.Interfaces.Repositories;
using NUnit.Framework;

namespace Advance.Framework.Modules.Core.UnitTests.Repositories
{
    [TestFixture]
    internal class PersonRepositoryTests
    {
        [TestCase]
        public void Add()
        {
            /// Arrange
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var repository = unitOfWork.GetRepository<IPersonRepository>();
                var entity = new Person
                {
                };

                /// Act
                repository.Add(entity);
                unitOfWork.SaveChanges();
            }

            /// Assert
        }
    }
}
