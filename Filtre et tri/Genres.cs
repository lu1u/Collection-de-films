using CollectionDeFilms.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

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
        public static List<string> getGenres()
        {
            if (_genres == null)
            {
                // Construire une nouvelle liste de genres
                _genres = new List<string>();
                SQLiteDataReader reader = BaseFilms.instance.getGenres();
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
        private static void ajouteGenres(string genres, List<string> res)
        {
            genres = genres.Trim();
            string[] morceaux = genres.Split(BaseFilms.SEPARATEUR_LISTES_CHAR);
            foreach(string m in morceaux)
            {
                if (m?.Length > 0)
                {
                    string s = magnifique(m);
                    if (!recherche(res, s))
                        res.Add(s);
                }
            }
        }

        private static bool recherche(List<string> res, string val)
        {
            string Val = val.ToLower();
            foreach (string s in res)
                if (s.ToLower().Equals(Val))
                    return true;

            return false;
        }

        /// <summary>
        /// Tranforme une chaine de caracteres: initiale majuscule pour chaque mot
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static string magnifique(string v)
        {
            StringBuilder res = new StringBuilder();
            if (v != null)
            {
                bool precedentSeparateur = true;
                for (int i = 0; i < v.Length; i++)
                {
                    if (precedentSeparateur)
                        res.Append( char.ToUpper(v[i]));
                    else
                        res.Append(v[i]);

                    precedentSeparateur = char.IsSeparator(v[i]);
                }
            }
            return res.ToString();
        }
    }
}
