using Collection_de_films.Database;
using Collection_de_films.Internet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlDataReader = System.Data.SQLite.SQLiteDataReader;

namespace Collection_de_films.Films
{
    public class Film
    {
        // Masque de bits
        public const int FLAG_A_VOIR = 1;

        public const int FLAG_VU = 2;

        public string _etiquettes = "";
        public int _flags;
        public string _titre = "";
        private List<InfosFilm> _alternatives;
        private string _chemin;
        private ETAT _etat;
        private int _id;
        private InfosFilm _infos = new InfosFilm();

        private ListViewItem _lvItem;

        private int _nbAlternatives;

        public Film( string fichier, string etiquettes = "" )
        {
            _chemin = fichier;
            _titre = Path.GetFileNameWithoutExtension( fichier );
            _etiquettes = etiquettes;
        }

        public Film( SqlDataReader reader )
        {
            _id = reader.GetInt32( reader.GetOrdinal( BaseFilms.FILMS_ID ) );
            _chemin = reader.GetString( reader.GetOrdinal( BaseFilms.FILMS_CHEMIN ) );
            _titre = reader.GetString( reader.GetOrdinal( BaseFilms.FILMS_TITRE ) ) ?? Path.GetFileNameWithoutExtension( _chemin );
            _infos._realisateur = reader.GetString( reader.GetOrdinal( BaseFilms.FILMS_REALISATEUR ) ) ?? "";
            _infos._acteurs = reader.GetString( reader.GetOrdinal( BaseFilms.FILMS_ACTEURS ) ) ?? "";
            _infos._genres = reader.GetString( reader.GetOrdinal( BaseFilms.FILMS_GENRES ) ) ?? "";
            _infos._nationalite = reader.GetString( reader.GetOrdinal( BaseFilms.FILMS_NATIONALITE ) ) ?? "";
            _infos._resume = reader.GetString( reader.GetOrdinal( BaseFilms.FILMS_RESUME ) ) ?? "";
            _infos._dateSortie = reader.GetString( reader.GetOrdinal( BaseFilms.FILMS_DATESORTIE ) ) ?? "";
            _flags = reader.GetInt32( reader.GetOrdinal( BaseFilms.FILMS_FLAGS ) );
            if ( !reader.IsDBNull( reader.GetOrdinal( BaseFilms.FILMS_IMAGE_ID ) ) )
                _infos._imageId = reader.GetInt32( reader.GetOrdinal( BaseFilms.FILMS_IMAGE_ID ) );
            else
                _infos._imageId = -1;

            _etiquettes = reader.GetString( reader.GetOrdinal( BaseFilms.FILMS_TAG ) );
            _etat = intToEtat( reader.GetInt32( reader.GetOrdinal( BaseFilms.FILMS_ETAT ) ) );

            _nbAlternatives = BaseFilms.instance.getNbAlternatives( _id );

            if ( _infos._imageId == -1 || _infos._resume == null || "".Equals( _infos._resume ) )
                choisiMeilleureAlternative();
        }

        public enum ETAT
        {
            NOUVEAU, // Le film vient d'etre ajouté, pas encore de recherche d'informations
            RECHERCHE, // recherche en cours
            PAS_TROUVE, // pas trouve sur internet
            ALTERNATIVES, // plusieurs alternatives trouvees
            OK,          // informations trouvees
            DANS_LA_QUEUE // film mis dans la queue de traitement
        };



