using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Repositories;
using NUnit.Framework;

namespace Advance.Framework.ContactModule.Repositories.EntityFramework.Test
{
    [SetUpFixture]
    class SetUpFixture
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Container.Instance
                .RegisterType<IUnitOfWork, UnitOfWork>()
                .RegisterType<IPersonRepository, PersonRepository>()
                .RegisterType<IPhoneNumberRepository, PhoneNumberRepository>()
                ;
        }
    }
}
