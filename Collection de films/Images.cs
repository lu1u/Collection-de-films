using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_de_films
{
    class Images
    {
        /// <summary>
        /// Retaille proportionnellement une image pour s'assurer qu'elle ne depasse pas la largeur donnée
        /// </summary>
        /// <param name="image"></param>
        /// <param name="largeurMax"></param>
        /// <returns></returns>
        static public Image retaille( Image image, int largeurMax )
        {
            if ( largeurMax == 0 )
                // pas de changement
                return image;
            if ( image == null )
                return null;

            if ( image.Width <= largeurMax )
                return image;

            double ratio = image.Height / image.Width ;

            int newHeight = (int)(largeurMax * ratio);

            var newImage = new Bitmap(largeurMax, newHeight);

            using ( var graphics = Graphics.FromImage( newImage ) )
                graphics.DrawImage( image, 0, 0, largeurMax, newHeight );

            return newImage;
        }

        /// <summary>
        /// Zoome proportionnellement une image pour qu'elle tienne dans un rectangle
        /// </summary>
        /// <param name="image"></param>
        /// <param name="bounds"></param>
        /// <returns></returns>
        public static Image zoomImage( Image image, Rectangle bounds )
        {
            if ( image == null )
                return null;
            double ratioX = (double)bounds.Width / (double)image.Width;
            double ratioY = (double)bounds.Height / (double)image.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using ( var graphics = Graphics.FromImage( newImage ) )
                graphics.DrawImage( image, 0, 0, newWidth, newHeight );

            return newImage;
        }
        static public byte[] imageToByteArray( Image imageIn )
        {
            if ( imageIn != null )
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save( ms, getImageFormat( imageIn ) );
                return ms.ToArray();
            }
            else
                return new byte[0];
        }

        private static ImageFormat getImageFormat( Image image )
        {
            if ( ImageFormat.Jpeg.Equals( image.RawFormat ) )
            {
                return ImageFormat.Jpeg;
            }
            else if ( ImageFormat.Png.Equals( image.RawFormat ) )
            {
                return ImageFormat.Png;

            }
            else if ( ImageFormat.Gif.Equals( image.RawFormat ) )
            {
                return ImageFormat.Gif;
            }

            return ImageFormat.Jpeg; // Format par defaut
        }

        public static Image byteArrayToImage( byte[] byteArrayIn )
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static Image ombre( Image image, int decalage )
        {
            Image img = new Bitmap(image.Width+decalage, image.Height+decalage);
            using ( Graphics g = Graphics.FromImage( img ) )
            {
                using ( Brush b = new SolidBrush( Color.FromArgb( 64, 0, 0, 0 ) ) )
                {
                    g.FillRectangle( b, decalage, decalage, image.Width, image.Height );
                    g.DrawImageUnscaled( image, 0, 0 );
                }
            }
            return img;
        }
    }
}
