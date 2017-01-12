using Collection_de_films.Films;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Collection_de_films.Database
{
    partial class BaseDonnees: IDisposable
    {
        /// <summary>
        /// Table ALTERNATIVES
        /// </summary>
        const string TABLE_ALTERNATIVES = "ALTERNATIVES";
        const string ALTERNATIVES_FILMID = "FilmId";
        const string ALTERNATIVES_REALISATEUR = "REALISATEUR";
        const string ALTERNATIVES_ACTEURS = "ACTEURS";
        const string ALTERNATIVES_GENRES = "GENRES";
        const string ALTERNATIVES_NATIONALITE = "NATIONALITE";
        const string ALTERNATIVES_RESUME = "RESUME";
        const string ALTERNATIVES_DATESORTIE = "DATESORTIE";
        const string ALTERNATIVES_AFFICHE = "AFFICHE";

        private void creerTableAlternatives()
        {
            // Table alternatives
            SQLiteCommand commande = new SQLiteCommand("CREATE TABLE " + TABLE_ALTERNATIVES
                + " ( "
                + ALTERNATIVES_FILMID + " INTEGER REFERENCES films([id]),"
                + ALTERNATIVES_REALISATEUR + " TEXT NOT NULL,"
                + ALTERNATIVES_ACTEURS + " TEXT NOT NULL,"
                + ALTERNATIVES_GENRES + " TEXT NOT NULL,"
                + ALTERNATIVES_NATIONALITE + " TEXT NOT NULL,"
                + ALTERNATIVES_RESUME + " TEXT NOT NULL,"
                + ALTERNATIVES_DATESORTIE + " TEXT NOT NULL,"
                + ALTERNATIVES_AFFICHE + " BLOB "
                + " );", maConnexion);
            commande.ExecuteNonQuery();
        }

        private void SaveAlternatives(int id, List<InfosFilm> alternatives)
        {
            using (SQLiteCommand command = new SQLiteCommand("DELETE FROM ALTERNATIVES WHERE FilmId = @id"))
            {
                command.Parameters.AddWithValue("@id", id);
                executeNonQuery(command);
            }

            // Ajouter les nouvelles alternatives, associees au film dont on donne l'id
            if (alternatives != null)
                foreach (InfosFilm f in alternatives)
                    using (SQLiteCommand command = new SQLiteCommand("INSERT into ALTERNATIVES " +
                                "(filmid, realisateur, acteurs, genres, nationalite, resume, datesortie, affiche)"
                            + " VALUES (@id, @realisateur, @acteurs, @genres, @nationalite, @resume, @datesortie, @affiche)"))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@realisateur", f._realisateur);
                        command.Parameters.AddWithValue("@acteurs", f._acteurs);
                        command.Parameters.AddWithValue("@genres", f._genres);
                        command.Parameters.AddWithValue("@nationalite", f._nationalite);
                        command.Parameters.AddWithValue("@datesortie", f._dateSortie);
                        command.Parameters.AddWithValue("@resume", f._resume);
                        command.Parameters.AddWithValue("@affiche", Film.imageToByteArray(f._affiche));

                        executeNonQuery(command);
                    }
        }


        internal int getNbAlternatives(int id)
        {
            using (SQLiteCommand command = new SQLiteCommand("SELECT COUNT(*) FROM ALTERNATIVES WHERE FilmId = @id"))
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


        public void supprimeAlternatives(Film film)
        {
            using (SQLiteCommand command = new SQLiteCommand("DELETE FROM " + TABLE_ALTERNATIVES + " WHERE " + ALTERNATIVES_FILMID + " = @id"))
            {
                command.Parameters.AddWithValue("@id", film.Id);
                executeNonQuery(command);
            }
        }

        public void supprimeAlternativesOrphelines()
        {
            using (SQLiteCommand command = new SQLiteCommand("DELETE FROM " + TABLE_ALTERNATIVES 
                + " WHERE " + ALTERNATIVES_FILMID 
                + " not in ( SELECT " + FILMS_ID + " FROM " + TABLE_FILMS + ")"))
            {
                executeNonQuery(command);
            }
        }
    }
}
