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
