using Collection_de_films.Internet;
using System;
using System.Collections.Generic;
using System.Data.SQLite;


namespace Collection_de_films.Database
{


    /*   CREATE TABLE RECHERCHES_INTERNET(
       NOM TEXT NOT NULL UNIQUE,
       URL_RECHERCHE TEXT NOT_NULL,
       XPATH_RECHERCHE TEXT NOT_NULL,
       URL_FILM TEXT NOT_NULL,
       XPATH_REALISATEUR TEXT NOT_NULL,
       XPATH_ACTEURS TEXT NOT_NULL,
       XPATH_GENRES TEXT NOT_NULL,
       XPATH_NATIONALITE TEXT NOT_NULL,
       XPATH_RESUME TEXT NOT_NULL,
       XPATH_DATESORTIE TEXT NOT_NULL,
       XPATH_AFFICHE TEXT NOT_NULL,
           PRIMARY KEY(`NOM`)
   );*/
    partial class BaseDonnees : IDisposable
    {
        public const string TABLE_RECHERCHES = "RECHERCHES_INTERNET";
        public const string RECHERCHE_NOM = "NOM";
        public const string RECHERCHE_RANG = "RANG";
        public const string RECHERCHE_URL_RECHERCHE = "URL_RECHERCHE";
        public const string RECHERCHE_XPATH_RECHERCHE = "XPATH_RECHERCHE";
        public const string RECHERCHE_URL_FILM = "URL_FILM";
        public const string RECHERCHE_XPATH_REALISATEUR = "XPATH_REALISATEUR";
        public const string RECHERCHE_XPATH_ACTEURS = "XPATH_ACTEURS";
        public const string RECHERCHE_XPATH_GENRES = "XPATH_GENRES";
        public const string RECHERCHE_XPATH_NATIONALITE = "XPATH_NATIONALITE";
        public const string RECHERCHE_XPATH_RESUME = "XPATH_RESUME";
        public const string RECHERCHE_XPATH_DATESORTIE = "XPATH_DATESORTIE";
        public const string RECHERCHE_XPATH_AFFICHE = "XPATH_AFFICHE";

        private void creerTableRecherche()
        {
            // Table films
            SQLiteCommand commande = new SQLiteCommand("CREATE TABLE " + TABLE_RECHERCHES
                + " ( "
                + " " + RECHERCHE_NOM + " TEXT NOT NULL UNIQUE,"
                + " " + RECHERCHE_RANG + " INTEGER NOT NULL,"
                + " " + RECHERCHE_URL_RECHERCHE + " TEXT NOT NULL,"
                + " " + RECHERCHE_XPATH_RECHERCHE + " TEXT NOT NULL,"
                + " " + RECHERCHE_URL_FILM + " TEXT NOT NULL,"
                + " " + RECHERCHE_XPATH_REALISATEUR + " TEXT,"
                + " " + RECHERCHE_XPATH_ACTEURS + " TEXT,"
                + " " + RECHERCHE_XPATH_GENRES + " TEXT,"
                + " " + RECHERCHE_XPATH_NATIONALITE + " TEXT,"
                + " " + RECHERCHE_XPATH_RESUME + " TEXT,"
                + " " + RECHERCHE_XPATH_DATESORTIE + " TEXT,"
                + " " + RECHERCHE_XPATH_AFFICHE + " TEXT,"
                + " PRIMARY KEY(" + RECHERCHE_NOM + ")"
                + " );", maConnexion);
            commande.ExecuteNonQuery();
        }

