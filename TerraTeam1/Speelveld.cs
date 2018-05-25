using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
            int amountOfFreeFields = this.CountAmounOfEmptyFieldsInSpeelveld();
            int amountAdded = 0;

            foreach (var p in Planten)
            {
                while (amountOfFreeFields > 0)
                {
                    int rndValueXinp = rnd.Next(0, this.GrootteX);
                    int rndValueYinp = rnd.Next(0, this.GrootteY);

                    if (this.Terrarium[rndValueXinp, rndValueYinp] == null)
                    {
                        this.Terrarium[rndValueXinp, rndValueYinp] = p;
                        p.PosX = rndValueXinp;
                        p.PosY = rndValueYinp;

                        amountOfFreeFields--;
                        amountAdded++;
                        break;  // stop while-loop
                    }
                }
            }
            return amountAdded;
        }

        public int AddCarnivorenToSpeelveld(List<Carnivoor> Carnivoren)
        {
            Random rnd = new Random();
            int amountOfFreeFields = this.CountAmounOfEmptyFieldsInSpeelveld();
            int amountAdded = 0;

            foreach (var p in Carnivoren)
            {
                while (amountOfFreeFields > 0)
                {
                    int rndValueXinp = rnd.Next(0, this.GrootteX);
                    int rndValueYinp = rnd.Next(0, this.GrootteY);

                    // test if the animal can be put on an empty place
                    if (this.Terrarium[rndValueXinp, rndValueYinp] == null)
                    {
                        this.Terrarium[rndValueXinp, rndValueYinp] = p;
                        p.PosX = rndValueXinp;
                        p.PosY = rndValueYinp;

                        amountOfFreeFields--;
                        amountAdded++;
                        break;  // stop while-loop
                    }
                }
            }
            return amountAdded;
        }

        public int AddHerbivorenToSpeelveld(List<Herbivoor> Herbivoren)
        {
            if (Herbivoren == null)
            {
                return 0;
            }

            Random rnd = new Random();
            int amountOfFreeFields = this.CountAmounOfEmptyFieldsInSpeelveld();
            int amountAdded = 0;

            foreach (var p in Herbivoren)
            {
                while (amountOfFreeFields > 0)
                {
                    int rndValueXinp = rnd.Next(0, this.GrootteX);
                    int rndValueYinp = rnd.Next(0, this.GrootteY);

                    // test if the animal can be put on an empty place
                    if (this.Terrarium[rndValueXinp, rndValueYinp] == null)
                    {
                        this.Terrarium[rndValueXinp, rndValueYinp] = p;
                        p.PosX = rndValueXinp;
                        p.PosY = rndValueYinp;

                        amountOfFreeFields--;
                        amountAdded++;
                        break;  // stop while-loop
                    }
                }
            }
            return amountAdded;
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

        public int CountAmounOfHerbivorenInSpeelveld()
        {
            int amount = 0;

            for (int x = 0; x < this.GrootteX; x++)
            {
                for (int y = 0; y < this.GrootteY; y++)
                {
                    if (this.Terrarium[x, y] != null)
                    {
                        if (this.Terrarium[x, y].GetType() == typeof(Herbivoor))
                            amount++;
                    }
                }
            }
            return amount;
        }

        public int CountAmounOfCarnivorenInSpeelveld()
        {
            int amount = 0;

            for (int x = 0; x < this.GrootteX; x++)
            {
                for (int y = 0; y < this.GrootteY; y++)
                {
                    if (this.Terrarium[x, y] != null)
                    {
                        if (this.Terrarium[x, y].GetType() == typeof(Carnivoor))
                            amount++;
                    }
                }
            }
            return amount;
        }

        public int CountAmounOfEmptyFieldsInSpeelveld()
        {
            int amount = 0;

            for (int x = 0; x < this.GrootteX; x++)
            {
                for (int y = 0; y < this.GrootteY; y++)
                {
                    if (this.Terrarium[x, y] == null)
                        amount++;
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
            Thread.Sleep(500);
            Console.Clear();
            for (int x = 0; x <= GrootteX - 1; x++)
            {
                for (int y = 0; y <= GrootteY - 1; y++)
                {
                    if (this.Terrarium[x, y] != null)
                    {
                        switch(this.Terrarium[x, y].ToString())
                        {
                            case "H":
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                break;
                            case "C":
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case "P":
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                        }
                        Console.Write(this.Terrarium[x, y].ToString());
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write('.');
                    }
                    Console.Write("     ");

                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                

            }
            Console.Write("---------------:D------------------");
        }
    }
}
