using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Modules.Cms.Entities;
using Advance.Framework.Modules.Cms.Interfaces;
using NUnit.Framework;

namespace Advance.Framework.Contexts.EntityFramework.UnitTests.Repositories
{
    [TestFixture]
    internal class WebPageRepositoryTests
    {
        [TestCase]
        public void ListAll()
        {
            /// Arrange
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var webPageRepository = unitOfWork.GetRepository<IWebPageRepository>();

                /// Act
                var result = webPageRepository.ListAll();
            }
        }

        [TestCase]
        public void Add()
        {
            /// Arrange
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var webPageRepository = unitOfWork.GetRepository<IWebPageRepository>();
                var entity = new WebPage
                {
                };

                /// Act
                webPageRepository.Add(entity);

                unitOfWork.Commit();
            }

            /// Assert
        }
    }
}
