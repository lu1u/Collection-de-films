using System.Data.SQLite;

namespace Collection_de_films.Database
{
    partial class BaseFilms
    {
        /// <summary>
        /// Vue des films filtres
        /// </summary>
        public const string VUE_FILMS_FILTRES = "FILMSFILTRES";
        public const string VUE_FILMS_SELECT = BaseFilms.FILMS_ID + "," + BaseFilms.FILMS_CHEMIN + "," + BaseFilms.FILMS_TITRE + "," + BaseFilms.FILMS_REALISATEUR + "," + BaseFilms.FILMS_ACTEURS + "," + BaseFilms.FILMS_GENRES + "," + BaseFilms.FILMS_NATIONALITE + "," + BaseFilms.FILMS_RESUME + "," + BaseFilms.FILMS_DATESORTIE + "," + BaseFilms.FILMS_ETAT + "," + BaseFilms.FILMS_FLAGS + "," + BaseFilms.FILMS_TAG ;

        private void CreateView( string viewName, string select, Filtre filtre )
        {
            string sql = $"CREATE VIEW {viewName} AS select {select} FROM {filtre.table} {filtre.condition} {filtre.order}";
            MainForm.WriteMessageToConsole( "Création du filtre:" + sql );
            executeScalar( sql );
        }

        private void DeleteView( string viewName )
        {
            executeNonQuery( new SQLiteCommand( "DROP VIEW IF EXISTS " + viewName ) );
        }
    }
}
