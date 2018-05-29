using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam1
{
    public class Mens : Carnivoor
    {
        // Constructor
        public Mens()
        {
            this.Naam = "M";
        }

        public static List<Mens> CreateMensen(int aantal)
        {
            List<Mens> laMens = new List<Mens> { };
            while (aantal > 0)
            {
                laMens.Add(new Mens());
                aantal--;
            }
            return laMens;
        }


        public override void Vecht(Speelveld eoSpeelveld , Dier dier)
        {
            if (this.TotAantStappen <= 0)
            {
                //Dier dier = null;

                //if ((PosY + 1 < eoSpeelveld.GrootteY)
                //    && (eoSpeelveld.Terrarium[PosX,PosY+1]!=null)
                //    && (eoSpeelveld.Terrarium[PosX, PosY + 1].GetType() == typeof(Dier)))
                //{
                //    dier = (Dier)eoSpeelveld.Terrarium[PosX, PosY + 1];
                //}

                // test if the animal at the right position is a carnivoor
                if (dier!=null && dier.GetType() == typeof(Carnivoor))
                {
                    if (this.Levenskracht > dier.Levenskracht)
                    {
                        this.Eet(eoSpeelveld, dier);
                    }
                    else if (this.Levenskracht < dier.Levenskracht)
                    {
                        // add the levenskracht of the carnivoor with the carnivoor
                        dier.Levenskracht += this.Levenskracht;
                        // remove the current carnivoor
                        this.Delete();
                        eoSpeelveld.Terrarium[PosX, PosY] = null;   // todo: move this to the delete() of the carnivoor
                    }
                    else
                    {
                        this.Eet(eoSpeelveld, dier);
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
                    if (dier.GetType() == typeof(Carnivoor))
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
            }
        }

    }
}
