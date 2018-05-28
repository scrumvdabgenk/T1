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
            Assert.AreEqual(speelveld.CountAmounOfEmptyFieldsInSpeelveld(), 36 - rndValuePlant);
            Assert.AreEqual(speelveld.CountAmounOfHerbivorenInSpeelveld(), 0);
            Assert.AreEqual(speelveld.CountAmounOfCarnivorenInSpeelveld(), 0);
        }

        [TestMethod]
        public void TestSpeelveldPlaceTooManyPlantsOnSpeelveld()
        {
            Speelveld speelveld = new Speelveld(2, 2);

            List<Plant> planten = Plant.CreatePlanten(5);
            int amAdded = speelveld.AddPlantenToSpeelveld(planten);
            Assert.AreEqual(speelveld.CountAmounOfPlantsInSpeelveld(), 4);
            Assert.AreEqual(amAdded, 4);
        }


        [TestMethod]
        public void TestSpeelveldSeriousTest1()
        {
            Speelveld speelveld = new Speelveld(3, 3);

            List<Plant> planten = Plant.CreatePlanten(2);
            planten[0].PosX = 1;
            planten[0].PosY = 2;
            planten[1].PosX = 2;
            planten[1].PosY = 1;
            speelveld.AddPlantenToSpeelveld(planten, true);

            List<Herbivoor> herbivoren = Herbivoor.CreateHerbivoren(2);
            herbivoren[0].PosX = 0;
            herbivoren[0].PosY = 1;
            herbivoren[1].PosX = 2;
            herbivoren[1].PosY = 0;
            speelveld.AddHerbivorenToSpeelveld(herbivoren, true);

            List<Carnivoor> carnivoren = Carnivoor.CreateCarnivoren(3);
            carnivoren[0].PosX = 0;
            carnivoren[0].PosY = 0;
            carnivoren[1].PosX = 1;
            carnivoren[1].PosY = 0;
            carnivoren[2].PosX = 1;
            carnivoren[2].PosY = 1;
            speelveld.AddCarnivorenToSpeelveld(carnivoren, true);

            speelveld.ToonSpeelveld();

            speelveld.DoActionsOf1Day(carnivoren, herbivoren, planten);

            speelveld.ToonSpeelveld(20);
        }
    }
}
