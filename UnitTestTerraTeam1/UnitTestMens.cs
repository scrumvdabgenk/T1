using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TerraTeam1;

namespace UnitTestTerraTeam1
{
    [TestClass]
    public class UnitTestMens
    {
        Dier dier = new Carnivoor();

        ////[TestMethod]
        ////public void TestMethodMensEet()
        ////{
        ////    Speelveld loSpeelveld = new Speelveld(3, 3);

        ////    List<Herbivoor> herbivoren = Herbivoor.CreateHerbivoren(9);
        ////    for (int x = 0; x < 3; x++)
        ////    {
        ////        for (int y = 0; y < 3; y++)
        ////        {
        ////            herbivoren[x + (y * 3)].PosX = x;
        ////            herbivoren[x + (y * 3)].PosY = y;
        ////        }
        ////    }
        ////    for (int x = 0; x < herbivoren.Count; x++)
        ////    {
        ////        if (x == 4)
        ////        {
        ////            herbivoren.Remove(herbivoren[4]);
        ////            break;
        ////        }
        ////    }

        ////    loSpeelveld.AddHerbivorenToSpeelveld(herbivoren, true);

        ////    // here, I overwrite the position [1, 1]
        ////    List<Carnivoor> carnivoren = Carnivoor.CreateCarnivoren(1);
        ////    carnivoren[0].PosX = 1;
        ////    carnivoren[0].PosY = 1;
        ////    loSpeelveld.AddCarnivorenToSpeelveld(carnivoren, true);

        ////    // do the eet()
        ////    carnivoren[0].Eet(loSpeelveld, dier);

        ////    // assume
        ////    for (int x = 0; x < 3; x++)
        ////    {
        ////        for (int y = 0; y < 3; y++)
        ////        {
        ////            if (x == 1 && y == 2)
        ////                Assert.AreEqual(loSpeelveld.Terrarium[x, y].GetType(), typeof(Carnivoor));
        ////            else
        ////            {
        ////                if (x == 1 && y == 1)
        ////                    Assert.AreEqual(loSpeelveld.Terrarium[x, y], null);
        ////                else
        ////                    Assert.AreEqual(loSpeelveld.Terrarium[x, y].GetType(), typeof(Herbivoor));
        ////            }
        ////        }
        ////    }
        ////}

        [TestMethod]
        public void TestMethodMensVecht()
        {
            Speelveld loSpeelveld = new Speelveld(3, 3);

            // . C .    --> this one will not fight
            // . M C    --> these 2 will fight, the left will win
            // . . .

            List<Carnivoor> carnivoren = Carnivoor.CreateCarnivoren(2);
            List<Mens> mensen = Mens.CreateMensen(1);

            mensen[0].PosX = 1;
            mensen[0].PosY = 1;
            mensen[0].Levenskracht = 10;
            carnivoren[0].PosX = 1;
            carnivoren[0].PosY = 2;
            carnivoren[0].Levenskracht = 5;
            carnivoren[1].PosX = 0;
            carnivoren[1].PosY = 1;

            loSpeelveld.AddMensenToSpeelveld(mensen, true);
            loSpeelveld.AddCarnivorenToSpeelveld(carnivoren, true);

            dier = carnivoren[0];

            mensen[0].Vecht(loSpeelveld, dier);

            // assume
            Assert.AreEqual(loSpeelveld.Terrarium[0, 1].GetType(), typeof(Carnivoor));
            Assert.AreEqual(loSpeelveld.Terrarium[1, 1], null);
            Assert.AreEqual(loSpeelveld.Terrarium[1, 2].GetType(), typeof(Mens));
        }

        [TestMethod]
        public void TestMethodMensVecht2()
        {
            Speelveld loSpeelveld = new Speelveld(3, 3);

            // . C .    --> this one will not fight
            // . M C    --> these 2 will fight, the right will win
            // . . .

            List<Carnivoor> carnivoren = Carnivoor.CreateCarnivoren(2);
            List<Mens> mensen = Mens.CreateMensen(1);

            mensen[0].PosX = 1;
            mensen[0].PosY = 1;
            mensen[0].Levenskracht = 5;
            carnivoren[0].PosX = 1;
            carnivoren[0].PosY = 2;
            carnivoren[0].Levenskracht = 10;
            carnivoren[1].PosX = 0;
            carnivoren[1].PosY = 1;

            loSpeelveld.AddMensenToSpeelveld(mensen, true);
            loSpeelveld.AddCarnivorenToSpeelveld(carnivoren, true);

            dier = carnivoren[0];

            mensen[0].Vecht(loSpeelveld, dier);

            // assume
            Assert.AreEqual(loSpeelveld.Terrarium[0, 1].GetType(), typeof(Carnivoor));
            Assert.AreEqual(loSpeelveld.Terrarium[1, 1], null);
            Assert.AreEqual(loSpeelveld.Terrarium[1, 2].GetType(), typeof(Carnivoor));
        }

        [TestMethod]
        public void TestMethodCarnivoorVecht2LevenskrachtGelijk()
        {
            Speelveld loSpeelveld = new Speelveld(3, 3);

            // . C .    --> this one will not fight
            // . M C    --> these 2 will fight, the right will win
            // . . .

            List<Carnivoor> carnivoren = Carnivoor.CreateCarnivoren(2);
            List<Mens> mensen = Mens.CreateMensen(1);

            mensen[0].PosX = 1;
            mensen[0].PosY = 1;
            mensen[0].Levenskracht = 10;
            carnivoren[0].PosX = 1;
            carnivoren[0].PosY = 2;
            carnivoren[0].Levenskracht = 10;
            carnivoren[1].PosX = 0;
            carnivoren[1].PosY = 1;

            loSpeelveld.AddMensenToSpeelveld(mensen, true);
            loSpeelveld.AddCarnivorenToSpeelveld(carnivoren, true);

            dier = carnivoren[0];

            mensen[0].Vecht(loSpeelveld, dier);

            // assume
            Assert.AreEqual(loSpeelveld.Terrarium[0, 1].GetType(), typeof(Carnivoor));
            Assert.AreEqual(loSpeelveld.Terrarium[1, 1], null);
            Assert.AreEqual(loSpeelveld.Terrarium[1, 2].GetType(), typeof(Mens));
        }
    }
}
