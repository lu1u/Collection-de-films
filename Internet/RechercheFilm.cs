using CollectionDeFilms.Films;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace CollectionDeFilms.Internet
{
    abstract class RechercheFilm
    {
        public static readonly char[] TRIM_CHAR = { ' ', ',', '\n' };
        public static readonly char[] SEPARATORS = { ' ', ',', '-', '}', '\'', '"', '~', '{', '(', ')', '/', '\\', '=', '*', '&', ':', ';', ',', '.', '_' };

        protected abstract List<string> PageRecherche(string titre);
        protected abstract Task<InfosFilm> PageFilm(string url);
        virtual async public Task<List<InfosFilm>> loadInfosFilm(Film f)
        {
            // Page de recherche allocine pour trouver la ou les pages consacrees au film
            List<string> requetes = PageRecherche(f.Titre);
            if (requetes == null)
                // Pas trouve
                return null;

            List<InfosFilm> alternatives = new List<InfosFilm>();
            foreach (string requete in requetes)
            {

                MainForm.WriteMessageToConsole(requete);
                InfosFilm infos = await PageFilm(requete);
                if (infos != null && !infos.estVide())
                    alternatives.Add(infos);
            }

            return alternatives;
        }

        public static string trim(string key)
        {
            if (key == null)
                return "";
            return HttpUtility.HtmlDecode(key).Trim().Trim(TRIM_CHAR);
        }
    }
}
