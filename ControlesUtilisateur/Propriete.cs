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
        protected Rectangle _rectangle;
        public Propriete()
        {

        }

        public virtual void SetRectangle( Rectangle r)
        {
            _rectangle = r;
        }



        public virtual void Resize( int Largeur )
        {

        }

        public abstract Size getTaille(int Largeur, ListeProprietes.Attributs attributs);
        public abstract void Dessine(Graphics g, RectangleF bounds, ListeProprietes.Attributs attributs);
        public virtual Cursor OnMouseMove(float X, float Y, ref bool invalidate ) {  return null; }

        public virtual void SetLargeurLabel(float x, int largeurTotale)
        {
            _xValeur = x;
        }

        public abstract SizeF GetLargeurLabel(ListeProprietes.Attributs attributs);

        internal virtual bool OnClick(float v1, float v2)
        {
            return false;
        }
    }
}
