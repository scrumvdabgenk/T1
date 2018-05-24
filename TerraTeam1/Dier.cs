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

        // constructor
        public Dier()
        {
            this.Naam = "";

        }

        public void Stap(int Xpos, int Ypos)
        {
            this.PosX += Xpos;
            this.PosY += Ypos;

        }
        /// <summary>
        /// Mag enkel bewegen indien de bestemming "." is.
        /// </summary>
        /// <param name="Beweeg"></param>
        public void Beweeg(Speelveld eoSpeelveld)
        {
            for (int teller = 1; teller <= 100; teller++)
            {
                Random rnd = new Random();
                int stap = rnd.Next(1, 4);
                int x = 0;
                int y = 0;

                if (eoSpeelveld.Terrarium[PosX + 1, PosY] == null)
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
                    if (eoSpeelveld.Terrarium[PosX + x, PosY + y] == null)
                    {
                        Stap(x, y);
                        break; //ga uit de loop
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


        public void Delete()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this.Naam;
        }
    }
}
