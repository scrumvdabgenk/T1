using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraTeam1;

namespace TerraTeam1
{
    class Program
    {
        static int cnGrootteX = 20;
        static int cnGrootteY = 30;
        static int cnDisplayModel = 0;

        static void Main(string[] args)
        {
            Console.Clear();
            LijnTrekker nieuweLijn = new LijnTrekker();
            string titel = "Terrarium";
            Console.SetWindowSize(150,80);
            Console.SetBufferSize(150, 80);
            string lcInput = "";
            while (lcInput != "0")
            {
                // do some Console stuff
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(titel);
                Console.ForegroundColor = ConsoleColor.White;
                nieuweLijn.TrekLijn(0, titel.Length, '=');
                //Console.WriteLine("=========");
                Console.WriteLine("Ontdek de wereld");
                Console.WriteLine("\n");
                Console.WriteLine("1) start terrarium");
                Console.WriteLine("2) setup");
                //Console.WriteLine("3) do internal test 1");
                //Console.WriteLine("4) do internal test 2");
                //Console.WriteLine("5) do internal test 3");
                Console.WriteLine("0) stop");

                lcInput = Console.ReadLine();

                switch (lcInput)
                {
                    case "1":
                        DoTerrateam();
                        break;
                    case "2":
                        ChangeSetup();
                        break;
                    //case "3":
                    //    DoTest1();
                    //    break;
                    //case "4":
                    //    DoTest2();
                    //    break;
                    //case "5":
                    //    DoTest3();
                    //    break;
                }
            }
        }


        static void ChangeSetup()
        {
            Console.Clear();
            LijnTrekker nieuweLijn = new LijnTrekker();
            string lcInput = "";
            int lnResult = 0;
            string titel = "Terrarium Setup";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(titel);
            Console.ForegroundColor = ConsoleColor.White;
            nieuweLijn.TrekLijn(0, titel.Length, '-');
            //Console.WriteLine("---------------");
            Console.WriteLine("Geef nieuwe terrarium Breedte ({0}) :", cnGrootteX);
            lcInput = Console.ReadLine();
            if (Int32.TryParse(lcInput, out lnResult))
            {
                cnGrootteX = lnResult;
            }
            Console.WriteLine("Geef nieuwe terrarium Hoogte ({0}) :", cnGrootteY);
            lcInput = Console.ReadLine();
            if (Int32.TryParse(lcInput, out lnResult))
            {
                cnGrootteY = lnResult;
            }
            Console.WriteLine("Geef nieuwe weergave stijl 0(Letters)/1(Blokjes) ({0}) :", cnDisplayModel);

            lcInput = Console.ReadLine();
            if (Int32.TryParse(lcInput, out lnResult))
            {
                cnDisplayModel = lnResult;
            }
        }

        static void DoTerrateam()
        {
            // do some Console stuff
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Clear();
//          Console.SetWindowSize(cnGrootteY+1, cnGrootteX+1);
            //Console.SetBufferSize(cnGrootteY+1, cnGrootteX+1);

            // create speelveld and additional data
            Random rnd = new Random();
            Speelveld speelveld = new Speelveld(cnGrootteY, cnGrootteX, cnDisplayModel);

            int rndspeelveld = speelveld.GrootteX * speelveld.GrootteY;
            int rndspeelveld1 = speelveld.GrootteX + speelveld.GrootteY;
            int rndValuePlant = (cnGrootteX + cnGrootteY)/2;
            int rndValueherbivoor = (cnGrootteX + cnGrootteY)/2;
            int rndValueCarnivoor = cnGrootteX+cnGrootteY;
            int rndValueMens = cnGrootteX + cnGrootteY;

            ////////int rndValuePlant = rnd.Next(1, ((rndspeelveld / rndspeelveld1) / 5)+1);
            ////////int rndValueherbivoor = rnd.Next(1, ((rndspeelveld / rndspeelveld1) / 4)+1);
            ////////int rndValueCarnivoor = rnd.Next(1, ((rndspeelveld / rndspeelveld1) / 4)+1);
            ////////int rndValueMens = rnd.Next(1, ((rndspeelveld / rndspeelveld1) / 4)+1);

            List<Plant> planten = Plant.CreatePlanten(rndValuePlant);
            speelveld.AddPlantenToSpeelveld(planten);

            List<Herbivoor> herbivoren = Herbivoor.CreateHerbivoren(rnd.Next(1, rndValueherbivoor));
            speelveld.AddHerbivorenToSpeelveld(herbivoren);

            List<Carnivoor> carnivoren = Carnivoor.CreateCarnivoren(rnd.Next(1, rndValueCarnivoor));
            speelveld.AddCarnivorenToSpeelveld(carnivoren);

            List<Mens>mensen = Mens.CreateMensen(rnd.Next(1, rndValueMens));
            speelveld.AddMensenToSpeelveld(mensen);

            speelveld.ToonSpeelveld(); ;
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                int lnReturn = speelveld.DoActionsOf1Day(mensen, carnivoren, herbivoren, planten);

                speelveld.ToonSpeelveld();

                speelveld.ResetAllStappen(herbivoren, carnivoren);
                speelveld.RemoveDeletedCarnivoren(ref carnivoren);
                speelveld.RemoveDeletedHerbivoren(ref herbivoren);
                speelveld.RemoveDeletedMensen(ref mensen);

                if (lnReturn == -1)
                    break;  // stop while loop
            }
            Console.CursorVisible = true;
        }

