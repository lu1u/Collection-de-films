﻿using Collection_de_films.Fenetres;
using Collection_de_films_2.Resources;
using CollectionDeFilms.Actions;
using CollectionDeFilms.Database;
using CollectionDeFilms.Fenetres;
using CollectionDeFilms.Films;
using CollectionDeFilms.Filtre_et_tri;
using CollectionDeFilms.Internet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionDeFilms
{
    public partial class MainForm : Form
    {
        public Filtre _filtre;
        public static MainForm _instance;
        ActionsDifferees _actionsDifferees;
        CopieFichiers _copieFichiers;

        public MainForm()
        {
            _instance = this;
            _filtre = new Filtre();

            InitializeComponent();

            _copieFichiers = new CopieFichiers(toolStripStatusLabelFichiersACopier, tsProgressbarCopieEnCours);
        }

        private void onFormLoad(object sender, EventArgs e)
        {
            // Ajoute les films deja dans la base de donnees
            using (Splashscreen s = new Splashscreen())
            {
                s.Show();
                s.Update();
                _actionsDifferees = new ActionsDifferees(toolStripStatusLabel);
                toolStripComboBoxTri.SelectedIndex = 0;


                #region DATE_AJOUT
                //IEnumerator<Film> iFilms = BaseFilms.instance.getFilmEnumerator("");
                //while (iFilms.MoveNext())
                //{
                //    Film f = iFilms.Current;
                //    f.chargeDonneesDepuisBase();
                //    try
                //    {
                //        f.DateCreation = File.GetCreationTime(f.Chemin);
                //        WriteMessageToConsole(f.Titre + ": date de création " + f.DateCreation.ToShortDateString() + " " + f.DateCreation.ToShortTimeString());
                //    }
                //    catch (Exception ex)
                //    {
                //        WriteErrorToConsole("Erreur date de creation " + f.Chemin);
                //        WriteExceptionToConsole(ex);
                //    }
                //}
                #endregion

                // Etat des separateurs de fenetre
                splitContainer1.SplitterDistance = Configuration.splitter1Distance;
                splitContainer2.SplitterDistance = Configuration.splitter2Distance;
                remplitListFilms();
                //verifiePresenceFichiers();

                if (Configuration.relancerRechercheAuto)
                    reprendTraitementFilms();
                s.Close();
            }
        }

        private void onListviewFilmsDrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (e.Item.Tag is Film)
            {
                Film f = (Film)e.Item.Tag;
                f?.drawItem(e, _filtre);
            }
        }


        private void onListFilmsSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                Film f = e.Item.Tag as Film;
                if (f != null)
                {
                    //_selectedId = f.Id;
                    updatePanneauInfo(f);
                }
            }
        }


        private void onTextBoxFiltreTextChanged(object sender, EventArgs e)
        {
            _filtre.Recherche = textboxFiltre.Text;
            timerChangeFiltre.Enabled = true;
            timerChangeFiltre.Start();
        }

        private void TimerChangeFiltre_Tick(object sender, EventArgs e)
        {
            timerChangeFiltre.Enabled = false;
            timerChangeFiltre.Stop();
            remplitListFilms();
        }



        private void onListviewFilmsMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Film selected = getSelectedFilm();
                if (selected == null)
                    return;

                if (listViewFilms.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuFilm.Show(Cursor.Position);
                }
            }
        }


        private void onDropdownCopierSur(object sender, EventArgs e)
        {
            ToolStripMenuItem dropDown = (ToolStripMenuItem)sender;
            dropDown.DropDownItems.Clear();
            IEnumerable<DriveInfo> devices = DriveInfo.GetDrives().Where(d => (d.DriveType == DriveType.Removable) && (d.IsReady));
            if (devices?.Count() > 0)
            {
                dropDown.Enabled = true;
                foreach (DriveInfo drive in devices)
                {
                    ToolStripLabel item = new ToolStripLabel(drive.VolumeLabel + " [" + drive.RootDirectory + "]");
                    item.Tag = drive;
                    item.Enabled = true;
                    item.Image = DestinationCopie.GetFileIcon(drive.Name).ToBitmap();
                    item.AutoSize = false;
                    item.Alignment = ToolStripItemAlignment.Left;
                    item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    item.ImageAlign = ContentAlignment.MiddleLeft;
                    item.Size = new Size(item.Image.Width * 2 + 100, item.Image.Height);
                    item.Click += onClickItemCopierSur;
                    dropDown.DropDownItems.Add(item);
                }
            }
            else
                dropDown.Enabled = false;
        }

        // Click sur un menu "Copier sur" construit dynamiquement avec la liste des medias amovibles
        private void onClickItemCopierSur(object sender, EventArgs e)
        {
            Film selected = getSelectedFilm();
            if (selected == null)
                return;

            ToolStripLabel l = sender as ToolStripLabel;
            if (l != null)
            {
                DriveInfo drive = l.Tag as DriveInfo;
                if (l != null)
                {
                    WriteMessageToConsole($"Copie de {selected.Titre} sur {drive.Name}");
                    string source = selected.Chemin;
                    string destination = Path.Combine(drive.RootDirectory.FullName, Path.GetFileName(source));
                    // Lancer la copie
                    _copieFichiers.ajoute(selected.Titre, source, destination);
                }
            }
        }

        private void onCliqueEffaceRequete(object sender, EventArgs e)
        {
            textboxFiltre.Text = "";
            _filtre.Recherche = textboxFiltre.Text;
            remplitListFilms();
        }

        private void onFilmContextMenuLireLeFilm(object sender, EventArgs e)
        {
            Film selected = getSelectedFilm();
            if (selected == null)
                return;

            WriteMessageToConsole("Lecture du film " + selected.Chemin);
            try
            {
                Process.Start(selected.Chemin);
            }
            catch (Exception ex)
            {
                WriteExceptionToConsole(ex);
                MessageBox.Show($"Impossible de lire le film {selected.Chemin}", "Erreur de lecture", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void onFilmContextMenuLireMarquerVu(object sender, EventArgs e)
        {
            Film selected = getSelectedFilm();
            if (selected == null)
                return;

            ChoixDate dlg = new ChoixDate();
            dlg.date = selected.DateVu;
            dlg.Vu = selected.Vu;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                if (dlg.Vu)
                    selected.DateVu = dlg.date;
                else
                    selected.Vu = false;

                changeEtat(selected);
                updatePanneauInfo(selected);
            }
        }

        private void onFilmContextMenuLireMarquerAVoir(object sender, EventArgs e)
        {
            Film selected = getSelectedFilm();
            if (selected == null)
                return;

            selected.aVoir = !selected.aVoir;
            changeEtat(selected);
            Toast.Show(this, selected.aVoir ? "Film marqué comme à voir" : "Suppression de l'indicateur A voir");
        }

        private void onFilmContextMenuLireExplorer(object sender, EventArgs e)
        {
            Film selected = getSelectedFilm();
            if (selected == null)
                return;

            WriteMessageToConsole($"Ouverture du film {selected.Chemin} dans l'explorateur Windows");
            FileDriveUtils.OpenFolderAndSelectItem(selected.Chemin);
        }

        private void onFilmContextMenuLireEditer(object sender, EventArgs e)
        {
            Film selected = getSelectedFilm();
            if (selected == null)
                return;
            EditeFilm dlg = new EditeFilm();
            dlg.film = selected;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                changeEtat(selected);
                RemplitListeGenres();
                RemplitListeEtiquettes();
            }
        }

        private void onFilmContextMenuLireSupprimer(object sender, EventArgs e)
        {
            Film selected = getSelectedFilm();
            if (selected == null)
                return;

            string message = string.Format("Supprimer le film  \"{0}\"\n({1})\nde la base?\nLe film n'est pas supprimé du disque", selected.Titre, selected.Chemin);
            if (MessageBox.Show(message, "Supprimer", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                BaseFilms.instance.supprimeFilm(selected.Id);
                listViewFilms.Items.Remove(listViewFilms.SelectedItems[0]);
                listViewFilms.Invalidate();
                toolStripStatusLabelNbAffiches.Text = string.Format("{0} films affichés", listViewFilms.Items.Count);
                toolStripStatusLabelNbFilmsBD.Text = string.Format("{0} films dans la base", BaseFilms.instance.getNbFilms());
            }
        }

        private void onFilmContextMenuLireRecharger(object sender, EventArgs e)
        {
            Film selected = getSelectedFilm();
            if (selected == null)
                return;

            Toast.Show(this, $"Recharger les informations de {selected.Titre}");
            WriteMessageToConsole($"Recharger les informations de {selected.Titre}");
            selected.Etat = Film.ETAT.RECHERCHE;
            _actionsDifferees.ajoute(new ActionNouveauFilm(selected), ActionsDifferees.PRIORITE.HAUTE); ;
            MainForm.changeEtat(selected);
        }

        private void onFilmContextMenuLireCopierSurCle(object sender, EventArgs e)
        {
            Film selected = getSelectedFilm();
            if (selected == null)
                return;
            DestinationCopie dlg = new DestinationCopie();
            dlg.film = selected;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                string source = selected.Chemin;
                string destination = Path.Combine(dlg.destinationDevice.RootDirectory.FullName, Path.GetFileName(source));
                // Lancer la copie
                _copieFichiers.ajoute(selected.Titre, source, destination);
            }
        }

        private void onSplitContainer1Moved(object sender, SplitterEventArgs e)
        {
            Configuration.splitter1Distance = splitContainer1.SplitterDistance;
        }

        private void onSplitContainer2Moved(object sender, SplitterEventArgs e)
        {
            Configuration.splitter2Distance = splitContainer2.SplitterDistance;
            //flowLayoutPanelInfos.Width = splitContainer2.SplitterDistance -20;
            listeProprietesFilm.MinimumSize = new Size(splitContainer2.SplitterDistance - 30, listeProprietesFilm.Size.Height);
            //labelResume.Width = splitContainer2.SplitterDistance - 20;
        }

        private void onToolStripMenuConfiguration(object sender, EventArgs e)
        {
            ConfigurationDlg dlg = new ConfigurationDlg();
            dlg.ShowDialog(this);
            remplitListFilms();
        }

        private void onToolStripMenuCollections(object sender, EventArgs e)
        {
            string baseCourante = BaseFilms.instance.name;
            GestionBase dlg = new GestionBase();

            dlg.ShowDialog(this);
            if (!baseCourante.Equals(BaseFilms.instance.name))
            {
                if (Configuration.relancerRechercheAuto)
                    reprendTraitementFilms();

                remplitListFilms();
                updatePanneauInfo();
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Ajoute un ou plusieurs fichiers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///////////////////////////////////////////////////////////////////////////////////////////
        private void onMenuItemAjouterFichiers(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                BaseFilms bd = BaseFilms.instance;
                foreach (string fichier in openFileDialog.FileNames)
                {
                    Film film = new Film(fichier, "");

                    if (!bd.filmExisteMemeChemin(film))
                    {
                        WriteMessageToConsole("Ajout du film " + fichier);
                        film.Etat = Film.ETAT.NOUVEAU;
                        film.DateCreation = DateTime.Now;
                        bd.ajouteFilm(film);
                        ajouteFilm(film);
                        _actionsDifferees.ajoute(new ActionNouveauFilm(film));
                    }
                    else
                        WriteMessageToConsole(fichier + " déjà référencé");
                }
            }
        }

        async private void onMenuAjouterRepertoire(object sender, EventArgs e)
        {
            AjouteRepertoire dlg = new AjouteRepertoire();
            dlg.repertoire = Configuration.instance.dernierRepertoireAjoute;
            dlg.actionSiDupplique = AjouteRepertoire.toACTION(Configuration.instance.actionSiDupplique);
            if (dlg.ShowDialog(this) == DialogResult.Cancel)
                return;

            string etiquettes = dlg.etiquettes;
            string repertoire = dlg.repertoire;
            bool sousrepertoires = dlg.sousrepertoires;
            bool tagrepertoire = dlg.tagrepertoire;
            AjouteRepertoire.ACTION_SI_DUPPLIQUE action = dlg.actionSiDupplique;

            Configuration.instance.dernierRepertoireAjoute = repertoire;
            Configuration.instance.actionSiDupplique = AjouteRepertoire.toInt(action);
            if (tagrepertoire)
                etiquettes += (etiquettes.Length == 0 ? "" : BaseFilms.SEPARATEUR_LISTES) + new DirectoryInfo(repertoire).Name;
            etiquettes = Film.nettoieEtiquettes(etiquettes);
            await Task.Run(() => scruteRepertoire(repertoire, sousrepertoires, etiquettes, tagrepertoire, action));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Double clic sur la liste des alternatives: choix d'une alternative
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///////////////////////////////////////////////////////////////////////////////////////////
        private void onListviewAlternativesDoubleClick(object sender, EventArgs e)
        {
            Film selected = getSelectedFilm();
            // Retrouver le film selectionne
            if (!(selected is Film))
                return;
            if (listViewAlternatives.SelectedIndices.Count < 1)
                return;

            int alternative = listViewAlternatives.SelectedIndices[0];
            selected.setAlternative(alternative);
            changeEtat(selected);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Supprimer les alternatives d'un film
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///////////////////////////////////////////////////////////////////////////////////////////
        private void ButtonSupprimerAlternatives_Click(object sender, EventArgs e)
        {
            Film selected = getSelectedFilm();
            if (selected == null)
            {
                Toast.Show(this, "Sélectionnez d'abord un film");
                return;
            }

            // Suppression des alternatives dans la base
            if (selected.supprimeAlternatives())
            {
                Toast.Show(this, "Alternatives supprimées");
                changeEtat(selected);
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Fermeture de la fenetre principale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///////////////////////////////////////////////////////////////////////////////////////////
        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Si une copie de fichier est en cours, on demande confirmation avant de fermer le programme
            if (_copieFichiers?.yaDesCopiesEnCours == true)
            {
                System.Media.SystemSounds.Question.Play();

                // Confirm user wants to close
                switch (MessageBox.Show(this, "Une copie de fichier est en cours, voulez-vous vraiment quitter le programme?\nLa copie sera annuléé", "Fermeture du programme", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        _copieFichiers.stop();
                        break;

                    default:
                        // Annuler la fermeture de la fenetre
                        e.Cancel = true;
                        return;
                }
            }

            _actionsDifferees.Stop();

            if (Configuration.menageALaFin)
            {
                using (MenageEnCours dlg = new MenageEnCours())
                {
                    dlg.Show(this);
                    dlg.Update();
                    BaseFilms.instance.menage(dlg);
                }
            }
        }

        private void onClickProgressCopie(object sender, EventArgs e)
        {
            _copieFichiers.onClickStatus();
        }

        /// <summary>
        /// Ouverture du menu contextuel "Recharger depuis": construire un sous menu avec
        /// la liste des sites de recherche disponibles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onContextMenuRechargerDepuisDropDownOpening(object sender, EventArgs e)
        {
            ToolStripMenuItem dropDown = (ToolStripMenuItem)sender;
            List<RechercheInternet> liste = BaseConfiguration.instance.getListeRechercheInternet();

            dropDown.DropDownItems.Clear();
            foreach (RechercheInternet ri in liste)
            {
                ToolStripLabel item = new ToolStripLabel(ri.nom);
                item.Tag = ri;
                item.Click += onClickItemRechargerDepuis;

                dropDown.DropDownItems.Add(item);
            }
        }

        private void onClickItemRechargerDepuis(object sender, EventArgs e)
        {
            Film selected = getSelectedFilm();
            if (selected == null)
                return;

            ToolStripLabel l = sender as ToolStripLabel;
            if (l != null)
            {
                RechercheInternet ri = new RechercheTheMovieDBOrg();// l.Tag as RechercheInternet;
                if (ri != null)
                {
                    WriteMessageToConsole($"Recherche de {selected.Titre} sur {ri.nom}");
                    selected.Etat = Film.ETAT.RECHERCHE;
                    // Ajouter recherche internet forcee sur ce site
                    _actionsDifferees.ajoute(new ActionChargeSite(selected, ri.nom), ActionsDifferees.PRIORITE.HAUTE);
                    changeEtat(selected);
                }
            }
        }




        private void onEtiquettesToolStripMenuItemDropDownOpening(object sender, EventArgs e)
        {
            ToolStripMenuItem dropDown = (ToolStripMenuItem)sender;
            List<string> liste = Etiquettes.getEtiquettes();
            dropDown.DropDownItems.Clear();
            string etiquette = _filtre.Etiquette.ToUpper();

            // Option specifique pour pas de genre selectionne
            {
                ToolStripMenuItem item = new ToolStripMenuItem("[Pas d'etiquette sélectionnée]");
                item.Tag = "";
                item.Enabled = true;
                item.Click += onClickItemSelectEtiquette;
                if ("".ToUpper().Equals(etiquette))
                    item.Checked = true;

                dropDown.DropDownItems.Add(item);
            }

            foreach (string s in liste)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(s);
                item.Tag = s;
                item.Enabled = true;
                item.Click += onClickItemSelectEtiquette;
                if (s.ToUpper().Equals(etiquette))
                    item.Checked = true;

                dropDown.DropDownItems.Add(item);
            }
        }

        private void onClickItemSelectEtiquette(object sender, EventArgs e)
        {
            ToolStripMenuItem l = sender as ToolStripMenuItem;
            if (l != null)
            {
                string etiquette = l.Tag as string;
                _filtre.Etiquette = etiquette;
                remplitListFilms();
            }

        }

        private void onExporterListeFilmsMenuItem(object sender, EventArgs e)
        {
            ExporteFilms dlg = new ExporteFilms();
            dlg.ShowDialog(this);
        }

        private void onLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel Sender = sender as LinkLabel;
            if (Sender != null)
            {
                string url;
                if (e.Link.LinkData != null)
                    url = e.Link.LinkData.ToString();
                else
                    url = Sender.Text.Substring(e.Link.Start, e.Link.Length);

                if (!url.Contains("://"))
                    url = "https://" + url;

                var si = new ProcessStartInfo(url);
                Process.Start(si);
                Sender.LinkVisited = true;
            }
        }

        private void onLinkCheminClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel Sender = sender as LinkLabel;
            if (Sender != null)
            {
                Film selected = getSelectedFilm();
                if (selected == null)
                    return;

                WriteMessageToConsole($"Ouverture du film {selected.Chemin} dans l'explorateur Windows");
                FileDriveUtils.OpenFolderAndSelectItem(selected.Chemin);
            }
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void onClicFilmsVus(object sender, EventArgs e)
        {
            MultistateToolstripMenuItem option = sender as MultistateToolstripMenuItem;
            if (option != null)
            {
                int etat = option.Etat;
                switch (etat)
                {
                    case 0: _filtre.Vu = Filtre.TROIS_ETATS.INDIFFERENT; break;
                    case 1: _filtre.Vu = Filtre.TROIS_ETATS.OUI; break;
                    case 2: _filtre.Vu = Filtre.TROIS_ETATS.NON; break;
                }
                remplitListFilms();
            }
        }

        private void onClicFilmsAVoir(object sender, EventArgs e)
        {
            MultistateToolstripMenuItem option = sender as MultistateToolstripMenuItem;
            if (option != null)
            {
                int etat = option.Etat;
                switch (etat)
                {
                    case 0: _filtre.AVoir = Filtre.TROIS_ETATS.INDIFFERENT; break;
                    case 1: _filtre.AVoir = Filtre.TROIS_ETATS.OUI; break;
                    case 2: _filtre.AVoir = Filtre.TROIS_ETATS.NON; break;
                }
                remplitListFilms();
            }
        }

        private void onTriSelectedChanged(object sender, EventArgs e)
        {
            ToolStripComboBox combo = sender as ToolStripComboBox;
            if (combo != null)
            {
                switch (combo.SelectedIndex)
                {
                    case 0: _filtre.TriPar(Filtre.TRI.TITRE, Filtre.ORDRE.CROISSANT); break;
                    case 1: _filtre.TriPar(Filtre.TRI.TITRE, Filtre.ORDRE.DECROISSANT); break;
                    case 2: _filtre.TriPar(Filtre.TRI.DUREE, Filtre.ORDRE.CROISSANT); break;
                    case 3: _filtre.TriPar(Filtre.TRI.DUREE, Filtre.ORDRE.DECROISSANT); break;
                    case 4: _filtre.TriPar(Filtre.TRI.DATE_VUE, Filtre.ORDRE.CROISSANT); break;
                    case 5: _filtre.TriPar(Filtre.TRI.DATE_VUE, Filtre.ORDRE.DECROISSANT); break;
                    case 6: _filtre.TriPar(Filtre.TRI.DATE_AJOUT, Filtre.ORDRE.CROISSANT); break;
                    case 7: _filtre.TriPar(Filtre.TRI.DATE_AJOUT, Filtre.ORDRE.DECROISSANT); break;
                }

                remplitListFilms();
            }
        }

        private void ButtonRelancerPasTrouve_Click(object sender, EventArgs e)
        {

        }

        private void onToolStripComboBoxGenresSelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxGenres.SelectedIndex >= 0)
            {
                string genre = toolStripComboBoxGenres.SelectedIndex == 0 ? "" : toolStripComboBoxGenres.Items[toolStripComboBoxGenres.SelectedIndex].ToString();
                selectGenre(genre);
            }
        }

        /// <summary>
        /// Prend un genre comme critère de selection
        /// </summary>
        /// <param name="genre"></param>
        private void selectGenre(string genre)
        {
            if (!genre.Equals(_filtre.Genre))
            {
                toolStripComboBoxGenres.SelectedItem = genre;
                _filtre.Genre = genre;
                remplitListFilms();
            }
        }

        private void onToolStripComboBoxEtiquettesSelectedChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxEtiquettes.SelectedIndex >= 0)
            {
                string etiquette = toolStripComboBoxEtiquettes.SelectedIndex == 0 ? "" : toolStripComboBoxEtiquettes.Items[toolStripComboBoxEtiquettes.SelectedIndex].ToString();
                selectEtiquette(etiquette);
            }
        }

        private void selectEtiquette(string etiquette)
        {
            if (!etiquette.Equals(_filtre.Etiquette))
            {
                toolStripComboBoxEtiquettes.SelectedItem = etiquette;
                _filtre.Etiquette = etiquette;
                remplitListFilms();
            }
        }

        /// <summary>
        /// Ouvrir la fenetre des etiquettes pour le film selectionne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void onFilmContextMenuEtiquettes(object sender, EventArgs e)
        {
            Film selected = getSelectedFilm();
            if (selected == null)
                return;

            EtiquettesDlg dlg = new EtiquettesDlg();
            dlg.film = selected;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                updatePanneauInfo(selected);
                RemplitListeEtiquettes();
            }
        }

    }
}
