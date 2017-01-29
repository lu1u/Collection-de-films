using System;
using Collection_de_films.Database;
using Collection_de_films.Films;
using SqlCommand = System.Data.SQLite.SQLiteCommand;

namespace Collection_de_films
{
    internal class Filtre
    {
        private const string PARAMETRE_RECHERCHE_CHAINE = "@CHERCHE";
        private const string PARAMETRE_RECHERCHE_NON_TROUVE = "@etat";
        private readonly int ETAT_NON_TROUVE = Film.etatToInt(Film.ETAT.PAS_TROUVE);

        enum STYLE_RECHERCHE { TOUT, CHAINE, NON_TROUVES, ALTERNATIVES, VUS, NON_VUS, A_VOIR }
        string _recherche = "";
        STYLE_RECHERCHE _style;
        string _condition = "";

        public Filtre()
        {
            _style = STYLE_RECHERCHE.TOUT;
        }
        public string Recherche
        {
            get
            {
                return _recherche;
            }

            set
            {
                _recherche = value;
                _style = STYLE_RECHERCHE.CHAINE;
                if (_recherche?.Length > 0)
                {
                    string rech = "'%" + _recherche.ToUpper() + "%'";
                    _condition = string.Format(" WHERE ("
                        + "    (UPPER(chemin) like {0})"
                        + " OR (UPPER(titre) like {0})"
                        + " OR (UPPER(realisateur) like {0})"
                        + " OR (UPPER(acteurs) like {0})"
                        + " OR (UPPER(genres) like {0})"
                        + " OR (UPPER(nationalite) like {0})"
                        + " OR (UPPER(resume) like {0})"
                        + " OR (UPPER(datesortie) like {0})"
                        + " OR (UPPER(tag)  like {0})"
                        + ")", rech );
                }
                else
                    _condition = "";
            }
        }

        public void tous()
        {
            _style = STYLE_RECHERCHE.TOUT;
            _recherche = "";
            _condition = rechercheTexte();
        }
        public void nonTrouves()
        {
            _style = STYLE_RECHERCHE.NON_TROUVES;
            _condition = "WHERE etat = " + Film.etatToInt(Film.ETAT.PAS_TROUVE ) + rechercheTexte();
        }

        public void alternatives()
        {
            _style = STYLE_RECHERCHE.ALTERNATIVES;
            _condition = "where FILMS.Id IN (SELECT FilmId FROM ALTERNATIVES)" + rechercheTexte();
        }
        


        public void alternativesAucuneChoisie()
        {
            _style = STYLE_RECHERCHE.ALTERNATIVES;
            _condition = $"where ({BaseFilms.FILMS_IMAGE_ID}=-1) AND {BaseFilms.FILMS_ID} IN (SELECT {BaseFilms.ALTERNATIVES_FILMID} FROM {BaseFilms.TABLE_ALTERNATIVES})"
                        + rechercheTexte();
        }


        internal void Vus()
        {
            _style = STYLE_RECHERCHE.VUS;
            _condition = $"where (({BaseFilms.FILMS_FLAGS} & {Film.FLAG_VU}) <> 0) " + rechercheTexte();
        }


        internal void NonVus()
        {
            _style = STYLE_RECHERCHE.NON_VUS;
            _condition = $"where (({BaseFilms.FILMS_FLAGS} & {Film.FLAG_VU}) = 0) " + rechercheTexte();

        }

        internal void AVoir()
        {
            _style = STYLE_RECHERCHE.A_VOIR;
            _condition = $"where (({BaseFilms.FILMS_FLAGS} & {Film.FLAG_A_VOIR}) <> 0) " + rechercheTexte();

        }

        private string rechercheTexte()
        {
            if ( _recherche?.Length > 0 )
            {
                string rech = "'%" + _recherche.ToUpper() + "%'";
                return string.Format( "AND ("
                        + "    (UPPER(chemin) like {0})"
                        + " OR (UPPER(titre) like {0})"
                        + " OR (UPPER(realisateur) like {0})"
                        + " OR (UPPER(acteurs) like {0})"
                        + " OR (UPPER(genres) like {0})"
                        + " OR (UPPER(nationalite) like {0})"
                        + " OR (UPPER(resume) like {0})"
                        + " OR (UPPER(datesortie) like {0})"
                        + " OR (UPPER(tag)  like {0})"
                        + ")", rech );
            }
            else
                return "";
        }

        public string getSQLCommand()
        {
            return "SELECT * FROM " + table + " " + condition;
        }

