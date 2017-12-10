using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using Collection_de_films.Films;
using Collection_de_films.Fenetres;
using System.Data.Common;

namespace Collection_de_films.Database
{
    sealed partial class BaseFilms : BaseDonnees
    {
        #region Constantes
        public const string EXTENSION = "collection";
        private static string DATABASE_PATH = Configuration.instance.baseFilms + "."+ EXTENSION ;
        public const string SEPARATEUR_LISTES = "|";
        public const char  SEPARATEUR_LISTES_CHAR = '|';
        #endregion


        private static object syncRoot = new object();


        public static BaseFilms instance
        {
            get
            {
                if ( _instance == null )
                    lock ( syncRoot )
                        if ( _instance == null )
                            _instance = new BaseFilms( DATABASE_PATH  );

                return _instance;
            }
        }

        private static volatile BaseFilms _instance;
        private BaseFilms(string dbName) : base( dbName)
        {
            creerVueFilms( new Filtre() );
        }

        internal static bool Existe( string nom )
        {
            string filePath = Path.Combine( baseDefaultLocation(), nom + '.' + EXTENSION);
            return File.Exists( filePath );
        }

        internal static void creerNouvelleBase( string nom )
        {
            lock ( syncRoot )
            {
                string dbName = getNomBase(nom) ;
                BaseFilms bf = new BaseFilms(dbName);
            }
        }

        internal static bool selectionneNouvelleBase( string nom )
        {
            lock ( syncRoot )
            {
                _instance?.Dispose();
                DATABASE_PATH = getNomBase(nom);
                _instance = new BaseFilms(DATABASE_PATH);
                Configuration.instance.baseFilms = nom;
            }

            return true;
        }

        internal static void supprimeCollection( string nom )
        {
            File.Delete( Path.Combine( baseDefaultLocation(), getNomBase(nom) ));
        }

        public static string getNomBase( string nom )
        {
            return nom + "." + EXTENSION;
        }

        /// <summary>
        /// Mettre ici du code SQL qu'on veut executer AVANT de se servir de la base
        /// </summary>
        protected override void SQLInitial()
        {
            //executeScalar("PRAGMA foreign_keys = OFF");
            //executeScalar( "BEGIN TRANSACTION;");
            //executeScalar( "CREATE TABLE ALTERNATIVES_2( FilmId INTEGER REFERENCES FILMS([ID] ), REALISATEUR TEXT NOT NULL, ACTEURS TEXT NOT NULL, GENRES TEXT NOT NULL, NATIONALITE TEXT NOT NULL, RESUME NOT NULL, DATESORTIE TEXT NOT NULL, AFFICHE_ID INTEGER REFERENCES IMAGES([ID]) )" );
            //executeScalar( "INSERT INTO ALTERNATIVES_2 SELECT * FROM ALTERNATIVES" );
            //executeScalar( "COMMIT TRANSACTION;");
            //executeScalar( "PRAGMA foreign_keys = ON;" );
        }



        /*
        async internal Task<SQLiteDataReader> executeReaderAsync( SQLiteCommand command )
        {
            try
            {
                command.Connection = maConnexion;
                DbDataReader reader = await command.ExecuteReaderAsync();
                return re
            }
            catch ( Exception e )
            {
                MainForm.WriteErrorToConsole( "Erreur à l'execution d'une requete SQL" );
                MainForm.WriteErrorToConsole( command.CommandText );
                MainForm.WriteErrorToConsole( command.Parameters.ToString() );
                MainForm.WriteExceptionToConsole( e );
            }

            return null;
        }*/



        internal void Menage( MenageEnCours dlg )
        {
            dlg.pourcentage( 30 );
            // Purger les alternatives non associees a un film
            supprimeAlternativesOrphelines();
            supprimeImagesOrphelines();
            dlg.pourcentage( 60 );
            // Compression de la base
            executeScalar( "VACUUM" );
            dlg.pourcentage( 100 );
        }

        /// <summary>
        /// S'assurer que la BD existe, la creer si elle n'existe pas
        /// </summary>
        protected override void AssureBDExiste(string dbName)
        {
            if ( File.Exists( dbName ) )
                connexion = new SQLiteConnection( $"Data Source={dbName};Version=3;" );
            else
            {
                try
                {
                    SQLiteConnection.CreateFile( dbName );
                    connexion = new SQLiteConnection( $"Data Source={dbName};Version=3;" );
                    connexion.Open();

                    creerTableImages();
                    creerTableFilms();
                    creerTableAlternatives();

                    connexion.Close();
                }
                catch ( Exception e )
                {
                    MainForm.WriteExceptionToConsole( e );
                }
            }
        }
    }
}