        /// <summary>
        /// Chargement des donnees du film depuis une page internet
        /// </summary>
        public async void chargeDonnees()
        {
            List<InfosFilm> liste = new List<InfosFilm>();
            try
            {
                MainForm.WriteMessageToConsole( "-----------------------------" );
                MainForm.WriteMessageToConsole( "Recherche d'informations pour le film " + _titre + " " + _chemin );

                Etat = ETAT.RECHERCHE;
                bool arretPremier = Configuration.arretRecherchePremier;
                _alternatives?.Clear();
                BaseFilms.instance.supprimeAlternatives( this );

                List<RechercheInternet> recherches = BaseConfiguration.instance.getListeRechercheInternet();

                if ( recherches != null )
                {
                    foreach ( RechercheInternet r in recherches )
                    {
                        List<InfosFilm> i = await r.rechercheInternet( this );
                        if ( i != null )
                        {
                            liste.AddRange( i );
                            if ( arretPremier )
                                break;
                        }
                    }
                }
                else
                    MainForm.WriteErrorToConsole( "Configurez des recherches internet dans la boite de configuration" );
            }
            catch ( Exception e )
            {
                MainForm.WriteExceptionToConsole( e );
            }

            switch ( liste.Count )
            {
                case 0:
                    Etat = ETAT.PAS_TROUVE;
                    break;

                case 1:
                    Etat = ETAT.OK;
                    _infos = liste[0];
                    break;

                default:
                    Etat = ETAT.ALTERNATIVES;
                    _alternatives = liste;
                    choisiMeilleureAlternative();
                    break;
            }

            BaseFilms.instance.update( this );
            updateListView();
        }

        /// <summary>
        /// Chargement des donnees du film depuis une page internet
        /// </summary>
        async public void chargeDonneesSite( string nomSite )
        {
            List<InfosFilm> liste = new List<InfosFilm>();

            try
            {
                MainForm.WriteMessageToConsole( "-----------------------------" );
                MainForm.WriteMessageToConsole( "Recherche d'informations pour le film " + _titre + " " + _chemin );
                MainForm.WriteMessageToConsole( "Depuis le site: " + nomSite );

                Etat = ETAT.RECHERCHE;
                RechercheInternet recherche = BaseConfiguration.instance.getRechercheInternet(nomSite);
                if ( recherche == null )
                {
                    MainForm.WriteErrorToConsole( "Impossible de trouver les informations de recherche sur le site " + nomSite );
                }
                else
                {
                    _alternatives?.Clear();
                    BaseFilms.instance.supprimeAlternatives( this );
                    liste = await recherche.rechercheInternet( this );
                }


                switch ( liste.Count )
                {
                    case 0:
                        Etat = ETAT.PAS_TROUVE;
                        break;

                    case 1:
                        Etat = ETAT.OK;
                        _infos = liste[0];
                        break;

                    default:
                        Etat = ETAT.ALTERNATIVES;
                        _alternatives = liste;
                        choisiMeilleureAlternative();
                        break;
                }
            }
            catch ( Exception e )
            {
                MainForm.WriteExceptionToConsole( e );
            }

            BaseFilms.instance.update( this );
            updateListView();
        }

        public ListViewItem getListviewItem( ListView lv )
        {
            if ( _lvItem == null )
            {
                _lvItem = new ListViewItem();
                _lvItem.Text = Titre;
                _lvItem.SubItems.Add( Resume ).BackColor = Color.WhiteSmoke;
                _lvItem.SubItems.Add( toTexte( Vu ) ).BackColor = Color.White;
                _lvItem.SubItems.Add( toTexte( aVoir ) ).BackColor = Color.WhiteSmoke;
                _lvItem.SubItems.Add( separe( Genres ) ).BackColor = Color.White;
                _lvItem.SubItems.Add( separe( Realisateur ) ).BackColor = Color.WhiteSmoke;
                _lvItem.SubItems.Add( separe( Acteurs ) ).BackColor = Color.White;
                _lvItem.SubItems.Add( DateSortie ).BackColor = Color.WhiteSmoke;
                _lvItem.SubItems.Add( _etiquettes ).BackColor = Color.White;
                _lvItem.ToolTipText = Tooltip();
                _lvItem.Tag = this;
            }

            return _lvItem;
        }

        /// <summary>
        /// Separe des elements codes dans une meme chaine et retourne une forme plus lisible
        /// </summary>
        /// <param name="texte"></param>
        /// <returns></returns>
        private static string separe( string texte )
        {
            string[] mots = texte.Split(BaseFilms.SEPARATEUR_LISTES_CHAR);
            if ( mots == null || mots.Length == 0 )
                return "";

            string result = mots[0];
            for ( int i = 1; i < mots.Length; i++ )
                result += ", " + mots[i];

            return result;
        }

