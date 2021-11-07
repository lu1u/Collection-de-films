using System;
using System.Drawing;
using System.Windows.Forms;

namespace CollectionDeFilms.ControlesUtilisateur
{
    public class ProprieteTexte : Propriete
    {
        private string _label, _valeur;

        public ProprieteTexte(string label, string value)
        {
            _label = label;
            _valeur = value;
        }


        public override void Dessine(Graphics g, RectangleF bounds, ListeProprietes.Attributs attributs)
        {
            g.DrawString(_label, attributs._fonte, attributs._BrushText, bounds.Left, bounds.Top);
            g.DrawString(_valeur, attributs._fonte, attributs._BrushText, bounds.Left + _xValeur, bounds.Top);
        }

        public override Size getTaille(int largeur, ListeProprietes.Attributs attributs)
        {
            SizeF label = TextRenderer.MeasureText(_label, attributs._fonte);
            SizeF texte = TextRenderer.MeasureText(_valeur, attributs._fonte);
            return new Size((int)(label.Width + texte.Width), (int)Math.Max( label.Height, texte.Height) + attributs._interligne);
        }

        public override SizeF GetLargeurLabel(ListeProprietes.Attributs attributs)
        {
            return TextRenderer.MeasureText(_label, attributs._fonte);
        }
    }
}
