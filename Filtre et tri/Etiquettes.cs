using CollectionDeFilms.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionDeFilms.Filtre_et_tri
{
    class Etiquettes
    {
        static List<string> _etiquettes;

        /// <summary>
        /// Retourne une liste de genres uniques
        /// </summary>
        /// <returns></returns>
        public static List<string> getEtiquettes()
        {
            if (_etiquettes == null)
            {
                // Construire une nouvelle liste d'etiquettes
                _etiquettes = new List<string>();
                SQLiteDataReader reader = BaseFilms.instance.getEtiquettes();
                if (reader.HasRows)
                {
                    int ordinal = reader.GetOrdinal(BaseFilms.FILMS_TAG);
                    // Read advances to the next row.
                    while (reader.Read())
                    {
                        string genres = reader.GetString(ordinal);
                        ajouteEtiquettes(genres, _etiquettes);
                    }
                }

                for (int i = 0; i < _etiquettes.Count; i++)
                    _etiquettes[i] = Genres.magnifique(_etiquettes[i]);

                _etiquettes.Sort();
                }

            return _etiquettes;
        }

        /// <summary>
        /// Mise a jour de la base, reinitialiser la liste de genres
        /// </summary>
        public static void updateEtiquettes()
        {
            _etiquettes = null;
        }

        /// <summary>
        /// Ajoute les genres donnés dans une chaine de caracteres a la liste s'ils n'y sont pas déjà
        /// </summary>
        /// <param name="genres"></param>
        /// <param name="res"></param>
        private static void ajouteEtiquettes(string genres, List<string> res)
        {
            genres = genres.Trim();
            string[] morceaux = genres.Split(BaseFilms.SEPARATEUR_LISTES_CHAR);
            foreach (string m in morceaux)
            {
                if (m?.Length > 0)
                {
                    string s = m.Trim().ToLower() ;
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
        /// Tranforme une chaine de caracteres: initiale majuscule, le reste en minuscules
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        //private static string magnifique(string v)
        //{
        //    if (v?.Length < 2)
        //        return v;
        //
        //    return v.Substring(0, 1).ToUpper() + v.Substring(1).ToLower() ;
        //}
    }
}
