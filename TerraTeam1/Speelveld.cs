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
        private int displayModelVal;
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
        public int DisplayModel
        {
            get { return displayModelVal; }
            set { displayModelVal = value; }
        }

        //Aanpassen van het speelveld aan de specificaties opgegeven in de constructor
        public Speelveld(int GrootteX, int GrootteY, int DisplayModel = 1)
        {
            this.grootteXval = GrootteX;
            this.grootteYval = GrootteY;
            this.displayModelVal = DisplayModel;
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


        public int AddMensenToSpeelveld(List<Mens> mensen, bool elDontFillInRandomValues = false)
        {
            Random rnd = new Random();
            int amountOfFreeFields = this.CountAmounOfEmptyFieldsInSpeelveld();
            int amountAdded = 0;

            foreach (var p in mensen)
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
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                break;
                            case "C":
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                break;
                            case "P":
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                break;
                            case "M":
                                Console.BackgroundColor = ConsoleColor.Gray;
                                break;
                            default:
                                Console.BackgroundColor = ConsoleColor.White;
                                break;

                        }
                        Console.SetBufferSize(300, 300);
                        Console.SetCursorPosition(x + enOffsetX, y + enOffsetY);
                        if (this.DisplayModel == 1)
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write(this.Terrarium[y, x].ToString());
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(x + enOffsetX, y + enOffsetY);
                        Console.Write(" ");
                        Console.ForegroundColor = ConsoleColor.Gray;
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

        public int DoActionsOf1Day(List<Mens> mensen, List<Carnivoor> carnivoren, List<Herbivoor> herbivoren, List<Plant> planten, int enOffsetX = 0)
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
                    Dier dier = null;

                    if ((C.PosY + 1 < this.GrootteY)
                        && (this.Terrarium[C.PosX, C.PosY + 1] != null)
                        && (this.Terrarium[C.PosX, C.PosY + 1].GetType() == typeof(Dier)))
                    {
                        dier = (Dier)this.Terrarium[C.PosX, C.PosY + 1];
                    }

                    C.Eet(this, dier);
                    C.Vecht(this, dier);
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
                    Dier dier = null;

                    if ((H.PosY + 1 < this.GrootteY)
                        && (this.Terrarium[H.PosX, H.PosY + 1] != null)
                        && (this.Terrarium[H.PosX, H.PosY + 1].GetType() == typeof(Dier)))
                    {
                        dier = (Dier)this.Terrarium[H.PosX, H.PosY + 1];
                    }

                    H.Eet(this, dier);
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
            // mensen business
            /////////////////////////////////////////////////
            foreach (Mens M in mensen)
            {
                if (!M.IsDeleted)
                {
                    Dier dier = null;

                    if ((M.PosY + 1 < this.GrootteY)
                        && (this.Terrarium[M.PosX, M.PosY + 1] != null)
                        && (this.Terrarium[M.PosX, M.PosY + 1].GetType() == typeof(Dier)))
                    {
                        dier = (Dier)this.Terrarium[M.PosX, M.PosY + 1];
                    }

                    M.Vecht(this, dier);
                    M.Eet(this, dier);
                    M.Beweeg(this);
                    this.ToonSpeelveld(enOffsetX * lnOffset, 0, "Mens");
                    lnOffset++;
                }
            }

            /////////////////////////////////////////////////
            // planten business
            /////////////////////////////////////////////////
            List<Plant> nieuweplanten = Plant.CreatePlanten((this.GrootteX * this.GrootteY) / (this.GrootteX + this.GrootteY));
            this.AddPlantenToSpeelveld(nieuweplanten);
            foreach (var plant in nieuweplanten)
            {
                planten.Add(plant);
            }
            this.ToonSpeelveld(enOffsetX * lnOffset, 0, "Plant");
            lnOffset++;
            //Console.ReadLine();
            Thread.Sleep(500);
            this.Volcano(ref mensen, ref carnivoren, ref herbivoren, ref planten, this);
            this.ToonSpeelveld(enOffsetX * lnOffset, 0, "Vulcano");
            //Console.ReadLine();            
            return 0;

        }

        public int RemoveDeletedHerbivoren(ref List<Herbivoor> eoHerbivoren)
        {
            int lnAmDeleted = 0;

            for (int x = eoHerbivoren.Count - 1; x >= 0; x--)
            {
                if (eoHerbivoren[x].IsDeleted)
                {
                    eoHerbivoren.Remove(eoHerbivoren[x]);
                    lnAmDeleted++;
                }
            }
            return lnAmDeleted;
        }

        public int RemoveDeletedCarnivoren(ref List<Carnivoor> eoCarnivoren)
        {
            int lnAmDeleted = 0;

            for (int x = eoCarnivoren.Count - 1; x >= 0; x--)
            {
                if (eoCarnivoren[x].IsDeleted)
                {
                    eoCarnivoren.Remove(eoCarnivoren[x]);
                    lnAmDeleted++;
                }
            }
            return lnAmDeleted;
        }

        public int RemoveDeletedMensen(ref List<Mens> eoMensen)
        {
            int lnAmDeleted = 0;

            for (int x = eoMensen.Count - 1; x >= 0; x--)
            {
                if (eoMensen[x].IsDeleted)
                {
                    eoMensen.Remove(eoMensen[x]);
                    lnAmDeleted++;
                }
            }
            return lnAmDeleted;
        }

        public int RemoveDeletedPlanten(ref List<Plant> eoPlanten)
        {
            int lnAmDeleted = 0;

            for (int x = eoPlanten.Count - 1; x >= 0; x--)
            {
                if (eoPlanten[x].IsDeleted)
                {
                    eoPlanten.Remove(eoPlanten[x]);
                    lnAmDeleted++;
                }
            }
            return lnAmDeleted;
        }

        public void Volcano(ref List<Mens> eoMensen, ref List<Carnivoor> eoCarnivoren, ref List<Herbivoor> eoHerbivoren, ref List<Plant> eoPlanten, Speelveld eoSpeelveld)
        {
            Random rnd = new Random();

            int extremeX = eoSpeelveld.GrootteX;
            int extremeY = eoSpeelveld.GrootteY;
            int centrepointX = rnd.Next(0, extremeX);
            int centrepointY = rnd.Next(0, extremeY);

            int diagonaalUitbarsting = 5; // Dient altijd oneven te zijn;

            int vulkaanMinX = 0 - ((diagonaalUitbarsting - 1) / 2);
            int vulkaanMaxX = ((diagonaalUitbarsting - 1) / 2);
            int vulkaanMinY = vulkaanMinX;
            int vulkaanMaxY = vulkaanMaxX;



            for (int i = vulkaanMinX; i <= vulkaanMaxX; i++)
            {
                for (int j = vulkaanMinY; j <= vulkaanMaxY; j++)
                {
                    if ((centrepointY + j < extremeY)
                        && (centrepointX + i < extremeX)
                        && (centrepointY + j >= 0)
                        && (centrepointX + i >= 0))
                    {
                        if (eoSpeelveld.Terrarium[centrepointY + j, centrepointX + i] != null)
                        {
                            if (eoSpeelveld.Terrarium[centrepointY + j, centrepointX + i].GetType() == typeof(Carnivoor))
                            {
                                eoSpeelveld.Terrarium[centrepointY + j, centrepointX + i].Delete();
                                this.RemoveDeletedCarnivoren(ref eoCarnivoren);
                            }
                            if (eoSpeelveld.Terrarium[centrepointY + j, centrepointX + i].GetType() == typeof(Herbivoor))
                            {
                                eoSpeelveld.Terrarium[centrepointY + j, centrepointX + i].Delete();
                                this.RemoveDeletedHerbivoren(ref eoHerbivoren);
                            }
                            if (eoSpeelveld.Terrarium[centrepointY + j, centrepointX + i].GetType() == typeof(Mens))
                            {
                                eoSpeelveld.Terrarium[centrepointY + j, centrepointX + i].Delete();
                                this.RemoveDeletedMensen(ref eoMensen);
                            }
                            if (eoSpeelveld.Terrarium[centrepointY + j, centrepointX + i].GetType() == typeof(Plant))
                            {
                                eoSpeelveld.Terrarium[centrepointY + j, centrepointX + i].Delete();
                                this.RemoveDeletedPlanten(ref eoPlanten);
                            }
                            this.Terrarium[centrepointY + j, centrepointX + i] = null;
                        }
                    }
                }
            }
        }
    }
}
