﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam1
{
    public abstract class Dier : IOrganismen
    {
        // constructor
        public Dier()
        {
            this.Naam = "";

        }

        public void Beweeg(int Xpos, int Ypos)
        {
            this.PosX = Xpos;
            this.PosY = Ypos;
        }

        public int Eet()
        {
            return 0;
        }

        private int totaantStappenValue;

        public int TotAantStappen
        {
            get { return totaantStappenValue; }
            set { totaantStappenValue = value; }
        }

        public int Levenskracht
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int PosX
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int PosY
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Naam
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
