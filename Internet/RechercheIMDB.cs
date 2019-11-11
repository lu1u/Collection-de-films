using CollectionDeFilms.Films;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollectionDeFilms.Internet
{
    internal class RechercheIMDB : RechercheFilm
    {
        private const string CHERCHE_RESUME = @"//div[@class='plot_summary_wrapper']//div[@class='summary_text']";
        private const string CHERCHE_REALISATEUR = @"//div[@class='credit_summary_item']//span[@itemprop='director']";
        private const string CHERCHE_ACTEURS = @"//div[@class='credit_summary_item']//span[@itemprop='actors']";
        private const string CHERCHE_IMAGE = @"//div[@class='poster']//img";
        private const string PAGE_RECHERCHE = @"http://www.imdb.com/find?ref_=nv_sr_fn&q={0}&s=tt&exact=true&ref_=fn_al_tt_ex";
        private const string PAGE_FILM = @"http://www.imdb.com/{0}";
        private const string LIENS_PAGES_FILMS = @"//table[@class='findList']//a[contains(@href,'/title/')]";

        /// <summary>
        /// Utilise la page de recherche de Imdb pour retrouver les adresses de la ou des pages
        /// consacrees au film
        /// </summary>
        /// <returns></returns>
        protected override List<string> PageRecherche(string Titre)
        {
            List<string> result = new List<string>();

            MainForm.WriteMessageToConsole("Recherche page film " + Titre);
            string requete = string.Format(PAGE_RECHERCHE, requeteIMDB(Titre));

            HtmlDocument doc = Internet.getInstance().loadPage(requete);
            MainForm.WriteMessageToConsole("Requete " + requete);
            HtmlNodeCollection ahrefs = doc.DocumentNode.SelectNodes(LIENS_PAGES_FILMS);
            if (ahrefs != null)
            {
                MainForm.WriteMessageToConsole(ahrefs.Count + " pages de film trouvees");
                foreach (HtmlNode ahref in ahrefs)
                {
                    string adresse = string.Format(PAGE_FILM, ahref.Attributes["href"].Value);
                    if (!result.Contains(adresse))
                        result.Add(adresse);
                }
            }
            else
                MainForm.WriteMessageToConsole("Page non trouvée");

            return result;
        }

        protected async override Task<InfosFilm> PageFilm(string requete)
        {
            MainForm.WriteMessageToConsole("Chargement de la page du film :" + requete);
            InfosFilm result = new InfosFilm();
            HtmlDocument doc = Internet.getInstance().loadPage(requete);

            // Image
            HtmlNode img = doc.DocumentNode.SelectSingleNode(CHERCHE_IMAGE);
            if (img != null)
            {
                string lienImage = img.Attributes["src"].Value;
                MainForm.WriteMessageToConsole("Image: " + lienImage);

                result._image = await Internet.loadImage(lienImage);
            }

            // Date de sortie
            HtmlNode date = doc.DocumentNode.SelectSingleNode(@"//div[@class='title_wrapper']//a[contains(@href,'releaseinfo')]");
            if (date != null)
                result._dateSortie = trim(date.InnerText);

            // Genres
            HtmlNodeCollection genres = doc.DocumentNode.SelectNodes(@"//div[@class='title_wrapper']//a[contains(@href,'/genre/')]");
            if (genres?.Count > 0)
            {
                result._genres = trim(genres[0].InnerText);
                for (int i = 1; i < genres.Count; i++)
                    result._genres += ", " + trim(genres[i].InnerText);
            }

            // Resume
            HtmlNode resume = doc.DocumentNode.SelectSingleNode(CHERCHE_RESUME);
            if (resume != null)
                result._resume = trim(resume.InnerText);

            // Realisateur
            HtmlNode realisateur = doc.DocumentNode.SelectSingleNode(CHERCHE_REALISATEUR);
            if (realisateur != null)
                result._realisateur = trim(realisateur?.InnerText);

            // Informations
            HtmlNodeCollection acteurs = doc.DocumentNode.SelectNodes(CHERCHE_ACTEURS);
            if (acteurs?.Count > 0)
            {
                result._acteurs = trim(acteurs[0].InnerText);
                for (int i = 1; i < acteurs.Count; i++)
                    result._acteurs += ", " + trim(acteurs[i].InnerText);
            }

            return result;
        }

        private static string requeteIMDB(string titre)
        {
            return titre.Replace("  ", "+").Replace(" ", "+").Replace("/", "").Replace("\\", "");
        }
    }
}
