using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                SizeF s = TextRenderer.MeasureText(_texte, f);
                return new Size((int)s.Width, (int)s.Height);
            }
        }

        public const int MARGE = 3;
        private string _label;
        private Size _tailleLabel;
        private Link[] _links;
        private Font _fonteLink;
        static Brush _brushOver;
        static Brush _brushVisite;
        static Brush _brushNonVisite;
        static Pen _penHover;

        static ProprieteLink()
        {
            _brushOver = new SolidBrush(Color.FromArgb(255, 170, 210, 238));
            _brushVisite = new SolidBrush(Color.FromArgb(255, 128, 0, 128));
            _brushNonVisite = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
            _penHover = new Pen(Color.Black);
            _penHover.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        }

        public ProprieteLink(string label, Link[] links)
        {
            _label = label;
            _links = links;
        }

        public override void setFont(Font f, Brush b)
        {
            base.setFont(f, b);
            _fonteLink = new Font(_fonte.FontFamily, _fonte.Size, _fonte.Style | FontStyle.Underline);

            _tailleLabel = TextRenderer.MeasureText(_label, _fonte);
        }

        public override void SetLargeurLabel(float xValeur, int largeurTotale)
        {
            base.SetLargeurLabel(xValeur, largeurTotale);
            CalculeRectangles();
        }

        /// <summary>
        /// Dessine l'ensemble de la propriete
        /// </summary>
        /// <param name="g"></param>
        /// <param name="bounds"></param>
        public override void Dessine(Graphics g, RectangleF bounds)
        {
            //g.DrawRectangle(Pens.Aqua, _rectangle);

            g.DrawString(_label, _fonte, _brush, bounds.Left, bounds.Top);

            foreach (Link l in _links)
            {
                if (l._hover)
                {
                    g.FillRectangle(_brushOver, l._rect.Left, l._rect.Top, l._rect.Width, l._rect.Height);
                    g.DrawRectangle(_penHover, l._rect.Left, l._rect.Top, l._rect.Width, l._rect.Height);
                }
                g.DrawString(l._texte, _fonteLink, l._visite ? _brushVisite : _brushNonVisite, l._rect.Left, l._rect.Top);
            }
        }

        private int CalculeRectangles()
        {
            int x = 0;
            int hauteurTotale = (int)TextRenderer.MeasureText(_label, _fonte).Height;
            foreach (Link l in _links)
            {
                Size s = l.CalculeTaille(_fonte);
                l._rect = new Rectangle(_rectangle.Left + (int)_xValeur + x, _rectangle.Top, s.Width, s.Height);
                x += s.Width + MARGE;
            }

            return hauteurTotale;
        }
        public override void SetRectangle(Rectangle r)
        {
            base.SetRectangle(r);
            CalculeRectangles();
        }

        public override Size getTaille(int largeur)
        {
            int hauteur = CalculeRectangles();

            return new Size(largeur, hauteur);
        }

        public override Cursor OnMouseMove(RectangleF bounds, float X, float Y, out bool invalidate)
        {
            Cursor c = null;
            invalidate = false;
            foreach (Link l in _links)
            {
                if (l._rect.Contains((int)X, (int)Y))
                {
                    if (l._hover != true)
                        invalidate = true;
                    l._hover = true;
                    c = Cursors.Hand;
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

        public override SizeF GetLargeurLabel()
        {
            return _tailleLabel;
        }

        internal override bool OnClick(RectangleF rProp, float X, float Y)
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