        private static string toTexte( bool ouiNon )
        {
            return ouiNon ? "Oui" : "Non";
        }

        /// <summary>
        /// Choisir une des alternative des informations du films
        /// </summary>
        /// <param name="indiceAlternative"></param>
        public void setAlternative( int indiceAlternative )
        {
            BaseFilms baseFilms = BaseFilms.instance;
            if ( _alternatives == null )
                return;
            Stopwatch sw = new Stopwatch();
            TimeSpan ts;
            if ( indiceAlternative < 0 || indiceAlternative >= _alternatives.Count )
                return;

            _infos = _alternatives[indiceAlternative];
            MainForm.WriteMessageToConsole( "Choix d'une alternative pour " + _titre );
            if ( Configuration.supprimerAutresAlternatives )
            {
                sw.Start();
                MainForm.WriteMessageToConsole( "Suppression des autres alternatives" );
                baseFilms.supprimeAlternatives( this );
                sw.Stop();
                ts = sw.Elapsed;
                MainForm.WriteMessageToConsole( $"Supprimer alternatives: {ts.Seconds}:{ts.Milliseconds}" );
            }


            MainForm.WriteMessageToConsole( "Réalisateur " + Realisateur );
            MainForm.WriteMessageToConsole( "Date sortie " + DateSortie );

            _etat = ETAT.OK;
            sw = new Stopwatch();
            sw.Start();
            baseFilms.update( this );
            sw.Stop();
            ts = sw.Elapsed;
            MainForm.WriteMessageToConsole( $"Update base: {ts.Seconds}:{ts.Milliseconds}" );

            sw = new Stopwatch();
            sw.Start();
            MainForm.update( this );
            sw.Stop();
            ts = sw.Elapsed;
            MainForm.WriteMessageToConsole( $"Update liste: {ts.Seconds}:{ts.Milliseconds}" );
        }

        public bool setInfos( List<InfosFilm> infos )
        {
            if ( infos?.Count > 0 )
            {
                MainForm.WriteMessageToConsole( "Informations trouvées" );
                if ( _alternatives == null )
                    _alternatives = infos;
                else
                    _alternatives.AddRange( infos );
                return true;
            }

            MainForm.WriteMessageToConsole( "Pas d'information trouvée" );
            return false;
        }

        public void updateListviewItem( ListView lv )
        {
            if ( _lvItem == null )
                _lvItem = new ListViewItem();
            while ( _lvItem.SubItems.Count < 9 )
                _lvItem.SubItems.Add( "" );

            _lvItem.Text = _titre;
            _lvItem.SubItems[1].Text = Resume;
            _lvItem.SubItems[2].Text = toTexte( Vu );
            _lvItem.SubItems[3].Text = toTexte( aVoir );
            _lvItem.SubItems[4].Text = separe( Genres );
            _lvItem.SubItems[5].Text = separe( Realisateur );
            _lvItem.SubItems[6].Text = separe( Acteurs );
            _lvItem.SubItems[7].Text = DateSortie;
            _lvItem.SubItems[8].Text = _etiquettes;

            _lvItem.ToolTipText = Tooltip();

            int index = lv.Items.IndexOf(_lvItem);
            if ( index != -1 )
            {
                lv.EnsureVisible( index );
                lv.Invalidate( lv.GetItemRect( index ) );
            }
        }

        #region proprietes

        async public Task<List<InfosFilm>> Alternatives()
        {
            if ( _alternatives == null )
            {
                _alternatives = BaseFilms.instance.getAlternatives( _id );
            }

            return _alternatives;
        }

        public bool aVoir
        {
            get { return (_flags & FLAG_A_VOIR) != 0; }
            set
            {
                if ( value )
                    _flags |= FLAG_A_VOIR;
                else
                    _flags &= ~FLAG_A_VOIR;
            }
        }

        public ETAT Etat
        {
            get { return _etat; }
            set
            {
                _etat = value;
                if ( _lvItem != null )
                    MainForm.update( this );
            }
        }

