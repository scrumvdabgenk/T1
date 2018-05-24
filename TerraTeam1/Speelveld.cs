﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam1
{
    public class Speelveld
    {
        //Creatie van een dynamic array voor speelveld
        public IOrganismen[,] Terrarium = null;

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

        public int AddPlantenToSpeelveld(List<Plant> Planten)
        {
            Random rnd = new Random();
            int amPlantenAdded = 0;

            foreach (var p in Planten)
            {
                if (amPlantenAdded < (this.GrootteX * this.GrootteY))
                {
                    while (true)
                    {
                        int rndValueXinp = rnd.Next(0, this.GrootteX);
                        int rndValueYinp = rnd.Next(0, this.GrootteY);

                        if (this.Terrarium[rndValueXinp, rndValueYinp] == null)
                        {
                            this.Terrarium[rndValueXinp, rndValueYinp] = p;
                            break;
                        }
                    }
                }
                else
                {
                    break;  // stop foreach loop
                }
                amPlantenAdded++;
            }
            return amPlantenAdded;
        }

        public int CountAmounOfPlantsInSpeelveld()
        {
            int amount = 0;

            for (int x = 0; x < this.GrootteX; x++)
            {
                for (int y = 0; y < this.GrootteY; y++)
                {
                    if (this.Terrarium[x, y] != null)
                    {
                        if (this.Terrarium[x, y].GetType() == typeof(Plant))
                            amount++;
                    }
                }
            }
            return amount;
        }

        public IOrganismen[,] returnMatrix()
        {
            return this.Terrarium;
        }

        public void ToonSpeelveld()
        {
            for (int x = 0; x <= GrootteX - 1; x++)
            {
                for (int y = 0; y <= GrootteY - 1; y++)
                {
                    if (this.Terrarium[x, y] != null)
                    {

                        Console.Write(this.Terrarium[x, y].ToString());

                    }

                    else
                    {
                        Console.Write('.');
                    }
                    Console.Write("     ");

                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

            }
        }

    }
}
