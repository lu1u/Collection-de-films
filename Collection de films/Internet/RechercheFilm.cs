using Collection_de_films.Films;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Collection_de_films.Internet
{
    abstract class RechercheFilm
    {
        public static readonly char[] TRIM_CHAR = { ' ', ',', '\n' };
        public static readonly char[] SEPARATORS = { ' ', ',', '-', '}', '\'', '"', '~', '{', '(', ')', '/', '\\', '=', '*', '&', ':', ';', ',', '.', '_' };

        protected abstract List<string> PageRecherche(string titre);
        protected abstract InfosFilm PageFilm(string url);
        virtual public List<InfosFilm> loadInfosFilm(Film f)
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
                InfosFilm infos = PageFilm(requete);
                if (infos != null && ! infos.estVide())
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
