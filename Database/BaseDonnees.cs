using System;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace CollectionDeFilms.Database
{
    abstract internal class BaseDonnees
    {
        protected SQLiteConnection connexion;
        protected abstract void assureBDExiste(string dbPath);
        protected abstract void creerTablesSiNonExiste();
        protected virtual void SQLInitial() { }

        protected string _dbPath;
        protected BaseDonnees(string dbPath)
        {
            _dbPath = Path.Combine(baseDefaultLocation(), dbPath);
            assureBDExiste(_dbPath);
            connexion.Open();
            creerTablesSiNonExiste();
            SQLInitial();
        }

        public static string baseDefaultLocation()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Collection de films");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }

        public string name => Path.GetFileNameWithoutExtension(_dbPath);


        internal void executeNonQuery(string sql)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(sql))
                executeNonQuery(cmd);
        }


        public void Dispose()
        {
            connexion?.Close();
            connexion?.Dispose();
        }

        /// <summary>
        /// Execute d'une commande SQL sans récupération de résultat
        /// </summary>
        /// <param name="command">Commande SQL a exécuter</param>
        /// <returns>true si la commande s'est correctement exécutée</returns>
        internal bool executeNonQuery(SQLiteCommand command)
        {
            try
            {
                command.Connection = connexion;
                MainForm.WriteMessageToConsole(command.CommandText);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MainForm.WriteErrorToConsole("Erreur à l'execution d'une requete SQL");
                MainForm.WriteErrorToConsole(command.CommandText);
                MainForm.WriteErrorToConsole(command.Parameters.ToString());
                MainForm.WriteExceptionToConsole(e);
                return false;
            }
        }

        internal Task executeNonQueryAsync(string sqlCommand)
        {
            MainForm.WriteMessageToConsole(sqlCommand);

            using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand))
                return executeNonQueryAsync(cmd);
        }

        async internal Task executeNonQueryAsync(SQLiteCommand command)
        {
            try
            {
                command.Connection = connexion;
                MainForm.WriteMessageToConsole(command.CommandText);
                await command.ExecuteNonQueryAsync();
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
                command.Connection = connexion;
                MainForm.WriteMessageToConsole(command.CommandText + ", paramètres:" + toString(command.Parameters));
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

        private string toString(SQLiteParameterCollection parameters)
        {
            string res = "";
            foreach (SQLiteParameter p in parameters)
                res += $"[{p.ParameterName}={p.Value}]";
            return res;
        }

        async internal Task<object> executeScalarAsync(string sqlCommand)
        {
            MainForm.WriteMessageToConsole(sqlCommand);

            using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand))
                return await executeScalarAsync(cmd);
        }

        internal object executeScalar(string sqlCommand)
        {
            MainForm.WriteMessageToConsole(sqlCommand);

            using (SQLiteCommand cmd = new SQLiteCommand(sqlCommand))
                return executeScalar(cmd);
        }


        internal object executeScalar(SQLiteCommand command)
        {
            try
            {
                command.Connection = connexion;
                MainForm.WriteMessageToConsole(command.CommandText + ", paramètres:" + toString(command.Parameters));
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

        async internal Task<object> executeScalarAsync(SQLiteCommand command)
        {
            try
            {
                command.Connection = connexion;
                MainForm.WriteMessageToConsole(command.CommandText + ", paramètres:" + toString(command.Parameters));
                return await command.ExecuteScalarAsync();
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

        /// <summary>
        /// Encode les caracteres spéciaux
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        protected static string Encode(string v)
        {
            v = v.Replace("'", "''");
            return v; ;
        }


        /// <summary>
        /// Lire une image dans une colonne d'un enregistrement de la base
        /// </summary>
        /// <param name="reader">Le curseur en cours, positionné sur le bon enregistrement</param>
        /// <param name="colonne">Numero de la colonne</param>
        /// <returns></returns>
        public static Image readImage(SQLiteDataReader reader, int colonne)
        {
            try
            {
                Stream picData = reader.GetStream(colonne);
                if (picData == null)
                    // Pas d'image
                    return null;

                return new Bitmap(picData);
            }
            catch (Exception)
            {
                // Pas d'image
                return null;
            }
        }
    }
}
