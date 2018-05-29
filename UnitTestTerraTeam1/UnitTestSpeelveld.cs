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

            // . . .
            // . . .
            // . . .

            List<Plant> planten = Plant.CreatePlanten(2);
            planten[0].PosX = 1;
            planten[0].PosY = 2;
            planten[1].PosX = 2;
            planten[1].PosY = 1;
            speelveld.AddPlantenToSpeelveld(planten, true);

            // . . .
            // . . P
            // . P .

            List<Herbivoor> herbivoren = Herbivoor.CreateHerbivoren(2);
            herbivoren[0].PosX = 0;
            herbivoren[0].PosY = 1;
            herbivoren[1].PosX = 2;
            herbivoren[1].PosY = 0;
            speelveld.AddHerbivorenToSpeelveld(herbivoren, true);

            // . H .
            // . . P
            // H P .

            List<Carnivoor> carnivoren = Carnivoor.CreateCarnivoren(3);
            carnivoren[0].PosX = 0;
            carnivoren[0].PosY = 0;
            carnivoren[1].PosX = 1;
            carnivoren[1].PosY = 0;
            carnivoren[2].PosX = 1;
            carnivoren[2].PosY = 1;
            speelveld.AddCarnivorenToSpeelveld(carnivoren, true);

            // C H .
            // C C P
            // H P .

            List<Mens> mensen = Mens.CreateMensen(1);
            mensen[0].PosX = 2;
            mensen[0].PosY = 2;
            speelveld.AddMensenToSpeelveld(mensen, true);

            // C H .
            // C C P
            // H P M

            speelveld.ToonSpeelveld();

            speelveld.DoActionsOf1Day(mensen, carnivoren, herbivoren, planten);

            speelveld.ToonSpeelveld(20);
        }

        [TestMethod]
        public void TestMethodHerbivoorWisDeletedHerbivoren()
        {
            Speelveld speelveld = new Speelveld(3, 3);

            List<Herbivoor> herbivoren = Herbivoor.CreateHerbivoren(3);
            herbivoren[0].IsDeleted = false;
            herbivoren[0].Levenskracht = 10;
            herbivoren[1].IsDeleted = true;
            herbivoren[1].Levenskracht = 11;
            herbivoren[2].IsDeleted = false;
            herbivoren[2].Levenskracht = 12;

            int lnResult = speelveld.RemoveDeletedHerbivoren(ref herbivoren);

            // assume
            Assert.AreEqual(lnResult, 1);
            Assert.AreEqual(herbivoren[0].Levenskracht, 10);
            Assert.AreEqual(herbivoren[1].Levenskracht, 12);
        }

        [TestMethod]
        public void TestMethodHerbivoorWisDeletedCarnivoren()
        {
            Speelveld speelveld = new Speelveld(3, 3);

            List<Carnivoor> carnivoren = Carnivoor.CreateCarnivoren(3);
            carnivoren[0].IsDeleted = false;
            carnivoren[0].Levenskracht = 10;
            carnivoren[1].IsDeleted = true;
            carnivoren[1].Levenskracht = 11;
            carnivoren[2].IsDeleted = false;
            carnivoren[2].Levenskracht = 12;

            int lnResult = speelveld.RemoveDeletedCarnivoren(ref carnivoren);

            // assume
            Assert.AreEqual(lnResult, 1);
            Assert.AreEqual(carnivoren[0].Levenskracht, 10);
            Assert.AreEqual(carnivoren[1].Levenskracht, 12);
        }

    }
}
