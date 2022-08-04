using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace CollectionDeFilms
{
    class ImagesUtils
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

            Image newImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphics = Graphics.FromImage(newImage))
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

            Image img = new Bitmap(image.Width + decalage * 2, image.Height + decalage * 2);
            using (Graphics g = Graphics.FromImage(img))
            {
                using (Brush b = new SolidBrush(Color.FromArgb((int)(128.0f / (float)decalage), 0, 0, 0)))
                    for (int i = 1; i <= decalage; i++)
                        g.FillRectangle(b, i, i, image.Width, image.Height);

                //Rectangle rect = new Rectangle(0, 0, image.Width + decalage, image.Height + decalage);
                //
                //GraphicsPath path = new GraphicsPath();
                //path.AddRectangle(rect);
                //// this is where we create the shadow effect, so we will use a 
                //// pathgradientbursh and assign our GraphicsPath that we created of a 
                //// Rounded Rectangle
                //using (PathGradientBrush _Brush = new PathGradientBrush(path))
                //{
                //    // set the wrapmode so that the colors will layer themselves
                //    // from the outer edge in
                //    _Brush.WrapMode = WrapMode.Clamp;
                //
                //    // Create a color blend to manage our colors and positions and
                //    // since we need 3 colors set the default length to 3
                //    ColorBlend _ColorBlend = new ColorBlend(3);
                //
                //    // here is the important part of the shadow making process, remember
                //    // the clamp mode on the colorblend object layers the colors from
                //    // the outside to the center so we want our transparent color first
                //    // followed by the actual shadow color. Set the shadow color to a 
                //    // slightly transparent DimGray, I find that it works best.|
                //    _ColorBlend.Colors = new Color[] { Color.Transparent, Color.FromArgb(250, Color.Black), Color.FromArgb(250, Color.DarkGray) };
                //
                //    // our color blend will control the distance of each color layer
                //    // we want to set our transparent color to 0 indicating that the 
                //    // transparent color should be the outer most color drawn, then
                //    // our Dimgray color at about 10% of the distance from the edge
                //    _ColorBlend.Positions = new float[] { 0f, .1f, 1f };
                //
                //    // assign the color blend to the pathgradientbrush
                //    _Brush.InterpolationColors = _ColorBlend;
                //
                //    // fill the shadow with our pathgradientbrush
                //    g.FillPath(_Brush, path);
                //}

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

        internal static Image cadre(Image image, Color couleur, int largeur)
        {
            Image img = new Bitmap(image.Width + largeur * 2, image.Height + largeur * 2);
            using (Graphics g = Graphics.FromImage(img))
            {
                g.DrawImageUnscaled(image, largeur, largeur);
                using (Pen p = new Pen(couleur, largeur))
                    g.DrawRectangle(p, largeur / 2, largeur / 2, img.Width - largeur, img.Height - largeur);
            }

            return img;
        }
    }
}
