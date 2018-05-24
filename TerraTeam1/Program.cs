using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            Speelveld speelveld = new Speelveld(6, 6);

            int rndspeelveld = speelveld.GrootteX * speelveld.GrootteY;
            int rndValuePlant = rnd.Next(1,rndspeelveld);

            List<Plant> planten = Plant.CreatePlanten(rndValuePlant);
            speelveld.AddPlantenToSpeelveld(planten);

            while (Console.ReadLine().ToUpper() != "S")
            {

            }


        }      
    }
}
