using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

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
        public Snelheid SnelheidObject { get; set; }

        // Methoden
        public abstract void Eet(Leven leven);
        public bool Honger()
        {
            return (MaagGevuld < 25);
        }

        public Snelheid SnelheidsObject { get; set; }
        public Timer Klok { get; set; }

        public Point Stap()
        {
            return Stap(this.SnelheidObject);
        }

        public Point Stap( Snelheid snelheidsObject )
        {
            this.SnelheidObject = snelheidsObject;
            // waar komt het object terecht bij de stap?
            int berekendeX = Locatie.X + ( snelheidsObject.X );
            int berekendeY = Locatie.Y + ( snelheidsObject.Y );
            // bepalen van het nieuwe tekengebied waar het object getekend gaat worden
            Rechthoek nieuwTekenGebied = new Rechthoek(new Point(berekendeX, berekendeY), Tekengebied.Afmetingen);
            // Berekenen van een nieuwe richting nav een eventuele overschrijding van een grens

            Vlak vlak = Rechthoek.GrensBereikt(nieuwTekenGebied, GraphicsVenster);
            // berekenen van een nieuwe ichting als het object een rand tegenekomt
            snelheidsObject = snelheidsObject.Stuiter(vlak);
            // opnieuw berekenen van de snelheid zodat een wijziging van de richting meegenomen wordt
            berekendeX = Locatie.X + ( snelheidsObject.X );
            berekendeY = Locatie.Y + ( snelheidsObject.Y );

            return new Point(berekendeX, berekendeY);
        }

        public void Beweeg()
        {
            Verwijder();
            Locatie = Stap();
            Teken();
        }
    }
}
