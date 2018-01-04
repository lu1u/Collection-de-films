using Collection_de_films.Films;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace Collection_de_films.Database
{
    partial class BaseFilms : IDisposable
    {
        /// <summary>
        /// Table ALTERNATIVES
        /// </summary>
        public const string TABLE_ALTERNATIVES = "ALTERNATIVES";
        public const string ALTERNATIVES_FILMID = "FilmId";
        public const string ALTERNATIVES_REALISATEUR = "REALISATEUR";
        public const string ALTERNATIVES_ACTEURS = "ACTEURS";
        public const string ALTERNATIVES_GENRES = "GENRES";
        public const string ALTERNATIVES_NATIONALITE = "NATIONALITE";
        public const string ALTERNATIVES_RESUME = "RESUME";
        public const string ALTERNATIVES_DATESORTIE = "DATESORTIE";
        public const string ALTERNATIVES_IMAGE = "IMAGE";

        private void creerTableAlternatives()
        {
            executeNonQuery( $"CREATE TABLE {TABLE_ALTERNATIVES} "
                + $" ({ALTERNATIVES_FILMID} INTEGER REFERENCES {TABLE_FILMS}([{FILMS_ID}]),"
                + $" {ALTERNATIVES_REALISATEUR} TEXT NOT NULL,"
                + $" {ALTERNATIVES_ACTEURS} TEXT NOT NULL,"
                + $" {ALTERNATIVES_GENRES} TEXT NOT NULL,"
                + $" {ALTERNATIVES_NATIONALITE} TEXT NOT NULL,"
                + $" {ALTERNATIVES_RESUME} NOT NULL,"
                + $" {ALTERNATIVES_DATESORTIE} TEXT NOT NULL,"
                + $" {ALTERNATIVES_IMAGE} BLOB"
                + " );" );
        }

        public void sauveAlternatives( int id, List<InfosFilm> alternatives )
        {
            using ( SQLiteCommand command = new SQLiteCommand( $"DELETE FROM {TABLE_ALTERNATIVES} WHERE {ALTERNATIVES_FILMID} = @id" ) )
            {
                command.Parameters.AddWithValue( "@id", id );
                executeNonQuery( command );
            }

            // Ajouter les nouvelles alternatives, associees au film dont on donne l'id
            if ( alternatives != null )
                foreach ( InfosFilm alternative in alternatives )
                    using ( SQLiteCommand command = new SQLiteCommand( $"INSERT into {TABLE_ALTERNATIVES} " +
                                $"({ALTERNATIVES_FILMID}, {ALTERNATIVES_REALISATEUR}, {ALTERNATIVES_ACTEURS}, {ALTERNATIVES_GENRES}, {ALTERNATIVES_NATIONALITE}, {ALTERNATIVES_RESUME}, {ALTERNATIVES_DATESORTIE}, {ALTERNATIVES_IMAGE})"
                            + " VALUES (@id, @realisateur, @acteurs, @genres, @nationalite, @resume, @datesortie, @affiche)" ) )
                    {
                        command.Parameters.AddWithValue( "@id", id );
                        command.Parameters.AddWithValue( "@realisateur", alternative._realisateur );
                        command.Parameters.AddWithValue( "@acteurs", alternative._acteurs );
                        command.Parameters.AddWithValue( "@genres", alternative._genres );
                        command.Parameters.AddWithValue( "@nationalite", alternative._nationalite );
                        command.Parameters.AddWithValue( "@datesortie", alternative._dateSortie );
                        command.Parameters.AddWithValue( "@resume", alternative._resume );
                        command.Parameters.AddWithValue( "@affiche", BaseFilms.SqlBinnaryPeutEtreNull(Images.imageToByteArray(alternative._image)));
                        executeNonQuery( command );
                    }
        }


        internal int getNbAlternatives( int id )
        {
            using ( SQLiteCommand command = new SQLiteCommand( "SELECT COUNT(*) FROM ALTERNATIVES WHERE FilmId = @id" ) )
            {

                command.Parameters.AddWithValue( "@id", id );
                return Convert.ToInt32( executeScalar( command ) );
            }
        }

        public async Task<List<InfosFilm>> getAlternatives( int id )
        {
            List<InfosFilm> result = new List<InfosFilm>();
            using ( SQLiteCommand command = new SQLiteCommand( "SELECT * FROM ALTERNATIVES WHERE FilmId = @id" ) )
            {
                command.Parameters.AddWithValue( "@id", id );

                using ( SQLiteDataReader reader = executeReader( command ) )
                    if ( reader.HasRows )
                    {
                        // Read advances to the next row.
                        while ( reader.Read() )
                        {
                            result.Add( new InfosFilm( reader ) );
                        }
                    }
            }
            return result;
        }


        /// <summary>
        /// Supprime les alternatives d'un film
        /// </summary>
        /// <param name="film"></param>
        public void supprimeAlternatives( int filmId )
        {
            // Supprimer les alternatives
            using ( SQLiteCommand command = new SQLiteCommand( $"DELETE FROM {TABLE_ALTERNATIVES} WHERE {ALTERNATIVES_FILMID} = @id" ) )
            {
                command.Parameters.AddWithValue( "@id", filmId );
                executeNonQuery( command );
            }
        }



        public void supprimeAlternativesOrphelines()
        {
            using ( SQLiteCommand command = new SQLiteCommand( $"DELETE FROM {TABLE_ALTERNATIVES} WHERE  {TABLE_ALTERNATIVES}.{ALTERNATIVES_FILMID} not in ( SELECT {TABLE_FILMS}.{FILMS_ID} FROM {TABLE_FILMS})" ) )
            {
                executeNonQuery( command );
            }
        }
    }
}
