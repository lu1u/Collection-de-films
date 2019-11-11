using Collection_de_films;
using Collection_de_films_2;
using CollectionDeFilms.Database;
using CollectionDeFilms.Internet;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionDeFilms.Films
{
    public partial class Film
    {
        private bool _donneesChargees = false;   // On ne charge les donnees que quand on en a besoin
        private int _id;
        private string _titre;
        private string _chemin;
        private string _etiquettes;
        private int _flags;
        private string _realisateur = "";
        private string _acteurs = "";
        private string _genres = "";
        private string _nationalite = "";
        private string _resume = "";
        private string _dateSortie = "";
        private bool _fichierNonTrouve;
        private DateTime _dateVu;
        private ETAT _etat;
        // Masque de bits pour FLAG
        public const int FLAG_A_VOIR = 1;
        // Cache de l'image dans la liste
        private Image _imageGrandeIcone;
        private List<InfosFilm> _alternatives;

        // Initialisation des membres statiques
        static StringFormat _formatLargeIcones;
        static Film()
        {
            _formatLargeIcones = new StringFormat();
            _formatLargeIcones.Alignment = StringAlignment.Center;
            _formatLargeIcones.LineAlignment = StringAlignment.Far;
            _formatLargeIcones.Trimming = StringTrimming.EllipsisWord;
        }


        public Film(SQLiteDataReader reader)
        {
            _id = reader.GetInt32(reader.GetOrdinal(BaseFilms.FILMS_ID));
        }

        public Film(string fichier, string etiquettes = "")
        {
            _chemin = fichier;
            _titre = Path.GetFileNameWithoutExtension(fichier);
            _etiquettes = etiquettes;
            _fichierNonTrouve = false;
        }

        public enum ETAT
        {
            NOUVEAU, // Le film vient d'etre ajouté, pas encore de recherche d'informations
            RECHERCHE, // recherche en cours
            PAS_TROUVE, // pas trouve sur internet
            OK,          // informations trouvees
            DANS_LA_QUEUE, // film mis dans la queue de traitement
        };

        internal ListViewItem createListviewItem()
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Tag = this;
            return lvi;
        }

        async internal void drawItem(DrawListViewItemEventArgs e)
        {
            chargeDonneesDepuisBase();
            if (e.Item.ToolTipText == null || e.Item.ToolTipText.Length == 0)
            {
                // En profiter pour calculer le tooltip
                e.Item.ToolTipText = getTooltip();
            }

            // Fond spécifique pour image sélectionnee
            if ((e.State & ListViewItemStates.Selected) != 0 && (e.State & ListViewItemStates.Focused) != 0)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                e.DrawFocusRectangle();
            }

            SizeF s = e.Graphics.MeasureString(Titre, e.Item.ListView.Font, e.Bounds.Width);
            Rectangle rImage = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height - (int)s.Height);

            // Image
            Image image = getImageFilm(rImage);
            if (image != null)
            {
                int dx = (rImage.Width - image.Width) / 2;
                int dy = (rImage.Height - image.Height) / 2;
                rImage.Offset(dx, dy);
                e.Graphics.DrawImageUnscaled(image, rImage.Left, rImage.Top);
            }

            // Texte
            using (Brush b = new SolidBrush(e.Item.ListView.ForeColor))
                e.Graphics.DrawString(Titre, e.Item.ListView.Font, b, e.Bounds, _formatLargeIcones);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Calcul le texte du tooltip
        /// </summary>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////////////////////////////
        public string getTooltip()
        {
            string result = "";

            result += Titre;
            result += " [" + Id + "]";
            if (_realisateur?.Length > 0)
                result += "\nDe : " + _realisateur;

            if (_acteurs?.Length > 0)
                result += "\nAvec : " + _acteurs;

            //if (_genres?.Length > 0)
            //    result += "\nGenre: " + _genres;
            //
            //if (_dateSortie?.Length > 0)
            //    result += "\nDate de sortie: " + _dateSortie;

            if (_resume?.Length > 0)
                result += "\n" + _resume;

            if (_alternatives != null)
                if (_alternatives.Count > 0)
                {
                result += "\nPlusieurs alternatives ont été trouvées pour ce film";
                }

            if (_dateVu.Ticks != 0)
            {
                result += "\nVu le " + _dateVu.ToLongDateString();
            }

            if (_etat != ETAT.OK)
                result += "\n" + getTextEtat();

            return result;
        }
        internal string getTextEtat()
        {
            switch (_etat)
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

                default:
                    return "Etat inconnu";
            }
        }

        async private void chargeDonneesDepuisBase()
        {
            if (!_donneesChargees)
            {
                // Lire les champs
                SQLiteDataReader reader = await BaseFilms.instance.getFilmsReader(_id);
                if (reader != null && reader.HasRows)
                {
                    reader.Read();
                    _chemin = reader.GetString(reader.GetOrdinal(BaseFilms.FILMS_CHEMIN));
                    _titre = reader.GetString(reader.GetOrdinal(BaseFilms.FILMS_TITRE)) ?? Path.GetFileNameWithoutExtension(_chemin);
                    _realisateur = reader.GetString(reader.GetOrdinal(BaseFilms.FILMS_REALISATEUR)) ?? "";
                    _acteurs = reader.GetString(reader.GetOrdinal(BaseFilms.FILMS_ACTEURS)) ?? "";
                    _genres = reader.GetString(reader.GetOrdinal(BaseFilms.FILMS_GENRES)) ?? "";
                    _nationalite = reader.GetString(reader.GetOrdinal(BaseFilms.FILMS_NATIONALITE)) ?? "";
                    _resume = reader.GetString(reader.GetOrdinal(BaseFilms.FILMS_RESUME)) ?? "";
                    _dateSortie = reader.GetString(reader.GetOrdinal(BaseFilms.FILMS_DATESORTIE)) ?? "";
                    _flags = reader.GetInt32(reader.GetOrdinal(BaseFilms.FILMS_FLAGS));
                    _etiquettes = reader.GetString(reader.GetOrdinal(BaseFilms.FILMS_TAG));
                    _etat = intToEtat(reader.GetInt32(reader.GetOrdinal(BaseFilms.FILMS_ETAT)));
                    try
                    {
                        _dateVu = new DateTime(reader.GetInt64(reader.GetOrdinal(BaseFilms.FILMS_DATEVU)));
                    }
                    catch (Exception)
                    {
                        // Pour récup
                        if ((reader.GetInt32(reader.GetOrdinal(BaseFilms.FILMS_ETAT)) & 2) != 0)
                            _dateVu = DateTime.Now;
                        else
                            _dateVu = new DateTime(0);
                    }
                    _fichierNonTrouve = false;
                    _donneesChargees = true;
                }
            }
        }

        #region proprietes

        public bool aVoir
        {
            get { return (_flags & FLAG_A_VOIR) != 0; }
            set
            {
                if (value)
                    _flags |= FLAG_A_VOIR;
                else
                    _flags &= ~FLAG_A_VOIR;

                BaseFilms.instance.updateFilm(_id, BaseFilms.FILMS_FLAGS, _flags);
                changeEtat();
            }
        }


        public ETAT Etat
        {
            get { return _etat; }
            set
            {
                _etat = value;
                changeEtat();
            }
        }

        public bool FichierNonTrouve
        {
            get { return _fichierNonTrouve; }
            set
            {
                _fichierNonTrouve = value;
                changeEtat();
            }
        }

        internal Image Affiche
        {
            get
            {
                //if (_image == null)
                //{
                //    _image = BaseFilms.instance.getImageFilm(_id);
                //}
                //return _image;
                return BaseFilms.instance.getAfficheFilm(_id);
            }
            set
            {
                BaseFilms.instance.sauveImage(_id, Images.retaille(value, Configuration.largeurMaxImages));
                changeEtat();
            }
        }

        public int EtatInt
        {
            get { return etatToInt(_etat); }
        }

        public int NbAlternatives
        {
            get { return Alternatives().Count(); }
        }

        public bool Vu
        {
            get { return _dateVu.Ticks != 0; }
            set
            {
                if (value)
                    _dateVu = DateTime.Now;
                else
                    _dateVu = new DateTime(0);

                BaseFilms.instance.updateFilm(_id, BaseFilms.FILMS_DATEVU, _dateVu.Ticks);
                changeEtat();
            }
        }

        public DateTime DateVu
        {
            get { return _dateVu; }
            set
            {
                _dateVu = value;

                BaseFilms.instance.updateFilm(_id, BaseFilms.FILMS_DATEVU, _dateVu.Ticks);
                changeEtat();
            }
        }

        internal string Acteurs { get => _acteurs; set { _acteurs = value; changeEtat(); } }
        internal string Chemin { get => _chemin; set { _chemin = value; changeEtat(); } }
        internal string DateSortie { get => _dateSortie; set { _dateSortie = value; changeEtat(); } }
        internal string Genres { get => _genres; set { _genres = value; changeEtat(); } }
        internal string Nationalite { get => _nationalite; set { _nationalite = value; changeEtat(); } }
        internal string Realisateur { get => _realisateur; set { _realisateur = value; changeEtat(); } }
        internal string Resume { get => _resume; set { _resume = value; changeEtat(); } }
        internal string Titre { get { chargeDonneesDepuisBase(); return _titre; } set { _titre = value; changeEtat(); } }
        internal string Etiquettes { get => _etiquettes; set { _etiquettes = value; changeEtat(); } }
        public int Flags { get => _flags; set { _flags = value; changeEtat(); } }
        public int Id { get => _id; set => _id = value; }

        public static int etatToInt(ETAT e)
        {
            switch (e)
            {
                case ETAT.NOUVEAU: return 0;
                case ETAT.RECHERCHE: return 1;
                case ETAT.PAS_TROUVE: return 2;
                case ETAT.OK: return 3;
                case ETAT.DANS_LA_QUEUE: return 4;
                default:
                    throw new ArgumentException($"ETAT de film incorrect {e}");
            }
        }
        public static ETAT intToEtat(int v)
        {
            switch (v)
            {
                case 0: return ETAT.NOUVEAU;
                case 1: return ETAT.RECHERCHE;
                case 2: return ETAT.PAS_TROUVE;
                case 3: return ETAT.OK;
                case 4: return ETAT.DANS_LA_QUEUE;
                default:
                    throw new ArgumentException($"ETAT de film incorrect {v}");
            }
        }

        #endregion

        /// <summary>
        /// Prend en compte le changement d'etat du film
        /// </summary>
        private void changeEtat()
        {
            _imageGrandeIcone?.Dispose();
            _imageGrandeIcone = null;   // Pour etre sur de la redessiner
        }

        /// <summary>
        /// Retourne une image pour representer le film dans la liste "Grande icones", son affiche si possible
        /// et les differentes icones refletant son etat
        /// </summary>
        /// <param name="film"></param>
        /// <param name="bounds"></param>
        /// <returns></returns>
        public Image getImageFilm(Rectangle bounds)
        {
            if (_imageGrandeIcone != null)
                return _imageGrandeIcone;

            // Fond de l'image
            Image imageGrandeIcone = getImageFond(bounds);

            using (Graphics g = Graphics.FromImage(imageGrandeIcone))
            {
                //Etiquettes
                if (imageGrandeIcone != null)
                {
                    Image etiquettes = getEtiquettes();
                    if (etiquettes != null)
                        g.DrawImage(etiquettes, 0, imageGrandeIcone.Height - etiquettes.Height, Math.Min(imageGrandeIcone.Width, etiquettes.Width), etiquettes.Height);
                }

                const int ratioEtiquette = 5;
                int largeurEtiquette = imageGrandeIcone.Width / ratioEtiquette;
                int hauteurEtiquette = largeurEtiquette;// imageGrandeIcone.Height / ratioEtiquette;
                if (Vu)
                    g.DrawImage(Resources.deja_vu, 0, 0, largeurEtiquette, hauteurEtiquette);

                if (aVoir)
                    g.DrawImage(Resources.a_voir, imageGrandeIcone.Width - largeurEtiquette - 4, 0, largeurEtiquette, hauteurEtiquette);


                if (FichierNonTrouve)
                    g.DrawImage(Resources.film_non_trouve, 2, imageGrandeIcone.Height - Resources.film_non_trouve.Height - 2, Resources.film_non_trouve.Width, Resources.film_non_trouve.Height);
            }

            _imageGrandeIcone = imageGrandeIcone;
            return _imageGrandeIcone;
        }

        /// <summary>
        /// Dessine une image contenant les etiquettes montrant l'etat de l'objet
        /// </summary>
        /// <returns></returns>
        private Image getEtiquettes()
        {
            Image etiquette;
            switch (Etat)
            {
                case ETAT.NOUVEAU:
                    etiquette = Images.copie(Resources.film_nouveau);
                    break;

                case ETAT.DANS_LA_QUEUE:
                    etiquette = Images.copie(Resources.film_dans_la_queue);
                    break;
                case ETAT.PAS_TROUVE:
                    etiquette = Images.copie(Resources.film_non_trouve);
                    break;

                case ETAT.RECHERCHE:
                    etiquette = Images.copie(Resources.film_recherche_en_cours);
                    break;
                default:
                    etiquette = null;
                    break;
            }

            return etiquette;
        }

        internal async void setAlternative(int indiceAlternative)
        {
            BaseFilms baseFilms = BaseFilms.instance;
            List<InfosFilm> alternatives = Alternatives();
            if (alternatives == null)
                return;
            if (indiceAlternative < 0 || indiceAlternative >= alternatives.Count)
                return;

            _realisateur = alternatives[indiceAlternative]._realisateur;
            _acteurs = alternatives[indiceAlternative]._acteurs;
            _genres = alternatives[indiceAlternative]._genres;
            _nationalite = alternatives[indiceAlternative]._nationalite;
            _resume = alternatives[indiceAlternative]._resume;
            _dateSortie = alternatives[indiceAlternative]._dateSortie;
            Affiche = alternatives[indiceAlternative]._image;
            MainForm.WriteMessageToConsole("Choix d'une alternative pour " + _titre);
            MainForm.WriteMessageToConsole("Réalisateur " + Realisateur);
            MainForm.WriteMessageToConsole("Date sortie " + DateSortie);

            _etat = ETAT.OK;
            baseFilms.update(this);
            if (Configuration.supprimerAutresAlternatives)
            {
                MainForm.WriteMessageToConsole("Suppression des autres alternatives");
                baseFilms.supprimeAlternatives(_id);
            }
            MainForm.changeEtat(this);
        }

        /// <summary>
        /// Retrouve l'image de fond: affiche si elle existe, liste d'alternatives ou icone "pas d'image"
        /// </summary>
        /// <returns></returns>
        private Image getImageFond(Rectangle bounds)
        {
            // D'abord, essayer avec l'affiche
            Image imageGrandeIcone = Affiche;
            if (imageGrandeIcone == null)
            {
                // Pas d'affiche choisie, des alternatives?
                if (NbAlternatives > 0)
                    return getimageAlternatives(bounds);
                else
                    // Utiliser l'image "pas d'affiche"
                    return Images.copie(Resources.film_nouveau);
            }
            else
            {
                // Une affiche selectionnee, ajouter une image pour les alternatives s'il y en a
                if (NbAlternatives > 0)
                    using (Graphics g = Graphics.FromImage(imageGrandeIcone))
                    {
                        g.DrawImageUnscaled(Resources.alternatives, imageGrandeIcone.Width - Resources.alternatives.Width, imageGrandeIcone.Height - Resources.alternatives.Height);
                    }
            }

            if (imageGrandeIcone != null)
            {
                Rectangle zoom = new Rectangle(bounds.Left, bounds.Top, bounds.Width, bounds.Height);
                zoom.Inflate(-4, -4);
                imageGrandeIcone = Images.ombre(Images.zoomImage(imageGrandeIcone, zoom), 4);
            }

            return imageGrandeIcone;
        }



        public List<InfosFilm> Alternatives()
        {
            if (_alternatives == null)
            {
                _alternatives = BaseFilms.instance.getAlternatives(_id);
            }

            return _alternatives;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Chargement des donnees du film depuis une page internet
        /// </summary>
        ///////////////////////////////////////////////////////////////////////////////////////////
        async public void chargeDonneesSite(string nomSite)
        {
            try
            {
                MainForm.WriteMessageToConsole($"Recherche d'informations pour le film {_titre} {_chemin}. Depuis le site: {nomSite}");

                RechercheInternet recherche = BaseConfiguration.instance.getRechercheInternet(nomSite);
                if (recherche == null)
                {
                    MainForm.WriteErrorToConsole("Impossible de trouver les informations de recherche sur ce site");
                    return;
                }

                // Modifier l'aspect du film dans l'interface utilisateur
                Etat = ETAT.RECHERCHE;
                _alternatives?.Clear();
                BaseFilms.instance.supprimeAlternatives(_id);
                changeEtat();
                MainForm.changeEtat(this);

                // Lancer la recherche, recuperer les versions du film trouvees sur internet
                List<InfosFilm> liste = await recherche.rechercheInternet(this);

                // Interpretation du resultat de la recherche
                switch (liste.Count)
                {
                    case 0:
                        // Rien trouvé
                        Etat = ETAT.PAS_TROUVE;
                        break;

                    case 1:
                        // Une seule version trouvee
                        Etat = ETAT.OK;
                        _realisateur = liste[0]._realisateur;
                        _acteurs = liste[0]._acteurs;
                        _genres = liste[0]._genres;
                        _nationalite = liste[0]._nationalite;
                        _resume = liste[0]._resume;
                        _dateSortie = liste[0]._dateSortie;

                        Affiche = liste[0]._image;
                        break;

                    default:
                        // Plusieurs versions trouvees, choisir la meilleure
                        _alternatives = liste;
                        choisiMeilleureAlternative();
                        break;
                }
                BaseFilms.instance.update(this);
            }
            catch (Exception e)
            {
                MainForm.WriteErrorToConsole($"Erreur lors de la recherche d'information pour le film {_titre}, sur le site {nomSite}");
                MainForm.WriteExceptionToConsole(e);
            }

            // Modifier l'apparence du film dans l'interface
            changeEtat();
            MainForm.changeEtat(this);
        }

        /// <summary>
        /// Calcule un score de qualite pour une InfoFilm
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private int calculScore(InfosFilm info)
        {
            if (info == null)
                return 0;
            int score = 0;

            if (info._acteurs?.Length > 0)
                score += 1;

            if (info._dateSortie?.Length > 0)
                score += 1;
            if (info._genres?.Length > 0)
                score += 1;
            if (info._nationalite?.Length > 0)
                score += 1;
            if (info._realisateur?.Length > 0)
                score += 1;
            if (info._resume?.Length > 0)
                score += 5;
            if (info._image != null)
                score += 5;
            return score;
        }
        private int calculScore()
        {
            int score = 0;

            if (_acteurs?.Length > 0)
                score += 1;

            if (_dateSortie?.Length > 0)
                score += 1;
            if (_genres?.Length > 0)
                score += 1;
            if (_nationalite?.Length > 0)
                score += 1;
            if (_realisateur?.Length > 0)
                score += 1;
            if (_resume?.Length > 0)
                score += 5;
            return score;
        }

        /// <summary>
        /// Choisi automatiquement la meilleure alternative pour un film:
        /// - un point par information
        /// - 5 points pour un resumé ou une affiche
        /// </summary>
        async private void choisiMeilleureAlternative()
        {
            List<InfosFilm> alternatives = Alternatives();
            int meilleurScore = -1;
            InfosFilm meilleure = null;
            foreach (InfosFilm info in alternatives)
            {
                int score = calculScore(info);
                if (score > meilleurScore)
                {
                    meilleurScore = score;
                    meilleure = info;
                }
            }

            if (meilleure != null)
                if (meilleurScore > calculScore())
                {
                    _realisateur = meilleure._realisateur;
                    _acteurs = meilleure._acteurs;
                    _genres = meilleure._genres;
                    _nationalite = meilleure._nationalite;
                    _resume = meilleure._resume;
                    _dateSortie = meilleure._dateSortie;

                    Image image = null;
                    if (meilleure._image != null)
                    {
                        // Utiliser cette image
                        image = meilleure._image;
                    }
                    else
                    {
                        // Prendre la premiere image existante dans les alternatives
                        List<InfosFilm> a = alternatives.Where(s => s._image != null).Take(1).ToList<InfosFilm>();
                        //foreach (InfosFilm info in alternatives)
                        //    if ( info._image!=null)
                        //    {
                        //        image = info._image;
                        //        break;
                        //    }
                        if (a?.Count > 0)
                            image = a[0]._image;
                    }

                    // Image trouvee?
                    if (image != null)
                        Affiche = image;
                }
        }
        /// <summary>
        /// Chargement des donnees du film depuis une page internet
        /// </summary>
        public async void chargeDonneesInternet()
        {
            List<InfosFilm> liste = new List<InfosFilm>();
            try
            {
                MainForm.WriteMessageToConsole("-----------------------------");
                MainForm.WriteMessageToConsole("Recherche d'informations pour le film " + _titre + " " + _chemin);

                Etat = ETAT.RECHERCHE;
                bool arretPremier = Configuration.arretRecherchePremier;
                _alternatives?.Clear();
                BaseFilms.instance.supprimeAlternatives(_id);

                List<RechercheInternet> recherches = BaseConfiguration.instance.getListeRechercheInternet();

                if (recherches != null)
                {
                    foreach (RechercheInternet r in recherches)
                    {
                        List<InfosFilm> info = await r.rechercheInternet(this);
                        if (info != null)
                        {
                            liste.AddRange(info);
                            if (arretPremier)
                                break;
                        }
                    }
                }
                else
                    MainForm.WriteErrorToConsole("Configurez des recherches internet dans la boite de configuration");
            }
            catch (Exception e)
            {
                MainForm.WriteExceptionToConsole(e);
            }


            switch (liste.Count)
            {
                case 0:
                    Etat = ETAT.PAS_TROUVE;
                    break;

                case 1:
                    _realisateur = liste[0]._realisateur;
                    _acteurs = liste[0]._acteurs;
                    _genres = liste[0]._genres;
                    _nationalite = liste[0]._nationalite;
                    _resume = liste[0]._resume;
                    _dateSortie = liste[0]._dateSortie;
                    //TODO: _image = liste[0]._image;
                    Etat = ETAT.OK;
                    break;

                default:
                    _alternatives = liste;
                    choisiMeilleureAlternative();
                    break;
            }

            BaseFilms.instance.update(this);
            changeEtat();
            MainForm.changeEtat(this);
        }

        /// <summary>
        /// Remplace les separateur par le 'SEPARATEUR d'étiquettes'
        /// </summary>
        /// <param name="etiquettes"></param>
        /// <returns></returns>
        public static string nettoieEtiquettes(string etiquettes)
        {
            etiquettes.Trim();
            return etiquettes.Replace("    ", BaseFilms.SEPARATEUR_LISTES)
                .Replace("   ", BaseFilms.SEPARATEUR_LISTES)
                .Replace("  ", BaseFilms.SEPARATEUR_LISTES)
                .Replace(",", BaseFilms.SEPARATEUR_LISTES)
                .Replace(" ", BaseFilms.SEPARATEUR_LISTES);
        }

        public static bool fichierSupporte(string fichier)
        {
            string ext = new FileInfo(fichier).Extension.ToLower();
            return ".avi".Equals(ext) || ".mkv".Equals(ext) || ".mpg".Equals(ext) || ".mp4".Equals(ext);
        }
    }
}
