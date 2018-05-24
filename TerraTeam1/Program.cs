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
            while (ingave != "s")
            {
                Random rnd = new Random();

                Speelveld speelveld = new Speelveld(6, 6);

                int rndspeelveld = speelveld.GrootteX * speelveld.GrootteY;
                int rndValuePlant = rnd.Next(1, rndspeelveld);

                List<Plant> planten = Plant.CreatePlanten(rndValuePlant);
                speelveld.AddPlantenToSpeelveld(planten);

                List<Carnivoor> carnivoren = Carnivoor.CreateCarnivoren(rnd.Next(1, rndspeelveld / 6));
                speelveld.AddCarnivorenToSpeelveld(carnivoren);

                List<Herbivoor> herbivoren = Herbivoor.CreateHerbivoren(rnd.Next(1, rndspeelveld / 6));
                speelveld.AddHerbivorenToSpeelveld(herbivoren);

                speelveld.ToonSpeelveld();
                ingave = Console.ReadLine();
            }

            Console.WriteLine("druk toets");
            Console.ReadLine();

        }      
    }
}
