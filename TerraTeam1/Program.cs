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
            while (Console.ReadLine().ToUpper() != "S")
            {

            }
        }

        public List<Plant> CreatePlanten(int aantal)
        {
            List<Plant> laPlant = new List<Plant> { };
            while (aantal > 0)
            {
                laPlant.Add(new Plant());
                aantal--;
            }
            return laPlant;
        }
    }
}
