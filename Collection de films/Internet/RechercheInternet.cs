using SqlDataReader = System.Data.SQLite.SQLiteDataReader;
using Collection_de_films.Database;
using Collection_de_films.Films;
using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Web;

namespace Collection_de_films.Internet
{
    public class RechercheInternet
    {
        public static readonly char[] TRIM_CHAR = { ' ', ',', '\n' };

        public string nom;
        public int rang;
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

        public RechercheInternet()
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

        public RechercheInternet(SqlDataReader reader)
        {
            int i = reader.GetOrdinal(BaseDonnees.RECHERCHE_NOM);
            
            nom = reader.GetString(reader.GetOrdinal(BaseDonnees.RECHERCHE_NOM));
            rang = reader.GetInt32(reader.GetOrdinal(BaseDonnees.RECHERCHE_RANG));
            formatUrlRecherche = reader.GetString(reader.GetOrdinal(BaseDonnees.RECHERCHE_URL_RECHERCHE));
            xpathRecherche = reader.GetString(reader.GetOrdinal(BaseDonnees.RECHERCHE_XPATH_RECHERCHE));
            formatUrlFilm = reader.GetString(reader.GetOrdinal(BaseDonnees.RECHERCHE_URL_FILM));
            xpathRealisateur = reader.GetString(reader.GetOrdinal(BaseDonnees.RECHERCHE_XPATH_REALISATEUR));
            xpathActeurs = reader.GetString(reader.GetOrdinal(BaseDonnees.RECHERCHE_XPATH_ACTEURS));
            xpathGenres = reader.GetString(reader.GetOrdinal(BaseDonnees.RECHERCHE_XPATH_GENRES));
            xpathNationalite = reader.GetString(reader.GetOrdinal(BaseDonnees.RECHERCHE_XPATH_NATIONALITE));
            xpathResume = reader.GetString(reader.GetOrdinal(BaseDonnees.RECHERCHE_XPATH_RESUME));
            xpathDateSortie = reader.GetString(reader.GetOrdinal(BaseDonnees.RECHERCHE_XPATH_DATESORTIE));
            xpathAffiche = reader.GetString(reader.GetOrdinal(BaseDonnees.RECHERCHE_XPATH_AFFICHE));
        }

        /// <summary>
        /// Recherche des informations pour un films
        /// </summary>
        /// <param name="film"></param>
        /// <returns></returns>
        internal bool rechercheInternet(Film film)
        {
            try
            {
                MainForm.WriteMessageToConsole("Recherche: " + nom);
                string url = string.Format(formatUrlRecherche, requete(film.Titre));
                List<string> pagesFilms = extract(url, xpathRecherche);
                if (pagesFilms==null)
                {
                    return false;
                }

                List<InfosFilm> infos = new List<InfosFilm>();
                foreach(string page in pagesFilms)
                {
                    InfosFilm info = chargePage(string.Format(formatUrlFilm, page));
                    if (!(info == null || info.estVide()))
                        infos.Add(info);
                }

                return film.setInfos(infos);
            }
            catch (Exception e)
            {
                MainForm.WriteExceptionToConsole(e);
                return false;
            }
        }


        /// <summary>
        /// Chargement de la page d'un film et extraction des informations
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        private InfosFilm chargePage(string requete)
        {
            MainForm.WriteMessageToConsole("Requete " + requete);
            HtmlDocument doc = Internet.getInstance().loadPage(requete);
            if (doc == null)
            {
                MainForm.WriteErrorToConsole("Erreur de chargement de la page " + requete);
                return null;
            }

            InfosFilm info = new InfosFilm();
            info._acteurs = cumuleExtract(doc, xpathActeurs);
            info._genres = cumuleExtract(doc, xpathGenres);
            info._nationalite = cumuleExtract(doc, xpathNationalite);
            info._realisateur = cumuleExtract(doc, xpathRealisateur);
            info._resume = cumuleExtract(doc, xpathResume);
            string imglink = cumuleExtract(doc, xpathAffiche);
            if (imglink != null)
                info.affiche = Internet.loadImage(imglink, Configuration.largeurMaxImages);

            return info;
        }

        private string cumuleExtract(HtmlDocument doc, string xpath)
        {
            List<string> elements = extract(doc, xpath);
            if (elements == null)
                return "";


            switch( elements.Count)
            {
                case 0:
                    return "";

                case 1:
                    return elements[0];

                default:
                    string result = elements[0];
                    for (int i = 1; i < elements.Count; i++)
                        result += ", " + elements[i];

                    return result;
            }
        }

        private List<string> extract(string requete, string xpath)
        {
            MainForm.WriteMessageToConsole("Requete " + requete);
            HtmlDocument doc = Internet.getInstance().loadPage(requete);
            if (doc == null)
            {
                MainForm.WriteErrorToConsole("Erreur de chargement de la page " + requete);
                return null;
            }
            return extract(doc, xpath);
        }

        private List<string> extract(HtmlDocument doc, string xpath)
        {
            if (xpath == null || xpath.Length == 0)
                return null;
            try
            {
                List<string> result = new List<string>();
                HtmlNodeCollection elements = doc.DocumentNode.SelectNodes(xpath);
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

            name = path.Substring(indexArrobas + 1);
            return true;
        }
        public static string trim(string key)
        {
            if (key == null)
                return "";
            return HttpUtility.HtmlDecode(key).Trim().Trim(TRIM_CHAR);
        }
        private static string requete(string titre)
        {
            return titre.Replace("  ", "+").Replace(" ", "+").Replace("/", "").Replace("\\", "");
        }
    }
}
