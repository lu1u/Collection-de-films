using CollectionDeFilms.Films;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollectionDeFilms.Internet
{
    class RechercheAllocine : RechercheFilm
    {
        private const string LIENS_PAGES_FILMS = @"//div[contains(@class,'colcontent')]//table[contains(@class,'totalwidth noborder purehtml')]//a[contains(@href,'fichefilm_gen_cfilm')]";
        private const string PAGE_RECHERCHE = @"http://www.allocine.fr/recherche/?q={0}";
        private const string PAGE_FILM = @"http://www.allocine.fr/{0}";
        private const string CHERCHE_IMAGE = @"//img[@class='thumbnail-img']";



        /// <summary>
        /// Utilise la page de recherche de Allocine pour retrouver les adresses de la ou des pages
        /// consacrees au film
        /// </summary>
        /// <returns></returns>
        protected override List<string> PageRecherche(string Titre)
        {
            List<string> result = new List<string>();

            MainForm.WriteMessageToConsole(">>Recherche page film " + Titre);
            // Page de recherche du film chez Allocine pour obtenir le lien vers la page du film
            string requete = string.Format(PAGE_RECHERCHE, requeteAllocine(Titre));
            MainForm.WriteMessageToConsole("Requete " + requete);
            HtmlDocument doc = Internet.getInstance().loadPage(requete);
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
                MainForm.WriteMessageToConsole("Film non trouvé");
            return result;
        }

        protected override async Task<InfosFilm> PageFilm(string requete)
        {
            InfosFilm result = new InfosFilm();
            // Chargement de la page du film
            HtmlDocument doc = Internet.getInstance().loadPage(requete);

            // Image
            HtmlNodeCollection img = doc.DocumentNode.SelectNodes(CHERCHE_IMAGE);
            if (img?.Count >= 1)
            {
                string lienImage = img[0].Attributes["src"].Value;
                MainForm.WriteMessageToConsole("Image: " + lienImage);
                result._image = await Internet.loadImage(lienImage);
            }

            // Informations
            {
                HtmlNodeCollection infos = doc.DocumentNode.SelectNodes("//div[@class='meta-body-item']");
                foreach (HtmlNode node in infos)
                {
                    HtmlNodeCollection nodes = node.ChildNodes;
                    if (nodes != null && nodes.Count >= 4)
                    {
                        string key = trim(nodes[1].InnerText);

                        if ("De".Equals(key))
                            result._realisateur = trim(nodes[3].InnerText);
                        else
                            if ("Avec".Equals(key))
                        {
                            result._acteurs = trim(nodes[3].InnerText);

                            for (int i = 4; i < nodes.Count; i++)
                            {
                                string text = trim(nodes[i].InnerText);
                                if (text.Length > 0 && !"plus".Equals(text))
                                    result._acteurs = result._acteurs + ", " + text;
                            }
                        }
                        else
                            if ("Genres".Equals(key))
                        {
                            result._genres = trim(nodes[3].InnerText);

                            for (int i = 4; i < nodes.Count; i++)
                            {
                                string text = trim(nodes[i].InnerText);
                                if (text.Length > 0 && !"plus".Equals(text))
                                    result._genres = trim(nodes[3].InnerText);
                            }
                        }
                        else if ("Nationalité".Equals(key))
                            result._nationalite = trim(nodes[3].InnerText);
                        else
                            if ("Date de sortie".Equals(key))
                            result._dateSortie = trim(nodes[3].InnerText);
                    }
                }

            }

            // Resume
            {
                HtmlNodeCollection resume = doc.DocumentNode.SelectNodes("//div[@class='ovw-synopsis-txt']");
                if (resume != null)
                    result._resume = trim(resume[0].InnerText);
            }

            return result;
        }


        private static string requeteAllocine(string titre)
        {
            return titre.Replace("  ", "+").Replace(" ", "+").Replace("/", "").Replace("\\", "");
            /*string[] mots = titre.Split(SEPARATORS);
            if (mots == null || mots.Length == 0)
                return "";

            string result = mots[0];
            for (int i = 1; i < mots.Length; i++)
                result += "+" + mots[i];
            return result;*/
        }
    }
}
