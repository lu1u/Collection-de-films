using Collection_de_films.Fenetres;
using CollectionDeFilms.Actions;
using CollectionDeFilms.Database;
using CollectionDeFilms.Films;
using CollectionDeFilms.Filtre_et_tri;
using CollectionDeFilms.Internet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionDeFilms
{
    partial class MainForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Mise a jour du panneau d'informations en fonction du film selectionné
        /// </summary>
        /// <param name="film">film</param>
        ///////////////////////////////////////////////////////////////////////////////////////////
        private void updatePanneauInfo(Film film = null)
        {
            if (film == null)
            {
                // Pas de film selectionné, cacher le panneau d'informations
                flowLayoutPanelInfosFilm.Hide();
                return;
            }

            WriteMessageToConsole($"Film: {film.Titre}, Id={film.Id}");
            TimeSpan s = film.Duree;

            flowLayoutPanelInfosFilm.Show();
            flowLayoutPanelInfosFilm.SuspendLayout();
            listeProprietesFilm.StartAjouteProprietes();
            listeProprietesFilm.Clear();
            labelEtat.Text = film.getTextEtat();
            labelTitre.Text = film.Titre;
            listeProprietesFilm.AjoutePropriete(new ControlesUtilisateur.ProprieteImage(film.Affiche));
            afficheInfoLinks("Titre:", film.Titre, (a) => { Cursor = Cursors.AppStarting; InternetUtils.rechercheSurInternet("film+" + a); Cursor = Cursors.Default; });
            afficheInfoLinks("Etiquettes:", film.Etiquettes, (a) => selectEtiquette(a) );
            afficheInfoLinks("Genres:", film.Genres, (a)=> selectGenre(a));
            afficheInfo("Durée:", s.Equals(TimeSpan.Zero) ? "" : $"{s:hh\\:mm\\:ss}");
            afficheInfo("Vue le:", film.DateVu.Ticks == 0 ? null : film.DateVu.ToLongDateString());
            afficheInfoLinks("Réalisateur:", film.Realisateur, (a) => { Cursor = Cursors.AppStarting; InternetUtils.rechercheSurInternet(a); Cursor = Cursors.Default; });
            afficheInfoLinks("Acteurs:", film.Acteurs, (a) => { Cursor = Cursors.AppStarting; InternetUtils.rechercheSurInternet(a); Cursor = Cursors.Default; });
            afficheInfo("Date sortie:", film.DateSortie);
            afficheInfo("Nationalité", film.Nationalite);
            afficheInfo("Ajouté le:", film.DateCreation.ToLongDateString());
            afficheInfoLinks("Chemin:", film.Chemin, (a) => { Cursor = Cursors.AppStarting; FileDriveUtils.OpenFolderAndSelectItem(a); Cursor = Cursors.Default; });

            if (film.Resume?.Length > 0)
                listeProprietesFilm.AjoutePropriete(new ControlesUtilisateur.ProprieteSimple(film.Resume));
            listeProprietesFilm.StopAjouteProprietes();

            switch (film.Etat)
            {
                case Film.ETAT.OK:
                case Film.ETAT.NOUVEAU:
                case Film.ETAT.RECHERCHE:
                    flowLayoutPanelPasTrouve.Hide();
                    break;

                default:
                    flowLayoutPanelPasTrouve.Show();
                    textBoxTitrePasTrouve.Text = film.Titre;
                    break;
            }

            listViewAlternatives.Items.Clear();
            List<InfosFilm> alternatives = film.Alternatives();
            if (alternatives?.Count > 0)
            {
                WriteMessageToConsole($"Alternatives: {alternatives.Count}");
                foreach (InfosFilm i in alternatives)
                {
                    WriteMessageToConsole($"Alternative: imageId={i._image}, resumé={i._resume}");
                }

                if (tabControlAlternatives.TabPages.IndexOf(tabpageAlternatives) == -1)
                    tabControlAlternatives.TabPages.Add(tabpageAlternatives);
                foreach (InfosFilm a in alternatives)
                {
                    ListViewItem item = a.getListViewItem(listViewAlternatives);
                    listViewAlternatives.Items.Add(item);
                }

                listViewAlternatives.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                buttonSupprimerAlternatives.Show();
            }
            else
            {
                tabControlAlternatives.TabPages.Remove(tabpageAlternatives);
                buttonSupprimerAlternatives.Hide();
            }

            flowLayoutPanelInfosFilm.ResumeLayout();
        }

        /// <summary>
        /// Mettre a jour un film dans la liste
        /// </summary>
        /// <param name="f"></param>
        private void updateFilm(Film f)
        {
            if (f != null)
            {
                Film selected = getSelectedFilm();
                //if (listViewFilms.SelectedItems.Count > 0)
                if (f == selected)
                {
                    listViewFilms.Invalidate(_instance.listViewFilms.SelectedItems[0].Bounds);
                    listViewFilms.SelectedItems[0].ToolTipText = f.getTooltip();
                }
            }
        }

        /// <summary>
        /// Affiche un champ contenant plusieurs liens, separes par SEPARATEUR_LISTE,
        /// un lien pour chaque morceau d'information
        /// </summary>
        /// <param name="key"></param>
        /// <param name="liens"></param>
        /// <param name="onClick"></param>
        private void afficheInfoLinks(string nom, string liens, ControlesUtilisateur.ProprieteLink.onClickLink onClick)
        {
            if (liens?.Length > 0)
            {
                string[] valeurs = liens.Split(BaseFilms.SEPARATEUR_LISTES_CHAR);
                if (valeurs?.Length > 0)
                {
                    ControlesUtilisateur.ProprieteLink.Link[] links = new ControlesUtilisateur.ProprieteLink.Link[valeurs.Length];
                    for (int i = 0; i < valeurs.Length; i++)
                        links[i] = new ControlesUtilisateur.ProprieteLink.Link(valeurs[i], valeurs[i], onClick);
                    ControlesUtilisateur.ProprieteLink propriete = new ControlesUtilisateur.ProprieteLink(nom, links);
                    listeProprietesFilm.AjoutePropriete(propriete);
                }
            }
        }


        /// <summary>
        /// Montrer une valeur dans le panneau d'information, cacher le control si cette valeur est vide
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="texte"></param>
        private void afficheInfo(string nom, string texte)
        {
            if (texte?.Length > 0)
                listeProprietesFilm.AjoutePropriete(new ControlesUtilisateur.ProprieteTexte(nom, texte));
        }

        /// <summary>
        /// Remplir la listview des films en fonction du filtre courant
        /// </summary>
        private void remplitListFilms()
        {
            Cursor c = Cursor;
            Cursor = Cursors.WaitCursor;
            listViewFilms.BeginUpdate();
            listViewFilms.Items.Clear();
            IEnumerator<Film> iFilms = BaseFilms.instance.getFilmEnumerator(_filtre);
            _filtre.change = false;

            while (iFilms.MoveNext())
            {
                if (_filtre.change)
                    // Le filtre a change depuis qu'on a commencé à remplir la liste
                    break;

                Film f = iFilms.Current;
                listViewFilms.Items.Add(f.createListviewItem());
            }

            // Selectionner un film
            if (listViewFilms.Items.Count > 0)
            {
                listViewFilms.FocusedItem = listViewFilms.Items[0];
                listViewFilms.Items[0].Selected = true;
                listViewFilms.Select();
                listViewFilms.EnsureVisible(0);
            }

            listViewFilms.EndUpdate();
            listViewFilms.Invalidate();

            RemplitListeGenres();
            RemplitListeEtiquettes();

            toolStripStatusLabelNbAffiches.Text = string.Format("{0} films affichés", listViewFilms.Items.Count);
            toolStripStatusLabelNbFilmsBD.Text = string.Format("{0} films dans la base", BaseFilms.instance.getNbFilms());

            Cursor = c;
        }

        private void RemplitListeEtiquettes()
        {
            List<string> liste = Etiquettes.getEtiquettes();
            toolStripComboBoxEtiquettes.Items.Clear();
            string etiquette = _filtre.Etiquette.ToUpper();
            int selected = 0;

            // Option specifique pour pas d'etiquette selectionnee
            toolStripComboBoxEtiquettes.Items.Add("[Pas d'etiquette sélectionnée]");

            foreach (string s in liste)
            {
                if (s.ToUpper().Equals(etiquette))
                    selected = toolStripComboBoxEtiquettes.Items.Count;
                toolStripComboBoxEtiquettes.Items.Add(s);
            }
            toolStripComboBoxEtiquettes.SelectedIndex = selected;

        }

        private void RemplitListeGenres()
        {
            // Une option de menu par genre
            List<string> liste = Genres.getGenres();
            toolStripComboBoxGenres.Items.Clear();
            int selected = 0;
            string genre = _filtre.Genre.ToUpper();
            toolStripComboBoxGenres.Items.Add("[Pas de genre sélectionné]");
            foreach (string s in liste)
            {
                if (s.ToUpper().Equals(genre))
                    selected = toolStripComboBoxGenres.Items.Count;
                toolStripComboBoxGenres.Items.Add(s);
            }
            toolStripComboBoxGenres.SelectedIndex = selected;
        }



        /// <summary>
        /// Lors de l'ouverture d'une base, reprend les traitements en tache de fond
        /// </summary>
        public void reprendTraitementFilms()
        {
            _actionsDifferees.Clear();
            IEnumerator<Film> iFilms = BaseFilms.instance.getFilmEnumerator($" {BaseFilms.FILMS_ETAT}={Film.etatToInt(Film.ETAT.PAS_TROUVE)} OR {BaseFilms.FILMS_ETAT}={Film.etatToInt(Film.ETAT.NOUVEAU)} OR {BaseFilms.FILMS_ETAT}={Film.etatToInt(Film.ETAT.DANS_LA_QUEUE)}");
            while (iFilms.MoveNext())
            {
                Film f = iFilms.Current;
                _actionsDifferees.ajoute(new ActionNouveauFilm(f), ActionsDifferees.PRIORITE.BASSE);
            }
        }

        /// <summary>
        /// Retourne le film selectionne dans la liste, ou null
        /// </summary>
        /// <returns></returns>
        private Film getSelectedFilm()
        {
            if (listViewFilms.SelectedIndices.Count < 1)
                return null;

            return listViewFilms.Items[listViewFilms.SelectedIndices[0]].Tag as Film;
        }

        /// <summary>
        /// Scrute un repertoire a la recherche de films, scrute aussi les sous repertoire si sousrepertoire = true
        /// </summary>
        /// <param name="path"></param>
        /// <param name="sousrepertoires"></param>
        /// <param name="etiquettes"></param>
        /// <param name="tagrepertoire"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private async Task<bool> scruteRepertoire(string path, bool sousrepertoires, string etiquettes, bool tagrepertoire, AjouteRepertoire.ACTION_SI_DUPPLIQUE action)
        {
            BaseFilms bd = BaseFilms.instance;
            WriteMessageToConsole($"Parcours du répertoire {path}");
            try
            {
                string[] fichiers = Directory.GetFiles(path);
                foreach (string fichier in fichiers)
                {
                    WriteMessageToConsole($"Fichier {fichier}");
                    if (getCancel())
                        return false;

                    if (Film.fichierSupporte(fichier))
                    {
                        if (bd.filmExisteFichier(fichier))
                        {
                            // Le film existe deja, action a entreprendre en fonction du choix de l'utilisateur
                            switch (action)
                            {
                                case AjouteRepertoire.ACTION_SI_DUPPLIQUE.IGNORER_NOUVEAU:
                                    WriteMessageToConsole($"{fichier} déjà référencé, ignoré");
                                    break;

                                case AjouteRepertoire.ACTION_SI_DUPPLIQUE.AJOUTER_NOUVEAU:
                                    {
                                        WriteMessageToConsole($"{fichier} déjà référencé, ajouter le nouveau");
                                        Film film = new Film(fichier, etiquettes);
                                        film.DateCreation = DateTime.Now;
                                        bd.ajouteFilm(film);
                                        ajouteFilm(film);
                                        _actionsDifferees.ajoute(new ActionNouveauFilm(film));
                                    }
                                    break;

                                case AjouteRepertoire.ACTION_SI_DUPPLIQUE.REMPLACER_ANCIEN:
                                    {
                                        Film f = await bd.getFilmFichier(Path.GetFileNameWithoutExtension(fichier));
                                        if (f != null)
                                        {
                                            WriteMessageToConsole($"{fichier} déjà référencé, remplacer l'ancien {f.Chemin}.");
                                            try
                                            {
                                                if (!(fichier.Equals(f.Chemin)))
                                                {
                                                    f.Chemin = fichier;
                                                    bd.update(f, null);
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                WriteExceptionToConsole(e);
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            // Nouveau fichier non encore reference dans la base
                            Film film = new Film(fichier, etiquettes);
                            WriteMessageToConsole($"Ajout du film {fichier}");
                            film.DateCreation = DateTime.Now;
                            bd.ajouteFilm(film);
                            ajouteFilm(film);
                            _actionsDifferees.ajoute(new ActionNouveauFilm(film));
                        }

                    }
                    else
                        WriteMessageToConsole("Pas un fichier film supporté");
                }

                if (getCancel())
                    return false;

                if (sousrepertoires)
                {
                    // Sous repertoires
                    WriteMessageToConsole($"Parcours des sous repertoires de {path}");
                    string[] directories = Directory.GetDirectories(path);
                    foreach (string repertoire in directories)
                    {
                        if (getCancel())
                            return false;
                        string etiq = etiquettes;
                        if (tagrepertoire)
                            etiq += (etiq.Length == 0 ? "" : BaseFilms.SEPARATEUR_LISTES) + new DirectoryInfo(repertoire).Name;
                        await scruteRepertoire(repertoire, sousrepertoires, etiq, tagrepertoire, action);
                    }
                }
            }
            catch (Exception e)
            {
                WriteErrorToConsole("Erreur lors de la scrutation du répertoire " + path);
                WriteExceptionToConsole(e);
            }
            return true;
        }

        public bool getCancel()
        {
            return false;
        }

        private void verifiePresenceFichiers()
        {
            IEnumerator<Film> iFilms = BaseFilms.instance.getFilmEnumerator(new Filtre());

            while (iFilms.MoveNext())
            {
                Film f = iFilms.Current;
                _actionsDifferees.ajoute(new ActionVerifFichier(f), ActionsDifferees.PRIORITE.BASSE);
            }
        }
    }
}
