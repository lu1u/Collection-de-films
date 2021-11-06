using CollectionDeFilms.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CollectionDeFilms.Films
{
    public partial class Film
    {
        static PointF[][] MOSAIQUES = // Position des images des alternatives pour faire une jolie mosaique en fonction du nombre (comme des points sur un dé)
        {
            new PointF[] { },                                                       // Zero alternatives, ne devrait jamais etre utilisee, mais simplifie le traitement
            new PointF[] {new PointF(0.5f, 0.5f) },                                 // Une alternative
            new PointF[] {new PointF(0.5f, 0.25f), new PointF(0.5f, 0.75f) },       // Deux alternatives
            new PointF[] {new PointF(0.33f, 0.33f), new PointF(0.5f, 0.5f), new PointF(0.66f, 0.66f) },     // Trois
            new PointF[] {new PointF(0.25f, 0.25f), new PointF(0.75f, 0.25f), new PointF(0.25f, 0.75f), new PointF(0.75f, 0.75f) },     // Quatre
            new PointF[] {new PointF(0.25f, 0.25f), new PointF(0.75f, 0.25f), new PointF(0.5f, 0.5f), new PointF(0.25f, 0.75f), new PointF(0.75f, 0.75f) },     // Cinq
            new PointF[] {  new PointF(0.3f, 0.25f), new PointF(0.7f, 0.25f),
                            new PointF(0.3f, 0.5f), new PointF(0.7f, 0.5f),
                            new PointF(0.3f, 0.75f), new PointF(0.7f, 0.75f) },     // Six

            new PointF[] {new PointF(0.25f, 0.25f), new PointF(0.75f, 0.25f),
                            new PointF(0.2f, 0.5f), new PointF(0.5f,0.5f), new PointF(0.8f, 0.5f),
                        new PointF(0.25f, 0.75f), new PointF(0.75f, 0.75f) },     // Sept

            new PointF[] {  new PointF(0.25f, 0.125f), new PointF(0.75f, 0.125f),
                            new PointF(0.3f, 0.3f), new PointF(0.7f, 0.3f),
                            new PointF(0.25f, 0.5f), new PointF(0.75f, 0.5f),
                            new PointF(0.3f, 0.6f), new PointF(0.7f, 0.6f),
                            new PointF(0.25f, 0.75f), new PointF(0.75f, 0.75f)},     // Huit

            new PointF[] {  new PointF(0.25f, 0.125f), new PointF(0.75f, 0.125f),
                            new PointF(0.2f, 0.3f), new PointF(0.8f, 0.3f),
                            new PointF(0.2f, 0.5f), new PointF(0.5f, 0.35f), new PointF(0.8f, 0.5f),
                            new PointF(0.25f, 0.6f), new PointF(0.75f, 0.6f),
                            new PointF(0.25f, 0.75f), new PointF(0.75f, 0.75f)},     // Neuf
            };

        static float[] TAILLES = // Tailles des images en fonction du nombre
        {
            1.0f, 0.75f, 0.5f, 0.3f, 0.4f, 0.33f, 0.2f, 0.25f, 0.25f, 0.25f
        };

        /// <summary>
        /// Dessine une image representant les alternatives d'un film
        /// </summary>
        /// <param name="film"></param>
        /// <param name="bounds"></param>
        /// <returns></returns>
        public Image getimageAlternatives(Rectangle bounds)
        {
            List<InfosFilm> alternatives = Alternatives().Where(s => s._image != null).Take(MOSAIQUES.Length).ToList<InfosFilm>();
            if (alternatives == null)
                return null;
            if (alternatives.Count == 0)
                return ImagesUtils.copie(Resources.film_alternatives);

            Image newImage = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                int nbImages = alternatives.Count;
                float taille = TAILLES[nbImages] * bounds.Width;
                // La forme de la mosaique depend du nombre d'alternatives
                PointF[] positions = MOSAIQUES[nbImages];
                for (int i = 0; i < nbImages; i++)
                {
                    using (Image image = ImagesUtils.ombre(alternatives[i]._image, 10))
                        g.DrawImage(image, (MOSAIQUES[nbImages][i].X * bounds.Width) - (taille / 2), (MOSAIQUES[nbImages][i].Y * bounds.Height) - (taille / 2), taille, taille);
                }

                // MOSAIQUE
                //int nbImages = alternatives.Count;
                //if (nbImages == 0)
                //    return null;
                //
                //int NB_COLONNES = (int)(Math.Ceiling(Math.Sqrt(nbImages)));
                //int NB_LIGNES = ((nbImages + NB_COLONNES - 1) / NB_COLONNES);
                //
                //int LARGEUR_COLONNE = bounds.Width / NB_COLONNES;
                //int HAUTEUR_COLONNE = bounds.Height / NB_LIGNES;
                //
                //for (int i = 0; i < alternatives.Count; i++)
                //{
                //    int y = ((i + NB_COLONNES - 1) / NB_COLONNES) * LARGEUR_COLONNE;
                //    int x = (i % NB_COLONNES) * HAUTEUR_COLONNE;
                //    Rectangle r = new Rectangle(x, y, LARGEUR_COLONNE, HAUTEUR_COLONNE);
                //    r.Inflate(-4, -4);
                //    Image img = Images.zoomImage(alternatives[i].affiche, r);
                //    if (img != null)
                //        g.DrawImageUnscaled(img, r.Left + (r.Width - img.Width) / 2, r.Top + (r.Height - img.Height) / 2);
                //}

                // IMAGES EN CASCADE
                //const int DECALE_X = 16;
                //const int DECALE_Y = 16;
                //int nbImages = alternatives.Count;
                //int LargeurImage = bounds.Width - (nbImages * DECALE_X);
                //int HauteurImage = bounds.Height - (nbImages * DECALE_Y);
                //Rectangle rImage = new Rectangle(0, 0, LargeurImage, HauteurImage);
                //
                //int x = 0;
                //int y = 0;
                //foreach (InfosFilm info in alternatives)
                //{
                //    Image i = Images.ombre(Images.zoomImage(info.affiche, rImage), DECALE_X / 2);
                //    if (i != null)
                //    {
                //        g.DrawImageUnscaled(i, x, y);
                //        x += DECALE_X;
                //        y += DECALE_Y;
                //    }
                //}
            }

            return newImage;
        }

        /// <summary>
        /// Supprimer les alternatives du film
        /// </summary>
        /// <returns></returns>
        internal bool supprimeAlternatives()
        {
            BaseFilms baseFilms = BaseFilms.instance;
            MainForm.WriteMessageToConsole("Suppression des autres alternatives");
            if (baseFilms.supprimeAlternatives(_id))
            {
                _alternatives = null;
                changeEtat();
                return true;
            }

            return false;
        }
    }
}
