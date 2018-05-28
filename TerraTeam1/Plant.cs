using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam1
{
    public class Plant : IOrganismen
    {
        private int posXValue;
        private int posYValue;
        private string naamValue;
        private int levenskrachtValue;
        private bool isDeletedValue;

        public Plant()
        {
            this.PosX = 0;
            this.PosY = 0;
            this.Naam = "P";
        }

        public Plant(int enPosX, int enPosY)
        {
            this.PosX = enPosX;
            this.PosY = enPosY;
            this.Naam = "P";
        }

        public static List<Plant> CreatePlanten(int aantal)
        {
            List<Plant> laPlant = new List<Plant> { };
            while (aantal > 0)
            {
                laPlant.Add(new Plant());
                aantal--;
            }
            return laPlant;
        }

        public int Levenskracht
        {
            get
            {
                return this.levenskrachtValue;
            }

            set
            {
                this.levenskrachtValue = value;
            }
        }

        public string Naam
        {
            get
            {
                return this.naamValue;
            }

            set
            {
                this.naamValue = value;
            }
        }

        public int PosX
        {
            get
            {
                return this.posXValue;
            }

            set
            {
                this.posXValue = value;
            }
        }

        public int PosY
        {
            get
            {
                return this.posYValue;
            }

            set
            {
                this.posYValue = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return this.isDeletedValue;
            }

            set
            {
                this.isDeletedValue = value;
            }
        }

        public void Delete()
        {
            this.isDeletedValue = true;
        }

        public override string ToString()
        {
            return this.Naam;
        }
    }
}
