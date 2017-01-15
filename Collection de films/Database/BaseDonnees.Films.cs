using Collection_de_films.Films;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_de_films.Database
{
    partial class BaseDonnees : IDisposable
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
        public const string FILMS_TAG = "TAG";
        public const string FILMS_IMAGE_ID = "IMAGE_ID";

        internal void creerTableFilms()
        {
            // Table films
            using (SQLiteCommand commande = new SQLiteCommand("CREATE TABLE " + TABLE_FILMS
                + " ( "
                + FILMS_ID + " INTEGER PRIMARY KEY   AUTOINCREMENT,"
                + FILMS_CHEMIN + " TEXT NOT NULL,"
                + FILMS_TITRE + " TEXT NOT NULL,"
                + FILMS_REALISATEUR + " TEXT NOT NULL,"
                + FILMS_ACTEURS + " TEXT NOT NULL,"
                + FILMS_GENRES + " TEXT NOT NULL,"
                + FILMS_NATIONALITE + " TEXT NOT NULL,"
                + FILMS_RESUME + " TEXT NOT NULL,"
                + FILMS_DATESORTIE + " TEXT NOT NULL,"
                + FILMS_ETAT + " INTEGER NOT NULL,"
                + FILMS_TAG + " TEXT NOT NULL,"
                + FILMS_IMAGE_ID + " INTEGER REFERENCES " + TABLE_IMAGES + "(" + IMAGES_ID + ")"
                + " );"))
                executeNonQuery(commande);
        }

        /// <summary>
        /// Retourne VRAI si le film existe deja dans la base (meme chemin)
        /// </summary>
        /// <param name="film"></param>
        /// <returns></returns>
        internal bool FilmExiste(Film film)
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

        public void ajouteFilm(Film f)
        {
            using (SQLiteCommand command = new SQLiteCommand($"INSERT into {TABLE_FILMS} " +
                        $"({FILMS_CHEMIN}, {FILMS_TITRE}, {FILMS_REALISATEUR}, {FILMS_ACTEURS}, {FILMS_GENRES}, {FILMS_NATIONALITE}, {FILMS_RESUME}, {FILMS_DATESORTIE}, {FILMS_IMAGE_ID}, {FILMS_ETAT}, {FILMS_TAG})"
                    + " VALUES (@chemin, @titre, @realisateur, @acteurs, @genres, @nationalite, @resume, @datesortie, @affiche, @etat, @tag)"))
            {
                if (f.getImage() != null)
                    f.imageId = getImageId(f.imageId, f.getImage());

                command.Parameters.AddWithValue("@chemin", f.Chemin);
                command.Parameters.AddWithValue("@titre", f.Titre);
                command.Parameters.AddWithValue("@realisateur", f.Realisateur);
                command.Parameters.AddWithValue("@acteurs", f.Acteurs);
                command.Parameters.AddWithValue("@genres", f.Genres);
                command.Parameters.AddWithValue("@nationalite", f.Nationalite);
                command.Parameters.AddWithValue("@datesortie", f.DateSortie);
                command.Parameters.AddWithValue("@resume", f.Resume);
                command.Parameters.AddWithValue("@affiche", f.imageId);
                command.Parameters.AddWithValue("@etat", f.EtatInt);
                command.Parameters.AddWithValue("@tag", f._etiquettes);
                executeNonQuery(command);

                // Obtenir l'id du dernier film ajoute
                command.CommandText = $"select last_insert_rowid() as {FILMS_ID} from {TABLE_FILMS};";
                object o = executeScalar(command);
                f.Id = Convert.ToInt32(o);

                sauveAlternatives(f.Id, f.Alternatives);
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

        internal void supprimeFilm(Film film)
        {
            using (SQLiteCommand command = new SQLiteCommand($"DELETE FROM {TABLE_FILMS} WHERE {FILMS_ID} = @id"))
            {
                supprimeAlternatives(film);
                supprimeImage(film.imageId);
                command.Parameters.AddWithValue("@id", film.Id);
                executeNonQuery(command);
            }
        }

        public void update(Film film)
        {
            using (SQLiteCommand command = new SQLiteCommand($"UPDATE {TABLE_FILMS} "
                + $"SET {FILMS_CHEMIN} =@chemin, {FILMS_TITRE} = @titre, {FILMS_REALISATEUR}=@realisateur, {FILMS_ACTEURS}=@acteurs, {FILMS_GENRES}=@genres, {FILMS_NATIONALITE}=@nationalite, {FILMS_RESUME}=@resume, {FILMS_DATESORTIE}=@datesortie, {FILMS_IMAGE_ID}=@affiche, {FILMS_ETAT}=@etat, {FILMS_TAG}=@tag"
                + $" WHERE {FILMS_ID} = @id"))
            {
                // Supprimer l'ancienne image du film
                supprimeImage(film.imageId);
                if (film.getImage() != null)
                    film.imageId = getImageId(film.imageId, film.getImage());

                command.Parameters.AddWithValue("@id", film.Id);
                command.Parameters.AddWithValue("@chemin", film.Chemin);
                command.Parameters.AddWithValue("@titre", film.Titre);
                command.Parameters.AddWithValue("@realisateur", film.Realisateur);
                command.Parameters.AddWithValue("@acteurs", film.Acteurs);
                command.Parameters.AddWithValue("@genres", film.Genres);
                command.Parameters.AddWithValue("@nationalite", film.Nationalite);
                command.Parameters.AddWithValue("@datesortie", film.DateSortie);
                command.Parameters.AddWithValue("@resume", film.Resume);
                command.Parameters.AddWithValue("@tag", film._etiquettes);
                command.Parameters.AddWithValue("@affiche", film.imageId);
                command.Parameters.AddWithValue("@etat", film.EtatInt);
                executeNonQuery(command);

                sauveAlternatives(film.Id, film.Alternatives);
            }
        }

        public static object SqlBinnaryPeutEtreNull(object v)
        {
            if (v == null)
                return System.Data.SqlTypes.SqlBinary.Null;
            else
                return v;
        }
        public List<Film> getListFilms(Filtre filtre)
        {
            List<Film> result = new List<Film>();
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM {VUE_FILMS_FILTRES}"))
                using (SQLiteDataReader reader = executeReader(cmd))
                    if (reader.HasRows)
                        while (reader.Read())
                            result.Add(new Film(reader));
            }
            catch (Exception e)
            {
                MainForm.WriteExceptionToConsole(e);
            }

            return result;
        }

        /// <summary>
        /// Retrouve une liste de films dans un certain etat, independamment du filtre utilise dans l'interface
        /// </summary>
        /// <param name="etat"></param>
        /// <returns></returns>
        public List<Film> getListFilms(Film.ETAT etat)
        {
            List<Film> result = new List<Film>();
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM {TABLE_FILMS} WHERE {FILMS_ETAT} = @etat"))
                {
                    cmd.Parameters.AddWithValue("@etat", Film.etatToInt(etat));
                    using (SQLiteDataReader reader = executeReader(cmd))
                    {
                        // Check is the reader has any rows at all before starting to read.
                        if (reader.HasRows)
                            // Read advances to the next row.
                            while (reader.Read())
                                result.Add(new Film(reader));
                    }
                }
            }
            catch (Exception e)
            {
                MainForm.WriteExceptionToConsole(e);
            }

            return result;
        }


        internal void creerVueFilms(Filtre filtre)
        {
            DeleteView(VUE_FILMS_FILTRES);
            CreateView(VUE_FILMS_FILTRES, filtre);
        }
    }
}