        public SqlCommand getSQLCommandCount()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT count(*) FROM FILMS";
            return cmd;
            /*
            switch ( _style)
            {
                case STYLE_RECHERCHE.CHAINE:
                    if (_recherche.Length == 0)
                        cmd.CommandText = "SELECT count(*) FROM FILMS";
                    else
                    {
                        _command.CommandText = "SELECT count(*) FROM FILMS WHERE "
                            + "    (UPPER(chemin) like @CHERCHE"
                            + " OR (UPPER(titre) like @CHERCHE)"
                            + " OR (UPPER(realisateur) like @CHERCHE)"
                            + " OR (UPPER(acteurs) like @CHERCHE)"
                            + " OR (UPPER(genres) like @CHERCHE)"
                            + " OR (UPPER(nationalite) like @CHERCHE)"
                            + " OR (UPPER(resume) like @CHERCHE)"
                            + " OR (UPPER(datesortie) like @CHERCHE)"
                            + " OR (UPPER(tag)  like @CHERCHE))";
                        _command.Parameters.AddWithValue("@CHERCHE", "%" + _recherche.ToUpper() + "%");
                    }
                    break;

                case STYLE_RECHERCHE.NON_TROUVES:
                   cmd.CommandText = "SELECT count(*) FROM FILMS WHERE etat = @etat";
                   cmd.Parameters.Clear();
                   cmd.Parameters.AddWithValue("@etat", Film.etatToInt(Film.ETAT.PAS_TROUVE));
                    break;

                case STYLE_RECHERCHE.ALTERNATIVES:
                    if (_recherche.Length == 0)
                        cmd.CommandText = "select count(*) FROM FILMS where FILMS.Id IN (SELECT FilmId FROM ALTERNATIVES)";
                    else
                    {
                        cmd.CommandText = "SELECT count(*) FROM FILMS WHERE "
                                + "(FILMS.Id IN (SELECT FilmId FROM ALTERNATIVES)) "
                                + " AND ((UPPER(chemin) like @CHERCHE"
                                + " OR (UPPER(titre) like @CHERCHE)"
                                + " OR (UPPER(realisateur) like @CHERCHE)"
                                + " OR (UPPER(acteurs) like @CHERCHE)"
                                + " OR (UPPER(genres) like @CHERCHE)"
                                + " OR (UPPER(nationalite) like @CHERCHE)"
                                + " OR (UPPER(resume) like @CHERCHE)"
                                + " OR (UPPER(datesortie) like @CHERCHE)"
                                + " OR (UPPER(tag)  like @CHERCHE)))";
                        cmd.Parameters.AddWithValue("@CHERCHE", "%" + _recherche.ToUpper() + "%");
                    }
                    break;

                default:
                    cmd.CommandText = "select count(*) from films";
                    break;
            }

            return cmd;*/
        }
        /*
        public SqlCommand getSQLCommandCount()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT count(*) FROM FILMS";
            return cmd;
            /*
            switch ( _style)
            {
                case STYLE_RECHERCHE.CHAINE:
                    if (_recherche.Length == 0)
                        cmd.CommandText = "SELECT count(*) FROM FILMS";
                    else
                    {
                        _command.CommandText = "SELECT count(*) FROM FILMS WHERE "
                            + "    (UPPER(chemin) like @CHERCHE"
                            + " OR (UPPER(titre) like @CHERCHE)"
                            + " OR (UPPER(realisateur) like @CHERCHE)"
                            + " OR (UPPER(acteurs) like @CHERCHE)"
                            + " OR (UPPER(genres) like @CHERCHE)"
                            + " OR (UPPER(nationalite) like @CHERCHE)"
                            + " OR (UPPER(resume) like @CHERCHE)"
                            + " OR (UPPER(datesortie) like @CHERCHE)"
                            + " OR (UPPER(tag)  like @CHERCHE))";
                        _command.Parameters.AddWithValue("@CHERCHE", "%" + _recherche.ToUpper() + "%");
                    }
                    break;

                case STYLE_RECHERCHE.NON_TROUVES:
                   cmd.CommandText = "SELECT count(*) FROM FILMS WHERE etat = @etat";
                   cmd.Parameters.Clear();
                   cmd.Parameters.AddWithValue("@etat", Film.etatToInt(Film.ETAT.PAS_TROUVE));
                    break;

                case STYLE_RECHERCHE.ALTERNATIVES:
                    if (_recherche.Length == 0)
                        cmd.CommandText = "select count(*) FROM FILMS where FILMS.Id IN (SELECT FilmId FROM ALTERNATIVES)";
                    else
                    {
                        cmd.CommandText = "SELECT count(*) FROM FILMS WHERE "
                                + "(FILMS.Id IN (SELECT FilmId FROM ALTERNATIVES)) "
                                + " AND ((UPPER(chemin) like @CHERCHE"
                                + " OR (UPPER(titre) like @CHERCHE)"
                                + " OR (UPPER(realisateur) like @CHERCHE)"
                                + " OR (UPPER(acteurs) like @CHERCHE)"
                                + " OR (UPPER(genres) like @CHERCHE)"
                                + " OR (UPPER(nationalite) like @CHERCHE)"
                                + " OR (UPPER(resume) like @CHERCHE)"
                                + " OR (UPPER(datesortie) like @CHERCHE)"
                                + " OR (UPPER(tag)  like @CHERCHE)))";
                        cmd.Parameters.AddWithValue("@CHERCHE", "%" + _recherche.ToUpper() + "%");
                    }
                    break;

                default:
                    cmd.CommandText = "select count(*) from films";
                    break;
            }

            return cmd;
        }*/

        public string table
        {
            get
            {
                return "FILMS";
            }
        }

        public string condition
        {
            get
            {
                return _condition;
            }
        }

    }
}