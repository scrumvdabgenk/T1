using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraTeam1;

namespace UnitTestTerraTeam1
{
    [TestClass]
    public class UnitTestSpeelveld
    {
        [TestMethod]
        public void TestSpeelveld()
        {
            Speelveld testVeld = new Speelveld(5,4);
            Assert.AreEqual(testVeld.GrootteX, 5);
            Assert.AreEqual(testVeld.GrootteY, 4);
        }
    }
}
