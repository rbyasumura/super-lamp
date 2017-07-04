using Advance.Framework.Contexts.EntityFramework.Wrappers;
using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Contexts;
using Advance.Framework.Interfaces.Loggers;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Loggers.log4net;
using Advance.Framework.Modules.Cms.Interfaces.Repositories;
using Advance.Framework.Modules.Cms.Repositories;
using Advance.Framework.Repositories;
using Kendo.Contexts.EntityFramework;
using NUnit.Framework;

namespace Advance.Framework.Modules.Cms.UnitTests.Repositories
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
                .RegisterType<ILogger, Log4NetLogger>()
                .RegisterType<IContextWrapper, DbContextWrapper<Context>>()
                ;
        }
    }
}
