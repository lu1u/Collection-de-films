using CollectionDeFilms.Database;
using CollectionDeFilms.Films;
using System.Data.SQLite;
/// <summary>
/// Filtre de selection pour afficher la liste des films: UI => requete SQL
/// </summary>
namespace CollectionDeFilms
{
    public class Filtre
    {
        public enum TROIS_ETATS { INDIFFERENT, OUI, NON };
        public enum TRI { TITRE, DATE_AJOUT, DATE_VUE, DUREE };
        public enum ORDRE { CROISSANT, DECROISSANT };
        private string _recherche = null;
        private string _requeteSQL = "";
        private string _critereTri = $" ORDER BY {BaseFilms.FILMS_TITRE} ";
        private string _genre = "";
        private string _etiquette = "";

        private TROIS_ETATS _vu = TROIS_ETATS.INDIFFERENT;
        private TROIS_ETATS _aVoir = TROIS_ETATS.INDIFFERENT;
        private TROIS_ETATS _alternatives = TROIS_ETATS.INDIFFERENT;
        public bool change { get; set; }

        public TRI tri { get; set; }

        public string Recherche
        {
            get { return _recherche; }
            set { _recherche = value; updateFiltre(); }
        }
        public TROIS_ETATS Vu
        {
            get { return _vu; }
            set { _vu = value; updateFiltre(); }
        }
        public TROIS_ETATS AVoir
        {
            get { return _aVoir; }
            set { _aVoir = value; updateFiltre(); }
        }
        public TROIS_ETATS Alternatives
        {
            get { return _alternatives; }
            set { _alternatives = value; updateFiltre(); }
        }

        public string Genre
        {
            get { return _genre; }
            set { _genre = value; updateFiltre(); }
        }
        public string Etiquette
        {
            get { return _etiquette; }
            set { _etiquette = value; updateFiltre(); }
        }

        public string RequeteSQL { get { return _requeteSQL; } private set { } }
        public string CritereTri { get { return _critereTri; } private set { } }

