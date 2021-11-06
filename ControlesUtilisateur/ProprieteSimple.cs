using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionDeFilms.ControlesUtilisateur
{
    class ProprieteSimple : Propriete
    {
        private string _label ;
        private SizeF _sLabel;
        private StringFormat _format;

        public ProprieteSimple(string label)
        {
            _label = label;
            _sLabel = TextRenderer.MeasureText(label, _fonte);
            _format = new StringFormat(StringFormatFlags.DisplayFormatControl);
        }

        public override void Dessine(Graphics g, RectangleF bounds)
        {
            g.DrawString(_label, _fonte, _brush, bounds, _format );
        }

        public override SizeF GetLargeurLabel()
        {
            return new SizeF(0,0) ;
        }

        public override Size getTaille(int largeur)
        {
            using(Graphics g = Graphics.FromHwnd((IntPtr)0))
                _sLabel = g.MeasureString(_label, _fonte, largeur);

            return new Size((int)_sLabel.Width, (int)_sLabel.Height);
        }
    }
}
