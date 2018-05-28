using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam1
{
    class Program
    {
        static int cnGrootteX = 6;
        static int cnGrootteY = 6;

        static void Main(string[] args)
        {
            string lcInput = "";
            while (lcInput != "0")
            {
                // do some Console stuff
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();
                Console.WriteLine("Terrateam");
                Console.WriteLine("=========");
                Console.WriteLine("1) start terrateam (press ESC to stop terrateam)");
                Console.WriteLine("2) setup");
                Console.WriteLine("3) do internal test 1");
                Console.WriteLine("4) do internal test 2");
                Console.WriteLine("5) do internal test 3");
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
                    case "3":
                        DoTest1();
                        break;
                    case "4":
                        DoTest2();
                        break;
                    case "5":
                        DoTest3();
                        break;
                }
            }
        }


        static void ChangeSetup()
        {
            string lcInput = "";
            int lnResult = 0;
            Console.WriteLine("Terrateam setup");
            Console.WriteLine("---------------");
            Console.WriteLine("Geef nieuwe terrateam Breedte ({0}) :", cnGrootteX);
            lcInput = Console.ReadLine();
            if (Int32.TryParse(lcInput, out lnResult))
            {
                cnGrootteX = lnResult;
            }
            Console.WriteLine("Geef nieuwe terrateam Hoogte ({0}) :", cnGrootteY);
            lcInput = Console.ReadLine();
            if (Int32.TryParse(lcInput, out lnResult))
            {
                cnGrootteY = lnResult;
            }
        }

        static void DoTerrateam()
        {
            // do some Console stuff
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.CursorVisible = false;
            Console.Clear();
            //Console.SetWindowSize(cnGrootteY+1, cnGrootteX+1);
            //Console.SetBufferSize(cnGrootteY+1, cnGrootteX+1);

            // create speelveld and additional data
            Random rnd = new Random();
            Speelveld speelveld = new Speelveld(cnGrootteY, cnGrootteX);

            int rndspeelveld = speelveld.GrootteX * speelveld.GrootteY;
            int rndValuePlant = 10;
            int rndValueherbivoor = 10;
            int rndValueCarnivoor = 10;

            ////int rndValuePlant = rnd.Next(1, rndspeelveld / 2);
            ////int rndValueherbivoor = rnd.Next(1, rndspeelveld / 2);
            ////int rndValueCarnivoor = rnd.Next(1, rndspeelveld / 4);

            List<Plant> planten = Plant.CreatePlanten(rndValuePlant);
            speelveld.AddPlantenToSpeelveld(planten);

            List<Herbivoor> herbivoren = Herbivoor.CreateHerbivoren(rnd.Next(1, rndValueherbivoor));
            speelveld.AddHerbivorenToSpeelveld(herbivoren);

            List<Carnivoor> carnivoren = Carnivoor.CreateCarnivoren(rnd.Next(1, rndValueCarnivoor));
            speelveld.AddCarnivorenToSpeelveld(carnivoren);

            speelveld.ToonSpeelveld(); ;
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                speelveld.DoActionsOf1Day(carnivoren, herbivoren, planten);

                speelveld.ToonSpeelveld();
                speelveld.ResetAllStappen(herbivoren, carnivoren);
            }
            Console.CursorVisible = true;
        }

        static void DoTest1()
        {
            Console.Clear();

            // test 1
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
            carnivoren[1].Levenskracht = 10;
            carnivoren[2].PosX = 1;
            carnivoren[2].PosY = 1;
            carnivoren[2].Levenskracht = 2;
            speelveld.AddCarnivorenToSpeelveld(carnivoren, true);

            speelveld.DoActionsOf1Day(carnivoren, herbivoren, planten, 10);

            Console.WriteLine("Press a key");
            Console.ReadLine();
        }

        static void DoTest2()
        {
            Console.Clear();

            // test 1
            Speelveld speelveld = new Speelveld(3, 3);

            List<Plant> planten = Plant.CreatePlanten(1);
            planten[0].PosX = 2;
            planten[0].PosY = 1;
            speelveld.AddPlantenToSpeelveld(planten, true);

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

            List<Carnivoor> carnivoren = Carnivoor.CreateCarnivoren(1);
            carnivoren[0].PosX = 0;
            carnivoren[0].PosY = 2;
            speelveld.AddCarnivorenToSpeelveld(carnivoren, true);

            speelveld.DoActionsOf1Day(carnivoren, herbivoren, planten, 10);

            Console.WriteLine("Press a key");
            Console.ReadLine();
        }

        static void DoTest3()
        {
            Console.Clear();

            // test 1
            Speelveld speelveld = new Speelveld(3, 3);

            List<Plant> planten = Plant.CreatePlanten(1);

            List<Herbivoor> herbivoren = Herbivoor.CreateHerbivoren(5);
            herbivoren[0].PosX = 0;
            herbivoren[0].PosY = 1;
            herbivoren[1].PosX = 0;
            herbivoren[1].PosY = 2;
            herbivoren[2].PosX = 1;
            herbivoren[2].PosY = 0;
            herbivoren[3].PosX = 1;
            herbivoren[3].PosY = 2;
            herbivoren[4].PosX = 2;
            herbivoren[4].PosY = 1;
            speelveld.AddHerbivorenToSpeelveld(herbivoren, true);

            List<Carnivoor> carnivoren = Carnivoor.CreateCarnivoren(4);
            carnivoren[0].PosX = 0;
            carnivoren[0].PosY = 0;
            carnivoren[1].PosX = 1;
            carnivoren[1].PosY = 1;
            carnivoren[2].PosX = 2;
            carnivoren[2].PosY = 2;
            carnivoren[3].PosX = 2;
            carnivoren[3].PosY = 0;
            speelveld.AddCarnivorenToSpeelveld(carnivoren, true);

            speelveld.DoActionsOf1Day(carnivoren, herbivoren, planten, 10);

            Console.WriteLine("Press a key");
            Console.ReadLine();
        }
    }
}
