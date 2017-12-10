using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Collection_de_films.Internet
{
    class Internet
    {
        static private Internet _instance = new Internet();
        //The cookies will be here.
        private static CookieContainer _cookies = new CookieContainer();

        public static Internet getInstance()
        {
            return _instance;
        }
        private Internet()
        {

        }

        public HtmlDocument loadPage(string requete)
        {
            HtmlWeb web = new HtmlWeb();
            web.UseCookies = true;
            web.UserAgent = "Mozilla/5.0 (Windows NT x.y; WOW64; rv:10.0) Gecko/20100101 Firefox/10.0";
            return web.Load(requete);
        }





        /// <summary>
        /// Charge une image sur Internet
        /// </summary>
        /// <param name="url"></param>
        /// <param name="largeurMax">largeur finale de l'image si elle est trop grande (ou 0 pour ne jamais retailler)</param>
        /// <returns></returns>
        async public static Task<Image> loadImage(string url, int largeurMax)
        {
            if (url == null || url.Length == 0)
                return null;

            HttpWebRequest wreq;
            HttpWebResponse wresp;
            Stream mystream;
            Bitmap bmp;

            bmp = null;
            mystream = null;
            wresp = null;
            try
            {
                wreq = (HttpWebRequest)WebRequest.Create(url);
                wreq.AllowWriteStreamBuffering = true;

                wresp = (HttpWebResponse)wreq.GetResponse();

                if ((mystream = wresp.GetResponseStream()) != null)
                    bmp = new Bitmap(mystream);

                return Images.retaille(bmp, largeurMax);
            }
            finally
            {
                if (mystream != null)
                    mystream.Close();

                if (wresp != null)
                    wresp.Close();
            }

            //return bmp;
        }
    }
}
