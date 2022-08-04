using System.Drawing;

namespace CollectionDeFilms.ControlesUtilisateur
{
    class ProprieteImage : Propriete

    {
        private Image _image;
        public ProprieteImage(Image image)
        {
            if (image == null)
                _image = Resources.film_non_trouve;
            else
                _image = image;
        }

        public override void Dessine(Graphics g, RectangleF bounds, ListeProprietes.Attributs attributs)
        {
            Rectangle rImage = new Rectangle((int)(bounds.Left + (bounds.Width - _image.Width) / 2.0f), (int)(bounds.Top + (bounds.Height - _image.Height) / 2.0f), _image.Width, _image.Height);
            rImage.Inflate(attributs._interligne, attributs._interligne);
            g.FillRectangle(attributs._BrushDeuxieme, rImage);
            rImage.Inflate(-attributs._interligne, -attributs._interligne);
            g.DrawImage(_image, rImage);
        }

        public override SizeF GetLargeurLabel(ListeProprietes.Attributs attributs)
        {
            return new SizeF(0, 0);
        }

        public override Size getTaille(int Largeur, ListeProprietes.Attributs attributs)
        {
            return new Size(_image.Width, _image.Height + (attributs._interligne * 4));
        }
    }
}
