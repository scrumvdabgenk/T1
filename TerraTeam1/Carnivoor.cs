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


        public virtual void Vecht(Speelveld eoSpeelveld, Dier dier)
        {
            if (this.TotAantStappen <= 0)
            {
                //Dier dier = null;

                //if ((PosY + 1 < eoSpeelveld.GrootteY)
                //    && (eoSpeelveld.Terrarium[PosX, PosY + 1] != null)
                //    && (eoSpeelveld.Terrarium[PosX, PosY + 1].GetType() == typeof(Dier)))
                //{
                //    dier = (Dier)eoSpeelveld.Terrarium[PosX, PosY + 1];
                //}

                // test if the animal at the right position is a carnivoor
                if (dier != null && (dier.GetType() == typeof(Carnivoor) || dier.GetType() == typeof(Mens)))
                {
                    if (this.Levenskracht > dier.Levenskracht)
                    {
                        this.Eet(eoSpeelveld, dier);
                    }
                    else
                    {
                        if (this.Levenskracht < dier.Levenskracht)
                        {
                            // add the levenskracht of the carnivoor with the carnivoor
                            dier.Levenskracht += this.Levenskracht;
                            // remove the current carnivoor
                            this.Delete();
                            eoSpeelveld.Terrarium[PosX, PosY] = null;   // todo: move this to the delete() of the carnivoor
                        }
                    }
                }
            }
        }

        public override void Eet(Speelveld eoSpeelveld, Dier dier)
        {
            if (this.TotAantStappen <= 0)
            {
                if (dier != null)
                {
                    // add the levenskracht of the herbivoor with the carnivoor
                    this.Levenskracht += dier.Levenskracht;
                    // remove the herbivoor
                    dier.Delete();
                    dier = null;   // todo: move this to the delete() of the carnivoor
                    Stap(0, 1, eoSpeelveld);
                    this.TotAantStappen++;
                }
            }

            ////{
            ////    // test if the animal at the right position is a herbivoor
            ////    if (PosY + 1 < eoSpeelveld.GrootteY &&
            ////        eoSpeelveld.Terrarium[PosX, PosY + 1] != null &&
            ////        eoSpeelveld.Terrarium[PosX, PosY + 1].GetType() == typeof(Herbivoor))
            ////    {
            ////        // add the levenskracht of the herbivoor with the carnivoor
            ////        this.Levenskracht += eoSpeelveld.Terrarium[PosX, PosY + 1].Levenskracht;
            ////        // remove the herbivoor
            ////        eoSpeelveld.Terrarium[PosX, PosY + 1].Delete();
            ////        eoSpeelveld.Terrarium[PosX, PosY + 1] = null;   // todo: move this to the delete() of the carnivoor
            ////        Stap(0, 1, eoSpeelveld);
            ////        this.TotAantStappen++;
            ////    }
            ////}

        }
    }
}
