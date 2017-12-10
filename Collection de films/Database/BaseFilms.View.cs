using System.Data.SQLite;

namespace Collection_de_films.Database
{
    partial class BaseFilms
    {
        /// <summary>
        /// Vue des films filtres
        /// </summary>
        public const string VUE_FILMS_FILTRES = "FILMSFILTRES";


        private void CreateView( string viewName, Filtre filtre )
        {
            string sql = $"CREATE VIEW {viewName} AS select * FROM {filtre.table} {filtre.condition} {filtre.order}";
            MainForm.WriteMessageToConsole( "Création du filtre:" + sql );
            executeScalar( sql );
        }

        private void DeleteView( string viewName )
        {
            executeNonQuery( new SQLiteCommand( "DROP VIEW IF EXISTS " + viewName ) );
        }
    }
}
