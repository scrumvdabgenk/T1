using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TerraTeam1;

namespace UnitTestTerraTeam1
{
    [TestClass]
    public class UnitTestHerbivoor
    {
        [TestMethod]
        public void TestMethodHerbivoorEet()
        {
            Speelveld loSpeelveld = new Speelveld(3, 3);

            // . P .    --> this one will not be eaten
            // . H P    --> the plant will be eaten
            // . . .

            List<Plant> planten = Plant.CreatePlanten(2);
            planten[0].PosX = 0;
            planten[0].PosY = 1;
            planten[1].PosX = 1;
            planten[1].PosY = 2;
            loSpeelveld.AddPlantenToSpeelveld(planten, true);

            List<Herbivoor> herbivoren = Herbivoor.CreateHerbivoren(1);
            herbivoren[0].PosX = 1;
            herbivoren[0].PosY = 1;
            herbivoren[0].Levenskracht = 10;
            loSpeelveld.AddHerbivorenToSpeelveld(herbivoren, true);

            herbivoren[0].Eet(loSpeelveld);

            // assume
            Assert.AreEqual(loSpeelveld.Terrarium[0, 1].GetType(), typeof(Plant));
            Assert.AreEqual(loSpeelveld.Terrarium[1, 2].GetType(), typeof(Herbivoor));
            Assert.AreEqual(loSpeelveld.Terrarium[1, 1], null);
        }
    }
}
