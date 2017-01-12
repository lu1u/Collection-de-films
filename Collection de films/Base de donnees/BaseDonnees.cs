using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using Collection_de_films.Films;
using Collection_de_films.Fenetres;

namespace Collection_de_films.Database
{
    partial class BaseDonnees : IDisposable
    {
        #region Constantes
        const string DATABASE_NAME = "collection films.sqlite";

        
        
        /// <summary>
        /// Vue des films filtres
        /// </summary>
        public const string VUE_FILMS_FILTRES = "FILMSFILTRES";


        // Table CONFIGURATION
        const string TABLE_CONFIGURATION = "CONFIGURATION";
        const string CONFIGURATION_NOM = "NOM";
        const string CONFIGURATION_VALEUR = "VALEUR";
        #endregion

        private static BaseDonnees _instance;
        private SQLiteConnection maConnexion;
        static public BaseDonnees getInstance()
        {
            if (_instance == null)
                _instance = new BaseDonnees();

            return _instance;
        }

        public void Dispose()
        {
            maConnexion?.Close();
        }


        private BaseDonnees()
        {
            AssureBDExiste();
            maConnexion.Open();
            creerVueFilms(new Filtre());
        }

        /// <summary>
        /// S'assurer que la BD existe, la creer si elle n'existe pas
        /// </summary>
        private void AssureBDExiste()
        {
            if (!File.Exists(DATABASE_NAME))
            {
                try
                {
                    SQLiteConnection.CreateFile(DATABASE_NAME);
                    maConnexion = new SQLiteConnection("Data Source=" + DATABASE_NAME + ";Version=3;");
                    maConnexion.Open();

                    creerTableFilms();
                    creerTableAlternatives();
                    creerTableRecherche();
                    creerTableConfiguration();
                    
                    maConnexion.Close();
                }
                catch (Exception e)
                {
                    MainForm.WriteExceptionToConsole(e);
                }
            }
            else
            {
                maConnexion = new SQLiteConnection("Data Source=" + DATABASE_NAME + ";Version=3;");
            }
        }

        internal void executeNonQuery(SQLiteCommand command)
        {
            try
            {
                command.Connection = maConnexion;
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MainForm.WriteErrorToConsole("Erreur à l'execution d'une requete SQL");
                MainForm.WriteErrorToConsole(command.CommandText);
                MainForm.WriteErrorToConsole(command.Parameters.ToString());
                MainForm.WriteExceptionToConsole(e);
            }
        }

        internal SQLiteDataReader executeReader(SQLiteCommand command)
        {
            try
            {
                command.Connection = maConnexion;
                return command.ExecuteReader();
            }
            catch (Exception e)
            {
                MainForm.WriteErrorToConsole("Erreur à l'execution d'une requete SQL");
                MainForm.WriteErrorToConsole(command.CommandText);
                MainForm.WriteErrorToConsole(command.Parameters.ToString());
                MainForm.WriteExceptionToConsole(e);
            }

            return null;
        }

        internal object executeScalar(string slqCommand)
        {
            return executeScalar(new SQLiteCommand(slqCommand));
        }

        internal object executeScalar(SQLiteCommand command)
        {
            try
            {
                command.Connection = maConnexion;
                return command.ExecuteScalar();
            }
            catch (Exception e)
            {
                MainForm.WriteErrorToConsole("Erreur à l'execution d'une requete SQL");
                MainForm.WriteErrorToConsole(command.CommandText);
                MainForm.WriteErrorToConsole(command.Parameters.ToString());
                MainForm.WriteExceptionToConsole(e);
            }
            return null;
        }

        internal void Menage( MenageEnCours dlg)
        {
            dlg.pourcentage(30);
            // Purger les alternatives non associees a un film
            executeScalar("DELETE FROM " + TABLE_ALTERNATIVES + " WHERE " + ALTERNATIVES_FILMID + " NOT IN (SELECT " + FILMS_ID + " FROM " + TABLE_FILMS + ")");
            dlg.pourcentage(60);
            // Compression de la base
            executeScalar("VACUUM");
            dlg.pourcentage(100);
        }
        
    }
}
