using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collection_de_films.Fenetres
{
    public partial class Splashscreen : Form
    {
        int _pourcent;
        public Splashscreen()
        {
            InitializeComponent();
        }

        public void setPourcent(int pourcent)
        {
            this._pourcent = pourcent;
            Invalidate();
            Update();
        }

        private void Splashscreen_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = ClientRectangle;

            rect.Inflate(-10, -10);
            rect = new Rectangle(rect.Left, rect.Bottom - 20, rect.Width, 10);
            using (Brush b = new SolidBrush(Color.FromArgb(150, 255, 255, 255)))
                e.Graphics.FillRectangle(b, rect);

            rect.Inflate(-1, -1);
            rect = new Rectangle(rect.Left, rect.Bottom - rect.Height, (int)(rect.Width * _pourcent / 100.0f), rect.Height);
            using (Brush b = new SolidBrush(Color.FromArgb(200, 255, 255, 255)))
                e.Graphics.FillRectangle(b, rect);

        }
    }
}