        public int EtatInt
        {
            get { return etatToInt( _etat ); }
        }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public int NbAlternatives
        {
            get { return _nbAlternatives; }
        }

        public bool Vu
        {
            get { return (_flags & FLAG_VU) != 0; }
            set
            {
                if ( value )
                    _flags |= FLAG_VU;
                else
                    _flags &= ~FLAG_VU;
            }
        }
        internal string Acteurs
        {
            get { return _infos._acteurs; }
            set { _infos._acteurs = value; }
        }

        internal Image affiche
        {
            get { return _infos.affiche; }
            set { _infos.affiche = value; }
        }

        internal string Chemin
        {
            get { return _chemin; }
        }

        internal string DateSortie
        {
            get { return _infos._dateSortie; }
            set { _infos._dateSortie = value; }
        }

        internal string Genres
        {
            get { return _infos._genres; }
            set { _infos._genres = value; }
        }

        internal int imageId
        {
            get { return _infos._imageId; }
            set { _infos._imageId = value; }
        }

        internal string Nationalite
        {
            get { return _infos._nationalite; }
            set { _infos._nationalite = value; }
        }

        internal string Realisateur
        {
            get { return _infos._realisateur; }
            set { _infos._realisateur = value; }
        }

        internal string Resume
        {
            get { return _infos._resume; }
            set { _infos._resume = value; }
        }

        internal string Titre
        {
            get { return _titre; }
            set { _titre = value; }
        }

        public static int etatToInt( ETAT e )
        {
            switch ( e )
            {
                case ETAT.NOUVEAU: return 0;
                case ETAT.RECHERCHE: return 1;
                case ETAT.PAS_TROUVE: return 2;
                case ETAT.OK: return 3;
                case ETAT.ALTERNATIVES: return 4;
                case ETAT.DANS_LA_QUEUE: return 5;
                default:
                    throw new ArgumentException( $"ETAT de film incorrect {e}" );
            }
        }

        public static Image getImage( SqlDataReader reader, int afficheIndex )
        {
            try
            {
                Stream picData = reader.GetStream(afficheIndex);

                if ( picData != null )
                    return new Bitmap( picData );
            }
            catch ( Exception )
            {
            }

            return null;
        }

        public static ETAT intToEtat( int v )
        {
            switch ( v )
            {
                case 0: return ETAT.NOUVEAU;
                case 1: return ETAT.RECHERCHE;
                case 2: return ETAT.PAS_TROUVE;
                case 3: return ETAT.OK;
                case 4: return ETAT.ALTERNATIVES;
                case 5: return ETAT.DANS_LA_QUEUE;
                default:
                    throw new ArgumentException( $"ETAT de film incorrect {v}" );
            }
        }

        /// <summary>
        /// Retourne une image pour representer le film dans la liste "Grande icones", son affiche si possible
        /// </summary>
        /// <param name="film"></param>
        /// <param name="bounds"></param>
        /// <returns></returns>
        async public Task<Image> getImage( Rectangle bounds )
        {
            Image image = getAffiche();
            if ( image != null )
            {
                image = Images.ombre( Images.zoomImage( image, bounds ), 2 );
            }
            else
            if ( NbAlternatives > 0 )
                image = await getimageAlternatives( bounds );
            else
                switch ( Etat )
                {
                    case ETAT.NOUVEAU:
                        image = Resources.film_nouveau;
                        break;

                    case ETAT.DANS_LA_QUEUE:
                        image = Resources.film_dans_la_queue;
                        break;

                    case ETAT.PAS_TROUVE:
                        image = Resources.film_non_trouve;
                        break;

                    case ETAT.RECHERCHE:
                        image = Resources.film_recherche_en_cours;
                        break;

                    case ETAT.ALTERNATIVES:
                        image = Resources.film_multiple;
                        break;

                    default:
                        image = Resources.film_nouveau;
                        break;
                }

            const int ratioEtiquette = 6;
            if ( Vu )
            {
                using ( Graphics g = Graphics.FromImage( image ) )
                {
                    g.DrawImage( Resources.deja_vu, 2, 2, image.Width / ratioEtiquette, image.Height / ratioEtiquette );
                }
            }

            if ( aVoir )
            {
                using ( Graphics g = Graphics.FromImage( image ) )
                {
                    g.DrawImage( Resources.a_voir, image.Width - (image.Width / ratioEtiquette) - 2, 2, image.Width / ratioEtiquette, image.Height / ratioEtiquette );
                }
            }

            return image; // Images.zoomImage( image, bounds );
        }

