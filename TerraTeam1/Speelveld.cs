using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
                                p.Levenskracht = 3;
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
                                p.Levenskracht = rnd.Next(0, 20);
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
                                p.Levenskracht = rnd.Next(0, 20);
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
                                p.Levenskracht = rnd.Next(0, 20);
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
            Thread.Sleep(0);

            for (int y = 0; y <= GrootteX - 1; y++)
            {
                for (int x = 0; x <= GrootteY - 1; x++)
                {
                    if (this.Terrarium[y, x] != null)
                    {
                        var kleur = ConsoleColor.Black;
                        switch (this.Terrarium[y, x].ToString())
                        {
                            case "H":
                                if (this.Terrarium[y, x].Levenskracht < 2)
                                {
                                    kleur = ConsoleColor.DarkRed;
                                }
                                else
                                {
                                    kleur = ConsoleColor.Red;
                                }
                                Console.ForegroundColor = kleur;
                                Console.BackgroundColor = kleur;
                                break;
                            case "C":
                                if (this.Terrarium[y, x].Levenskracht < 3)
                                {
                                    kleur = ConsoleColor.DarkYellow;
                                }
                                else
                                {
                                    kleur = ConsoleColor.Yellow;
                                }
                                Console.ForegroundColor = kleur;
                                Console.BackgroundColor = kleur;                               
                                break;
                            case "P":
                                if (this.Terrarium[y, x].Levenskracht < 1)
                                {
                                    kleur = ConsoleColor.DarkGreen;
                                }
                                else
                                {
                                    kleur = ConsoleColor.Green;
                                }
                                Console.ForegroundColor = kleur;
                                Console.BackgroundColor = kleur;
                                break;
                            case "M":
                                if (this.Terrarium[y, x].Levenskracht < 3)
                                {
                                    kleur = ConsoleColor.DarkGray;
                                }
                                else
                                {
                                    kleur = ConsoleColor.Gray;
                                }
                                Console.ForegroundColor = kleur;
                                Console.BackgroundColor = kleur;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.White;
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
                            Console.BackgroundColor = ConsoleColor.Black;
                            //Console.Write(this.Terrarium[y, x].ToString());
                            Console.Write(this.Terrarium[y, x].Levenskracht.ToString());
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
                Console.WriteLine("\n");
                //Console.SetCursorPosition(enOffsetX, GrootteY * 2);
                //Console.Write(ecFooter);
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
            foreach(Mens m in mensen)
            {
                m.Levenskracht--;
                if (m.Levenskracht <= 0)
                {
                    m.Delete();
                    this.Terrarium[m.PosX, m.PosY] = null;
                }
            }

            foreach(Herbivoor h in herbivoren)
            {
                h.Levenskracht--;
                if (h.Levenskracht <= 0)
                {
                    h.Delete();
                    this.Terrarium[h.PosX, h.PosY] = null;
                }
            }
            foreach (Carnivoor c in carnivoren)
            {
                c.Levenskracht--;
                if (c.Levenskracht <= 0)
                {
                    c.Delete();
                    this.Terrarium[c.PosX, c.PosY] = null;
                }
            }

            foreach (Plant p in planten)
            {
                p.Levenskracht--;
                if (p.Levenskracht <= 0)
                {
                    p.Delete();
                    this.Terrarium[p.PosX, p.PosY] = null;
                }
            }

            int lnOffset = 0;

            for(int i =0; i <= this.CountAmounOfCarnivorenInSpeelveld() ;i++)
            {

            }

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
            //Thread.Sleep(500);
            //Console.ReadLine();            

            string lcFilename = "c:\\Oefeningenfolder Johan Ballet\\Scrum\\Terrarium\\TerrariumSettings.txt";
            int lnReturn = 0;
            Console.WriteLine("'v': volgende dag, 's': bewaren, 'l': lezen, 'q': volcano, 'e': earthquake'x': stoppen");
            string lcInput = Console.ReadLine();
            switch (lcInput)
            {
                case "s":
                    this.SaveSpeelveld(lcFilename, mensen, carnivoren, herbivoren, planten);
                    break;
                case "l":
                    this.LoadSpeelveld(lcFilename, ref mensen, ref carnivoren, ref herbivoren, ref planten);
                    break;
                case "q":
                    this.Volcano(ref mensen, ref carnivoren, ref herbivoren, ref planten, this);
                    this.ToonSpeelveld(enOffsetX * lnOffset, 0, "Vulcano");
                    break;
                case "e":
                    this.Earthquake(ref mensen, ref carnivoren, ref herbivoren, ref planten, this);
                    this.ToonSpeelveld(enOffsetX * lnOffset, 0, "Earthquake");
                    break;
                case "x":
                    lnReturn = -1;
                    break;
            }

            return lnReturn;
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

            int grootteUitb = (((extremeX * extremeY) / (extremeX + extremeY)) / 2);

            int diagonaalUitbarsting = (grootteUitb * 2) + 1; // Dient altijd oneven te zijn;

            int vulkaanMinX = 0 - ((diagonaalUitbarsting - 1) / 2);
            int vulkaanMaxX = ((diagonaalUitbarsting - 1) / 2);
            int vulkaanMinY = vulkaanMinX;
            int vulkaanMaxY = vulkaanMaxX;



            for (int i = vulkaanMinX; i <= vulkaanMaxX; i++)
            {
                for (int j = vulkaanMinY; j <= vulkaanMaxY; j++)
                {
                    if ((centrepointY + j < extremeY - 1)
                        && (centrepointX + i < extremeX - 1)
                        && (centrepointY + j >= 0)
                        && (centrepointX + i >= 0))
                    {
                        if (eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j] != null)
                        {
                            if (eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j].GetType() == typeof(Carnivoor))
                            {

                                eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j].Delete();

                            }
                            if (eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j].GetType() == typeof(Herbivoor))
                            {
                                eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j].Delete();

                            }
                            if (eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j].GetType() == typeof(Mens))
                            {
                                eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j].Delete();

                            }
                            if (eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j].GetType() == typeof(Plant))
                            {
                                eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j].Delete();

                            }
                            this.Terrarium[centrepointX + i, centrepointY + j] = null;
                        }
                    }
                }
            }
            this.RemoveDeletedCarnivoren(ref eoCarnivoren);
            this.RemoveDeletedHerbivoren(ref eoHerbivoren);
            this.RemoveDeletedMensen(ref eoMensen);
            this.RemoveDeletedPlanten(ref eoPlanten);
        }

        public void Earthquake(ref List<Mens> eoMensen, ref List<Carnivoor> eoCarnivoren, ref List<Herbivoor> eoHerbivoren, ref List<Plant> eoPlanten, Speelveld eoSpeelveld)
        {
            Random rnd = new Random();

            int extremeX = eoSpeelveld.GrootteX;
            int extremeY = eoSpeelveld.GrootteY;
            int centrepointX = rnd.Next(0, extremeX);
            int centrepointY = rnd.Next(0, extremeY);

            int grootteBeving = (((extremeX * extremeY) / (extremeX + extremeY)) / 2);

            int diagonaalBeving = (grootteBeving * 2) + 1; // Dient altijd oneven te zijn;

            int bevingMinX = 0 - ((diagonaalBeving - 1) / 2);
            int bevingMaxX = ((diagonaalBeving - 1) / 2);
            int bevingMinY = bevingMinX;
            int bevingMaxY = bevingMaxX;



            for (int i = bevingMinX; i <= bevingMaxX; i++)
            {
                for (int j = bevingMinY; j <= bevingMaxY; j++)
                {
                    if ((centrepointY + j < extremeY - 1)
                        && (centrepointX + i < extremeX - 1)
                        && (centrepointY + j >= 0)
                        && (centrepointX + i >= 0))
                    {
                        if (eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j] != null)
                        {
                            if (eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j].GetType() == typeof(Carnivoor))
                            {
                                ((Carnivoor)eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j]).Beweeg(eoSpeelveld);
                                //this.RemoveDeletedCarnivoren(ref eoCarnivoren);
                            }
                            else if (eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j].GetType() == typeof(Herbivoor))
                            {
                                ((Herbivoor)eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j]).Beweeg(eoSpeelveld);
                            }
                            else if (eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j].GetType() == typeof(Mens))
                            {
                                ((Mens)eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j]).Beweeg(eoSpeelveld);
                            }
                            else if (eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j].GetType() == typeof(Plant))
                            {
                                eoSpeelveld.Terrarium[centrepointX + i, centrepointY + j].Delete();

                            }
                            this.Terrarium[centrepointX + i, centrepointY + j] = null;
                        }
                    }
                }
            }
            this.RemoveDeletedPlanten(ref eoPlanten);
        }


        public int SaveSpeelveld(string ecFilename, List<Mens> mensen, List<Carnivoor> carnivoren, List<Herbivoor> herbivoren, List<Plant> planten)
        {
            int lnAmAdded = 0;
            using (StreamWriter loBestand = new StreamWriter(ecFilename))
            {

                loBestand.WriteLine("SIZE," + this.GrootteX.ToString() + "," + this.GrootteY.ToString());

                foreach (Mens loMens in mensen)
                {
                    loBestand.WriteLine("M," + loMens.PosX.ToString() + "," + loMens.PosY.ToString() + "," + loMens.Levenskracht.ToString());
                }
                foreach (Carnivoor loCarnivoor in carnivoren)
                {
                    loBestand.WriteLine("C," + loCarnivoor.PosX.ToString() + "," + loCarnivoor.PosY.ToString() + "," + loCarnivoor.Levenskracht.ToString());
                }
                foreach (Herbivoor loHerbivoor in herbivoren)
                {
                    loBestand.WriteLine("H," + loHerbivoor.PosX.ToString() + "," + loHerbivoor.PosY.ToString() + "," + loHerbivoor.Levenskracht.ToString());
                }
                foreach (Plant loPlant in planten)
                {
                    loBestand.WriteLine("P," + loPlant.PosX.ToString() + "," + loPlant.PosY.ToString() + "," + loPlant.Levenskracht.ToString());
                }
            }
            return lnAmAdded;
        }

        public int LoadSpeelveld(string ecFilename, ref List<Mens> mensen, ref List<Carnivoor> carnivoren, ref List<Herbivoor> herbivoren, ref List<Plant> planten)
        {
            int lnAmAdded = 0;
            using (StreamReader loBestand = new StreamReader(ecFilename))
            {
                mensen.Clear();
                carnivoren.Clear();
                herbivoren.Clear();
                planten.Clear();

                for (int x = 0; x < this.GrootteX; x++)
                {
                    for (int y = 0; y < this.GrootteY; y++)
                    {
                        this.Terrarium[x, y] = null;
                    }
                }

                String lcLine = loBestand.ReadLine();
                while (!String.IsNullOrEmpty(lcLine))
                {
                    String[] laCell = lcLine.Split(new[] { ',' });
                    string lcType = "";
                    int lnPosX = 0, lnPosY = 0, lnLevenskracht = 0;

                    if (laCell.Length > 0)
                    {
                        lcType = laCell[0];
                    }
                    else
                    {
                        lcType = "";
                    }
                    if (laCell.Length > 1 && Int32.TryParse(laCell[1], out lnPosX))
                    {
                    }
                    else
                    {
                        lnPosX = 0;
                    }
                    if (laCell.Length > 2 && Int32.TryParse(laCell[2], out lnPosY))
                    {
                    }
                    else
                    {
                        lnPosY = 0;
                    }
                    if (laCell.Length > 3 && Int32.TryParse(laCell[3], out lnLevenskracht))
                    {
                    }
                    else
                    {
                        lnLevenskracht = 0;
                    }

                    switch (lcType.ToUpper())
                    {
                        case "M":
                            Mens loMens = new Mens();
                            loMens.PosX = lnPosX;
                            loMens.PosY = lnPosY;
                            loMens.Levenskracht = lnLevenskracht;
                            mensen.Add(loMens);
                            lnAmAdded++;
                            break;
                        case "C":
                            Carnivoor loCarnivoor = new Carnivoor();
                            loCarnivoor.PosX = lnPosX;
                            loCarnivoor.PosY = lnPosY;
                            loCarnivoor.Levenskracht = lnLevenskracht;
                            carnivoren.Add(loCarnivoor);
                            lnAmAdded++;
                            break;
                        case "H":
                            Herbivoor loHerbivoor = new Herbivoor();
                            loHerbivoor.PosX = lnPosX;
                            loHerbivoor.PosY = lnPosY;
                            loHerbivoor.Levenskracht = lnLevenskracht;
                            herbivoren.Add(loHerbivoor);
                            lnAmAdded++;
                            break;
                        case "P":
                            Plant loPlant = new Plant();
                            loPlant.PosX = lnPosX;
                            loPlant.PosY = lnPosY;
                            loPlant.Levenskracht = lnLevenskracht;
                            planten.Add(loPlant);
                            lnAmAdded++;
                            break;
                        case "SIZE":
                            this.GrootteX = lnPosX;
                            this.GrootteY = lnPosY;
                            this.Terrarium = new IOrganismen[GrootteX, GrootteY];
                            break;

                    }

                    lcLine = loBestand.ReadLine();
                }

                this.AddPlantenToSpeelveld(planten, true);
                this.AddCarnivorenToSpeelveld(carnivoren, true);
                this.AddHerbivorenToSpeelveld(herbivoren, true);
                this.AddMensenToSpeelveld(mensen, true);
            }

            return lnAmAdded;
        }
    }
}
