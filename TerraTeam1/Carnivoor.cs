using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam1
{
    public class Carnivoor : Dier
    {
        // constructor
        public Carnivoor()
        {
            this.Naam = "C";
        }

        public static List<Carnivoor> CreateCarnivoren(int aantal)
        {
            List<Carnivoor> laCarnivoor = new List<Carnivoor> { };
            while (aantal > 0)
            {
                laCarnivoor.Add(new Carnivoor());
                aantal--;
            }
            return laCarnivoor;
        }


        public void Vecht(Speelveld eoSpeelveld)
        {
            // test if the animal at the right position is a carnivoor
            if (PosX + 1 <= eoSpeelveld.GrootteX &&
                eoSpeelveld.Terrarium[PosX + 1, PosY] != null &&
                eoSpeelveld.Terrarium[PosX + 1, PosY].Naam.ToUpper() == "C")
            {
                if (this.Levenskracht != eoSpeelveld.Terrarium[PosX + 1, PosY].Levenskracht)
                {
                    if (this.Levenskracht > eoSpeelveld.Terrarium[PosX + 1, PosY].Levenskracht)
                    {
                        // add the levenskracht of the carnivoor with the carnivoor
                        this.Levenskracht += eoSpeelveld.Terrarium[PosX + 1, PosY].Levenskracht;
                        // remove the other carnivoor
                        eoSpeelveld.Terrarium[PosX + 1, PosY].Delete();
                        eoSpeelveld.Terrarium[PosX + 1, PosY] = null;   // todo: move this to the delete() of the carnivoor
                    }

                    if (this.Levenskracht < eoSpeelveld.Terrarium[PosX + 1, PosY].Levenskracht)
                    {
                        // add the levenskracht of the carnivoor with the carnivoor
                        eoSpeelveld.Terrarium[PosX + 1, PosY].Levenskracht += this.Levenskracht;
                        // remove the current carnivoor
                        this.Delete();
                        eoSpeelveld.Terrarium[PosX, PosY] = null;   // todo: move this to the delete() of the carnivoor
                    }
                }
                else
                {
                    // not implemented, coul:d return something whatever
                }
            }

            this.TotAantStappen++;
        }

        public override void Eet(Speelveld eoSpeelveld)
        {
            // test if the animal at the right position is a herbivoor
            if (PosX + 1 <= eoSpeelveld.GrootteX && 
                eoSpeelveld.Terrarium[PosX + 1, PosY] != null && 
                eoSpeelveld.Terrarium[PosX + 1, PosY].Naam.ToUpper() == "H")
            {
                // add the levenskracht of the carnivoor with the carnivoor
                this.Levenskracht += eoSpeelveld.Terrarium[PosX + 1, PosY].Levenskracht;
                // remove the carnivoor
                eoSpeelveld.Terrarium[PosX + 1, PosY].Delete();
                eoSpeelveld.Terrarium[PosX + 1, PosY] = null;   // todo: move this to the delete() of the carnivoor
            }
        }
    }
}
