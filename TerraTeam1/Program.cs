using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam1
{
    class Program
    {
        static void Main(string[] args)
        {
            string ingave = "";
            //while (ingave.ToLower() != "s")
            {
                Random rnd = new Random();

                Speelveld speelveld = new Speelveld(4, 4);

                int rndspeelveld = speelveld.GrootteX * speelveld.GrootteY;
                int rndValuePlant = rnd.Next(1, rndspeelveld / 2);
                int rndValueherbivoor = rnd.Next(1, rndspeelveld / 2);
                int rndValueCarnivoor = rnd.Next(1, rndspeelveld /5);

                List<Plant> planten = Plant.CreatePlanten(rndValuePlant);
                speelveld.AddPlantenToSpeelveld(planten);

                List<Herbivoor> herbivoren = Herbivoor.CreateHerbivoren(rnd.Next(1, rndValueherbivoor));
                speelveld.AddHerbivorenToSpeelveld(herbivoren);

                List<Carnivoor> carnivoren = Carnivoor.CreateCarnivoren(rnd.Next(1, rndValueCarnivoor));
                speelveld.AddCarnivorenToSpeelveld(carnivoren);

                speelveld.ToonSpeelveld();
                ingave = Console.ReadLine();

                foreach (Herbivoor Dier in herbivoren)
                {
                    Dier.Eet(speelveld);
                    speelveld.ToonSpeelveld();
                    ingave = Console.ReadLine();
                    
                }

               
            }

            //Console.WriteLine("druk toets");
            //Console.ReadLine();

        }
    }
}
