using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NatSimII
{
    interface IBewegendObject
    {
        // public vars
        Snelheid SnelheidsObject { get; set; }
        Timer Klok { get; set; }

        // Methods
        Point Stap();
        Point Stap(Snelheid SnelheidsObject);
    }
}