        /// <summary>
        /// Dessine une image representant les alternatives d'un film
        /// </summary>
        /// <param name="film"></param>
        /// <param name="bounds"></param>
        /// <returns></returns>
        async public Task<Image> getimageAlternatives( Rectangle bounds )
        {
            Image newImage = new Bitmap(bounds.Width, bounds.Height);
            using ( Graphics g = Graphics.FromImage( newImage ) )
            {
                List<InfosFilm> alternatives = await Alternatives();
                alternatives = alternatives.Where( s => s.affiche != null ).ToList<InfosFilm>();

                // 9 images au max
                while ( alternatives.Count > 9 )
                {
                    int indice = alternatives.IndexOf(null);
                    if ( indice == -1 )
                        indice = alternatives.Count - 1;
                    alternatives.RemoveAt( indice );
                }

                int nbImages = alternatives.Count;
                if ( nbImages == 0 )
                    return null;

                int NB_COLONNES = (int)(Math.Ceiling(Math.Sqrt(nbImages)));
                int NB_LIGNES = ((nbImages + NB_COLONNES - 1) / NB_COLONNES);

                int LARGEUR_COLONNE = bounds.Width / NB_COLONNES;
                int HAUTEUR_COLONNE = bounds.Height / NB_LIGNES;

                for ( int i = 0; i < alternatives.Count; i++ )
                {
                    int y = ((i + NB_COLONNES - 1) / NB_COLONNES) * LARGEUR_COLONNE;
                    int x = (i % NB_COLONNES) * HAUTEUR_COLONNE;
                    Rectangle r = new Rectangle(x, y, LARGEUR_COLONNE, HAUTEUR_COLONNE);
                    r.Inflate( -4, -4 );
                    Image img = Images.zoomImage(alternatives[i].affiche, r);
                    if ( img != null )
                        g.DrawImageUnscaled( img, r.Left + (r.Width - img.Width) / 2, r.Top + (r.Height - img.Height) / 2 );
                }

                /* IMAGES EN CASCADE
                int LargeurImage = bounds.Width - (nbImages * 2);
                int HauteurImage = bounds.Height - (nbImages * 2);
                Rectangle rImage = new Rectangle(0, 0, LargeurImage, HauteurImage);

                int x = 0;
                int y = 0;
                foreach (InfosFilm info in alternatives)
                {
                    Image i = zoomImage(info._affiche, rImage);
                    if (i != null)
                    {
                        g.DrawImageUnscaled(i, x, y);
                        x += 2;
                        y += 2;
                    }
                }
                */
            }

            return newImage;
        }

        async public Task<Image> getImageSmall( Rectangle bounds )
        {
            Image image = getAffiche();
            if ( image != null )
                image = Images.zoomImage( image, bounds );
            else
            if ( NbAlternatives > 0 )
                image = await getimageAlternatives( bounds );
            else
                switch ( Etat )
                {
                    case ETAT.NOUVEAU:
                        image = Resources.film_nouveau;
                        break;

                    case ETAT.DANS_LA_QUEUE:
                        image = Resources.film_dans_la_queue;
                        break;

                    case ETAT.PAS_TROUVE:
                        image = Resources.film_non_trouve;
                        break;

                    case ETAT.RECHERCHE:
                        image = Resources.film_recherche_en_cours;
                        break;

                    case ETAT.ALTERNATIVES:
                        image = Resources.film_multiple;
                        break;

                    default:
                        image = Resources.film_nouveau;
                        break;
                }

            return Images.zoomImage( image, bounds );
        }
        internal ListViewItem getLVItem()
        {
            if ( _lvItem == null )
            {
            }
            return _lvItem;
        }

