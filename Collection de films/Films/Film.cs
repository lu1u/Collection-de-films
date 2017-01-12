using Collection_de_films.Database;
using Collection_de_films.Internet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SqlDataReader = System.Data.SQLite.SQLiteDataReader;

namespace Collection_de_films.Films
{
    public class Film
    {
        public enum ETAT { NOUVEAU, RECHERCHE, PAS_TROUVE, TIMEOUT, OK };
        ETAT _etat;
        private int _id;
        string _chemin;
        public string _titre = "";
        public string _etiquettes = "";
        private InfosFilm _infos = new InfosFilm();
        private List<InfosFilm> _alternatives;
        private ListViewItem _lvItem;
        private int _nbAlternatives;

        public Film(string fichier, string etiquettes)
        {
            _chemin = fichier;
            _titre = Path.GetFileNameWithoutExtension(fichier);
            _etiquettes = etiquettes;
        }


        public Film(SqlDataReader reader)
        {
            _id = reader.GetInt32(reader.GetOrdinal("Id"));
            _chemin = reader.GetString(reader.GetOrdinal("chemin"));
            _titre = reader.GetString(reader.GetOrdinal("titre"));
            _infos._realisateur = reader.GetString(reader.GetOrdinal("realisateur"));
            _infos._acteurs = reader.GetString(reader.GetOrdinal("acteurs"));
            _infos._genres = reader.GetString(reader.GetOrdinal("genres"));
            _infos._nationalite = reader.GetString(reader.GetOrdinal("nationalite"));
            _infos._resume = reader.GetString(reader.GetOrdinal("resume"));
            _infos._dateSortie = reader.GetString(reader.GetOrdinal("datesortie"));
            _etiquettes = reader.GetString(reader.GetOrdinal("tag"));
            _etat = intToEtat(reader.GetInt32(reader.GetOrdinal("etat")));

            int afficheIndex = reader.GetOrdinal("affiche");
            // If a column is nullable always check for DBNull...
            if (!reader.IsDBNull(afficheIndex))
                _infos._affiche = getImage(reader, afficheIndex);

            _nbAlternatives = Database.BaseDonnees.getInstance().getNbAlternatives(_id);
        }

        public void FillListviewItem(ListViewItem item)
        {
            item.Text = _titre;
            //int indiceImage = listViewFilms.LargeImageList.Images.Add(f.getImage(), Color.Transparent);
            //listViewFilms.SmallImageList.Images.Add(f.getImage(), Color.Transparent);
            //item.ImageIndex = indiceImage;
            item.SubItems.Add(Genres);
            item.SubItems.Add(Realisateur);
            item.SubItems.Add(Acteurs);
            item.SubItems.Add(DateSortie);
            item.SubItems.Add(_etiquettes);
            item.SubItems.Add(Resume);

            item.ToolTipText = Tooltip();
            item.Tag = this;
            setLVItem(item);
        }
        #region proprietes
        public static ETAT intToEtat(int v)
        {
            switch (v)
            {
                case 0: return ETAT.NOUVEAU;
                case 1: return ETAT.RECHERCHE;
                case 2: return ETAT.PAS_TROUVE;
                //case 3: return ETAT.CHOIX_MULTIPLE;
                case 4: return ETAT.TIMEOUT;
                case 3: return ETAT.OK;
                default:
                    return ETAT.NOUVEAU;
            }
        }

        public static int etatToInt(ETAT e)
        {
            switch (e)
            {
                case ETAT.NOUVEAU: return 0;
                case ETAT.RECHERCHE: return 1;
                case ETAT.PAS_TROUVE: return 2;
                case ETAT.TIMEOUT: return 4;
                case ETAT.OK: return 3;
                default:
                    return 0;
            }
        }

        public static Image getImage(SqlDataReader reader, int afficheIndex)
        {
            try
            {
                Stream picData = reader.GetStream(afficheIndex);

                if (picData != null)
                    return new Bitmap(picData);
            }
            catch (Exception)
            {

            }

            return null;
        }

        public List<InfosFilm> Alternatives
        {
            get
            {
                if (_alternatives == null)
                {
                    _alternatives = Database.BaseDonnees.getInstance().getAlternatives(_id);
                }

                return _alternatives;
            }
        }

        public int NbAlternatives
        {
            get { return _nbAlternatives; }
        }
        public ETAT Etat
        {
            get { return _etat; }
        }

