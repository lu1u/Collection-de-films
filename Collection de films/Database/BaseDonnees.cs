﻿using System;
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
            _dbPath = dbPath;
            AssureBDExiste(dbPath);
            connexion.Open();
            SQLInitial();
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


        async internal void executeNonQueryAsync( SQLiteCommand command )
        {
            try
            {
                command.Connection = connexion;
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

        internal object executeScalar( string slqCommand )
        {
            using ( SQLiteCommand cmd = new SQLiteCommand( slqCommand ) )
                return executeScalar( cmd );
        }

        internal object executeScalar( SQLiteCommand command )
        {
            try
            {
                command.Connection = connexion;
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
