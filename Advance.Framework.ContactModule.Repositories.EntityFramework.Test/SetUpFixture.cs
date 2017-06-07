using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Repositories;
using Advance.Framework.Repositories.EntityFramework;
using NUnit.Framework;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Test
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