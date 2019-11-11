using CollectionDeFilms.Database;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

/// <summary>
/// Gestion de la selection par Genres
/// </summary>
namespace CollectionDeFilms.Filtre_et_tri
{
    static class Genres
    {
        static List<string> _genres;

        /// <summary>
        /// Retourne une liste de genres uniques
        /// </summary>
        /// <returns></returns>
        public static async Task<List<string>> getGenres()
        {
            if (_genres == null)
            {
                // Construire une nouvelle liste de genres
                _genres = new List<string>();
                SQLiteDataReader reader = await BaseFilms.instance.getGenres();
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal(BaseFilms.FILMS_GENRES);
                    // Read advances to the next row.
                    while (reader.Read())
                    {
                        string genres = reader.GetString(ordinal);
                        ajouteGenres(genres, _genres);
                    }
                }

                _genres.Sort();
            }

            return _genres;
        }

        /// <summary>
        /// Mise a jour de la base, reinitialiser la liste de genres
        /// </summary>
        public static void updateGenres()
        {
            _genres = null;
        }

        /// <summary>
        /// Ajoute les genres donnés dans une chaine de caracteres a la liste s'ils n'y sont pas déjà
        /// </summary>
        /// <param name="genres"></param>
        /// <param name="res"></param>
        private static bool ajouteGenres(string genres, List<string> res)
        {
            bool change = false;
            genres = genres.Trim();
            string[] morceaux = genres.Split(BaseFilms.SEPARATEUR_LISTES_CHAR);
            foreach(string m in morceaux)
            {
                if (m?.Length > 0)
                {
                    string s = magnifique(m);
                    if (res.IndexOf(s) == -1)
                    {
                        change = true;
                        res.Add(s);
                    }
                }
            }

            return change;
        }

        /// <summary>
        /// Tranforme une chaine de caracteres: initiale majuscule
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private static string magnifique(string v)
        {
            if (v?.Length < 2)
                return v;

            return v.Substring(0, 1).ToUpper() + v.Substring(1);
        }
    }
}
