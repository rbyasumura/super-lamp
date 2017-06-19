using Advance.Framework.DependencyInjection.Unity;
using Advance.Framework.Interfaces.Loggers;
using Advance.Framework.Loggers.log4net;
using NUnit.Framework;

namespace Advance.Framework.Loggers.UnitTests
{
    [SetUpFixture]
    internal class SetUpFixture
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Container.Instance.RegisterType<ILogger, Log4NetLogger>();
        }
    }
}
