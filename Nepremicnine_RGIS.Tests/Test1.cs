namespace Nepremicnine_RGIS.Tests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestVrni10()
        {
            int result = Controllers.TestniKontroler.vrni10();
            Assert.AreEqual(10, result);
        }
    }
}
