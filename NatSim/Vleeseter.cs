using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatSimII
{
    public abstract class Vleeseter : Dier
    {
        public Vleeseter(int verhoudingsTicksJaren, string latijnseNaam, int levensduur, double gewichtMaximaal) : base(verhoudingsTicksJaren, latijnseNaam, levensduur, gewichtMaximaal) { }

        public override void Eet(Leven leven)
        {
            if(leven.IsDier)
            {
                if (Honger())
                {
                    if (leven.Tekengebied.Breedte * leven.Tekengebied.Hoogte < this.Tekengebied.Breedte * this.Tekengebied.Hoogte)
                    {
                        leven.Sterf();
                    }
                    else
                    {
                        SnelheidsObject = SnelheidsObject.KeerOm();
                    }
                }
            }
        }
    }
}
