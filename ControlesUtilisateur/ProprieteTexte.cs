using System;
using System.Drawing;
using System.Windows.Forms;

namespace CollectionDeFilms.ControlesUtilisateur
{
    public class ProprieteTexte : Propriete
    {
        private string _label, _valeur;
        private readonly Size _sLabel;
        private readonly Size _sVal;

        public ProprieteTexte(string label, string value)
        {
            _label = label;
            _valeur = value;
            _sLabel = TextRenderer.MeasureText(_label, _fonte);
            _sVal = TextRenderer.MeasureText(_valeur, _fonte);
        }


        public override void Dessine(Graphics g, RectangleF bounds)
        {
            g.DrawString(_label,_fonte, _brush, bounds.Left, bounds.Top);
            g.DrawString(_valeur, _fonte, _brush, bounds.Left + _xValeur, bounds.Top);
        }

        public override Size getTaille(int largeur)
        {            
            return new Size((int)Math.Max( _sLabel.Width, _xValeur + _sVal.Width), Math.Max(_sLabel.Height, (int)_sVal.Height));
        }

        public override SizeF GetLargeurLabel()
        {
            return _sLabel;
        }
    }
}
