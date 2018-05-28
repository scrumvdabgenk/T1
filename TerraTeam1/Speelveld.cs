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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Planten"></param>
        /// <param name="elDontFillInRandomValues">if True, the fields XPOS, YPOS, levenskracht will not be filled in with random values</param>
        /// <returns></returns>
        public int AddPlantenToSpeelveld(List<Plant> Planten, bool elDontFillInRandomValues = false)
        {
            Random rnd = new Random();
            int amountOfFreeFields = this.CountAmounOfEmptyFieldsInSpeelveld();
            int amountAdded = 0;

            foreach (var p in Planten)
            {
                if (!p.IsDeleted)
                {
                    while (amountOfFreeFields > 0)
                    {
                        int rndValueXinp = rnd.Next(0, this.GrootteX);
                        int rndValueYinp = rnd.Next(0, this.GrootteY);

                        if (this.Terrarium[rndValueXinp, rndValueYinp] == null)
                        {
                            if (elDontFillInRandomValues == true)
                            {
                                this.Terrarium[p.PosX, p.PosY] = p;
                            }
                            else
                            {
                                this.Terrarium[rndValueXinp, rndValueYinp] = p;
                                p.PosX = rndValueXinp;
                                p.PosY = rndValueYinp;
                            }

                            amountOfFreeFields--;
                            amountAdded++;
                            break;  // stop while-loop
                        }
                    }
                }
            }
            return amountAdded;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Carnivoren"></param>
        /// <param name="elDontFillInRandomValues">if True, the fields XPOS, YPOS, levenskracht will not be filled in with random values</param>
        /// <returns></returns>
        public int AddCarnivorenToSpeelveld(List<Carnivoor> Carnivoren, bool elDontFillInRandomValues = false)
        {
            Random rnd = new Random();
            int amountOfFreeFields = this.CountAmounOfEmptyFieldsInSpeelveld();
            int amountAdded = 0;

            foreach (var p in Carnivoren)
            {
                if (!p.IsDeleted)
                {
                    while (amountOfFreeFields > 0)
                    {
                        int rndValueXinp = rnd.Next(0, this.GrootteX);
                        int rndValueYinp = rnd.Next(0, this.GrootteY);

                        // test if the animal can be put on an empty place
                        if (this.Terrarium[rndValueXinp, rndValueYinp] == null)
                        {
                            if (elDontFillInRandomValues == true)
                            {
                                this.Terrarium[p.PosX, p.PosY] = p;
                            }
                            else
                            {
                                this.Terrarium[rndValueXinp, rndValueYinp] = p;
                                p.PosX = rndValueXinp;
                                p.PosY = rndValueYinp;
                                p.Levenskracht = rnd.Next(0, 100);
                            }

                            amountOfFreeFields--;
                            amountAdded++;
                            break;  // stop while-loop
                        }
                    }
                }
            }
            return amountAdded;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Herbivoren"></param>
        /// <param name="elDontFillInRandomValues">if True, the fields XPOS, YPOS, levenskracht will not be filled in with random values</param>
        /// <returns></returns>
        public int AddHerbivorenToSpeelveld(List<Herbivoor> Herbivoren, bool elDontFillInRandomValues = false)
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
                if (!p.IsDeleted)
                {
                    while (amountOfFreeFields > 0)
                    {
                        int rndValueXinp = rnd.Next(0, this.GrootteX);
                        int rndValueYinp = rnd.Next(0, this.GrootteY);

                        // test if the animal can be put on an empty place
                        if (this.Terrarium[rndValueXinp, rndValueYinp] == null)
                        {
                            if (elDontFillInRandomValues == true)
                            {
                                this.Terrarium[p.PosX, p.PosY] = p;
                            }
                            else
                            {
                                this.Terrarium[rndValueXinp, rndValueYinp] = p;
                                p.PosX = rndValueXinp;
                                p.PosY = rndValueYinp;
                                p.Levenskracht = rnd.Next(0, 100);
                            }

                            amountOfFreeFields--;
                            amountAdded++;
                            break;  // stop while-loop
                        }
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

        public void ToonSpeelveld(int enOffsetX = 0, int enOffsetY = 0, string ecFooter = "")
        {
            Thread.Sleep(150);

            for (int y = 0; y <= GrootteX - 1; y++)
            {
                for (int x = 0; x <= GrootteY - 1; x++)
                {
                    if (this.Terrarium[y, x] != null)
                    {
                        switch (this.Terrarium[y, x].ToString())
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
                        Console.SetCursorPosition(x + enOffsetX, y + enOffsetY);
                        Console.Write(this.Terrarium[y, x].ToString());
                    }
                    else
                    {
                        Console.SetCursorPosition(x + enOffsetX, y + enOffsetY);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        //Console.Write('.');
                    }
                }
            }

            if (!String.IsNullOrEmpty(ecFooter))
            {
                Console.SetCursorPosition(enOffsetX, GrootteY * 2);
                Console.Write(ecFooter);
            }

            //Console.SetCursorPosition(0, GrootteY * 2);
            //Console.WriteLine("Press a key");
            //Console.ReadLine();
        }

        public int ResetAllStappen(List<Herbivoor> Herbivoren, List<Carnivoor> Carnivoren)
        {
            return this.ResetAllStappenHerbivoren(Herbivoren) + this.ResetAllStappenCarnivoren(Carnivoren);
        }

        public int ResetAllStappenHerbivoren(List<Herbivoor> Herbivoren)
        {
            int lnAmReset = 0;
            foreach (Herbivoor H in Herbivoren)
            {
                if (!H.IsDeleted)
                {
                    if (H.TotAantStappen > 0)
                    {
                        H.TotAantStappen = 0;
                        lnAmReset++;
                    }
                }
            }
            return lnAmReset;
        }

        public int ResetAllStappenCarnivoren(List<Carnivoor> Carnivoren)
        {
            int lnAmReset = 0;
            foreach (Carnivoor H in Carnivoren)
            {
                if (!H.IsDeleted)
                {
                    if (H.TotAantStappen > 0)
                    {
                        H.TotAantStappen = 0;
                        lnAmReset++;
                    }
                }
            }
            return lnAmReset;
        }

        public int DoActionsOf1Day(List<Carnivoor> carnivoren, List<Herbivoor> herbivoren, List<Plant> planten, int enOffsetX = 0)
        {
            int lnOffset = 0;

            this.ToonSpeelveld(enOffsetX * lnOffset, 0, "Start");
            lnOffset++;

            List<Herbivoor> nieuweherbivoren = new List<Herbivoor>();

            /////////////////////////////////////////////////
            // carnivoren business
            /////////////////////////////////////////////////
            foreach (Carnivoor C in carnivoren)
            {
                if (!C.IsDeleted)
                {
                    C.Eet(this);
                    C.Vecht(this);
                    C.Beweeg(this);

                    this.ToonSpeelveld(enOffsetX * lnOffset, 0, "Carni");
                    lnOffset++;
                }
            }

            /////////////////////////////////////////////////
            // herbivoren business
            /////////////////////////////////////////////////
            foreach (Herbivoor H in herbivoren)
            {
                if (!H.IsDeleted)
                {
                    H.Eet(this);
                    H.Beweeg(this);
                    Herbivoor nieuweherbivoor = H.PlantVoort(this, herbivoren);
                    if (nieuweherbivoor != null)
                    {
                        nieuweherbivoren.Add(nieuweherbivoor);
                    }
                    this.ToonSpeelveld(enOffsetX * lnOffset, 0, "Herbi");
                    lnOffset++;
                }
            }
            this.AddHerbivorenToSpeelveld(nieuweherbivoren);
            if (nieuweherbivoren != null)
            {
                foreach (Herbivoor Dier in nieuweherbivoren)
                {
                    herbivoren.Add(Dier);
                }
            }
            this.ToonSpeelveld(enOffsetX * lnOffset, 0, "Paren");
            lnOffset++;

            /////////////////////////////////////////////////
            // planten business
            /////////////////////////////////////////////////
            List<Plant> nieuweplanten = Plant.CreatePlanten((this.GrootteX * this.GrootteY) / 12);
            this.AddPlantenToSpeelveld(nieuweplanten);
            foreach (var plant in nieuweplanten)
            {
                planten.Add(plant);
            }
            this.ToonSpeelveld(enOffsetX * lnOffset, 0, "Plant");
            lnOffset++;

            return 0;
        }
    }
}
