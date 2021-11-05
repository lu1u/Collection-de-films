using CollectionDeFilms.Fenetres;
using CollectionDeFilms.Films;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;

namespace CollectionDeFilms.Database
{
    sealed partial class BaseFilms : BaseDonnees
    {
        #region Constantes
        public const string EXTENSION = "collection2";
        private static string DATABASE_PATH = Configuration.instance.baseFilms + "." + EXTENSION;
        public const string SEPARATEUR_LISTES = "|";
        public const char SEPARATEUR_LISTES_CHAR = '|';
        #endregion


        private static object syncRoot = new object();


        public static BaseFilms instance
        {
            get
            {
                if (_instance == null)
                    lock (syncRoot)
                        if (_instance == null)
                            _instance = new BaseFilms(DATABASE_PATH);

                return _instance;
            }
        }

        private static volatile BaseFilms _instance;
        private BaseFilms(string dbName) : base(dbName)
        {
        }

        internal static bool existe(string nom)
        {
            string filePath = Path.Combine(baseDefaultLocation(), nom + '.' + EXTENSION);
            return File.Exists(filePath);
        }

        /// <summary>
        /// Retourne VRAI si le film dont on donne l'id existe dans la base
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        async public Task<bool> existe(int id)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT COUNT({FILMS_ID}) FROM {TABLE_FILMS} WHERE {FILMS_ID} = @id"))
            {
                cmd.Parameters.AddWithValue("@id", id);
                int n = Convert.ToInt32(await executeScalarAsync(cmd));
                return n > 0;
            }
        }

        internal static void creerNouvelleBase(string nom)
        {
            lock (syncRoot)
            {
                string dbName = getNomBase(nom);
                BaseFilms bf = new BaseFilms(dbName);
            }
        }

        internal static bool selectionneNouvelleBase(string nom)
        {
            lock (syncRoot)
            {
                _instance?.Dispose();
                DATABASE_PATH = getNomBase(nom);
                _instance = new BaseFilms(DATABASE_PATH);
                Configuration.instance.baseFilms = nom;
            }

            return true;
        }

        internal static void supprimeCollection(string nom)
        {
            File.Delete(Path.Combine(baseDefaultLocation(), getNomBase(nom)));
        }

        public static string getNomBase(string nom)
        {
            return nom + "." + EXTENSION;
        }


        /// <summary>
        /// Mettre ici du code SQL qu'on veut executer AVANT de se servir de la base
        /// </summary>
        protected override void SQLInitial()
        {
            executeNonQuery("PRAGMA CACHE_SIZE = 200000");
        }



        //TODO:
        //async internal void menage( MenageEnCours dlg )
        //{
        //    dlg.pourcentage( 30 );
        //    // Purger les alternatives non associees a un film
        //    //TODO: supprimeAlternativesOrphelines();
        //    dlg.pourcentage( 60 );
        //    // Compression de la base
        //    executeNonQueryAsync( "VACUUM" );
        //    dlg.pourcentage( 100 );
        //}

        /// <summary>
        /// S'assurer que la BD existe, la creer si elle n'existe pas
        /// </summary>
        protected override void assureBDExiste(string dbName)
        {
            if (File.Exists(dbName))
                connexion = new SQLiteConnection($"Data Source={dbName};Version=3;");
            else
            {
                try
                {
                    SQLiteConnection.CreateFile(dbName);
                    connexion = new SQLiteConnection($"Data Source={dbName};Version=3;");
                    connexion.Open();

                    creerTableFilms();
                    creerTableCopies();
                    creerTableAlternatives();

                    connexion.Close();
                }
                catch (Exception e)
                {
                    MainForm.WriteExceptionToConsole(e);
                }
            }
        }

        /// <summary>
        /// Creer les tables de la base, si elles n'existent pas
        /// </summary>
        protected override void creerTablesSiNonExiste()
        {
            creerTableFilms();
            creerTableCopies();
            creerTableAlternatives();
        }

        /// <summary>
        /// Faire le menage de la base des films
        /// </summary>
        /// <param name="dlg"></param>
        internal void menage(MenageEnCours dlg)
        {
            dlg.pourcentage(20);

            // Supprimer les affiches de films qui ne sont plus associées à un film
            using (SQLiteCommand cmd = new SQLiteCommand($"DELETE FROM {TABLE_IMAGES} WHERE {IMAGES_FILM_ID} NOT IN (SELECT {FILMS_ID} from {TABLE_FILMS});"))
            {
                executeNonQuery(cmd);
            }

            dlg.pourcentage(40);

            // Purger les alternatives non associees a un film
            supprimeAlternativesOrphelines();
            dlg.pourcentage(60);
            // Compression de la base
            executeNonQueryAsync("VACUUM");
            dlg.pourcentage(100);
        }

        public IEnumerator<Film> getFilmEnumerator(String condition)
        {
            SQLiteDataReader reader = null;
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand($"SELECT {BaseFilms.FILMS_ID} FROM {TABLE_FILMS} {condition} ;"))
                {
                    reader = executeReader(cmd);
                }
            }
            catch (Exception e)
            {
                MainForm.WriteExceptionToConsole(e);
            }

            if (reader != null)
            {
                // Check is the reader has any rows at all before starting to read.
                if (reader.HasRows)
                    // Read advances to the next row.
                    while (reader.Read())
                        yield return new Film(reader);

                reader.Close();
            }
        }

        public IEnumerator<Film> getFilmEnumerator(Filtre filtre)
        {
            SQLiteDataReader reader = null;
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand($"SELECT {BaseFilms.FILMS_ID} FROM {TABLE_FILMS} {filtre.RequeteSQL} {filtre.CritereTri} ;"))
                {
                    reader = executeReader(cmd);
                }
            }
            catch (Exception e)
            {
                MainForm.WriteExceptionToConsole(e);
            }

            if (reader != null)
            {
                // Check is the reader has any rows at all before starting to read.
                if (reader.HasRows)
                    // Read advances to the next row.
                    while (reader.Read())
                        yield return new Film(reader);

                reader.Close();
            }
        }
    }
}
