using Collection_de_films.Films;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Collection_de_films.Database
{
    partial class BaseDonnees : IDisposable
    {
        private static BaseDonnees _instance = new BaseDonnees();

        public const string VUE_FILMS_FILTRES = "FILMSFILTRES";

        //SqlConnection connection;
        public static BaseDonnees getInstance()
        {
            if (_instance == null)
                _instance = new BaseDonnees();

            return _instance;
        }


        private BaseDonnees()
        {
            try
            {
                //connection = new SqlConnection(Properties.Settings.Default.connexion);
                //connection.Open();
                creerVueFilms(new Filtre());
            }
            catch (System.Exception e)
            {
                MainForm.WriteExceptionToConsole(e);
            }
        }

        public void Dispose()
        {
            //connection.Close();
        }
        /*
        internal bool FilmExiste(Film film)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connexion))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT chemin FROM FILMS WHERE chemin = @chemin";
                    cmd.Parameters.AddWithValue("@chemin", film.Chemin);

                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check is the reader has any rows at all before starting to read.
                            if (reader.HasRows)
                            {
                                return true;
                            }
                        }
                    }
                    catch (Exception e)
                    {

                        MainForm.WriteExceptionToConsole(e);
                    }
                }
                connection.Close();
            }

            return false;
        }
        */
        internal int getNbAlternatives(int id)
        {
            int nb = 0;
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT COUNT(*) FROM ALTERNATIVES WHERE FilmId = @id";

                        command.Parameters.AddWithValue("@id", id);
                        nb = (int)(Int32)command.ExecuteScalar();
                    }
                    catch (Exception e)
                    {
                        MainForm.WriteExceptionToConsole(e);
                    }
                }

                connection.Close();
            }
            return nb;
        }
        
        public List<Film> getListFilms(Filtre filtre)
        {
            List<Film> result = new List<Film>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connexion))
            {
                connection.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT * FROM " + VUE_FILMS_FILTRES;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = connection;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check is the reader has any rows at all before starting to read.
                            if (reader.HasRows)
                            {
                                // Read advances to the next row.
                                while (reader.Read())
                                {
                                    result.Add(new Film(reader));
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MainForm.WriteExceptionToConsole(e);
                }
                finally
                {
                    connection.Close();
                }

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
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connexion))
            {
                connection.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = connection;

                        cmd.CommandText = "SELECT * FROM FILMS WHERE etat = @etat";
                        cmd.Parameters.AddWithValue("@etat", Film.etatToInt(etat));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check is the reader has any rows at all before starting to read.
                            if (reader.HasRows)
                            {
                                // Read advances to the next row.
                                while (reader.Read())
                                {
                                    result.Add(new Film(reader));
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MainForm.WriteExceptionToConsole(e);
                }
                finally
                {
                    connection.Close();
                }

            }

            return result;
        }

        static public List<InfosFilm> GetAlternatives(int id)
        {
            List<InfosFilm> result = new List<InfosFilm>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT * FROM ALTERNATIVES WHERE FilmId = @id";

                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Check is the reader has any rows at all before starting to read.
                            if (reader.HasRows)
                            {
                                // Read advances to the next row.
                                while (reader.Read())
                                {
                                    result.Add(new InfosFilm(reader));
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MainForm.WriteExceptionToConsole(e);
                    }
                }

                connection.Close();
            }
            return result;
        }

        public void ajouteFilm(Film f)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "INSERT into FILMS " +
                            "(chemin, titre, realisateur, acteurs, genres, nationalite, resume, datesortie, affiche, etat, tag)"
                        + " VALUES (@chemin, @titre, @realisateur, @acteurs, @genres, @nationalite, @resume, @datesortie, @affiche, @etat, @tag)"
                        + " SET @id = SCOPE_IDENTITY()";
                        command.Parameters.AddWithValue("@chemin", f.Chemin);
                        command.Parameters.AddWithValue("@titre", f.Titre);
                        command.Parameters.AddWithValue("@realisateur", f.Realisateur);
                        command.Parameters.AddWithValue("@acteurs", f.Acteurs);
                        command.Parameters.AddWithValue("@genres", f.Genres);
                        command.Parameters.AddWithValue("@nationalite", f.Nationalite);
                        command.Parameters.AddWithValue("@datesortie", f.DateSortie);
                        command.Parameters.AddWithValue("@resume", f.Resume);
                        command.Parameters.AddWithValue("@affiche", SqlBinnaryPeutEtreNull(f.getAfficheBytes()));
                        command.Parameters.AddWithValue("@etat", f.EtatInt);
                        command.Parameters.AddWithValue("@tag", f._etiquettes);
                        int id = -1;
                        command.Parameters.AddWithValue("@id", id).Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();
                        id = (int)command.Parameters["@ID"].Value;
                        f.Id = id;

                        SaveAlternatives(id, f.Alternatives);
                    }
                    catch (Exception e)
                    {
                        MainForm.WriteExceptionToConsole(e);
                    }

                }
                connection.Close();
            }
        }

        public static object SqlBinnaryPeutEtreNull(object v)
        {
            if (v == null)
                return System.Data.SqlTypes.SqlBinary.Null;
            else
                return v;
        }

        private void SaveAlternatives(int id, List<InfosFilm> alternatives)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connexion))
            {
                connection.Open();
                // Supprimer les anciennes alternatives
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "DELETE FROM ALTERNATIVES WHERE FilmId = @id";

                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        MainForm.WriteExceptionToConsole(e);
                    }
                }

                // Ajouter les nouvelles alternatives, associees au film dont on donne l'id
                if (alternatives != null)
                    foreach (InfosFilm f in alternatives)
                        using (SqlCommand command = new SqlCommand())
                        {
                            try
                            {
                                command.Connection = connection;
                                command.CommandType = CommandType.Text;
                                command.CommandText = "INSERT into ALTERNATIVES " +
                                    "(filmid, realisateur, acteurs, genres, nationalite, resume, datesortie, affiche)"
                                + " VALUES (@id, @realisateur, @acteurs, @genres, @nationalite, @resume, @datesortie, @affiche)";
                                command.Parameters.AddWithValue("@id", id);
                                command.Parameters.AddWithValue("@realisateur", f._realisateur);
                                command.Parameters.AddWithValue("@acteurs", f._acteurs);
                                command.Parameters.AddWithValue("@genres", f._genres);
                                command.Parameters.AddWithValue("@nationalite", f._nationalite);
                                command.Parameters.AddWithValue("@datesortie", f._dateSortie);
                                command.Parameters.AddWithValue("@resume", f._resume);
                                command.Parameters.AddWithValue("@affiche", Film.imageToByteArray(f._affiche));

                                command.ExecuteNonQuery();
                            }
                            catch (Exception e)
                            {
                                MainForm.WriteExceptionToConsole(e);
                            }
                        }
                connection.Close();
            }
        }

        public void update(Film film)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "UPDATE Films SET chemin =@chemin, " +
                            "titre = @titre, realisateur=@realisateur, acteurs=@acteurs, genres=@genres, nationalite=@nationalite, resume=@resume, datesortie=@datesortie, affiche=@affiche, etat=@etat, tag=@tag" +
                            " WHERE Id = @id";

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
                        command.Parameters.Add("@affiche", SqlDbType.VarBinary).Value = SqlBinnaryPeutEtreNull(film.getAfficheBytes());
                        command.Parameters.AddWithValue("@etat", film.EtatInt);
                        command.ExecuteNonQuery();

                        SaveAlternatives(film.Id, film.Alternatives);
                    }
                    catch (Exception e)
                    {
                        MainForm.WriteExceptionToConsole(e);
                    }
                }
                connection.Close();
            }
        }

        public void ajouteGenre(string genre)
        {

        }

        /// <summary>
        /// Creer la requete sql qui permet de retrouver la liste des films en fonction du filtre
        /// </summary>
        /// <param name="_filtre"></param>
        /// <returns></returns>
        internal SqlCommand creerRequete(Filtre filtre)
        {
            return new SqlCommand();
        }

        /// <summary>
        /// Retrouve le n ieme film dans la liste des films correspondant au filtre
        /// </summary>
        /// <param name="requete"></param>
        /// <param name="itemIndex"></param>
        /// <returns></returns>
        internal Film getFilm(int itemIndex)
        {
            Film result = null;
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connexion))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.Connection = connection;
                        // cmd.CommandText = "SELECT x.* FROM ( select *, ROW_NUMBER() OVER(ORDER BY id ASC) AS Rank FROM FILMS ) X WHERE Rank = @nb";
                        cmd.CommandText = "SELECT * FROM " + VUE_FILMS_FILTRES + " WHERE " + INDEX_NUMBER + " = @nb";
                        cmd.Parameters.AddWithValue("@nb", itemIndex + 1);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check is the reader has any rows at all before starting to read.
                            if (reader.HasRows)
                            {
                                reader.Read();
                                result = new Film(reader);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MainForm.WriteExceptionToConsole(e);
                    }
                }
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Retourne le nombre de films presents dans la base
        /// </summary>
        /// <returns></returns>
        internal int getNbFilms(Filtre filtre = null)
        {
            int nb = 0;
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connexion))
            {
                connection.Open();
                try
                {
                    SqlCommand command;
                    if (filtre == null)
                    {
                        command = new SqlCommand();
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT COUNT(*) FROM FILMS";
                    }
                    else
                        command = filtre.getSQLCommandCount();
                    command.Connection = connection;

                    nb = (int)(Int32)command.ExecuteScalar();
                }
                catch (Exception e)
                {
                    MainForm.WriteExceptionToConsole(e);
                }
                connection.Close();
            }

            return nb;
        }

       

        internal void supprimeFilm(Film film)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "DELETE FROM FILMS WHERE id = @id";
                        command.Parameters.AddWithValue("@id", film.Id);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        MainForm.WriteExceptionToConsole(e);
                    }
                }
                connection.Close();
            }
        }

        internal void creerVueFilms(Filtre filtre)
        {
            DeleteView(VUE_FILMS_FILTRES);
            CreateView(VUE_FILMS_FILTRES, filtre);
        }
    }
}

