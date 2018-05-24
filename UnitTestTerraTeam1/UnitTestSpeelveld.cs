using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraTeam1;
using System.Collections.Generic;

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

        [TestMethod]
        public void TestSpeelveld2()
        {
            Random rnd = new Random();

            Speelveld speelveld = new Speelveld(6, 6);

            int rndspeelveld = speelveld.GrootteX * speelveld.GrootteY;
            int rndValuePlant = rnd.Next(1, rndspeelveld);

            List<Plant> planten = Plant.CreatePlanten(rndValuePlant);
            speelveld.AddPlantenToSpeelveld(planten);
            Assert.AreEqual(speelveld.CountAmounOfPlantsInSpeelveld(), rndValuePlant);

        }



    }
}
