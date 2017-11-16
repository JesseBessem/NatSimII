using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatSimII
{
    public abstract class Planteneter : Dier
    {
        public Planteneter(int verhoudingsTicksJaren, string latijnseNaam, int levensduur, double gewichtMaximaal) : base(verhoudingsTicksJaren, latijnseNaam, levensduur, gewichtMaximaal) { }

        public override void Eet(Leven leven)
        {
            if(leven.IsPlant)
            {
                if(WordtVergiftigdDoor.Contains(leven.NederlandseNaam))
                {
                    if(Honger())
                    {
                        this.Sterf();
                        leven.Sterf();
                    }
                    else
                    {
                        SnelheidsObject = SnelheidsObject.KeerOm();
                    }
                }
                else if (MaagGevuld < 75)
                {
                    MaagGevuld = MaagGevuld + leven.Voedingswaarde;
                    leven.Sterf();
                }
            }
            else
            {
                SnelheidsObject = SnelheidsObject.KeerOm();
            }
        }
    }
}
