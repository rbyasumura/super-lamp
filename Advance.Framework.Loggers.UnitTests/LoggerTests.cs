using NUnit.Framework;

namespace Advance.Framework.Loggers.UnitTests
{
    [TestFixture]
    public class LoggerTests
    {
        [Test]
        public void Log()
        {
            /// Arrange

            /// Act
            Logger.Instance.Log("This is a test");

            /// Assert
        }
    }
}
