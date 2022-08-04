using System;
using System.Drawing;
using System.Windows.Forms;

namespace CollectionDeFilms.ControlesUtilisateur
{
    public class ProprieteLink : Propriete
    {
        public delegate void onClickLink(string link);
        public class Link
        {
            public bool _visite;
            public string _texte;
            public string _link;
            public onClickLink onClick;
            public bool _hover;
            public Rectangle _rect;

            public Link(string texte, string link, onClickLink deleg)
            {
                _visite = false;
                _hover = false;
                _texte = texte;
                _link = link;
                onClick = deleg;
            }

            public Size CalculeTaille(Font f)
            {
                Graphics g = Graphics.FromHwnd((IntPtr)0);
                SizeF s = g.MeasureString(_texte, f);
                return new Size((int)s.Width, (int)s.Height);
            }
        }

        public const int MARGE = 3;
        private string _label;
        private Link[] _links;
        private Font _fonteLink;


        public ProprieteLink(string label, Link[] links)
        {
            _label = label;
            _links = links;
        }

        public override void SetLargeurLabel(float xValeur, int largeurTotale)
        {
            base.SetLargeurLabel(xValeur, largeurTotale);
        }

        /// <summary>
        /// Dessine l'ensemble de la propriete
        /// </summary>
        /// <param name="g"></param>
        /// <param name="bounds"></param>
        public override void Dessine(Graphics g, RectangleF bounds, ListeProprietes.Attributs attributs)
        {
            if (_fonteLink == null)
                _fonteLink = new Font(attributs._fonte, FontStyle.Underline);
            //g.DrawRectangle(Pens.Aqua, _rectangle);

            g.DrawString(_label, attributs._fonte, attributs._BrushText, bounds.Left, bounds.Top);

            foreach (Link l in _links)
            {
                if (l._hover)
                {
                    Rectangle rLink = new Rectangle(l._rect.Left, l._rect.Top, l._rect.Width, l._rect.Height);
                    rLink.Inflate(2, 2);

                    g.FillRectangle(attributs._BrushHover, rLink);
                    g.DrawRectangle(attributs._penHover, rLink);
                }
                g.DrawString(l._texte, _fonteLink, l._visite ? attributs._BrushVisite : attributs._BrushLien, l._rect.Left, l._rect.Top);
            }
        }

        private int CalculeRectangles(Font fonte)
        {
            int x = 0;
            int hauteurTotale = (int)TextRenderer.MeasureText(_label, fonte).Height;
            foreach (Link l in _links)
            {
                Size s = l.CalculeTaille(fonte);
                l._rect = new Rectangle(_rectangle.Left + (int)_xValeur + x, _rectangle.Top, s.Width, s.Height);
                x += s.Width + MARGE;
            }

            return hauteurTotale;
        }
        public override void SetRectangle(Rectangle r)
        {
            base.SetRectangle(r);
        }

        public override Size getTaille(int largeur, ListeProprietes.Attributs attributs)
        {
            int hauteur = CalculeRectangles(attributs._fonte);

            return new Size(largeur, hauteur + attributs._interligne);
        }

        public override Cursor OnMouseMove(float X, float Y, ref bool invalidate)
        {
            Cursor c = null;

            foreach (Link l in _links)
            {
                if (l._rect.Contains((int)X, (int)Y))
                {
                    if (l._hover != true)
                        invalidate = true;
                    l._hover = true;
                    c = Cursors.Hand;
                    break;
                }
                else
                {
                    if (l._hover != false)
                        invalidate = true;
                    l._hover = false;
                }
            }

            return c;
        }

        public override SizeF GetLargeurLabel(ListeProprietes.Attributs attributs)
        {
            return TextRenderer.MeasureText(_label, attributs._fonte);
        }

        internal override bool OnClick(float X, float Y)
        {
            foreach (Link l in _links)
            {
                if (l._rect.Contains((int)X, (int)Y))
                {
                    l.onClick?.Invoke(l._link);
                    l._visite = true;
                    return true;
                }
            }
            return false;
        }
    }
}
