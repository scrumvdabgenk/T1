using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam1
{
    class Mens : Carnivoor
    {
        public override void Vecht(Speelveld eoSpeelveld)
        {
            if (this.TotAantStappen <= 0)
            {
                // test if the animal at the right position is a carnivoor
                if (PosY + 1 < eoSpeelveld.GrootteY
                    && eoSpeelveld.Terrarium[PosX, PosY + 1] != null
                    && eoSpeelveld.Terrarium[PosX, PosY + 1].GetType() == typeof(Carnivoor))
                {
                    if (this.Levenskracht > eoSpeelveld.Terrarium[PosX, PosY + 1].Levenskracht)
                    {
                        // add the levenskracht of the carnivoor with the carnivoor
                        this.Levenskracht += eoSpeelveld.Terrarium[PosX, PosY + 1].Levenskracht;
                        // remove the other carnivoor
                        eoSpeelveld.Terrarium[PosX, PosY + 1].Delete();
                        eoSpeelveld.Terrarium[PosX, PosY + 1] = null;   // todo: move this to the delete() of the carnivoor
                        this.TotAantStappen++;
                    }
                    else
                    {
                        if (this.Levenskracht < eoSpeelveld.Terrarium[PosX, PosY + 1].Levenskracht)
                        {
                            // add the levenskracht of the carnivoor with the carnivoor
                            eoSpeelveld.Terrarium[PosX, PosY + 1].Levenskracht += this.Levenskracht;
                            // remove the current carnivoor
                            this.Delete();
                            eoSpeelveld.Terrarium[PosX, PosY] = null;   // todo: move this to the delete() of the carnivoor
                        }
                    }
                }
            }
        }

    }
}
