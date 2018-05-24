using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam1
{
    abstract class Dier
    {
        public Dier()
        {

        }
        private int nameValue;

        public int Name
        {
            get { return nameValue; }
            set { nameValue = value; }
        }

        private int bewegingValue;

        public int Beweging
        {
            get { return bewegingValue; }
            set { bewegingValue = value; }
        }

        private int etenValue;

        public int Eten
        {
            get { return etenValue; }
            set { etenValue = value; }
        }

        private int totaantStappenValue;

        public int TotAantStappen
        {
            get { return totaantStappenValue; }
            set { totaantStappenValue = value; }
        }





    }
}
