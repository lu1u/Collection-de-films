using CollectionDeFilms.Internet;
using System;
using System.Collections.Generic;
using System.Data.SQLite;


namespace CollectionDeFilms.Database
{
    sealed partial class BaseConfiguration : BaseDonnees
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
            executeNonQuery($"CREATE TABLE IF NOT EXISTS {TABLE_RECHERCHES}"
                + $" ( {RECHERCHE_NOM} TEXT NOT NULL UNIQUE,"
                + $" {RECHERCHE_RANG} INTEGER NOT NULL,"
                + $" {RECHERCHE_URL_RECHERCHE} TEXT NOT NULL,"
                + $" {RECHERCHE_XPATH_RECHERCHE} TEXT NOT NULL,"
                + $" {RECHERCHE_URL_FILM} TEXT NOT NULL,"
                + $" {RECHERCHE_XPATH_REALISATEUR} TEXT,"
                + $" {RECHERCHE_XPATH_ACTEURS} TEXT,"
                + $" {RECHERCHE_XPATH_GENRES} TEXT,"
                + $" {RECHERCHE_XPATH_NATIONALITE} TEXT,"
                + $" {RECHERCHE_XPATH_RESUME} TEXT,"
                + $" {RECHERCHE_XPATH_DATESORTIE} TEXT,"
                + $" {RECHERCHE_XPATH_AFFICHE} TEXT,"
                + " PRIMARY KEY(" + RECHERCHE_NOM + ")"
                + " );");



            using (SQLiteCommand cmd = new SQLiteCommand($"insert into {TABLE_RECHERCHES} VALUES(@nom, @rang, @urlrecherche, @xpathrecherche, @urlfilm, @xpathrealisateur, @xpathacteurs, @xpathgenres, @xpathnationalite, @xpathresume, @xpathdatesortie, @xpathaffiche)"))
            {
                cmd.Parameters.AddWithValue("@nom", "TheMovieDB.org");
                cmd.Parameters.AddWithValue("@rang", 0);
                cmd.Parameters.AddWithValue("@urlrecherche", "https://www.themoviedb.org/search?language=fr-FR&query={0}");
                cmd.Parameters.AddWithValue("@xpathrecherche", "//section[@class='main_content search_results']//a[@class='title result']/@href");
                cmd.Parameters.AddWithValue("@urlfilm", "https://www.themoviedb.org/{0}");
                cmd.Parameters.AddWithValue("@xpathrealisateur", "//ol[@class='people no_image']//li[@class='profile']//p[.='Director']/preceding::p[1]//a");
                cmd.Parameters.AddWithValue("@xpathacteurs", "//div[@class='header large border first']//ol[@class='people']//p/a[contains(@href, '/person/')]");
                cmd.Parameters.AddWithValue("@xpathgenres", "//section[@class='genres right_column']//a[@class='rounded']");
                cmd.Parameters.AddWithValue("@xpathnationalite", "");
                cmd.Parameters.AddWithValue("@xpathresume", "//div[@class='overview']//p");
                cmd.Parameters.AddWithValue("@xpathdatesortie", "//span[@class='release_date']");
                cmd.Parameters.AddWithValue("@xpathaffiche", "//div[@class='poster']//div[@class='image_content']//img/@data-src");
                executeReader(cmd);
            }

