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
        // Masque de bits pour FLAG
        public const int FLAG_A_VOIR = 1;
        public const int FLAG_VU = 2;

        public enum ETAT
        {
            NOUVEAU, // Le film vient d'etre ajouté, pas encore de recherche d'informations
            RECHERCHE, // recherche en cours
            PAS_TROUVE, // pas trouve sur internet
            ALTERNATIVES, // plusieurs alternatives trouvees
            OK,          // informations trouvees
            DANS_LA_QUEUE // film mis dans la queue de traitement
        };


        private int _id;
        private string _titre = "";
        private string _chemin;
        private string _etiquettes = "";
        private int _flags;
        private string _realisateur = "";
        private string _acteurs = "";
        private string _genres = "";
        private string _nationalite = "";
        private string _resume = "";
        private string _dateSortie = "";
        private Image _image;
        private Image _imageGrandeIcone;
        private ETAT _etat;


        private List<InfosFilm> _alternatives;


        //private ListViewItem _lvItem;

        public Film(string fichier, string etiquettes = "")
        {
            _chemin = fichier;
            _titre = Path.GetFileNameWithoutExtension(fichier);
            _etiquettes = etiquettes;
        }

        public Film(SqlDataReader reader)
        {
            _id = reader.GetInt32(reader.GetOrdinal(BaseFilms.FILMS_ID));
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
                _image = BaseFilms.readImage(reader, reader.GetOrdinal(BaseFilms.FILMS_IMAGE));
            }
            catch
            {
                MainForm.WriteMessageToConsole($"Film {_id}, {_titre} pas d'image");
            }
            if (_image == null || _resume == null || "".Equals(_resume))
                choisiMeilleureAlternative();
        }






        #region Public Methods

        /// <summary>
        /// Chargement des donnees du film depuis une page internet
        /// </summary>
        public async void chargeDonnees()
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
                    _image = liste[0]._image;
                    Etat = ETAT.OK;
                    break;

                default:
                    _alternatives = liste;
                    choisiMeilleureAlternative();
                    Etat = ETAT.ALTERNATIVES;
                    break;
            }

            BaseFilms.instance.update(this);
            updateListView();
        }

        internal static bool fichierSupporte(string fichier)
        {
            string ext = new FileInfo(fichier).Extension.ToLower();
            return ".avi".Equals(ext) || ".mkv".Equals(ext) || ".mpg".Equals(ext) || ".mp4".Equals(ext);
        }

        /// <summary>
        /// Chargement des donnees du film depuis une page internet
        /// </summary>
        async public void chargeDonneesSite(string nomSite)
        {
            List<InfosFilm> liste = new List<InfosFilm>();

            try
            {
                MainForm.WriteMessageToConsole("-----------------------------");
                MainForm.WriteMessageToConsole("Recherche d'informations pour le film " + _titre + " " + _chemin);
                MainForm.WriteMessageToConsole("Depuis le site: " + nomSite);

                Etat = ETAT.RECHERCHE;
                RechercheInternet recherche = BaseConfiguration.instance.getRechercheInternet(nomSite);
                if (recherche == null)
                {
                    MainForm.WriteErrorToConsole("Impossible de trouver les informations de recherche sur le site " + nomSite);
                }
                else
                {
                    _alternatives?.Clear();
                    BaseFilms.instance.supprimeAlternatives(_id);
                    liste = await recherche.rechercheInternet(this);
                }

                switch (liste.Count)
                {
                    case 0:
                        Etat = ETAT.PAS_TROUVE;
                        break;

                    case 1:
                        Etat = ETAT.OK;
                        _realisateur = liste[0]._realisateur;
                        _acteurs = liste[0]._acteurs;
                        _genres = liste[0]._genres;
                        _nationalite = liste[0]._nationalite;
                        _resume = liste[0]._resume;
                        _dateSortie = liste[0]._dateSortie;
                        _image = liste[0]._image;
                        break;

                    default:
                        Etat = ETAT.ALTERNATIVES;
                        _alternatives = liste;
                        choisiMeilleureAlternative();
                        break;
                }
                BaseFilms.instance.update(this);
            }
            catch (Exception e)
            {
                MainForm.WriteExceptionToConsole(e);
            }
            updateListView();
        }

        public ListViewItem getListviewItem(ListView lv)
        {

            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = Titre;
            lvItem.SubItems.Add(Resume).BackColor = Color.WhiteSmoke;
            lvItem.SubItems.Add(toTexte(Vu)).BackColor = Color.White;
            lvItem.SubItems.Add(toTexte(aVoir)).BackColor = Color.WhiteSmoke;
            lvItem.SubItems.Add(separe(Genres)).BackColor = Color.White;
            lvItem.SubItems.Add(separe(Realisateur)).BackColor = Color.WhiteSmoke;
            lvItem.SubItems.Add(separe(Acteurs)).BackColor = Color.White;
            lvItem.SubItems.Add(DateSortie).BackColor = Color.WhiteSmoke;
            lvItem.SubItems.Add(_etiquettes).BackColor = Color.White;
            lvItem.ToolTipText = Tooltip();
            lvItem.Tag = this;// _id;

            return lvItem;
        }

        /// <summary>
        /// Choisir une des alternative des informations du films
        /// </summary>
        /// <param name="indiceAlternative"></param>
        public async void setAlternative(int indiceAlternative)
        {
            BaseFilms baseFilms = BaseFilms.instance;
            List<InfosFilm> alternatives = await Alternatives();
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
            _image = alternatives[indiceAlternative]._image;
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
            MainForm.update(this);
        }

        public bool setInfos(List<InfosFilm> infos)
        {
            if (infos?.Count > 0)
            {
                MainForm.WriteMessageToConsole("Informations trouvées");
                if (_alternatives == null)
                    _alternatives = infos;
                else
                    _alternatives.AddRange(infos);
                changeEtat();
                return true;
            }

            MainForm.WriteMessageToConsole("Pas d'information trouvée");
            return false;
        }

        public void updateListviewItem(ListView lv)
        {
            lv.Invalidate();
            lv.Update();
            /*
            ListViewItem lvItem = getListviewItem(lv);
            int index = -1;
            for (int i = 0; i < lv.Items.Count; i++)
                if (lv.Items[i].Tag == lvItem.Tag)
                {
                    index = i;
                    break;
                }

            if (index != -1)
            {
                lv.Items[index] = lvItem;
                lv.EnsureVisible(index);
                lv.Invalidate(lv.GetItemRect(index));
            }
            */
        }

        #endregion Public Methods

        #region Internal Methods


        internal byte[] getImageBytes()
        {
            Image image = Image;
            if (image == null)
                return null;
            return Images.imageToByteArray(image);
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

                case ETAT.ALTERNATIVES:
                    return "Plusieurs alternatives ont été trouvées pour ce film";

                default:
                    return "Etat inconnu";
            }
        }

        internal void supprimeAlternatives()
        {
            BaseFilms baseFilms = BaseFilms.instance;
            MainForm.WriteMessageToConsole("Suppression des autres alternatives");
            baseFilms.supprimeAlternatives(_id);
            _alternatives = null;
            changeEtat();
        }

        private void changeEtat()
        {
            _imageGrandeIcone = null;
            updateListView();
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        /// Separe des elements codes dans une meme chaine et retourne une forme plus lisible
        /// </summary>
        /// <param name="texte"></param>
        /// <returns></returns>
        private static string separe(string texte)
        {
            string[] mots = texte.Split(BaseFilms.SEPARATEUR_LISTES_CHAR);
            if (mots == null || mots.Length == 0)
                return "";

            string result = mots[0];
            for (int i = 1; i < mots.Length; i++)
                result += ", " + mots[i];

            return result;
        }

        private static string toTexte(bool ouiNon)
        {
            return ouiNon ? "Oui" : "Non";
        }

        #endregion Private Methods

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

        internal Image Image
        {
            get
            {
                if (_image == null)
                {
                    _image = BaseFilms.instance.getImageFilm(_id);
                }
                return _image;
            }
            set
            {
                _image = value;
                changeEtat();
            }
        }

        public int EtatInt
        {
            get { return etatToInt(_etat); }
        }



        public int NbAlternatives
        {
            get { if (_alternatives != null) return _alternatives.Count; else return 0; }
        }

        public bool Vu
        {
            get { return (_flags & FLAG_VU) != 0; }
            set
            {
                if (value)
                    _flags |= FLAG_VU;
                else
                    _flags &= ~FLAG_VU;

                changeEtat();
            }
        }

        internal string Acteurs { get => _acteurs; set { _acteurs = value; changeEtat(); } }
        internal string Chemin { get => _chemin; set { _chemin = value; changeEtat(); } }
        internal string DateSortie { get => _dateSortie; set { _dateSortie = value; changeEtat(); }}
        internal string Genres { get => _genres; set { _genres = value; changeEtat(); }}
        internal string Nationalite { get => _nationalite; set { _nationalite = value; changeEtat(); }}
        internal string Realisateur { get => _realisateur; set { _realisateur = value; changeEtat(); }}
        internal string Resume { get => _resume; set { _resume = value; changeEtat(); }}
        internal string Titre { get => _titre; set { _titre = value; changeEtat(); }}
        internal string Etiquettes { get => _etiquettes; set { _etiquettes = value; changeEtat(); }}
        public int Flags { get => _flags; set { _flags = value; changeEtat(); }}
        public int Id { get => _id; set => _id = value; }

        public static int etatToInt(ETAT e)
        {
            switch (e)
            {
                case ETAT.NOUVEAU: return 0;
                case ETAT.RECHERCHE: return 1;
                case ETAT.PAS_TROUVE: return 2;
                case ETAT.OK: return 3;
                case ETAT.ALTERNATIVES: return 4;
                case ETAT.DANS_LA_QUEUE: return 5;
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
                case 4: return ETAT.ALTERNATIVES;
                case 5: return ETAT.DANS_LA_QUEUE;
                default:
                    throw new ArgumentException($"ETAT de film incorrect {v}");
            }
        }

        async public Task<List<InfosFilm>> Alternatives()
        {
            if (_alternatives == null)
            {
                _alternatives = await BaseFilms.instance.getAlternatives(_id);
            }

            return _alternatives;
        }
        /// <summary>
        /// Retourne une image pour representer le film dans la liste "Grande icones", son affiche si possible
        /// </summary>
        /// <param name="film"></param>
        /// <param name="bounds"></param>
        /// <returns></returns>
        async public Task<Image> getImageGrandeIcone(Rectangle bounds)
        {
            if (_imageGrandeIcone != null)
                return _imageGrandeIcone;

            _imageGrandeIcone = Image;
            if (_imageGrandeIcone != null)
            {
                _imageGrandeIcone = Images.ombre(Images.zoomImage(_imageGrandeIcone, bounds), 2);
            }
            else
            if (NbAlternatives > 0)
                _imageGrandeIcone = await getimageAlternatives(bounds);
            else
            {
                // Creer une image de film vide
                _imageGrandeIcone = Resources.film_nouveau;
            }

            if (_imageGrandeIcone != null)
                using (Graphics g = Graphics.FromImage(_imageGrandeIcone))
                {
                    Image etiquette;
                    // Ajouter une etiquette en fonction de l'etat du film
                    switch (Etat)
                    {
                        case ETAT.NOUVEAU: etiquette = Resources.film_nouveau; break;
                        case ETAT.DANS_LA_QUEUE: etiquette = Resources.film_dans_la_queue; break;
                        case ETAT.PAS_TROUVE: etiquette = Resources.film_non_trouve; break;
                        case ETAT.RECHERCHE: etiquette = Resources.film_recherche_en_cours; break;
                        case ETAT.ALTERNATIVES: etiquette = Resources.film_alternatives; break;

                        default:
                            etiquette = null;
                            break;
                    }
                    const int ratioEtiquette = 6;
                    int largeurEtiquette = _imageGrandeIcone.Width / ratioEtiquette;
                    int hauteurEtiquette = _imageGrandeIcone.Height / ratioEtiquette;

                    if (etiquette != null)
                        g.DrawImage(etiquette, _imageGrandeIcone.Width - largeurEtiquette - 2, _imageGrandeIcone.Height - hauteurEtiquette - 2, largeurEtiquette, hauteurEtiquette);

                    if (Vu)
                        g.DrawImage(Resources.deja_vu, 2, 2, largeurEtiquette, hauteurEtiquette);

                    if (aVoir)
                        g.DrawImage(Resources.a_voir, _imageGrandeIcone.Width - largeurEtiquette - 2, 2, largeurEtiquette, hauteurEtiquette);
                }

            return _imageGrandeIcone; // Images.zoomImage( image, bounds );
        }

        /// <summary>
        /// Dessine une image representant les alternatives d'un film
        /// </summary>
        /// <param name="film"></param>
        /// <param name="bounds"></param>
        /// <returns></returns>
        async public Task<Image> getimageAlternatives(Rectangle bounds)
        {
            Image newImage = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                List<InfosFilm> alternatives = await Alternatives();
                alternatives = alternatives.Where(s => s.affiche != null).ToList<InfosFilm>();

                // 9 images au max
                while (alternatives.Count > 9)
                {
                    int indice = alternatives.IndexOf(null);
                    if (indice == -1)
                        indice = alternatives.Count - 1;
                    alternatives.RemoveAt(indice);
                }

                int nbImages = alternatives.Count;
                if (nbImages == 0)
                    return null;

                int NB_COLONNES = (int)(Math.Ceiling(Math.Sqrt(nbImages)));
                int NB_LIGNES = ((nbImages + NB_COLONNES - 1) / NB_COLONNES);

                int LARGEUR_COLONNE = bounds.Width / NB_COLONNES;
                int HAUTEUR_COLONNE = bounds.Height / NB_LIGNES;

                for (int i = 0; i < alternatives.Count; i++)
                {
                    int y = ((i + NB_COLONNES - 1) / NB_COLONNES) * LARGEUR_COLONNE;
                    int x = (i % NB_COLONNES) * HAUTEUR_COLONNE;
                    Rectangle r = new Rectangle(x, y, LARGEUR_COLONNE, HAUTEUR_COLONNE);
                    r.Inflate(-4, -4);
                    Image img = Images.zoomImage(alternatives[i].affiche, r);
                    if (img != null)
                        g.DrawImageUnscaled(img, r.Left + (r.Width - img.Width) / 2, r.Top + (r.Height - img.Height) / 2);
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

        async public Task<Image> getImageSmall(Rectangle bounds)
        {
            Image image = Image;
            if (image != null)
                image = Images.zoomImage(image, bounds);
            else
            if (NbAlternatives > 0)
                image = await getimageAlternatives(bounds);
            else
                switch (Etat)
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

            return Images.zoomImage(image, bounds);
        }

        /// <summary>
        /// Calcul le texte du tooltip
        /// </summary>
        /// <returns></returns>
        internal string Tooltip()
        {
            string result = _titre;

            if (_realisateur.Length > 0)
                result += "\nDe : " + _realisateur;

            if (_acteurs.Length > 0)
                result += "\nAvec : " + _acteurs;

            if (_genres.Length > 0)
                result += "\nGenre: " + _genres;
            if (_dateSortie.Length > 0)
                result += "\nDate de sortie: " + _dateSortie;

            if (_resume.Length > 0)
                result += "\n" + _resume;

            if (_alternatives?.Count > 0)
            {
                result += "\nPlusieurs alternatives ont été trouvées pour ce film, vous pouvez utiliser le panneau de droite pour les visualiser et choisir laquelle vous convient le mieux";
            }
            return result;
        }

        #endregion proprietes
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
            if (_image != null)
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
            List<InfosFilm> alternatives = await Alternatives();
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
                    _image = meilleure._image;
                }
        }

        private void updateListView()
        {
            MainForm.update(this);
        }
    }
}
