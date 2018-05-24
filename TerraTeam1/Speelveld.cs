using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam1
{
    public class Speelveld
    {
        //Creatie van een dynamic array voor speelveld
        IOrganismen[,] Terrarium = null;

        //Aanmaken van de grootte values voor X en Y
        private int grootteXval;
        private int grootteYval;
        public int GrootteX
        {
            get { return grootteXval; }
            set { grootteXval = value; }
        }
        public int GrootteY
        {
            get { return grootteYval; }
            set { grootteYval = value; }
        }

        //Aanpassen van het speelveld aan de specificaties opgegeven in de constructor
        public Speelveld(int GrootteX, int GrootteY)
        {
            this.grootteXval = GrootteX;
            this.grootteYval = GrootteY;
            Terrarium = new IOrganismen[GrootteX, GrootteY];
        }

        public void AddPlantenToSpeelveld(List<Plant> laPlanten)
        {
            Random rnd = new Random();

            foreach (var p in laPlanten)
            {
                while (true)
                {
                    int rndValueXinp = rnd.Next(0, this.GrootteX - 1);
                    int rndValueYinp = rnd.Next(0, this.GrootteY - 1);

                    if (this.Terrarium[rndValueXinp, rndValueYinp] == null)
                    {
                        this.Terrarium[rndValueXinp, rndValueYinp] = p;
                        break;
                    }
                }
            }

        }

        public int CountAmounOfPlantsInSpeelveld()
        {
            int amount = 0;

            for (int x = 0;x< this.GrootteX;x++)
            {
                for (int y = 0;y < this.GrootteY;y++)
                {
                    if (this.Terrarium[x,y] != null)
                    {
                        if (this.Terrarium[x, y].GetType()==typeof(Plant))
                            amount++;
                    }
                }
            }
            return amount;
        }

    }
}
