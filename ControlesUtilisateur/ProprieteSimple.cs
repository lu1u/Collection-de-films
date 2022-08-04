using System;
using System.Drawing;

namespace CollectionDeFilms.ControlesUtilisateur
{
    class ProprieteSimple : Propriete
    {
        private string _label;

        public ProprieteSimple(string label)
        {
            _label = label;
        }

        public override void Dessine(Graphics g, RectangleF bounds, ListeProprietes.Attributs attributs)
        {
            g.DrawString(_label, attributs._fonte, attributs._BrushText, bounds);
        }

        public override SizeF GetLargeurLabel(ListeProprietes.Attributs attributs)
        {
            return new SizeF(0, 0);
        }

        public override Size getTaille(int largeur, ListeProprietes.Attributs attributs)
        {
            Graphics g = Graphics.FromHwnd((IntPtr)0);
            SizeF s = g.MeasureString(_label, attributs._fonte, largeur);
            return new Size((int)s.Width, (int)s.Height + attributs._interligne);
        }
    }
}
