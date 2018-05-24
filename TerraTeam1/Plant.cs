﻿using System;
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

        public Plant()
        {
            this.PosX = 0;
            this.PosY = 0;
        }

        public Plant(int enPosX, int enPosY)
        {
            this.PosX = enPosX;
            this.PosY = enPosY;
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

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}