        static void DoTest1()
        {
            Console.Clear();

            // test 1
            Speelveld speelveld = new Speelveld(3, 3,0);

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

            List<Carnivoor> carnivoren = Carnivoor.CreateCarnivoren(2);
            carnivoren[0].PosX = 0;
            carnivoren[0].PosY = 0;
            carnivoren[1].Levenskracht = 10;
            carnivoren[1].PosX = 1;
            carnivoren[1].PosY = 1;
            carnivoren[1].Levenskracht = 10;
            //carnivoren[1].PosX = 1;
            //carnivoren[1].PosY = 0;
            //carnivoren[1].Levenskracht = 10;
            speelveld.AddCarnivorenToSpeelveld(carnivoren, true);

            // C H .
            // . C P
            // H P .

            List<Mens> mensen = Mens.CreateMensen(2);
            mensen[0].PosX = 1;
            mensen[0].PosY = 0;
            mensen[0].Levenskracht = 10;
            mensen[1].PosX = 1;
            mensen[1].PosY = 1;
            mensen[1].Levenskracht = 15;
            speelveld.AddMensenToSpeelveld(mensen, true);

            // C H .
            // M C P
            // H P M

            speelveld.DoActionsOf1Day(mensen, carnivoren, herbivoren, planten, 10);

            Console.WriteLine("Press a key");
            Console.ReadLine();
        }

        static void DoTest2()
        {
            Console.Clear();

            // test 1
            Speelveld speelveld = new Speelveld(3, 3,0);

            // . . .
            // . . .
            // . . .

            List<Plant> planten = Plant.CreatePlanten(1);
            planten[0].PosX = 2;
            planten[0].PosY = 1;
            speelveld.AddPlantenToSpeelveld(planten, true);

            // . . .
            // . . .
            // . P .

            List<Herbivoor> herbivoren = Herbivoor.CreateHerbivoren(5);
            herbivoren[0].PosX = 0;
            herbivoren[0].PosY = 0;
            herbivoren[1].PosX = 0;
            herbivoren[1].PosY = 1;
            herbivoren[2].PosX = 1;
            herbivoren[2].PosY = 0;
            herbivoren[3].PosX = 1;
            herbivoren[3].PosY = 1;
            herbivoren[4].PosX = 2;
            herbivoren[4].PosY = 0;
            speelveld.AddHerbivorenToSpeelveld(herbivoren, true);

            // H H .
            // H H .
            // H P .

            List<Carnivoor> carnivoren = Carnivoor.CreateCarnivoren(1);
            carnivoren[0].PosX = 0;
            carnivoren[0].PosY = 2;
            speelveld.AddCarnivorenToSpeelveld(carnivoren, true);

            // H H C
            // H H .
            // H P .

            List<Mens> mensen = Mens.CreateMensen(1);
            carnivoren[0].PosX = 2;
            carnivoren[0].PosY = 2;
            speelveld.AddMensenToSpeelveld(mensen, true);

            // H H C
            // H H .
            // H P M

            speelveld.DoActionsOf1Day(mensen, carnivoren, herbivoren, planten, 10);

            Console.WriteLine("Press a key");
            Console.ReadLine();
        }

        static void DoTest3()
        {
            Console.Clear();

            // test 1
            Speelveld speelveld = new Speelveld(3, 3,0);

            // . . .
            // . . .
            // . . .

            List<Plant> planten = Plant.CreatePlanten(1);
            planten[0].PosX = 2;
            planten[0].PosY = 1;
            speelveld.AddPlantenToSpeelveld(planten, true);

            // . . .
            // . . .
            // P H .

            List<Herbivoor> herbivoren = Herbivoor.CreateHerbivoren(4);
            herbivoren[0].PosX = 0;
            herbivoren[0].PosY = 1;
            //herbivoren[1].PosX = 0;
            //herbivoren[1].PosY = 2;
            herbivoren[1].PosX = 1;
            herbivoren[1].PosY = 0;
            herbivoren[2].PosX = 1;
            herbivoren[2].PosY = 2;
            herbivoren[3].PosX = 2;
            herbivoren[3].PosY = 1;
            speelveld.AddHerbivorenToSpeelveld(herbivoren, true);

            // . H .
            // H . H
            // P H .

            List<Carnivoor> carnivoren = Carnivoor.CreateCarnivoren(3);
            carnivoren[0].PosX = 0;
            carnivoren[0].PosY = 0;
            carnivoren[1].PosX = 1;
            carnivoren[1].PosY = 1;
            carnivoren[2].PosX = 2;
            carnivoren[2].PosY = 2;
            speelveld.AddCarnivorenToSpeelveld(carnivoren, true);

            // C H .
            // H C H
            // H P C

            List<Mens> mensen = Mens.CreateMensen(1);
            mensen[0].PosX = 0;
            mensen[0].PosY = 2;
            speelveld.AddMensenToSpeelveld(mensen, true);

            speelveld.DoActionsOf1Day(mensen, carnivoren, herbivoren, planten, 10);

            Console.WriteLine("Press a key");
            Console.ReadLine();
        }
    }
}