            using (SQLiteCommand cmd = new SQLiteCommand($"insert into {TABLE_RECHERCHES} VALUES(@nom, @rang, @urlrecherche, @xpathrecherche, @urlfilm, @xpathrealisateur, @xpathacteurs, @xpathgenres, @xpathnationalite, @xpathresume, @xpathdatesortie, @xpathaffiche)"))
            {
                cmd.Parameters.AddWithValue("@nom", "Allocine.fr");
                cmd.Parameters.AddWithValue("@rang", 1);
                cmd.Parameters.AddWithValue("@urlrecherche", "http://www.allocine.fr/recherche/?q={0}");
                cmd.Parameters.AddWithValue("@xpathrecherche", "//div[contains(@class,'colcontent')]//table[contains(@class,'totalwidth noborder purehtml')]//a[contains(@href,'fichefilm_gen_cfilm')]/@href");
                cmd.Parameters.AddWithValue("@urlfilm", "http://www.allocine.fr/{0}");
                cmd.Parameters.AddWithValue("@xpathrealisateur", "//div[@class='meta col-xs-12 col-md-8']//span[@itemprop='director']//a//span");
                cmd.Parameters.AddWithValue("@xpathacteurs", "//div[@class='meta col-xs-12 col-md-8']//div[@class='meta-body-item' and contains(.,'Avec')]//span[position()>1 and not(contains(text(),'plus'))]");
                cmd.Parameters.AddWithValue("@xpathgenres", "//div[@class='meta col-xs-12 col-md-8']//div[@class='meta-body-item' and contains(.,'Genres')]//span[position()>1 and not(contains(text(),'plus'))]//span");
                cmd.Parameters.AddWithValue("@xpathnationalite", "//div[@class='meta col-xs-12 col-md-8']//div[@class='meta-body-item' and contains(.,'Nationalit')]//span[position()>1 and not(contains(text(),'plus'))]");
                cmd.Parameters.AddWithValue("@xpathresume", "//div[@class='ovw-synopsis-txt']//p");
                cmd.Parameters.AddWithValue("@xpathdatesortie", "//div[@class='meta col-xs-12 col-md-8']//div[@class='meta-body-item' and contains(.,'Date de sortie')]//strong//span");
                cmd.Parameters.AddWithValue("@xpathaffiche", "//figure[@class='thumbnail col-xs-12 col-md-4']//img[@class='thumbnail-img']/@src");
                executeReader(cmd);
            }

            using (SQLiteCommand cmd = new SQLiteCommand($"insert into {TABLE_RECHERCHES} VALUES(@nom, @rang, @urlrecherche, @xpathrecherche, @urlfilm, @xpathrealisateur, @xpathacteurs, @xpathgenres, @xpathnationalite, @xpathresume, @xpathdatesortie, @xpathaffiche)"))
            {
                cmd.Parameters.AddWithValue("@nom", "Imdb.com");
                cmd.Parameters.AddWithValue("@rang", 2);
                cmd.Parameters.AddWithValue("@urlrecherche", "http://www.imdb.com/find?ref_=nv_sr_fn&q={0}&s=tt&exact=true&ref_=fn_al_tt_ex");
                cmd.Parameters.AddWithValue("@xpathrecherche", "//table[@class='findList']//td[@class='result_text']//a[contains(@href,'/title/')]/@href");
                cmd.Parameters.AddWithValue("@urlfilm", "http://www.imdb.com/{0}");
                cmd.Parameters.AddWithValue("@xpathrealisateur", "//div[@class='credit_summary_item']//span[@itemprop='director']");
                cmd.Parameters.AddWithValue("@xpathacteurs", "//div[@class='credit_summary_item']//span[@itemprop='actors']");
                cmd.Parameters.AddWithValue("@xpathgenres", "//div[@class='title_wrapper']//div[@class='subtext']//a[contains(@href,'/genre/')]//span");
                cmd.Parameters.AddWithValue("@xpathnationalite", "");
                cmd.Parameters.AddWithValue("@xpathresume", "//div[@class='plot_summary_wrapper']//div[@class='summary_text']");
                cmd.Parameters.AddWithValue("@xpathdatesortie", "//div[@class='title_wrapper']//div[@class='subtext']//a[contains(@href,'/releaseinfo')]");
                cmd.Parameters.AddWithValue("@xpathaffiche", "//div[@class='poster']//img/@src");
                executeReader(cmd);
            }
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
                                                        + "(" + RECHERCHE_NOM + ","
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