        private void updateFiltre()
        {
            change = true;
            _requeteSQL = "";

            string contient = "";
            if (_recherche != null)
            {
                if (_recherche.StartsWith("-"))
                {
                    // Recherche quelque chose qui ne CONTIENT pas
                    string rech = "'%" + _recherche.Substring(1) + "%'";
                    contient = string.Format("("
                        + $"    (UPPER({BaseFilms.FILMS_CHEMIN}) not like {{0}})"
                        + $" AND (UPPER({BaseFilms.FILMS_TITRE}) not like {{0}})"
                        + $" AND (UPPER({BaseFilms.FILMS_REALISATEUR}) not like {{0}})"
                        + $" AND (UPPER({BaseFilms.FILMS_ACTEURS}) not like {{0}})"
                        + $" AND (UPPER({BaseFilms.FILMS_GENRES}) not like {{0}})"
                        + $" AND (UPPER({BaseFilms.FILMS_NATIONALITE}) not like {{0}})"
                        + $" AND (UPPER({BaseFilms.FILMS_RESUME}) not like {{0}})"
                        + $" AND (UPPER({BaseFilms.FILMS_DATESORTIE}) not like {{0}})"
                        + $" AND (UPPER({BaseFilms.FILMS_TAG})  not like {{0}})"
                        + ")", rech);
                }
                else
                {
                    // Recherche quelque chose qui contient
                    string rech = "'%" + _recherche.Trim() + "%'";
                    contient = string.Format("("
                                                + $"    (UPPER({BaseFilms.FILMS_CHEMIN}) like {{0}})"
                                                + $" OR (UPPER({BaseFilms.FILMS_TITRE}) like {{0}})"
                                                + $" OR (UPPER({BaseFilms.FILMS_REALISATEUR}) like {{0}})"
                                                + $" OR (UPPER({BaseFilms.FILMS_ACTEURS}) like {{0}})"
                                                + $" OR (UPPER({BaseFilms.FILMS_GENRES}) like {{0}})"
                                                + $" OR (UPPER({BaseFilms.FILMS_NATIONALITE}) like {{0}})"
                                                + $" OR (UPPER({BaseFilms.FILMS_RESUME}) like {{0}})"
                                                + $" OR (UPPER({BaseFilms.FILMS_DATESORTIE}) like {{0}})"
                                                + $" OR (UPPER({BaseFilms.FILMS_TAG})  like {{0}})"
                                            + ")", rech);
                }
            }

            // Films deja vus
            string critereVu = "";
            switch (Vu)
            {
                case TROIS_ETATS.INDIFFERENT: break;
                case TROIS_ETATS.OUI: critereVu = $"({BaseFilms.FILMS_DATEVU} <> 0)"; break;
                case TROIS_ETATS.NON: critereVu = $"({BaseFilms.FILMS_DATEVU} = 0)"; break;
            }

            // Films a voir
            string critereAVoire = "";
            switch (AVoir)
            {
                case TROIS_ETATS.INDIFFERENT: break;
                case TROIS_ETATS.OUI: critereAVoire = $"(({BaseFilms.FILMS_FLAGS} & {Film.FLAG_A_VOIR}) <> 0)"; break;
                case TROIS_ETATS.NON: critereAVoire = $"(({BaseFilms.FILMS_FLAGS} & {Film.FLAG_A_VOIR}) = 0)"; break;
            }

            // Films avec alternatives
            string critereAlternatives = "";
            switch (Alternatives)
            {
                case TROIS_ETATS.INDIFFERENT: break;
                case TROIS_ETATS.OUI: critereAlternatives = $"({BaseFilms.TABLE_FILMS}.{BaseFilms.FILMS_ID} IN (SELECT {BaseFilms.ALTERNATIVES_FILMID} FROM {BaseFilms.TABLE_ALTERNATIVES}))"; break;
                case TROIS_ETATS.NON: critereAlternatives = $"({BaseFilms.TABLE_FILMS}.{BaseFilms.FILMS_ID} NOT IN (SELECT {BaseFilms.ALTERNATIVES_FILMID} FROM {BaseFilms.TABLE_ALTERNATIVES}))"; break;
            }

            if (contient?.Length > 0)
                _requeteSQL += contient;

            if (critereVu?.Length > 0)
                _requeteSQL += mayBeAnd(_requeteSQL) + critereVu;

            if (critereAVoire?.Length > 0)
                _requeteSQL += mayBeAnd(_requeteSQL) + critereAVoire;

            if (critereAlternatives?.Length > 0)
                _requeteSQL += mayBeAnd(_requeteSQL) + critereAlternatives;

            // Filtre sur le genre
            if (_genre?.Length > 0)
            {
                string rech = "'%" + _genre + "%'";
                contient = string.Format($"(UPPER({BaseFilms.FILMS_GENRES}) like {{0}})", rech);
                _requeteSQL += mayBeAnd(_requeteSQL) + contient;
            }

            // Filtre sur les etiquettes
            if (_etiquette?.Length > 0)
            {
                string rech = "'%" + _etiquette + "%'";
                contient = string.Format($"(UPPER({BaseFilms.FILMS_TAG}) like {{0}})", rech);
                _requeteSQL += mayBeAnd(_requeteSQL) + contient;
            }

            // Ajouter mot cle SQL WHERE s'il y a des criteres
            if (_requeteSQL?.Length > 0)
                _requeteSQL = $"WHERE ({_requeteSQL})";

        }


        /// <summary>
        /// Ajoute eventuellement un mot cle SQL "AND" entre deux conditions
        /// </summary>
        /// <param name="requeteSQL"></param>
        /// <returns></returns>
        private string mayBeAnd(string requeteSQL)
        {
            if (requeteSQL?.Length > 0)
                return " AND ";
            else
                return "";
        }

        internal SQLiteCommand getSQLCommandCount()
        {
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = "SELECT count(*) FROM FILMS " + _requeteSQL;
            return cmd;
        }


        internal void TriPar(TRI tri, ORDRE o)
        {
            string critere = "";
            string ordre = "";
            this.tri = tri;
            switch (tri)
            {
                case TRI.TITRE: critere = BaseFilms.FILMS_TITRE; break;
                case TRI.DATE_AJOUT: critere = BaseFilms.FILMS_DATECREATION; break;
                case TRI.DUREE: critere = BaseFilms.FILMS_DUREE; break;
                case TRI.DATE_VUE: critere = BaseFilms.FILMS_DATEVU; break;
            }

            switch (o)
            {
                case ORDRE.CROISSANT: ordre = "ASC"; break;
                case ORDRE.DECROISSANT: ordre = "DESC"; break;
            }

            _critereTri = $" ORDER BY {critere} {ordre}";
        }
    }
}
