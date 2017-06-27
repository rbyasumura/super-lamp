using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Modules.Core.Interfaces.Repositories;
using NUnit.Framework;

namespace Advance.Framework.Modules.Core.UnitTests.Repositories
{
    [TestFixture]
    internal class StateRepositoryTests
    {
        [TestCase]
        public void GetById()
        {
            /// Arrange
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var repository = unitOfWork.GetRepository<IStateRepository>();

                /// Act
                var result = repository.GetById("CA-ON");
            }

            /// Assert
        }
    }
}
