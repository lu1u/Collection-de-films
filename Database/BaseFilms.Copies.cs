using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionDeFilms.Database
{
    sealed partial class BaseFilms : BaseDonnees
    {
        /// <summary>
        ///  Table FILMS
        /// </summary>
        public const string TABLE_COPIES = "COPIES";
        public const string COPIES_ID = "ID";



        public const string COPIES_TEXTE = "TEXTE";
        public const string COPIES_SOURCE = "SOURCE";
        public const string COPIES_DESTINATION = "DESTINATION";

        /// <summary>
        /// Creer la table des copies
        /// </summary>
        private void creerTableCopies()
        {
            // Table films
            using (SQLiteCommand commande = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS {TABLE_COPIES}  ( "
                + $"{COPIES_ID} INTEGER PRIMARY KEY   AUTOINCREMENT,"
                + $"{COPIES_TEXTE} TEXT NOT NULL,"
                + $"{COPIES_SOURCE} TEXT NOT NULL,"
                + $"{COPIES_DESTINATION} TEXT NOT NULL );"))
                executeNonQuery(commande);
        }



        /// <summary>
        /// Vide la table des copies
        /// </summary>
        public async void videTableCopies()
        {
            await executeNonQueryAsync($"DELETE FROM {TABLE_COPIES};");
        }

       /// <summary>
       /// Ajoute une copie a la table des copies
       /// </summary>
       /// <param name="texte"></param>
       /// <param name="source"></param>
       /// <param name="destination"></param>
       /// <returns>Id de l'enregistrement</returns>
        public async Task<int> ajouteCopie(string texte, string source, string destination)
        {
            using (SQLiteCommand command = new SQLiteCommand($"INSERT into {TABLE_COPIES}  ({COPIES_TEXTE}, {COPIES_SOURCE}, {COPIES_DESTINATION})"
                    + " VALUES (@texte, @source, @destination)"))
            {
                command.Parameters.AddWithValue("@texte", texte );
                command.Parameters.AddWithValue("@source", source );
                command.Parameters.AddWithValue("@destination", destination);
                
                executeNonQuery(command);

                // Obtenir l'id du dernier film ajoute
                command.CommandText = $"select last_insert_rowid() as {COPIES_ID} from {TABLE_COPIES};";
                object o = await executeScalarAsync(command);
                return Convert.ToInt32(o);
            }
        }


        /// <summary>
        /// Retourne le nombre de copies qu'il y a dans la liste
        /// </summary>
        /// <returns></returns>
        public int getNbCopies()
        {
            using (SQLiteCommand command = new SQLiteCommand($"SELECT COUNT(*) FROM {TABLE_COPIES}"))
            {

                return Convert.ToInt32(executeScalar(command));
            }
        }

        /// <summary>
        /// Retourne une seul copie si la liste n'est pas vide
        /// </summary>
        /// <param name="texte"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns>vrai s'il y a une copie</returns>
        public bool getCopie(ref string texte, ref string source, ref string destination, ref int id)
        {
            using (SQLiteCommand command = new SQLiteCommand($"SELECT* FROM {TABLE_COPIES} ORDER BY ROWID ASC LIMIT 1"))
            {
                SQLiteDataReader reader = executeReader(command);
                if (reader != null && reader.HasRows)
                {
                    reader.Read();
                    id = reader.GetInt32(reader.GetOrdinal(BaseFilms.COPIES_ID));
                    texte = reader.GetString(reader.GetOrdinal(BaseFilms.COPIES_TEXTE));
                    source = reader.GetString(reader.GetOrdinal(BaseFilms.COPIES_SOURCE));
                    destination = reader.GetString(reader.GetOrdinal(BaseFilms.COPIES_DESTINATION));

                    
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Supprime la copie dont on donne l'id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true si suppression ok</returns>
        public bool supprimeCopie(int id)
        {
            // Supprimer la copie de la liste
            executeNonQueryAsync($"DELETE FROM {TABLE_COPIES} WHERE ID={id}");
            return true;
        }

        /// <summary>
        /// Retourne un objet qui permet d'iterer sur les copies
        /// </summary>
        /// <returns></returns>
        public IEnumerator<(string texte, string source, string destination)> getCopiesEnumerator()
        {
            SQLiteDataReader reader = null;
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM {TABLE_COPIES};"))
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
                    {
                        string texte = reader.GetString(reader.GetOrdinal(BaseFilms.COPIES_TEXTE));
                        string source = reader.GetString(reader.GetOrdinal(BaseFilms.COPIES_SOURCE));
                        string destination = reader.GetString(reader.GetOrdinal(BaseFilms.COPIES_DESTINATION));

                        yield return ( texte, source, destination);
                    }

                reader.Close();
            }
        }
    }
}
