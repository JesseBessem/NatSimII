using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NatSimII
{
    public abstract class Leven : GrafischObject
    {
        public Leven()
        {
            initClass(1, "", int.MaxValue);
        }
        public Leven(int verhoudingsTicksJaren, string latijseNaam, int levensduur)
        {
            initClass(verhoudingsTicksJaren, latijseNaam, levensduur);
        }

        private void initClass(int verhoudingsTicksJaren, string latijnseNaam, int levensduur)
        {
            VerhoudingsTicksJaren = verhoudingsTicksJaren;
            _latijnseNaam = latijnseNaam;
            _levensduur = levensduur;
            _verouder = new Timer();
            _verouder.Interval = _aantalTicksPerSeconde * VerhoudingsTicksJaren;
            _verouder.Start();
            _verouder.Tick += _verouder_Tick;
        }

        private void _verouder_Tick( object sender, EventArgs e )
        {
            if ( Leeftijd < Levensduur )
            {
                Leeftijd++;
            }
            else
            {
                _verouder.Stop();
                Sterf();
            }
        }

        // internal variablen
        private const int _aantalTicksPerSeconde = 1000;
        private string _latijnseNaam;
        private double _levensduur;
        private Timer _verouder;

        // Eigenschappen
        public int Leeftijd { get; set; }
        public int VerhoudingsTicksJaren { get; set; }
        public int Voedingswaarde { get; set; }

        // Readonly eigenschappen
        public string LatijnseNaam { get { return _latijnseNaam; } }
        public double Levensduur { get { return _levensduur; } }
        public string NederlandseNaam { get { return this.ToString().Split('.').Last(); } }
        public Timer Verouder { get { return _verouder; } }

        // Methoden
        public void Sterf()
        {
            Verwijder();
            MessageBox.Show("IS DOOD!", this.NederlandseNaam);
        }
        public bool IsPlant
        {
            get { return this.GetType().IsSubclassOf(typeof(Plant)); }
        }
        public bool IsDier
        {
            get { return this.GetType().IsSubclassOf(typeof(Dier)); }
        }
    }
}
