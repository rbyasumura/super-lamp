using Advance.Framework.Contexts.EntityFramework.Repositories;
using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Modules.Cms.Interfaces;
using NUnit.Framework;

namespace Advance.Framework.Contexts.EntityFramework.UnitTests.Repositories
{
    [SetUpFixture]
    internal class SetUpFixture
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Container.Instance.RegisterType<IUnitOfWork, Context>()
                .RegisterType<IWebPageRepository, WebPageRepository>()
                ;
        }
    }
}