        public int EtatInt
        {
            get { return etatToInt(_etat); }
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
        internal Image affiche
        {
            get { return _infos._affiche; }
            set { _infos._affiche = value; }
        }

        internal string Chemin
        {
            get { return _chemin; }
        }
        internal string Titre
        {
            get { return _titre; }
            set { _titre = value; }
        }

        internal string Realisateur
        {
            get { return _infos._realisateur; }
            set { _infos._realisateur = value; }
        }

        internal string Acteurs
        {
            get { return _infos._acteurs; }
            set { _infos._acteurs = value; }
        }

        internal string Genres
        {
            get { return _infos._genres; }
            set { _infos._genres = value; }
        }


        internal string Nationalite
        {
            get { return _infos._nationalite; }
            set { _infos._nationalite = value; }
        }

        internal string Resume
        {
            get { return _infos._resume; }
            set { _infos._resume = value; }
        }


        internal string DateSortie
        {
            get { return _infos._dateSortie; }
            set { _infos._dateSortie = value; }
        }

        internal void setLVItem(ListViewItem item)
        {
            _lvItem = item;
        }

        internal ListViewItem getLVItem()
        {
            return _lvItem;
        }

        /// <summary>
        /// Calcul le texte du tooltip
        /// </summary>
        /// <returns></returns>
        internal string Tooltip()
        {
            string result = _titre;

            if (_infos._realisateur.Length > 0)
                result += "\nDe : " + _infos._realisateur;

            if (_infos._acteurs.Length > 0)
                result += "\nAvec : " + _infos._acteurs;

            if (_infos._genres.Length > 0)
                result += "\nGenre: " + _infos._genres;
            if (_infos._dateSortie.Length > 0)
                result += "\nDate de sortie: " + _infos._dateSortie;

            if (_infos._resume.Length > 0)
                result += "\n" + _infos._resume;

            if (_alternatives?.Count > 0)
            {
                result += "\nPlusieurs alternatives ont été trouvées pour ce film, vous pouvez utiliser le panneau de droite pour les visualiser et choisir laquelle vous convient le mieux";
            }
            return result;
        }
        #endregion
        internal byte[] getAfficheBytes()
        {
            if (_etat != ETAT.OK)
                return null;

            Image image = getImage();
            return imageToByteArray(image);
        }

        internal Image getImage()
        {
            /* switch (_etat)
             {
                 case ETAT.NOUVEAU:
                     return Resources.Resources.film_nouveau;

                 case ETAT.RECHERCHE:
                     return Resources.Resources.film_recherche;

                 case ETAT.PAS_TROUVE:
                     return Resources.Resources.film_pas_trouve;

                 case ETAT.TIMEOUT:
                     return Resources.Resources.film_timeout;
                 default:*/
            return _infos?._affiche;
            //}
        }

        private void UpdateImage()
        {
            Image img = getImage();
            if (img != null)
                MainForm.changeAffiche(img, _lvItem);
        }

        private void UpdateAll()
        {
            MainForm.update(this);
        }

        /// <summary>
        /// Chargement des donnees du film depuis une page internet
        /// </summary>
        public void ChargeDonnees()
        {
            try
            {
                MainForm.WriteMessageToConsole("-----------------------------");
                MainForm.WriteMessageToConsole("Recherche d'informations pour le film " + _titre + " " + _chemin);

                _etat = ETAT.RECHERCHE;
                UpdateImage();

                /*
                if (!chargeInfos(new RechercheAllocine()))
                    chargeInfos(new RechercheIMDB());
                    */

                bool arretPremier = Configuration.getInstance().getBoolValue(Configuration.CONFIGURATION_ARRET_RECHERCHE_PREMIER);
                _alternatives?.Clear();
                BaseDonnees.getInstance().supprimeAlternatives(this);

                List<RechercheInternet> recherches = BaseDonnees.getInstance().getListeRechercheInternet();
                if (recherches != null)
                {
                    foreach (RechercheInternet r in recherches)
                        if (r.rechercheInternet(this))
                        {
                            if ( arretPremier)
                                break;
                        }

                    BaseDonnees.getInstance().update(this);
                }
                else
                    MainForm.WriteErrorToConsole("Configurez des recherches internet dans la boite de configuration");

            }
            catch (Exception e)
            {

                MainForm.WriteExceptionToConsole(e);
            }

            UpdateAll();
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
                case ETAT.TIMEOUT:
                    return "Le site de recherche a mis trop longtemps à répondre";

                default:
                    return "Etat inconnu";
            }
        }

        public bool setInfos(List<InfosFilm> infos)
        {
            if (infos == null)
            {
                _etat = ETAT.PAS_TROUVE;
                UpdateImage();
                return false;
            }
            else

                switch (infos.Count)
                {
                    case 0:
                        MainForm.WriteMessageToConsole("0 pages d'information trouvée");
                        _etat = ETAT.PAS_TROUVE;
                        break;


                    case 1:
                        _etat = ETAT.OK;
                        MainForm.WriteMessageToConsole("La page du film a été trouvée");
                        _infos = infos[0];
                        break;


                    default:
                        _etat = ETAT.OK;
                        MainForm.WriteMessageToConsole("Film trouvé avec plusieurs alternatives");
                        _alternatives.AddRange( infos) ;
                        break;
                }

            return _etat == ETAT.OK;
        }
/*
        private bool chargeInfos(RechercheFilm recherche)
        {
            List<InfosFilm> infos = recherche.loadInfosFilm(this);
            if (infos == null)
            {
                _etat = ETAT.PAS_TROUVE;
                UpdateImage();
                return false;
            }
            else

                switch (infos.Count)
                {
                    case 0:
                        MainForm.WriteMessageToConsole("0 pages d'information trouvée");
                        _etat = ETAT.PAS_TROUVE;
                        break;


                    case 1:
                        _etat = ETAT.OK;
                        MainForm.WriteMessageToConsole("La page du film a été trouvée");
                        _infos = infos[0];
                        break;


                    default:
                        _etat = ETAT.OK;
                        MainForm.WriteMessageToConsole("Film trouvé avec plusieurs alternatives");
                        _alternatives = infos;
                        break;
                }

            return _etat == ETAT.OK;
        }
        */
        static public byte[] imageToByteArray(Image imageIn)
        {
            if (imageIn != null)
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
            else
                return new byte[0];
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        /// <summary>
        /// Choisir une des alternative des informations du films
        /// </summary>
        /// <param name="indiceAlternative"></param>
        public void setAlternative(int indiceAlternative)
        {
            if (_alternatives == null)
                return;

            if (indiceAlternative < 0 || indiceAlternative >= _alternatives.Count)
                return;

            _infos = _alternatives[indiceAlternative];
            // Finalement, on garde les alternatives
            //_alternatives = null;
            MainForm.WriteMessageToConsole("Choix d'une alternative pour " + _titre);
            MainForm.WriteMessageToConsole("Réalisateur " + Realisateur);
            MainForm.WriteMessageToConsole("Date sortie " + DateSortie);

            _etat = ETAT.OK;
            BaseDonnees.getInstance().update(this);
            MainForm.update(this);
        }
    }
}
