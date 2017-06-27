using Advance.Framework.Contexts.EntityFramework.Wrappers;
using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Loggers;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Loggers.log4net;
using Advance.Framework.Modules.Core.Interfaces.Repositories;
using Advance.Framework.Modules.Core.Repositories;
using Advance.Framework.Repositories;
using Kendo.Contexts.EntityFramework;
using Kendo.Interfaces.Repositories;
using Kendo.Repositories;
using NUnit.Framework;

namespace Kendo.UnitTests.Repositories
{
    [SetUpFixture]
    internal class SetUpFixture
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Container.Instance
                .RegisterType<IUnitOfWork, UnitOfWork>()
                .RegisterType<IMemberRepository, MemberRepository>()
                .RegisterType<ILogger, Log4NetLogger>()
                .RegisterType<IContextWrapper, DbContextWrapper<Context>>()
                .RegisterType<ITournamentRepository, TournamentRepository>()
                .RegisterType<IStateRepository, StateRepository>()
                ;
        }
    }
}
