using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatSimII
{
    public abstract class Alleseter : Dier
    {
        public Alleseter(int verhoudingsTicksJaren, string latijnseNaam, int levensduur, double gewichtMaximaal) : base(verhoudingsTicksJaren, latijnseNaam, levensduur, gewichtMaximaal) { }

        public override void Eet(Leven leven)
        {
            
        }
    }
}
