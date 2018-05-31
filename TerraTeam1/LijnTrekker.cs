using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam1
{
    public class LijnTrekker
    {
        public void TrekLijn(int spacer = 0, int NumOfCar=80, char tekenChar = '_')//vergeet niet dat alle niet-optionele parameters voor de optionele parameters moeten staan
        {
            StringBuilder openRuimte = new StringBuilder();
            for (int teller = 1;teller<=spacer;teller++)
            {
                openRuimte.Append(' ');
            }
            for (int teller=0; teller<NumOfCar ; teller++)
            {
                Console.Write(tekenChar + openRuimte.ToString());
            }
            Console.WriteLine();
        }

    }
}
