using Advance.Framework.Contexts.EntityFramework;
using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Repositories;
using Advance.Framework.Modules.Contacts.Interfaces.Repositories;
using Advance.Framework.Modules.Contacts.Repositories;
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
                ;
        }
    }
}
