using System;
using System.Data.SQLite;
using System.IO;

namespace CollectionDeFilms.Database
{
    sealed partial class BaseConfiguration : BaseDonnees
    {
        public const string DATABASE_NAME = "configuration.db";
        const string CONFIGURATION_NOM = "NOM";
        const string CONFIGURATION_VALEUR = "VALEUR";
        const string TABLE_CONFIGURATION = "CONFIGURATION";
        private static volatile BaseConfiguration _instance;

        private static object syncRoot = new object();
        public static BaseConfiguration instance
        {
            get
            {
                if (_instance == null)
                    lock (syncRoot)
                        if (_instance == null)
                            _instance = new BaseConfiguration(DATABASE_NAME);

                return _instance;
            }
        }

        private BaseConfiguration(string dbName) : base(dbName)
        {
        }

        internal void creerTableConfiguration()
        {
            // Table de configuration
            SQLiteCommand commande = new SQLiteCommand("CREATE TABLE IF NOT EXISTS " + TABLE_CONFIGURATION +
                " ( "
                + CONFIGURATION_NOM + "	TEXT NOT NULL UNIQUE,"
                + CONFIGURATION_VALEUR + " TEXT NOT NULL,"
                + "PRIMARY KEY(" + CONFIGURATION_NOM + ")"
                + " ) WITHOUT ROWID;", connexion);

            commande.ExecuteNonQuery();
        }

        internal string getValeurConfiguration(string nom)
        {
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT " + CONFIGURATION_VALEUR + " FROM " + TABLE_CONFIGURATION
                                             + " WHERE " + CONFIGURATION_NOM + " = @nom"))
            {
                cmd.Parameters.AddWithValue("@nom", nom);
                return Convert.ToString( executeScalar(cmd));
            }
        }

        internal async void setValeurConfiguration(string nom, string valeur)
        {
            using (SQLiteCommand cmd = new SQLiteCommand("INSERT OR REPLACE INTO "
                                                        + TABLE_CONFIGURATION
                                                        + " (" + CONFIGURATION_NOM + "," + CONFIGURATION_VALEUR + ") "
                                                        + " VALUES(@nom, @valeur)"))
            {
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@valeur", valeur);
                await executeNonQueryAsync(cmd);
            }
        }

        /// <summary>
        /// S'assurer que la BD existe, la creer si elle n'existe pas
        /// </summary>
        protected override void assureBDExiste(string dbName)
        {
            if (File.Exists(dbName))
            {
                connexion = new SQLiteConnection($"Data Source={dbName};Version=3;");
            }
            else
            {
                try
                {
                    SQLiteConnection.CreateFile(dbName);
                    connexion = new SQLiteConnection($"Data Source={dbName};Version=3;");
                    connexion.Open();
                    //TODO: creerTableRecherche();
                    creerTableConfiguration();
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
            creerTableConfiguration();
        }
    }
}
