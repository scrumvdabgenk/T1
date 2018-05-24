using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestTerraTeam1;
using TerraTeam1;
using System.Collections.Generic;

namespace UnitTestTerraTeam1
{
    [TestClass]
    public class UnitTestPlant
    {
        [TestMethod]
        public void TestMethodTestCreateAantalPlanten()
        {
            /* unit test 01 */
            List<Plant> laPlant = Plant.CreatePlanten(3);
            Assert.AreEqual(3, laPlant.Count);
        }

        [TestMethod]
        public void TestPropertyTestPlantenXYPos()
        {
            List<Plant> laPlant = Plant.CreatePlanten(1);
            laPlant[0].PosX = 10;
            laPlant[0].PosY = 20;
            Assert.AreEqual(laPlant[0].PosX, 10);
            Assert.AreEqual(laPlant[0].PosY, 20);
        }

        [TestMethod]
        public void TestPropertyTestPlantenLevenskracht()
        {
            List<Plant> laPlant = Plant.CreatePlanten(1);
            laPlant[0].Levenskracht = 12345;
            Assert.AreEqual(laPlant[0].Levenskracht, 12345);
        }

        [TestMethod]
        public void TestPropertyTestPlantenNaam()
        {
            List<Plant> laPlant = Plant.CreatePlanten(1);
            laPlant[0].Naam = "P";
            Assert.AreEqual(laPlant[0].Naam, "P");
        }

    }
}
