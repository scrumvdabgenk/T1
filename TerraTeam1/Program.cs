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

            Random rnd = new Random();

            Speelveld speelveld = new Speelveld(6, 6);

            int rndspeelveld = speelveld.GrootteX * speelveld.GrootteY;
            int rndValuePlant = rnd.Next(1, rndspeelveld / 2);
            int rndValueherbivoor = rnd.Next(1, rndspeelveld - 7);
            int rndValueCarnivoor = rnd.Next(1, rndspeelveld / 2);

            List<Plant> planten = Plant.CreatePlanten(rndValuePlant);
            speelveld.AddPlantenToSpeelveld(planten);

            List<Herbivoor> herbivoren = Herbivoor.CreateHerbivoren(rnd.Next(1, rndValueherbivoor));
            speelveld.AddHerbivorenToSpeelveld(herbivoren);

            List<Carnivoor> carnivoren = Carnivoor.CreateCarnivoren(rnd.Next(1, rndValueCarnivoor));
            speelveld.AddCarnivorenToSpeelveld(carnivoren);

            speelveld.ToonSpeelveld();;
            while (ingave.ToLower() != "s")
            {
                List<Herbivoor> nieuweherbivoren = new List<Herbivoor>();

                foreach (Herbivoor H in herbivoren)
                {
                    {
                        H.Eet(speelveld);
                    }
                    {
                        Herbivoor nieuweherbivoor = H.PlantVoort(speelveld, herbivoren);

                        if (nieuweherbivoor != null)
                        {
                            nieuweherbivoren.Add(nieuweherbivoor);
                        }
                    }
                    {
                        H.Beweeg(speelveld);
                    }
                }
                speelveld.AddHerbivorenToSpeelveld(nieuweherbivoren);

                if (nieuweherbivoren != null)
                {
                    foreach (Herbivoor Dier in nieuweherbivoren)
                    {
                        herbivoren.Add(Dier);
                    }
                }

                speelveld.ToonSpeelveld();
            }


            //Console.WriteLine("druk toets");
            //Console.ReadLine();

        }
    }
}
