using CollectionDeFilms.Database;
using CollectionDeFilms.Films;
using CollectionDeFilms.Internet;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Web;

namespace CollectionDeFilms.Internet
{
    public class RechercheSurSite : RechercheInternet
    {
        public string formatUrlRecherche;
        public string xpathRecherche;
        public string formatUrlFilm;
        public string xpathRealisateur;
        public string xpathActeurs;
        public string xpathGenres;
        public string xpathNationalite;
        public string xpathResume;
        public string xpathDateSortie;
        public string xpathAffiche;


        public RechercheSurSite()
        {
            nom = "";
            rang = 0;
            formatUrlRecherche = "{0}";
            xpathRecherche = "";
            formatUrlFilm = "{0}";
            xpathRealisateur = "";
            xpathActeurs = "";
            xpathGenres = "";
            xpathNationalite = "";
            xpathResume = "";
            xpathDateSortie = "";
            xpathAffiche = "";
        }

        public RechercheSurSite(SQLiteDataReader reader)
        {
            nom = reader.GetString(reader.GetOrdinal(BaseConfiguration.RECHERCHE_NOM));
            rang = reader.GetInt32(reader.GetOrdinal(BaseConfiguration.RECHERCHE_RANG));
            formatUrlRecherche = reader.GetString(reader.GetOrdinal(BaseConfiguration.RECHERCHE_URL_RECHERCHE));
            xpathRecherche = reader.GetString(reader.GetOrdinal(BaseConfiguration.RECHERCHE_XPATH_RECHERCHE));
            formatUrlFilm = reader.GetString(reader.GetOrdinal(BaseConfiguration.RECHERCHE_URL_FILM));
            xpathRealisateur = reader.GetString(reader.GetOrdinal(BaseConfiguration.RECHERCHE_XPATH_REALISATEUR));
            xpathActeurs = reader.GetString(reader.GetOrdinal(BaseConfiguration.RECHERCHE_XPATH_ACTEURS));
            xpathGenres = reader.GetString(reader.GetOrdinal(BaseConfiguration.RECHERCHE_XPATH_GENRES));
            xpathNationalite = reader.GetString(reader.GetOrdinal(BaseConfiguration.RECHERCHE_XPATH_NATIONALITE));
            xpathResume = reader.GetString(reader.GetOrdinal(BaseConfiguration.RECHERCHE_XPATH_RESUME));
            xpathDateSortie = reader.GetString(reader.GetOrdinal(BaseConfiguration.RECHERCHE_XPATH_DATESORTIE));
            xpathAffiche = reader.GetString(reader.GetOrdinal(BaseConfiguration.RECHERCHE_XPATH_AFFICHE));
        }


        /// <summary>
        /// Recherche des informations pour un films, on obtient une liste de liens sur les films qui correspondent
        /// </summary>
        /// <param name="film"></param>
        /// <returns>Une liste d'infosFilm contenant les differentes versions trouvees sur Internet</returns>
        override async internal Task<List<InfosFilm>> recherche(Film film)
        {
            try
            {
                // Charger une liste des pages referencant ce film
                MainForm.WriteMessageToConsole("Recherche: " + nom);
                string url = string.Format(formatUrlRecherche, requete(film.Titre));
                List<string> pagesFilms = await extract(url, xpathRecherche);
                if (pagesFilms == null)
                    return null;

                // Analyser chaque page referencant ce film
                List<InfosFilm> infos = new List<InfosFilm>();
                foreach (string page in pagesFilms)
                {
                    InfosFilm info = await chargePage(string.Format(formatUrlFilm, page));
                    if (!(info == null || info.estVide()))
                        infos.Add(info);
                }

                return infos;
            }
            catch (Exception e)
            {
                MainForm.WriteExceptionToConsole(e);
                return null;
            }
        }

