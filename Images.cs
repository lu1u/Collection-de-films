using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace CollectionDeFilms
{
    class Images
    {
        /// <summary>
        /// Retaille proportionnellement une image pour s'assurer qu'elle ne depasse pas la largeur donnée
        /// </summary>
        /// <param name="image"></param>
        /// <param name="largeurMax"></param>
        /// <returns></returns>
        static public Image retaille(Image image, int largeurMax)
        {
            if (image == null)
                return null;

            if (largeurMax == 0)
                // pas de changement
                return image;

            if (image.Width <= largeurMax)
                // Image pas trop grande
                return image;

            double ratio = (double)image.Height / (double)image.Width;

            int newHeight = (int)(largeurMax * ratio);

            Image newImage = new Bitmap(largeurMax, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, largeurMax, newHeight);

            return newImage;
        }

        /// <summary>
        /// Zoome proportionnellement une image pour qu'elle tienne dans un rectangle
        /// </summary>
        /// <param name="image"></param>
        /// <param name="bounds"></param>
        /// <returns></returns>
        public static Image zoomImage(Image image, Rectangle bounds)
        {
            if (image == null)
                return null;
            double ratioX = (double)bounds.Width / (double)image.Width;
            double ratioY = (double)bounds.Height / (double)image.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

        static public byte[] imageToByteArray(Image imageIn)
        {
            return imageToByteArray(imageIn, getImageFormat(imageIn));
        }

        static public byte[] imageToByteArray(Image imageIn, ImageFormat format)
        {
            if (imageIn != null)
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, format);
                return ms.ToArray();
            }
            else
                return new byte[0];
        }

        private static ImageFormat getImageFormat(Image image)
        {
            try
            {
                if (ImageFormat.Jpeg.Equals(image.RawFormat))
                {
                    return ImageFormat.Jpeg;
                }
                else if (ImageFormat.Png.Equals(image.RawFormat))
                {
                    return ImageFormat.Png;

                }
                else if (ImageFormat.Gif.Equals(image.RawFormat))
                {
                    return ImageFormat.Gif;
                }
            }
            catch
            {
            }
            return ImageFormat.Png; // Format par defaut
        }

        /// <summary>
        /// creer une image à partir d'un byteArray
        /// </summary>
        /// <param name="byteArrayIn"></param>
        /// <returns></returns>
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Retourne une copie de l'image apres lui avoir ajoute une ombre
        /// </summary>
        /// <param name="image"></param>
        /// <param name="decalage"></param>
        /// <returns></returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static Image ombre(Image image, int decalage)
        {
            if (decalage < 1)
                decalage = 1;

            Image img = new Bitmap(image.Width + decalage, image.Height + decalage);
            using (Graphics g = Graphics.FromImage(img))
            {
                using (Brush b = new SolidBrush(Color.FromArgb((int)(256.0f / (float)decalage), 0, 0, 0)))
                    for (int i = 0; i < decalage; i++)
                        g.FillRectangle(b, i, i, image.Width, image.Height);
                g.DrawImageUnscaled(image, 0, 0);
            }
            return img;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Creer une copie de l'image
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        internal static Image copie(Image image)
        {
            if (image == null)
                return null;
            return new Bitmap(image);
        }
    }
}
