using Advance.Framework.Modules.Cms.Repositories;
using NUnit.Framework;

namespace Advance.Framework.Modules.Cms.UnitTests
{
    [TestFixture]
    public class WebPageRepositoryTests
    {
        [Test]
        public void TestMethod()
        {
            /// Arrange
            var webPageRepository = new WebPageRepository();

            /// Act
            var result = webPageRepository.ListAll();

            /// Assert
        }
    }
}
