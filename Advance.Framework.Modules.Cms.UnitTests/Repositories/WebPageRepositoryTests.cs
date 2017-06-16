using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Modules.Cms.Entities;
using Advance.Framework.Modules.Cms.Interfaces.Repositories;
using NUnit.Framework;
using System.Linq;

namespace Advance.Framework.Modules.Cms.UnitTests.Repositories
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
                unitOfWork.SaveChanges();
            }

            /// Assert
        }

        [TestCase]
        public void Update()
        {
            /// Arrange
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var webPageRepository = unitOfWork.GetRepository<IWebPageRepository>();
                var entities = webPageRepository.ListAll();
                var first = entities.First();
                first.Title = "First";
                var second = entities.Skip(1).First();
                second.Title = "Second";
                var third = entities.Skip(2).First();
                third.Title = "Third";

                /// Act
                webPageRepository.Update(first);
                unitOfWork.SaveChanges();
            }

            /// Assert
        }

        [TestCase]
        public void Update_DontSaveChanges()
        {
            /// Arrange
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var webPageRepository = unitOfWork.GetRepository<IWebPageRepository>();
                var entities = webPageRepository.ListAll();
                var first = entities.First();
                first.Title = "First";
                var second = entities.Skip(1).First();
                second.Title = "Second";
                var third = entities.Skip(2).First();
                third.Title = "Third";

                /// Act
                webPageRepository.Update(first);
            }

            /// Assert
        }

        [TestCase]
        public void Delete()
        {
            /// Arrange
            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var webPageRepository = unitOfWork.GetRepository<IWebPageRepository>();
                var entities = webPageRepository.ListAll();
                var first = entities.First();

                /// Act
                webPageRepository.Delete(first);
                unitOfWork.SaveChanges();
            }

            /// Assert
        }
    }
}
