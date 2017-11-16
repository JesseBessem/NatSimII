using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NatSimII
{
    public partial class frmNatSimII : Form
    {
        //
        // Initialisatie
        //
        Graphics papier;

        public frmNatSimII()
        {
            InitializeComponent();
            papier = pbWereld.CreateGraphics();
        }

        private void ResizePictureBox() {
            // Deze methode zorgt ervoor dat de grootte van de picturebox
            // aangepast wordt als het formulier geresized wordt

            int margeBreedte = 40;
            int margeHoogte = 64;

            pbWereld.Width = this.Width - grbDieren.Width - grbPlanten.Width - margeBreedte;
            pbWereld.Height = this.Height - margeHoogte;
            pbWereld.CreateGraphics();
        }

        private void ResizeLblInformatie() {
            // Deze methode zorgt ervoor dat de hoogte van het label
            // aangepast wordt als het formulier geresized wordt

            int margeHoogte = 88;

            lblInformatie.Height = this.Height - margeHoogte - pnlKnoppen.Height;
        }

        private void frmNatSim_Resize(object sender, EventArgs e)
        {
            // methodes voor resizen picturebox en lbl aanroepen
            ResizePictureBox();
            ResizeLblInformatie();
        }

        private void pbWereld_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TekenDier(e.Location);
            }
            else if (e.Button == MouseButtons.Right) {
                TekenPlant(e.Location);
            }
        }
        private void TekenDier(Point locatie)
        {
            if (rdbKonijn.Checked == true)
            {
                Konijn konijn1 = new Konijn(locatie, "Flappie", Color.Red);
                konijn1.Teken(pbWereld.CreateGraphics());
            }
            else if (rdbKoe.Checked == true) {
                Koe koe1 = new Koe(locatie, "Berta1", Color.Brown);
                koe1.Teken(pbWereld.CreateGraphics());
            }
        }
        private void TekenPlant(Point locatie)
        {
            if (rdbGras.Checked == true)
            {
                Gras gras1 = new Gras(locatie);
                gras1.Teken(pbWereld.CreateGraphics());
            }
            else if (rdbVenijnBoom.Checked == true)
            {
                Venijnboom boom1 = new Venijnboom(locatie);
                boom1.Teken(pbWereld.CreateGraphics());
            }
        }

        private void pbWereld_Click(object sender, EventArgs e)
        {

        }
    }
}
