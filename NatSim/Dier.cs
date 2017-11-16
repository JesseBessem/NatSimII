using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NatSimII
{
    public abstract class Dier : Leven, IBewegendObject
    {
        // constructor
        public Dier(int verhoudingsTicksJaren, string latijnseNaam, int levensduur, double gewichtMaximaal)
            : base(verhoudingsTicksJaren, latijnseNaam, levensduur)
        {
            InitDier(gewichtMaximaal);
        }
        // initialisatie
        private void InitDier(double gewichtMaximaal)
        {
            _gewichtMaximaal = gewichtMaximaal;
            WordtVergiftigdDoor = new List<string>();
        }

        // private variablen
        private double _gewichtMaximaal = 0;
        // Eigenschappen voor alle dieren
        public int MaagGevuld { get; set; }
        public int SpijsverteringsDuur { get; set; }
        public double GewichtMaximaal { get { return _gewichtMaximaal;  } }
        public List<string> WordtVergiftigdDoor { get; set; }
        public Snelheid SnelheidObect { get; set; }
        public Snelheid SnelheidsObject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        System.Windows.Forms.Timer IBewegendObject.Klok { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // Methoden
        public abstract void Eet(Leven leven);
        public bool Honger()
        {
            return (MaagGevuld < 25);
        }

        public Point Stap()
        {
            return Stap(this.SnelheidsObject);
            // waar komt object terecht
            int berekendeX = Locatie.X + (SnelheidsObject.X);
            int berekendeY = Locatie.Y + (SnelheidsObject.Y);
            // bepalen van het nieuwe tekengebied waar het object getekend gaat worden
            Rechthoek nieuwTekengebied =
                new Rechthoek(new Point(berekendeX, berekendeY), Tekengebied.Afmetingen);

            Vlak vlak = Rechthoek.GrensBereikt(nieuwTekengebied, GraphicsVenster);

            SnelheidsObject = SnelheidsObject.Stuiter(vlak);

            berekendeX = Locatie.X + (SnelheidsObject.X);
            berekendeY = Locatie.Y + (SnelheidsObject.Y);

            return new Point(berekendeX, berekendeY);

        }

        public Point Stap(Snelheid SnelheidsObject)
        {
            throw new NotImplementedException();
        }
    }
}
