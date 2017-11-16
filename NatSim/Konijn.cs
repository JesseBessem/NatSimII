using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace NatSimII
{
    public class Konijn : Alleseter
    {
        public Konijn() : base(_verhoudingsTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            InitClass(new Point(0, 0), "", Color.Brown);
        }
        public Konijn(Point locatie) : base(_verhoudingsTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            InitClass(locatie, "", Color.Brown);
        }
        public Konijn(Point locatie, string naam, Color kleur) : base(_verhoudingsTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            InitClass(locatie, naam, kleur);
        }

        private void InitClass(Point locatie, string naam, Color kleur)
        {
            Locatie = locatie;
            Naam = naam;
            Kleur = kleur;
            Tekengebied.Afmetingen = new Size(10, 10);
            WordtVergiftigdDoor.Add("Vingerhoedskruid");
            WordtVergiftigdDoor.Add("Venijnboom");
            Gewicht = 5;
            Voedingswaarde = 1;
        }

        private const string _latijnseNaam = "Oryctolagus ciniculus";
        private const int _leeftijd = 9;
        private const int _verhoudingsTicksJaren = 1;
        private const double _gewichtMaximaal = 10;

        public string Naam { get; set; }
        public double Gewicht { get; set; }
        public DateTime Geboortedatum { get; set; }
        public DateTime Sterfdatum { get; set; }
    }
}