        public List<RechercheInternet> getListeRechercheInternet()
        {
            List<RechercheInternet> result = new List<RechercheInternet>();
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.CommandText = "SELECT * FROM " + TABLE_RECHERCHES + " ORDER BY " + RECHERCHE_RANG;
                    using (SQLiteDataReader reader = executeReader(cmd))
                    {
                        // Check is the reader has any rows at all before starting to read.
                        if (reader.HasRows)
                        {
                            // Read advances to the next row.
                            while (reader.Read())
                            {
                                result.Add(new RechercheInternet(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MainForm.WriteExceptionToConsole(e);
            }

            return result;
        }

        public void addRechercheInternet(RechercheInternet r)
        {
            using (SQLiteCommand command = new SQLiteCommand("INSERT into " + TABLE_RECHERCHES + " ("
                        + RECHERCHE_NOM + ","
                        + RECHERCHE_RANG + ","
                        + RECHERCHE_URL_FILM + ","
                        + RECHERCHE_URL_RECHERCHE + ","
                        + RECHERCHE_XPATH_ACTEURS + ","
                        + RECHERCHE_XPATH_AFFICHE + ","
                        + RECHERCHE_XPATH_DATESORTIE + ","
                        + RECHERCHE_XPATH_GENRES + ","
                        + RECHERCHE_XPATH_NATIONALITE + ","
                        + RECHERCHE_XPATH_REALISATEUR + ","
                        + RECHERCHE_XPATH_RECHERCHE + ","
                        + RECHERCHE_XPATH_RESUME
                        + ")"
                    + " VALUES (@nom, @rang, @urlfilm, @urlrecherche, @acteurs, @affiche, @datesortie, @genres, @nationalite, @realisateur, @recherche, @resume)"))
            {
                command.Parameters.AddWithValue("@nom", r.nom);
                command.Parameters.AddWithValue("@rang", r.rang);
                command.Parameters.AddWithValue("@urlfilm", r.formatUrlFilm);
                command.Parameters.AddWithValue("@urlrecherche", r.formatUrlRecherche);
                command.Parameters.AddWithValue("@acteurs", r.xpathActeurs);
                command.Parameters.AddWithValue("@affiche", r.xpathAffiche);
                command.Parameters.AddWithValue("@datesortie", r.xpathDateSortie);
                command.Parameters.AddWithValue("@genres", r.xpathGenres);
                command.Parameters.AddWithValue("@nationalite", r.xpathNationalite);
                command.Parameters.AddWithValue("@realisateur", r.xpathRealisateur);
                command.Parameters.AddWithValue("@recherche", r.xpathRecherche);
                command.Parameters.AddWithValue("@resume", r.xpathResume);

                executeNonQuery(command);
            }
        }

        public RechercheInternet getRechercheInternet(string nom)
        {
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM " + TABLE_RECHERCHES + " WHERE " + RECHERCHE_NOM + " = @nom"))
                try
                {
                    cmd.Parameters.AddWithValue("@nom", nom);
                    using (SQLiteDataReader reader = executeReader(cmd))
                    {
                        // Check is the reader has any rows at all before starting to read.
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return new RechercheInternet(reader);
                        }
                    }

                }
                catch (Exception)
                {

                }
            return null;
        }

        public void updateRechercheInternet(RechercheInternet r)
        {
            using (SQLiteCommand command = new SQLiteCommand("INSERT OR REPLACE INTO "
                                                        + TABLE_RECHERCHES
                                                        + "("   + RECHERCHE_NOM + ","
                                                                + RECHERCHE_RANG + ","
                                                                + RECHERCHE_URL_FILM + ","
                                                                + RECHERCHE_URL_RECHERCHE + ","
                                                                + RECHERCHE_XPATH_ACTEURS + ","
                                                                + RECHERCHE_XPATH_AFFICHE + ","
                                                                + RECHERCHE_XPATH_DATESORTIE + ","
                                                                + RECHERCHE_XPATH_GENRES + ","
                                                                + RECHERCHE_XPATH_NATIONALITE + ","
                                                                + RECHERCHE_XPATH_REALISATEUR + ","
                                                                + RECHERCHE_XPATH_RECHERCHE + ","
                                                                + RECHERCHE_XPATH_RESUME + ")"
                    + " VALUES (@nom, @rang, @urlfilm, @urlrecherche, @acteurs, @affiche, @datesortie, @genres, @nationalite, @realisateur, @recherche, @resume)"))
            {
                command.Parameters.AddWithValue("@nom", r.nom);
                command.Parameters.AddWithValue("@rang", r.rang);
                command.Parameters.AddWithValue("@urlfilm", r.formatUrlFilm);
                command.Parameters.AddWithValue("@urlrecherche", r.formatUrlRecherche);
                command.Parameters.AddWithValue("@acteurs", r.xpathActeurs);
                command.Parameters.AddWithValue("@affiche", r.xpathAffiche);
                command.Parameters.AddWithValue("@datesortie", r.xpathDateSortie);
                command.Parameters.AddWithValue("@genres", r.xpathGenres);
                command.Parameters.AddWithValue("@nationalite", r.xpathNationalite);
                command.Parameters.AddWithValue("@realisateur", r.xpathRealisateur);
                command.Parameters.AddWithValue("@recherche", r.xpathRecherche);
                command.Parameters.AddWithValue("@resume", r.xpathResume);

                executeNonQuery(command);
            }
        }

    }
}
