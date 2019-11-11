using CollectionDeFilms.Films;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace CollectionDeFilms.Database
{
    internal partial class BaseFilms : IDisposable
    {
        /// <summary>
        ///  Table FILMS
        /// </summary>
        public const string TABLE_FILMS = "FILMS";
        public const string FILMS_ID = "ID";
        public const string FILMS_CHEMIN = "CHEMIN";
        public const string FILMS_TITRE = "TITRE";
        public const string FILMS_REALISATEUR = "REALISATEUR";
        public const string FILMS_ACTEURS = "ACTEURS";
        public const string FILMS_GENRES = "GENRES";
        public const string FILMS_NATIONALITE = "NATIONALITE";
        public const string FILMS_RESUME = "RESUME";
        public const string FILMS_DATESORTIE = "DATESORTIE";
        public const string FILMS_ETAT = "ETAT";
        public const string FILMS_DATEVU = "DATE_VU";
        public const string FILMS_FLAGS = "FLAGS";
        public const string FILMS_TAG = "TAG";
        public const string FILMS_IMAGE = "IMAGE";

        internal void creerTableFilms()
        {
            // Table films
            using (SQLiteCommand commande = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS {TABLE_FILMS}  ( "
                + $"{FILMS_ID} INTEGER PRIMARY KEY   AUTOINCREMENT,"
                + $"{FILMS_CHEMIN} TEXT NOT NULL,"
                + $"{FILMS_TITRE} TEXT NOT NULL,"
                + $"{FILMS_REALISATEUR} TEXT NOT NULL,"
                + $"{FILMS_ACTEURS} TEXT NOT NULL,"
                + $"{FILMS_GENRES} TEXT NOT NULL,"
                + $"{FILMS_NATIONALITE} TEXT NOT NULL,"
                + $"{FILMS_RESUME} TEXT NOT NULL,"
                + $"{FILMS_DATESORTIE} TEXT NOT NULL,"
                + $"{FILMS_ETAT} INTEGER NOT NULL,"
                + $"{FILMS_DATEVU} INTEGER,"
                + $"{FILMS_FLAGS} INTEGER NOT NULL,"
                + $"{FILMS_TAG} TEXT NOT NULL,"
                + $"{FILMS_IMAGE} BLOB"
                + " );"))
                executeNonQuery(commande);
        }



        /// <summary>
        /// Retourne VRAI si le film existe deja dans la base (meme fichier)
        /// </summary>
        /// <param name="film"></param>
        /// <returns></returns>
        internal bool filmExisteFichier(string chemin)
        {
            String nom = BaseDonnees.Encode(Path.GetFileNameWithoutExtension(chemin));

            using (SQLiteCommand cmd = new SQLiteCommand($@"SELECT Count(*) FROM {TABLE_FILMS} WHERE {FILMS_CHEMIN} LIKE '%\{nom}.%'"))
            {
                try
                {
                    object o = executeScalar(cmd);
                    return (Convert.ToInt32(o) > 0);
                }
                catch (Exception e)
                {
                    MainForm.WriteExceptionToConsole(e);
                }
            }

            return false;
        }

        /// <summary>
		/// Retourne VRAI si le film existe deja dans la base (meme chemin)
		/// </summary>
		/// <param name="film"></param>
		/// <returns></returns>
		internal bool filmExisteMemeChemin(Film film)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT Count(*) FROM {TABLE_FILMS} WHERE {FILMS_CHEMIN} = @chemin"))
            {
                cmd.Parameters.AddWithValue("@chemin", film.Chemin);
                try
                {
                    object o = executeScalar(cmd);
                    return (Convert.ToInt32(o) > 0);
                }
                catch (Exception e)
                {
                    MainForm.WriteExceptionToConsole(e);
                }
            }

            return false;
        }

        public async void ajouteFilm(Film f)
        {
            using (SQLiteCommand command = new SQLiteCommand($"INSERT into {TABLE_FILMS} " +
                        $"({FILMS_CHEMIN}, {FILMS_TITRE}, {FILMS_REALISATEUR}, {FILMS_ACTEURS}, {FILMS_GENRES}, {FILMS_NATIONALITE}, {FILMS_RESUME}, {FILMS_DATESORTIE}, {FILMS_ETAT}, {FILMS_TAG}, {FILMS_FLAGS}, {FILMS_IMAGE})"
                    + " VALUES (@chemin, @titre, @realisateur, @acteurs, @genres, @nationalite, @resume, @datesortie, @etat, @tag, @flags, @image)"))
            {
                //if ( f.getImage() != null )
                //    f.imageId = getImageId( f.imageId, f.getImage() );

                command.Parameters.AddWithValue("@chemin", f.Chemin);
                command.Parameters.AddWithValue("@titre", f.Titre);
                command.Parameters.AddWithValue("@realisateur", f.Realisateur);
                command.Parameters.AddWithValue("@acteurs", f.Acteurs);
                command.Parameters.AddWithValue("@genres", f.Genres);
                command.Parameters.AddWithValue("@nationalite", f.Nationalite);
                command.Parameters.AddWithValue("@datesortie", f.DateSortie);
                command.Parameters.AddWithValue("@resume", f.Resume);
                command.Parameters.AddWithValue("@etat", f.EtatInt);
                command.Parameters.AddWithValue("@tag", f.Etiquettes);
                command.Parameters.AddWithValue("@flags", f.Flags);
                command.Parameters.AddWithValue("@image", BaseFilms.SqlBinaryPeutEtreNull(Images.imageToByteArray(f.Affiche)));

                executeNonQuery(command);

                // Obtenir l'id du dernier film ajoute
                command.CommandText = $"select last_insert_rowid() as {FILMS_ID} from {TABLE_FILMS};";
                object o = executeScalar(command);
                f.Id = Convert.ToInt32(o);
                sauveAlternatives(f.Id, f.Alternatives());
            }

        }

        /// <summary>
        /// Retourne un objet qui permettra de lire les informations du film dont on donne l'id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        async internal Task<SQLiteDataReader> getFilmsReader(int id)
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM {TABLE_FILMS} WHERE {FILMS_ID} = @id"))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return executeReader(cmd);
                }
            }
            catch (Exception e)
            {
                MainForm.WriteExceptionToConsole(e);
                return null;
            }
        }



        public static object SqlBinaryPeutEtreNull(object v)
        {
            if (v == null)
                return System.Data.SqlTypes.SqlBinary.Null;
            else
                return v;
        }

        public SQLiteDataReader getFilmsReader()
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand($"SELECT {BaseFilms.FILMS_ID}FROM {TABLE_FILMS}"))
                {
                    return executeReader(cmd);
                }
            }
            catch (Exception e)
            {
                MainForm.WriteExceptionToConsole(e);
                return null;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Retrouve le film dont le chemin de fichier est celui qu'on donne en parametre
        /// </summary>
        /// <param name="chemin"></param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////////////////////////////
        internal async Task<Film> getFilmFichier(string chemin)
        {
            string nomFichier = BaseDonnees.Encode(Path.GetFileNameWithoutExtension(chemin));
            using (SQLiteCommand cmd = new SQLiteCommand($@"SELECT * FROM {TABLE_FILMS} WHERE {FILMS_CHEMIN} LIKE '%\{nomFichier}.%'"))
            {
                using (SQLiteDataReader reader = executeReader(cmd))
                {
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        if (await reader.ReadAsync())
                            return new Film(reader);
                        else
                            return null;
                    }
                    else
                        return null;
                }
            }
        }

        /// <summary>
        /// Retourne l'affiche du film
        /// </summary>
        /// <param name="filmId"></param>
        /// <returns></returns>
        internal Image getAfficheFilm(int filmId)
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand($"SELECT {FILMS_IMAGE} FROM {TABLE_FILMS} WHERE {FILMS_ID} = @id"))
                {
                    cmd.Parameters.AddWithValue("@id", filmId);
                    using (SQLiteDataReader reader = executeReader(cmd))
                    {
                        // Check is the reader has any rows at all before starting to read.
                        if (reader.HasRows)
                        {
                            // Read advances to the next row.
                            if (reader.Read())
                            {
                                return readImage(reader, reader.GetOrdinal(BaseFilms.FILMS_IMAGE));
                            }
                            else
                                return null;
                        }
                        else
                            return null;
                    }
                }
            }
            catch (Exception e)
            {
                MainForm.WriteExceptionToConsole(e);
                return null;
            }
        }


        /// <summary>
        /// Met a jour les informations d'un film
        /// </summary>
        /// <param name="film"></param>
        public async void update(Film film)
        {
            using (SQLiteCommand command = new SQLiteCommand($"UPDATE {TABLE_FILMS} "
                + $"SET {FILMS_CHEMIN} =@chemin, {FILMS_TITRE} = @titre, {FILMS_REALISATEUR}=@realisateur, {FILMS_ACTEURS}=@acteurs, "
                + $"{FILMS_GENRES}=@genres, {FILMS_NATIONALITE}=@nationalite, {FILMS_RESUME}=@resume, {FILMS_DATESORTIE}=@datesortie, "
                + $"{FILMS_ETAT}=@etat, {FILMS_DATEVU}=@datevu, {FILMS_TAG}=@tag, {FILMS_FLAGS}=@flags"
                + $" WHERE {FILMS_ID} = @id"))
            {
                command.Parameters.AddWithValue("@id", film.Id);
                command.Parameters.AddWithValue("@chemin", film.Chemin);
                command.Parameters.AddWithValue("@titre", film.Titre);
                command.Parameters.AddWithValue("@realisateur", film.Realisateur);
                command.Parameters.AddWithValue("@acteurs", film.Acteurs);
                command.Parameters.AddWithValue("@genres", film.Genres);
                command.Parameters.AddWithValue("@nationalite", film.Nationalite);
                command.Parameters.AddWithValue("@datesortie", film.DateSortie);
                command.Parameters.AddWithValue("@resume", film.Resume);
                command.Parameters.AddWithValue("@datevu", film.DateVu.Ticks);
                command.Parameters.AddWithValue("@tag", film.Etiquettes);
                command.Parameters.AddWithValue("@image", BaseFilms.SqlBinaryPeutEtreNull(Images.imageToByteArray(film.Affiche)));
                command.Parameters.AddWithValue("@etat", film.EtatInt);
                command.Parameters.AddWithValue("@flags", film.Flags);
                executeNonQuery(command);
                sauveAlternatives(film.Id, film.Alternatives());
            }
        }

        /// <summary>
        /// Retourne la liste des genres de films
        /// </summary>
        /// <returns></returns>
        internal async Task<SQLiteDataReader> getGenres()
        {
            using (SQLiteCommand command = new SQLiteCommand($"SELECT DISTINCT {BaseFilms.FILMS_GENRES} FROM {BaseFilms.TABLE_FILMS};"))
                return executeReader(command);
        }
        /// <summary>
        /// Retourne la liste des etiquettes de films
        /// </summary>
        /// <returns></returns>
        internal async Task<SQLiteDataReader> getEtiquettes()
        {
            using (SQLiteCommand command = new SQLiteCommand($"SELECT DISTINCT {BaseFilms.FILMS_TAG} FROM {BaseFilms.TABLE_FILMS};"))
                return executeReader(command);
        }
    }
}
