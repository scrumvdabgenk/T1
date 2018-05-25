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
            // do some Console stuff
            Console.SetCursorPosition(0, 0);
            //Console.BackgroundColor = ConsoleColor.White;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            string lcInput = "";
            while (lcInput != "0")
            {
                Console.Clear();
                Console.WriteLine("Terrateam");
                Console.WriteLine("=========");
                Console.WriteLine("1) start terrateam (press ESC to stop terrateam)");
                Console.WriteLine("2) setup");
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
            // create speelveld and additional data
            Random rnd = new Random();

            Speelveld speelveld = new Speelveld(cnGrootteX, cnGrootteY);

            int rndspeelveld = speelveld.GrootteX * speelveld.GrootteY;
            int rndValuePlant = 10;
            int rndValueherbivoor = 15;
            int rndValueCarnivoor = 15;

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
                List<Herbivoor> nieuweherbivoren = new List<Herbivoor>();

                /////////////////////////////////////////////////
                // carnivoren business
                /////////////////////////////////////////////////
                foreach (Carnivoor C in carnivoren)
                {
                    C.Eet(speelveld);
                    C.Vecht(speelveld);
                    C.Beweeg(speelveld);
                    speelveld.ToonSpeelveld();
                }

                /////////////////////////////////////////////////
                // herbivoren business
                /////////////////////////////////////////////////
                foreach (Herbivoor H in herbivoren)
                {
                    {
                        H.Eet(speelveld);
                    }

                    {
                        H.Beweeg(speelveld);
                    }

                    {
                        Herbivoor nieuweherbivoor = H.PlantVoort(speelveld, herbivoren);

                        if (nieuweherbivoor != null)
                        {
                            nieuweherbivoren.Add(nieuweherbivoor);
                        }
                    }
                    speelveld.ToonSpeelveld();
                }
                speelveld.AddHerbivorenToSpeelveld(nieuweherbivoren);

                if (nieuweherbivoren != null)
                {
                    foreach (Herbivoor Dier in nieuweherbivoren)
                    {
                        herbivoren.Add(Dier);
                    }
                }

                /////////////////////////////////////////////////
                // planten business
                /////////////////////////////////////////////////
                List<Plant> nieuweplanten = Plant.CreatePlanten(rndspeelveld / 12);
                speelveld.AddPlantenToSpeelveld(nieuweplanten);
                foreach (var plant in nieuweplanten)
                {
                    planten.Add(plant);
                }

                speelveld.ToonSpeelveld();
            }
        }
    }
}