        internal void setLVItem( ListViewItem item )
        {
            _lvItem = item;
        }

        /// <summary>
        /// Calcul le texte du tooltip
        /// </summary>
        /// <returns></returns>
        internal string Tooltip()
        {
            string result = _titre;

            if ( _infos._realisateur.Length > 0 )
                result += "\nDe : " + _infos._realisateur;

            if ( _infos._acteurs.Length > 0 )
                result += "\nAvec : " + _infos._acteurs;

            if ( _infos._genres.Length > 0 )
                result += "\nGenre: " + _infos._genres;
            if ( _infos._dateSortie.Length > 0 )
                result += "\nDate de sortie: " + _infos._dateSortie;

            if ( _infos._resume.Length > 0 )
                result += "\n" + _infos._resume;

            if ( _alternatives?.Count > 0 )
            {
                result += "\nPlusieurs alternatives ont été trouvées pour ce film, vous pouvez utiliser le panneau de droite pour les visualiser et choisir laquelle vous convient le mieux";
            }
            return result;
        }

        #endregion proprietes

        internal Image getAffiche()
        {
            if ( _infos == null )
                return null;

            if ( _infos.affiche != null )
                return _infos.affiche;

            if ( _infos._imageId == -1 )
                return null;

            _infos.affiche = BaseFilms.instance.getImage( _infos._imageId );
            return _infos.affiche;
        }

        internal byte[] getAfficheBytes()
        {
            if ( _etat != ETAT.OK )
                return null;

            Image image = getAffiche();
            return Images.imageToByteArray( image );
        }
        internal string getTextEtat()
        {
            switch ( _etat )
            {
                case ETAT.NOUVEAU:
                    return "Nouveau film, les informations n'ont pas encore été cherchées sur Internet";

                case ETAT.OK:
                    return "Les informations de ce film ont été correctement trouvées sur Internet";

                case ETAT.PAS_TROUVE:
                    return "Ce film n'a pas été trouvé sur Internet, essayez de modifier le film et de relancer la recherche";

                case ETAT.RECHERCHE:
                    return "Recherche en cours";

                case ETAT.DANS_LA_QUEUE:
                    return "Le film est en attente de traitement";

                case ETAT.ALTERNATIVES:
                    return "Plusieurs alternatives ont été trouvées pour ce film";

                default:
                    return "Etat inconnu";
            }
        }


        private void updateListView()
        {
            MainForm.update( this );
        }


        /// <summary>
        /// Choisi automatiquement la meilleure alternative pour un film:
        /// - un point par information
        /// - 5 points pour un resumé ou une affiche
        /// </summary>
        async private void choisiMeilleureAlternative()
        {
            List<InfosFilm> alternatives = await Alternatives();
            int meilleurScore = -1;
            InfosFilm meilleure = null;
            foreach ( InfosFilm info in alternatives )
            {
                int score = calculScore(info);
                if ( score > meilleurScore )
                {
                    meilleurScore = score;
                    meilleure = info;
                }
            }

            if ( meilleure != null )
            {
                int scoreActuel = calculScore(_infos);
                if ( scoreActuel < meilleurScore )
                {
                    _infos = meilleure;
                    _infos._imageId = meilleure._imageId;
                }
            }
        }

        /// <summary>
        /// Calcule un score de qualite pour une InfoFilm
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private int calculScore( InfosFilm info )
        {
            if ( info == null )
                return 0;
            int score = 0;

            if ( info._acteurs?.Length > 0 )
                score += 1;

            if ( info._dateSortie?.Length > 0 )
                score += 1;
            if ( info._genres?.Length > 0 )
                score += 1;
            if ( info._nationalite?.Length > 0 )
                score += 1;
            if ( info._realisateur?.Length > 0 )
                score += 1;
            if ( info._resume?.Length > 0 )
                score += 5;
            if ( info._imageId != -1 )
                score += 5;
            return score;
        }
    }
}
