using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NatSimII
{
    public class Rechthoek
    {
        // meetkundige rechthoek bestaat uit 4 punten A, B, C en D
        // A 10, 4 ---------------------B 30, 4
        // |                                        |
        // |                                        |
        // |                                        |
        // C 10, 26--------------------D 30, 26
        // Alleen A nodig (de plek waar geklikt wordt, de overige punten berekenen met hoogte en    // breedte

        // properties
        public Size Afmetingen { get; set; }
        public Point A { get; set; }
        public Point Locatie { get { return A; } set { A = value; } } // is een alias voor A
        // constructors
        public Rechthoek() { }
        public Rechthoek(Point locatie, Size afmetingen) { }
        // readonly props
        public int Breedte { get { return Afmetingen.Width; } }
        public int Hoogte { get { return Afmetingen.Height; } }
        public Point B { get { return new Point(A.X + Breedte, A.Y); } }
        public Point C { get { return new Point(A.X + A.Y + Hoogte, A.Y); } }
        public Point D { get { return new Point(B.X, A.Y); } }

        // Static method om te bepalen of 2 objecten van het type rechthoek
        // elkaar raken (wereld en dier/plant). De method kan static zijn omdat alle parameters worden
        // meegegeven aan de method.
        public static Vlak GrensBereikt(Rechthoek r1, Rechthoek r2)
        {
            Vlak vlak = Vlak.Geen;
            // overschrijden linker of rechterkant
            if (r1.A.X <= r2.A.X || r1.B.X >= r2.B.X)
            {
                vlak = Vlak.Verticaal;
            }
            // overschrijden onder of bovenrand
            if (r1.A.Y <= r2.A.Y || r1.C.Y >= r2.C.Y)
            {

                if (vlak == Vlak.Verticaal)
                {
                    vlak = Vlak.Hoek;
                }
                else
                {
                    vlak = Vlak.Horizontaal;
                }
            }
            return vlak;
        }

        // raakt de meegegeven rechthoek de huidige instantie van Rechthoek?
        public Vlak GrensBereikt(Rechthoek r2)
        {
            // r1 is de huidige instantie van Rechthoek -> this
            return GrensBereikt(this, r2);
        }

        // valt de meegegeven rechthoek helemaal binnen de afmetingen
        // van de huidige instantie van de rechthoek
        public bool Overlap(Rechthoek rechthoek)
        {
            return ((rechthoek.D.X >= A.X && rechthoek.A.X <= D.X) &&
                    (rechthoek.D.Y >= A.Y && rechthoek.A.Y <= D.Y));
        }

        // omzetten naar VS object Rectangle
        public Rectangle ToRectangle()
        {
            return new Rectangle(Locatie, Afmetingen);
        }

        // om het object herbruikbaar te maken
        public int Oppervlakte()
        {
            return Hoogte * Breedte;
        }
        public int Omtrek()
        {
            return 2 * (Hoogte * Breedte);
        }

    }
}
