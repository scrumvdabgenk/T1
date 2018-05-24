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

    }
}
