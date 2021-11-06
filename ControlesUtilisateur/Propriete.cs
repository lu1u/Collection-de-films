using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionDeFilms.ControlesUtilisateur
{
    // Classe de base pour les proprietes
    public abstract class Propriete
    {
        protected float _xValeur = 10;
        protected Font _fonte;
        protected Brush _brush;
        protected Rectangle _rectangle;
        public Propriete()
        {

        }

        public virtual void SetRectangle( Rectangle r)
        {
            _rectangle = r;
        }

        public virtual void setFont(Font f, Brush b)
        {
            _fonte = f;
            _brush = b;
        }

        public virtual void Resize( int Largeur )
        {

        }

        public abstract Size getTaille(int Largeur);
        public abstract void Dessine(Graphics g, RectangleF bounds);
        public virtual Cursor OnMouseMove(RectangleF bounds, float X, float Y, out bool invalidate ) { invalidate = false;  return null; }

        public virtual void SetLargeurLabel(float x, int largeurTotale)
        {
            _xValeur = x;
        }

        public abstract SizeF GetLargeurLabel();

        internal virtual bool OnClick(RectangleF rProp, float v1, float v2)
        {
            return false;
        }
    }
}
