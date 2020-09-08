using Microsoft.VisualStudio.TestTools.UnitTesting;
using OIB_Generator.Helpers;

namespace OibGenerator.UnitTests
{
    [TestClass]
    public class OibGeneratorTests
    {
        [TestMethod]
        public void Should_generate_valid_oib()
        {
            // Act
            string oib = OIB_Generator.OibGenerator.GenerateOib();

            // Assert
            Assert.IsTrue(OibValidator.IsValidOib(oib));
        }
    }
}
