using System;
using System.Collections.Generic;
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
            if (PosX + 1 <= eoSpeelveld.GrootteX &&
                eoSpeelveld.Terrarium[PosX + 1, PosY] != null &&
                eoSpeelveld.Terrarium[PosX + 1, PosY].Naam.ToUpper() == "P")
            {
                // add the levenskracht of the herbivoor with the carnivoor
                this.Levenskracht++;
                // remove the plant
                eoSpeelveld.Terrarium[PosX + 1, PosY].Delete();
                eoSpeelveld.Terrarium[PosX + 1, PosY] = null;   // todo: move this to the delete() of the herbivoor
                Stap(1, 0, eoSpeelveld);
                this.TotAantStappen++;
            }
        }

        public void PlantVoort(Speelveld eoSpeelveld, List<Herbivoor> eaHerbivoren)
        {
            // test if the animal at the right position is a herbivoor
            if (PosX + 1 <= eoSpeelveld.GrootteX &&
                eoSpeelveld.Terrarium[PosX + 1, PosY] != null &&
                eoSpeelveld.Terrarium[PosX + 1, PosY].Naam.ToUpper() == "H")
            {
                List<Herbivoor> laHerbivoren = CreateHerbivoren(1);
                eaHerbivoren.Add(laHerbivoren[0]);
            }
        }
    }
}
