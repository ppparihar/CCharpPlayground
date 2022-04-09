using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Playground.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a = 10;
            var b = 20;
            var result = a + b;
            Assert.AreEqual(30, result);
        }
    }
}
