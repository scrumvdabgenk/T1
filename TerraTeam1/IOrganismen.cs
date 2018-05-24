using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam1
{
     public interface IOrganismen
    {
        int Levenskracht { get; set; }
        int PosX { get; set; }
        int PosY { get; set; }
        string Naam { get; set; }


        void Delete();

    }
}
