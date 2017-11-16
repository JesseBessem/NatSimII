using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Windows.Forms;

namespace NatSimII
{
    public class Natuur : List<Leven>
    {
        readonly Timer _levensKlok = new Timer();
        public new void Add(Leven leven)
        {
            if ( leven.IsDier )
            {
                Random rand = new Random();
                Snelheid snelheid = new Snelheid(rand.Next(-4, 4), rand.Next(-4, 4));
                ( (Dier)leven ).SnelheidObect = snelheid;
            }
            base.Add(leven);
        }

        public Natuur() : base()
        {
            _levensKlok.Start();
            _levensKlok.Tick += _levensKlok_Tick;
            _levensKlok.Interval = 10;
        }

        public void _levensKlok_Tick(object sender, EventArgs e)
        {
            foreach ( Leven leven in this )
            {
                if (leven.IsDier)
                {
                    ( (Dier) leven ).Beweeg();
                }
            }
        }
    }
}
