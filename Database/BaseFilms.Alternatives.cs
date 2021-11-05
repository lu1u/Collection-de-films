using CollectionDeFilms.Films;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionDeFilms.Database
{
    partial class BaseFilms : IDisposable
    {
        /// <summary>
        /// Table ALTERNATIVES
        /// </summary>
        public const string TABLE_ALTERNATIVES = "ALTERNATIVES";
        public const string ALTERNATIVES_FILMID = "FilmId";
        public const string ALTERNATIVES_TITRE = "TITRE";
        public const string ALTERNATIVES_REALISATEUR = "REALISATEUR";
        public const string ALTERNATIVES_ACTEURS = "ACTEURS";
        public const string ALTERNATIVES_GENRES = "GENRES";
        public const string ALTERNATIVES_NATIONALITE = "NATIONALITE";
        public const string ALTERNATIVES_RESUME = "RESUME";
        public const string ALTERNATIVES_DATESORTIE = "DATESORTIE";
        public const string ALTERNATIVES_IMAGE = "IMAGE";

        private void creerTableAlternatives()
        {
            executeNonQuery($"CREATE TABLE IF NOT EXISTS {TABLE_ALTERNATIVES} "
                + $" ({ALTERNATIVES_FILMID} INTEGER REFERENCES {TABLE_FILMS}([{FILMS_ID}]),"
                + $" {ALTERNATIVES_TITRE} TEXT NOT NULL,"
                + $" {ALTERNATIVES_REALISATEUR} TEXT NOT NULL,"
                + $" {ALTERNATIVES_ACTEURS} TEXT NOT NULL,"
                + $" {ALTERNATIVES_GENRES} TEXT NOT NULL,"
                + $" {ALTERNATIVES_NATIONALITE} TEXT NOT NULL,"
                + $" {ALTERNATIVES_RESUME} NOT NULL,"
                + $" {ALTERNATIVES_DATESORTIE} TEXT NOT NULL,"
                + $" {ALTERNATIVES_IMAGE} BLOB"
                + " );");
        }

        public void sauveAlternatives(int id, List<InfosFilm> alternatives)
        {
            using (SQLiteCommand command = new SQLiteCommand($"DELETE FROM {TABLE_ALTERNATIVES} WHERE {ALTERNATIVES_FILMID} = @id"))
            {
                command.Parameters.AddWithValue("@id", id);
                executeNonQuery(command);
            }

            // Ajouter les nouvelles alternatives, associees au film dont on donne l'id
            if (alternatives != null)
                foreach (InfosFilm alternative in alternatives)
                    using (SQLiteCommand command = new SQLiteCommand($"INSERT into {TABLE_ALTERNATIVES} " +
                                $"({ALTERNATIVES_FILMID}, {ALTERNATIVES_TITRE}, {ALTERNATIVES_REALISATEUR}, {ALTERNATIVES_ACTEURS}, {ALTERNATIVES_GENRES}, {ALTERNATIVES_NATIONALITE}, {ALTERNATIVES_RESUME}, {ALTERNATIVES_DATESORTIE}, {ALTERNATIVES_IMAGE})"
                            + " VALUES (@id, @titre, @realisateur, @acteurs, @genres, @nationalite, @resume, @datesortie, @affiche)"))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@titre", alternative._titre);
                        command.Parameters.AddWithValue("@realisateur", alternative._realisateur);
                        command.Parameters.AddWithValue("@acteurs", alternative._acteurs);
                        command.Parameters.AddWithValue("@genres", alternative._genres);
                        command.Parameters.AddWithValue("@nationalite", alternative._nationalite);
                        command.Parameters.AddWithValue("@datesortie", alternative._dateSortie);
                        command.Parameters.AddWithValue("@resume", alternative._resume);
                        command.Parameters.AddWithValue("@affiche", BaseFilms.SqlBinaryPeutEtreNull(Images.imageToByteArray(alternative._image)));
                        executeNonQuery(command);
                    }
        }


        internal int getNbAlternatives(int id)
        {
            using (SQLiteCommand command = new SQLiteCommand($"SELECT COUNT(*) FROM {TABLE_ALTERNATIVES} WHERE {ALTERNATIVES_FILMID} = @id"))
            {

                command.Parameters.AddWithValue("@id", id);
                return Convert.ToInt32(executeScalar(command));
            }
        }

        public List<InfosFilm> getAlternatives(int id)
        {
            List<InfosFilm> result = new List<InfosFilm>();
            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM ALTERNATIVES WHERE FilmId = @id"))
            {
                command.Parameters.AddWithValue("@id", id);

                using (SQLiteDataReader reader = executeReader(command))
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            result.Add(new InfosFilm(reader));
                        }
                    }
            }
            return result;
        }


        /// <summary>
        /// Supprime les alternatives d'un film
        /// </summary>
        /// <param name="film">Id du film</param>
        /// <returns>true si la commande s'est bien passee</returns>
        public bool supprimeAlternatives(int filmId)
        {
            // Supprimer les alternatives
            using (SQLiteCommand command = new SQLiteCommand($"DELETE FROM {TABLE_ALTERNATIVES} WHERE {ALTERNATIVES_FILMID} = @id"))
            {
                command.Parameters.AddWithValue("@id", filmId);
                return executeNonQuery(command);
            }
        }


        /// <summary>
        /// Supprime les affiches d'un film
        /// </summary>
        /// <param name="film">Id du film</param>
        /// <returns>true si la commande s'est bien passee</returns>
        public bool supprimeImages(int filmId)
        {
            // Supprimer les alternatives
            using (SQLiteCommand command = new SQLiteCommand($"DELETE FROM {TABLE_IMAGES} WHERE {IMAGES_FILM_ID} = @id"))
            {
                command.Parameters.AddWithValue("@id", filmId);
                return executeNonQuery(command);
            }
        }

        public void supprimeAlternativesOrphelines()
        {
            using (SQLiteCommand command = new SQLiteCommand($"DELETE FROM {TABLE_ALTERNATIVES} WHERE  {TABLE_ALTERNATIVES}.{ALTERNATIVES_FILMID} not in ( SELECT {TABLE_FILMS}.{FILMS_ID} FROM {TABLE_FILMS})"))
            {
                executeNonQuery(command);
            }
        }


        internal void sauveImage(int id, Image image)
        {
            using (SQLiteCommand command = new SQLiteCommand($"DELETE FROM {TABLE_IMAGES} WHERE {IMAGES_FILM_ID} = @id"))
            {
                command.Parameters.AddWithValue("@id", id);
                executeNonQuery(command);
            }
            using (SQLiteCommand command = new SQLiteCommand($"INSERT INTO {TABLE_IMAGES}  VALUES (@id, @image)"))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@image", BaseFilms.SqlBinaryPeutEtreNull(Images.imageToByteArray(image)));
                executeNonQuery(command);
            }
        }

        /// <summary>
        /// Retourne le nombre de films presents dans la base
        /// </summary>
        /// <returns></returns>
        internal int getNbFilms(Filtre filtre = null)
        {
            int nb = 0;
            try
            {
                using (SQLiteCommand command = filtre == null ? new SQLiteCommand($"SELECT COUNT(*) FROM {TABLE_FILMS}") : filtre.getSQLCommandCount())
                    nb = Convert.ToInt32(executeScalar(command));
            }
            catch (Exception e)
            {
                MainForm.WriteExceptionToConsole(e);
            }
            return nb;
        }

        /// <summary>
        /// Met a jour une des colonnes d'un film
        /// </summary>
        /// <param name="id"></param>
        /// <param name="colonne"></param>
        /// <param name="valeur"></param>
        internal void updateFilm(int id, string colonne, int valeur)
        {
            using (SQLiteCommand command = new SQLiteCommand($"UPDATE {TABLE_FILMS}  SET {colonne} =@valeur WHERE {FILMS_ID} = @id"))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@valeur", valeur);
                executeNonQuery(command);
            }
        }


        /// <summary>
        /// Met a jour une des colonnes d'un film
        /// </summary>
        /// <param name="id"></param>
        /// <param name="colonne"></param>
        /// <param name="valeur"></param>
        internal void updateFilm(int id, string colonne, double valeur)
        {
            using (SQLiteCommand command = new SQLiteCommand($"UPDATE {TABLE_FILMS}  SET {colonne} = @valeur WHERE {FILMS_ID} = @id"))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@valeur", valeur);
                executeNonQuery(command);
            }
        }
        /// <summary>
        /// Met a jour une des colonnes d'un film
        /// </summary>
        /// <param name="id"></param>
        /// <param name="colonne"></param>
        /// <param name="valeur"></param>
        internal void updateFilm(int id, string colonne, long valeur)
        {
            using (SQLiteCommand command = new SQLiteCommand($"UPDATE {TABLE_FILMS}  SET {colonne} =@valeur WHERE {FILMS_ID} = @id"))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@valeur", valeur);
                executeNonQuery(command);
            }
        }

        /// <summary>
        /// Supprime un film de la base de donnees (ne supprime pas le fichier film)
        /// </summary>
        /// <param name="id"></param>
        internal void supprimeFilm(int id)
        {
            using (SQLiteCommand command = new SQLiteCommand($"DELETE FROM {TABLE_FILMS} WHERE {FILMS_ID} = @id"))
            {
                supprimeAlternatives(id);
                supprimeImages( id );
                command.Parameters.AddWithValue("@id", id);
                executeNonQuery(command);
            }
        }
    }
}
