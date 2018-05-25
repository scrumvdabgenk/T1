using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam1
{
    public class Herbivoor : Dier
    {
        public Herbivoor()
        {
            this.Naam = "H";
        }


        public static List<Herbivoor> CreateHerbivoren(int aantal)
        {
            List<Herbivoor> laHerbivoor = new List<Herbivoor> { };
            while (aantal > 0)
            {
                laHerbivoor.Add(new Herbivoor());
                aantal--;
            }
            return laHerbivoor;
        }


        public override void Eet(Speelveld eoSpeelveld)
        {
            // test if the animal at the right position is a plant
            if (PosY + 1 < eoSpeelveld.GrootteY &&
                eoSpeelveld.Terrarium[PosX, PosY+1] != null &&
                eoSpeelveld.Terrarium[PosX, PosY+1].Naam.ToUpper() == "P")
            {
                // add the levenskracht of the herbivoor with the carnivoor
                this.Levenskracht++;
                // remove the plant
                eoSpeelveld.Terrarium[PosX, PosY+1].Delete();
                eoSpeelveld.Terrarium[PosX, PosY+1] = null;   // todo: move this to the delete() of the herbivoor
                Stap(0, 1, eoSpeelveld);
                this.TotAantStappen++;
            }
        }

        public Herbivoor PlantVoort(Speelveld eoSpeelveld, List<Herbivoor> eaHerbivoren)
        {
            Random rnd = new Random();
            int flip = rnd.Next(1, 10);

            // test if the animal at the right position is a herbivoor
            if (PosY + 1 < eoSpeelveld.GrootteY &&
                eoSpeelveld.Terrarium[PosX, PosY+1] != null &&
                eoSpeelveld.Terrarium[PosX, PosY+1].Naam.ToUpper() == "H")
            {
                if (flip == 1)
                {
                    List<Herbivoor> laHerbivoren = CreateHerbivoren(1);
                    // eaHerbivoren.Add(laHerbivoren[0]);
                    return laHerbivoren[0];
                }
            }
            return null;
        }
    }
}
