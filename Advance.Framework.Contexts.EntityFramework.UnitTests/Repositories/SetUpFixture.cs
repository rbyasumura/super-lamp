using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Modules.Cms.Interfaces;
using Advance.Framework.Modules.Cms.Repositories;
using NUnit.Framework;

namespace Advance.Framework.Contexts.EntityFramework.UnitTests.Repositories
{
    [SetUpFixture]
    internal class SetUpFixture
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Container.Instance
                .RegisterType<IUnitOfWork, UnitOfWork>()
                .RegisterType<IWebPageRepository, WebPageRepository>()
                ;
        }
    }
}
