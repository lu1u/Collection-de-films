using HtmlAgilityPack;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CollectionDeFilms.Internet
{
    class InternetUtils
    {
        static private InternetUtils _instance = new InternetUtils();
        //The cookies will be here.
        private static CookieContainer _cookies = new CookieContainer();

        public static InternetUtils getInstance()
        {
            return _instance;
        }
        private InternetUtils()
        {

        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Charge une page HTML
        /// </summary>
        /// <param name="requete">URL de la page</param>
        /// <returns>HTMLDocument, eventuellement nul</returns>
        ///////////////////////////////////////////////////////////////////////////////////////////
        async static public Task<HtmlDocument> loadPage(string requete)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                web.UseCookies = true;
                web.UserAgent = "Mozilla/5.0 (Windows NT x.y; WOW64; rv:10.0) Gecko/20100101 Firefox/10.0";
                return await web.LoadFromWebAsync(requete);
            }
            catch( HtmlWebException e)
            {
                MainForm.WriteErrorToConsole("Erreur lors du chargmement d'une page: " + requete);
                MainForm.WriteExceptionToConsole(e);
                return null;
            }
        }



        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Charge une image sur Internet
        /// </summary>
        /// <param name="url"></param>
        /// <param name="largeurMax">largeur finale de l'image si elle est trop grande (ou 0 pour ne jamais retailler)</param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////////////////////////////
        async public static Task<Image> loadImage(string url, int largeurMax = 300)
        {
            if (url == null || url.Length == 0)
                return null;

            Stream mystream = null;
            HttpWebResponse wresp = null;

            try
            {
                HttpWebRequest wreq;
                wreq = (HttpWebRequest)WebRequest.Create(url);
                wreq.AllowWriteStreamBuffering = true;

                wresp = (HttpWebResponse)await wreq.GetResponseAsync();

                if ((mystream = wresp.GetResponseStream()) != null)
                {
                    Bitmap bmp = new Bitmap(mystream);
                    return Images.retaille(bmp, largeurMax);
                }
            }
            finally
            {
                if (mystream != null)
                    mystream.Close();

                if (wresp != null)
                    wresp.Close();
            }

            return null;
        }

        /// <summary>
        /// Calcule une URL pour cherche un film sur Internet
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public static string urlRecherche(string u)
        {
            return @"https://www.google.com/search?q=film+" + u.Replace(" ", "+").Replace("/", "").Replace("&", "+").Replace("++", "+");

        }
    }
}
