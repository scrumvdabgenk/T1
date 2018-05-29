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
            if (this.TotAantStappen <= 0)
            {
                // test if the animal at the right position is a plant
                if (PosY + 1 < eoSpeelveld.GrootteY &&
                    eoSpeelveld.Terrarium[PosX, PosY + 1] != null &&
                    eoSpeelveld.Terrarium[PosX, PosY + 1].GetType() == typeof(Plant))
                {
                    // add the levenskracht of the herbivoor with the carnivoor
                    this.Levenskracht++;
                    // remove the plant
                    eoSpeelveld.Terrarium[PosX, PosY + 1].Delete();
                    eoSpeelveld.Terrarium[PosX, PosY + 1] = null;   // todo: move this to the delete() of the herbivoor
                    Stap(0, 1, eoSpeelveld);
                    this.TotAantStappen++;
                }
            }
        }

        public Herbivoor PlantVoort(Speelveld eoSpeelveld, List<Herbivoor> eaHerbivoren)
        {
            if (this.TotAantStappen <= 0)
            {
                Random rnd = new Random();
                int flip = rnd.Next(1, 10);

                // test if the animal at the right position is a herbivoor
                if (PosY + 1 < eoSpeelveld.GrootteY &&
                    eoSpeelveld.Terrarium[PosX, PosY + 1] != null &&
                    eoSpeelveld.Terrarium[PosX, PosY + 1].GetType() == typeof(Herbivoor))
                {
                    if (flip == 1 || true)  // tricky!!!!
                    {
                        List<Herbivoor> laHerbivoren = CreateHerbivoren(1);
                        this.TotAantStappen++;
                        return laHerbivoren[0];
                    }
                }
            }
            return null;
        }
    }
}