        /// <summary>
        /// Charge une page Internet et extrait du contenu basé sur un xPath
        /// </summary>
        /// <param name="requete"></param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        private async Task<List<string>> extract(string requete, string xpath)
        {
            MainForm.WriteMessageToConsole("Requete " + requete);
            HtmlDocument doc = await InternetUtils.loadPage(requete);
            if (doc == null)
                return null;

            return extract(doc, xpath);
        }

        /// <summary>
        /// Extrait un ou plusieurs element d'un document HTML, selon un XPath
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="xpath"></param>
        /// <returns>Liste des elements</returns>
        private List<string> extract(HtmlDocument doc, string xpath)
        {
            if (xpath == null || xpath.Length == 0)
                return null;
            try
            {
                List<string> result = new List<string>();
                HtmlAgilityPack.HtmlNodeCollection elements = doc.DocumentNode.SelectNodes(xpath);
                if (elements != null)
                {
                    string name;
                    if (finiParAttribut(xpath, out name))
                    {
                        foreach (HtmlNode element in elements)
                        {
                            HtmlAttribute att = element.Attributes[name];
                            if (att != null)
                                result.Add(trim(att.Value));
                        }
                    }
                    else
                    {
                        foreach (HtmlNode element in elements)
                            result.Add(trim(element.InnerHtml));
                    }
                }

                return result;
            }
            catch (Exception)
            {

                return null;
            }
        }

        static private bool finiParAttribut(string path, out string name)
        {
            name = "";
            int indexArrobas = path.LastIndexOf('@');
            if (indexArrobas == -1)
                return false;

            int indexSlash = path.LastIndexOf('/');
            if (indexSlash > indexArrobas)
                return false;

            int indexCrochet = path.LastIndexOf(']');
            if (indexCrochet > indexArrobas)
                return false;
            name = path.Substring(indexArrobas + 1);
            return true;
        }
        public static string trim(string key)
        {
            if (key == null)
                return "";
            return HttpUtility.HtmlDecode(key).Trim().Trim(TRIM_CHAR);
        }


        private async Task<InfosFilm> chargePage(string requete)
        {
            MainForm.WriteMessageToConsole($"Requete {requete}");
            HtmlDocument doc = await InternetUtils.loadPage(requete);
            if (doc == null)
                return null;

            InfosFilm info = new InfosFilm();

            info._realisateur = cumuleExtract(doc, xpathRealisateur); MainForm.WriteMessageToConsole($"Réalisateur: {info._realisateur}");
            info._acteurs = cumuleExtract(doc, xpathActeurs); MainForm.WriteMessageToConsole("Acteurs: " + info._acteurs);
            info._genres = cumuleExtract(doc, xpathGenres); MainForm.WriteMessageToConsole("Genres: " + info._genres);
            info._nationalite = cumuleExtract(doc, xpathNationalite); MainForm.WriteMessageToConsole("Nationalite: " + info._nationalite);
            info._resume = cumuleExtract(doc, xpathResume); MainForm.WriteMessageToConsole("Résumé: " + info._resume);
            info._dateSortie = cumuleExtract(doc, xpathDateSortie); MainForm.WriteMessageToConsole("Date sortie: " + info._dateSortie);

            string imglink = cumuleExtract(doc, xpathAffiche); MainForm.WriteMessageToConsole("Affiche: " + imglink);
            if (imglink != null)
                info._image = Images.retaille(await InternetUtils.loadImage(imglink, Configuration.largeurMaxImages), Configuration.largeurMaxImages);
            return info;
        }



        /// <summary>
        /// Chargement de la page d'un film et extraction des informations
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>


        private string cumuleExtract(HtmlDocument doc, string xpath)
        {
            List<string> elements = extract(doc, xpath);
            if (elements == null)
                return "";


            switch (elements.Count)
            {
                case 0:
                    return "";

                case 1:
                    return trim(elements[0]);

                default:
                    string result = elements[0];
                    for (int i = 1; i < elements.Count; i++)
                        result += BaseFilms.SEPARATEUR_LISTES + elements[i];

                    return trim(result);
            }
        }
    }
}

