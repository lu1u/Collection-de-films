using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_de_films.Database
{
    abstract internal class BaseDonnees
    {
        protected SQLiteConnection connexion;
        protected abstract void AssureBDExiste(string dbPath);
        protected virtual void SQLInitial() { }
        protected string _dbPath ;
        protected BaseDonnees(string dbPath)
        {
            _dbPath = Path.Combine(baseDefaultLocation(), dbPath);
            AssureBDExiste(_dbPath);
            connexion.Open();
            SQLInitial();
        }

        public static string baseDefaultLocation()
        {
            string path = Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments), "Collection de films" );
            if ( !Directory.Exists( path ) )
                Directory.CreateDirectory( path );

            return path;
        }

        public string name => Path.GetFileNameWithoutExtension( _dbPath );



        internal void executeNonQuery( string sql )
        {
            using ( SQLiteCommand cmd = new SQLiteCommand( sql ) )
                executeNonQuery( cmd );
        }


        public void Dispose()
        {
            connexion?.Close();
            connexion?.Dispose();
        }

        internal void executeNonQuery( SQLiteCommand command )
        {
            try
            {
                command.Connection = connexion;
                MainForm.WriteMessageToConsole(command.CommandText);
                command.ExecuteNonQuery();
            }
            catch ( Exception e )
            {
                MainForm.WriteErrorToConsole( "Erreur à l'execution d'une requete SQL" );
                MainForm.WriteErrorToConsole( command.CommandText );
                MainForm.WriteErrorToConsole( command.Parameters.ToString() );
                MainForm.WriteExceptionToConsole( e );
            }
        }


        async internal Task executeNonQueryAsync( SQLiteCommand command )
        {
            try
            {
                command.Connection = connexion;
                MainForm.WriteMessageToConsole(command.CommandText);
                await command.ExecuteNonQueryAsync();
            }
            catch ( Exception e )
            {
                MainForm.WriteErrorToConsole( "Erreur à l'execution d'une requete SQL" );
                MainForm.WriteErrorToConsole( command.CommandText );
                MainForm.WriteErrorToConsole( command.Parameters.ToString() );
                MainForm.WriteExceptionToConsole( e );
            }
        }
        internal SQLiteDataReader executeReader( SQLiteCommand command )
        {
            try
            {
                command.Connection = connexion;
                MainForm.WriteMessageToConsole(command.CommandText);
                return command.ExecuteReader();
            }
            catch ( Exception e )
            {
                MainForm.WriteErrorToConsole( "Erreur à l'execution d'une requete SQL" );
                MainForm.WriteErrorToConsole( command.CommandText );
                MainForm.WriteErrorToConsole( command.Parameters.ToString() );
                MainForm.WriteExceptionToConsole( e );
            }

            return null;
        }

        internal object executeScalar( string sqlCommand )
        {
            MainForm.WriteMessageToConsole(sqlCommand);

            using ( SQLiteCommand cmd = new SQLiteCommand( sqlCommand ) )
                return executeScalar( cmd );
        }

        internal object executeScalar( SQLiteCommand command )
        {
            try
            {
                command.Connection = connexion;
                MainForm.WriteMessageToConsole(command.CommandText);
                return command.ExecuteScalar();
            }
            catch ( Exception e )
            {
                MainForm.WriteErrorToConsole( "Erreur à l'execution d'une requete SQL" );
                MainForm.WriteErrorToConsole( command.CommandText );
                MainForm.WriteErrorToConsole( command.Parameters.ToString() );
                MainForm.WriteExceptionToConsole( e );
            }
            return null;
        }
    }
}
