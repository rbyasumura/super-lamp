using Advance.Framework.Contexts.EntityFramework.Wrappers;
using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Loggers;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Loggers.log4net;
using Advance.Framework.Modules.Contacts.Interfaces.Repositories;
using Advance.Framework.Modules.Contacts.Repositories;
using Advance.Framework.Repositories;
using Kendo.Contexts.EntityFramework;
using NUnit.Framework;

namespace Advance.Framework.Modules.Contacts.UnitTests.Repositories
{
    [SetUpFixture]
    internal class SetUpFixture
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Container.Instance
                .RegisterType<IUnitOfWork, UnitOfWork>()
                .RegisterType<IPersonRepository, PersonRepository>()
                .RegisterType<IPhoneNumberRepository, PhoneNumberRepository>()
                .RegisterType<IContactRepository, ContactRepository>()
                .RegisterType<ILogger, Log4NetLogger>()
                .RegisterType<IContextWrapper, DbContextWrapper<Context>>()
                ;
        }
    }
}
