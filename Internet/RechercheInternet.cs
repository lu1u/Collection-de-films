using CollectionDeFilms.Database;
using CollectionDeFilms.Films;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using SqlDataReader = System.Data.SQLite.SQLiteDataReader;

namespace CollectionDeFilms.Internet
{
    public abstract class RechercheInternet
    {
        public static readonly char[] TRIM_CHAR = { ' ', ',', '\n' };

        public string nom;
        public int rang;

        internal abstract Task<List<InfosFilm>> recherche(Film film);

        public async Task<List<InfosFilm>> rechercheInternet(Film film)
        {
            return await recherche(film);
        }

        protected static string requete(string titre)
        {
            return titre.Replace("  ", "+").Replace(" ", "+").Replace("/", "").Replace("\\", "");
        }
    }


       
}
