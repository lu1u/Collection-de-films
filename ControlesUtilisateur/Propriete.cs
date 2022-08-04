using System.Drawing;
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

        public virtual void SetRectangle(Rectangle r)
        {
            _rectangle = r;
        }



        public virtual void Resize(int Largeur)
        {

        }

        public abstract Size getTaille(int Largeur, ListeProprietes.Attributs attributs);
        public abstract void Dessine(Graphics g, RectangleF bounds, ListeProprietes.Attributs attributs);

        /// <summary>
        /// Evenement Mouse Move
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="invalidate">Mettre a true si on doit reafficher, ne pas toucher sinon</param>
        /// <returns></returns>
        public virtual Cursor OnMouseMove(float X, float Y, ref bool invalidate) { return null; }

        public virtual void SetLargeurLabel(float x, int largeurTotale)
        {
            _xValeur = x;
        }

        // Calcule la taille de la premiere colonne de la propriete (permettra d'aligner toutes les deuxiemes colonnes)
        public abstract SizeF GetLargeurLabel(ListeProprietes.Attributs attributs);

        internal virtual bool OnClick(float v1, float v2)
        {
            return false;
        }
    }
}
