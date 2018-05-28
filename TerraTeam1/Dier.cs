using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraTeam1
{
    public abstract class Dier : IOrganismen
    {
        private string naamValue;
        private int posxValue;
        private int posyValue;
        private int levenskrachtValue;
        private int totaantStappenValue;
        private bool isDeletedValue;

        // constructor
        public Dier()
        {
            this.Naam = "";

        }

        public void Stap(int Xpos, int Ypos, Speelveld eoSpeelveld)
        {
            eoSpeelveld.Terrarium[this.PosX, this.PosY] = null;

            this.PosX += Xpos;
            this.PosY += Ypos;

            eoSpeelveld.Terrarium[this.PosX, this.PosY] = this;
        }

        /// <summary>
        /// Mag enkel bewegen indien de bestemming "." is.
        /// </summary>
        /// <param name="Beweeg"></param>
        public void Beweeg(Speelveld eoSpeelveld)
        {
            if (this.TotAantStappen <= 0)
            {
                Random rnd = new Random();
                for (int teller = 1; teller <= 100; teller++)
                {
                    int stap = rnd.Next(1, 5);
                    int x = 0;
                    int y = 0;

                    //if (PosX + 1 >= eoSpeelveld.GrootteX || eoSpeelveld.Terrarium[PosX + 1, PosY] == null)
                    {
                        switch (stap)
                        {
                            case 1:
                                x = 1;
                                y = 0;
                                if (PosX + 1 > eoSpeelveld.GrootteX)
                                {
                                    x = 0;
                                }
                                break;
                            case 2:
                                x = 0;
                                y = 1;
                                if (PosY + 1 > eoSpeelveld.GrootteY)
                                {
                                    y = 0;
                                }
                                break;
                            case 3:
                                x = -1;
                                y = 0;
                                if (PosX - 1 < 0)
                                {
                                    x = 0;
                                }
                                break;
                            case 4:
                                x = 0;
                                y = -1;
                                if (PosY - 1 < 0)
                                {
                                    y = 0;
                                }
                                break;
                            default:
                                break;
                        }
                        if (PosX + x < eoSpeelveld.GrootteX && PosY + y < eoSpeelveld.GrootteY)
                        {

                            if (eoSpeelveld.Terrarium[PosX + x, PosY + y] == null || eoSpeelveld.Terrarium[PosX + x, PosY + y].Naam.ToUpper() == "P")
                            {
                                Stap(x, y, eoSpeelveld);
                                break; //ga uit de loop
                            }
                        }
                    }
                }
            }
        }

        public virtual void Eet(Speelveld eoSpeelveld)
        {
            
        }

        public int TotAantStappen
        {
            get { return totaantStappenValue; }
            set { totaantStappenValue = value; }
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

        public int PosX
        {
            get
            {
                return this.posxValue;
            }

            set
            {
                this.posxValue = value;
            }
        }

        public int PosY
        {
            get
            {
                return this.posyValue;
            }

            set
            {
                this.posyValue = value;
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
            //throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this.Naam;
        }
    }
}
