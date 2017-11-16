using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatSimII
{
    public abstract class Plant : Leven
    {
        //
        // Initialisatie
        //
        public Plant() { }
        public Plant(int verhoudingsTicksJaren, string latijnseNaam,
                     int levensduur, Bloeiwijze bloeiwijzePlant)
            : base(verhoudingsTicksJaren, latijnseNaam, levensduur)
        {
            BloeiwijzePlant = bloeiwijzePlant;
        }
        //
        // Eigenschappen
        //
        public Bloeiwijze BloeiwijzePlant { get; set; }
    }
}