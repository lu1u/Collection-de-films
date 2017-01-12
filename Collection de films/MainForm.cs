using Collection_de_films.Database;
using Collection_de_films.Fenetres;
using Collection_de_films.Films;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace Collection_de_films
{

    public partial class MainForm : Form
    {
        [DllImport("shell32.dll", SetLastError = true)]
        public static extern int SHOpenFolderAndSelectItems(IntPtr pidlFolder, uint cidl, [In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl, uint dwFlags);

        [DllImport("shell32.dll", SetLastError = true)]
        public static extern void SHParseDisplayName([MarshalAs(UnmanagedType.LPWStr)] string name, IntPtr bindingContext, [Out] out IntPtr pidl, uint sfgaoIn, [Out] out uint psfgaoOut);

        
        Filtre _filtre = new Filtre();
        private List<Film> _filmsATraiter = new List<Film>();
        private ListViewColumnSorter lvwColumnSorter;


        private Film _selected;
        private bool _filtreChange = false;
        StringFormat _format = new StringFormat();
        StringFormat _formatDetails = new StringFormat();
        static MainForm _instance;
        private Brush _brosseColonneClaire = /*new LinearGradientBrush(new Rectangle(0, 0, 1000, 1000), Color.White, Color.LightGray, LinearGradientMode.Horizontal);*/
                                                new SolidBrush(Color.White);
        private Brush _brosseColonneFoncee = /* new LinearGradientBrush(new Rectangle(0, 0, 1000, 1000), Color.LightGray, Color.White, LinearGradientMode.Horizontal);*/
                                                new SolidBrush(Color.WhiteSmoke);

        private Brush _brosseOmbre = new SolidBrush(Color.FromArgb(64, 0, 0, 0));

        public MainForm()
        {
            _format.Alignment = StringAlignment.Center;
            _format.LineAlignment = StringAlignment.Far;
            _format.Trimming = StringTrimming.EllipsisCharacter;

            _formatDetails.Alignment = StringAlignment.Near;
            _formatDetails.LineAlignment = StringAlignment.Center;
            _formatDetails.Trimming = StringTrimming.Word;

            _instance = this;
            InitializeComponent();

            // Créer une instance d'une méthode de trie de la colonne ListView et l'attribuer
            // au contrôle ListView.
            lvwColumnSorter = new ListViewColumnSorter();
            listViewFilms.ListViewItemSorter = lvwColumnSorter;
        }

        /// <summary>
        /// Clic sur l'option "Ajouter un repertoire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClickMenuAjouterRepertoire(object sender, EventArgs e)
        {
            AjouteRepertoire dlg = new AjouteRepertoire();
            if (dlg.ShowDialog(this) == DialogResult.Cancel)
                return;

            string etiquettes = dlg.etiquettes;
            string repertoire = dlg.repertoire;
            bool sousrepertoires = dlg.sousrepertoires;
            bool tagrepertoire = dlg.tagrepertoire;
            if (tagrepertoire)
                etiquettes += (etiquettes.Length == 0 ? "" : ";") + new DirectoryInfo(repertoire).Name;
            etiquettes = nettoieEtiquettes(etiquettes);
            ScruteRepertoire(repertoire, sousrepertoires, etiquettes, tagrepertoire);
        }

        static private string nettoieEtiquettes(string etiquettes)
        {
            etiquettes.Trim();
            return etiquettes.Replace("    ", ";").Replace("   ", ";").Replace("  ", ";").Replace(",", ";").Replace(" ", ";");
        }

        private void ScruteRepertoire(string path, bool sousrepertoires, string etiquettes, bool tagrepertoire)
        {
            Database.BaseDonnees bd = Database.BaseDonnees.getInstance();
            WriteMessageToConsole("Ajout du répertoire " + path);
            //CollectionFilms films = CollectionFilms.getInstance();

            // Fichiers contenus
            WriteMessageToConsole("Parcours des fichiers");
            string[] fichiers = Directory.GetFiles(path);
            foreach (string fichier in fichiers)
            {
                if (getCancel())
                    return;

                string ext = new FileInfo(fichier).Extension.ToLower();
                if (".avi".Equals(ext) || ".mkv".Equals(ext) || ".mpg".Equals(ext))
                {
                    Film film = new Film(fichier, etiquettes);

                    if (!bd.FilmExiste(film))
                    {
                        WriteMessageToConsole("Ajout du film " + fichier);
                        bd.ajouteFilm(film);
                        AjouteFilm(film);
                        AjouteFilmATraiter(film);
                    }
                    else
                        WriteMessageToConsole(fichier + " déjà référencé");
                }
            }

            if (sousrepertoires)
            {
                // Sous repertoires
                WriteMessageToConsole("Parcours de sous repertoires");
                string[] directories = Directory.GetDirectories(path);
                foreach (string repertoire in directories)
                {
                    if (getCancel())
                        return;
                    string etiq = etiquettes;
                    if (tagrepertoire)
                        etiq += (etiq.Length == 0 ? "" : ";") + new DirectoryInfo(repertoire).Name;
                    ScruteRepertoire(repertoire, sousrepertoires, etiq, tagrepertoire);
                }
            }
        }


        public bool getCancel()
        {
            return false;
        }

        private void bgWorkerChargePagesDoWork(object sender, DoWorkEventArgs ex)
        {
            while (!bgWorkerChargePages.CancellationPending)
            {
                SetStatus(_filmsATraiter.Count + " films à traiter");

                Film f;
                if (_filmsATraiter.Count > 0)
                {
                    WriteMessageToConsole("Background worker: traitement d'un film");
                    f = _filmsATraiter[0];
                    _filmsATraiter.RemoveAt(0);
                    try
                    {
                        f.ChargeDonnees();
                    }
                    catch (Exception e)
                    {
                        WriteErrorToConsole("Erreur lors du chargement de " + f.Titre);
                        WriteExceptionToConsole(e);
                    }
                }

                System.Threading.Thread.Sleep(100);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void onLoad(object sender, EventArgs e)
        {
            bgWorkerChargePages.RunWorkerAsync();

            Configuration conf = Configuration.getInstance();
            if (Configuration.CONF_PARAM_LARGEICON.Equals(conf.getStringValue(Configuration.CONFIGURATION_VUE)))
                listViewFilms.View = View.LargeIcon;

            listViewAlternatives.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //copieToSQlite();
            /// Ajoute les films deja dans la base de donnees
            using (Splashscreen s = new Splashscreen())
            {
                s.Show();
                s.Update();
                updateListeFilms(x =>
               {
                   s.setPourcent(x);
               });
                s.Close();
            }

            if ( conf.getBoolValue(Configuration.CONFIGURATION_RELANCE_RECHERCHE, false))
                relanceRechercheFilms();
        }

#if RECUP_BASE
        private void copieToSQlite()
        {
            // Copier les tables Sql server dans Sqlite
            using (Splashscreen s = new Splashscreen())
            {
                s.Show();
                s.Update();
                SqliteDatabase sqliteDB = SqliteDatabase.getInstance();
                BaseDonnees bd = BaseDonnees.getInstance();
                List<Film> films = bd.getListFilms(new Collection_de_films.Filtre());
                int a = 0;
                foreach (Film f in films)
                {
                    a++;
                    s.setPourcent((int)(a * 100.0f / films.Count));
                    try
                    {
                        SQLiteCommand command = new SQLiteCommand("INSERT into FILMS " +
                                                "(chemin, titre, realisateur, acteurs, genres, nationalite, resume, datesortie, affiche, etat, tag)"
                                                    + " VALUES (@chemin, @titre, @realisateur, @acteurs, @genres, @nationalite, @resume, @datesortie, @affiche, @etat, @tag)");

                        command.Parameters.AddWithValue("@chemin", f.Chemin);
                        command.Parameters.AddWithValue("@titre", f.Titre);
                        command.Parameters.AddWithValue("@realisateur", f.Realisateur);
                        command.Parameters.AddWithValue("@acteurs", f.Acteurs);
                        command.Parameters.AddWithValue("@genres", f.Genres);
                        command.Parameters.AddWithValue("@nationalite", f.Nationalite);
                        command.Parameters.AddWithValue("@datesortie", f.DateSortie);
                        command.Parameters.AddWithValue("@resume", f.Resume);
                        command.Parameters.AddWithValue("@affiche", BaseDonnees.SqlBinnaryPeutEtreNull(f.getAfficheBytes()));
                        command.Parameters.AddWithValue("@etat", f.EtatInt);
                        command.Parameters.AddWithValue("@tag", f._etiquettes);
                        sqliteDB.executeNonQuery(command);

                        command.CommandText = "select last_insert_rowid() as id from FILMS;";
                        object o = sqliteDB.executeScalar(command);
                        WriteMessageToConsole(o.GetType().ToString());
                        int id = Convert.ToInt32(o);

                        // lire les alternatives de ce films
                        List<InfosFilm> alternatives = f.Alternatives;
                        foreach (InfosFilm info in alternatives)
                        {
                            SQLiteCommand commande = new SQLiteCommand("INSERT into ALTERNATIVES " +
                                "(filmid, realisateur, acteurs, genres, nationalite, resume, datesortie, affiche)"
                            + " VALUES (@id, @realisateur, @acteurs, @genres, @nationalite, @resume, @datesortie, @affiche)");
                            commande.Parameters.AddWithValue("@id", id);
                            commande.Parameters.AddWithValue("@realisateur", info._realisateur);
                            commande.Parameters.AddWithValue("@acteurs", info._acteurs);
                            commande.Parameters.AddWithValue("@genres", info._genres);
                            commande.Parameters.AddWithValue("@nationalite", info._nationalite);
                            commande.Parameters.AddWithValue("@datesortie", info._dateSortie);
                            commande.Parameters.AddWithValue("@resume", info._resume);
                            commande.Parameters.AddWithValue("@affiche", Film.imageToByteArray(info._affiche));

                            sqliteDB.executeNonQuery(commande);
                        }
                    }
                    catch (Exception ex)
                    {
                        MainForm.WriteExceptionToConsole(ex);
                    }

                }
                s.Close();
            }
        }
#endif

        /// <summary>
        /// Relance la recherche sur Internet pour tous les films nouveaux ou pas encore trouves
        /// </summary>
        private void relanceRechercheFilms()
        {
            Database.BaseDonnees bd = Database.BaseDonnees.getInstance();
            foreach (Film f in bd.getListFilms(Film.ETAT.NOUVEAU))
                AjouteFilmATraiter(f);

            foreach (Film f in bd.getListFilms(Film.ETAT.PAS_TROUVE))
                AjouteFilmATraiter(f);
        }


        /// <summary>
        /// Mise a jour de la liste des films
        /// </summary>
        public void updateListeFilms(Action<int> action = null)
        {
            Cursor = Cursors.WaitCursor;
            _filtreChange = false;
            /*listViewFilms.Items.Clear();
            //listViewFilms.SmallImageList.Images.Clear();
            //listViewFilms.LargeImageList.Images.Clear();
            */

            toolStripStatusLabelNbFilmsBD.Text = Database.BaseDonnees.getInstance().getNbFilms() + " films dans la bibliothèque";

            /*if (listViewFilms.VirtualMode)
            {
                listViewFilms.VirtualListSize = SqliteDatabase.getInstance().getNbFilms(_filtre);
            }
            else*/
            {
                listViewFilms.BeginUpdate();
                listViewFilms.Items.Clear();
                action?.Invoke(10);
                List<Film> films = // BaseDonnees.getInstance().getListFilms(_filtre);
                Database.BaseDonnees.getInstance().getListFilms(_filtre);
                action?.Invoke(40);
                toolStripStatusLabelNbAffiches.Text = films.Count + " films affichés";
                WriteMessageToConsole(_filtre.Recherche + ":" + films.Count + " films affichés");

                foreach (Film f in films)
                {
                    //Application.DoEvents();
                    if (_filtreChange)
                    {
                        listViewFilms.Items.Clear();
                        break;
                    }
                    //WriteMessageToConsole(f.Titre());
                    action?.Invoke((int)(50 + (int)(listViewFilms.Items.Count * 100.0f / films.Count) / 2.0f));
                    AjouteFilm(f);
                }
                listViewFilms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewFilms.SelectedIndices.Clear();
                if (listViewFilms.Items.Count > 0)
                    listViewFilms.Items[0].Selected = true;
                listViewFilms.EndUpdate();
            }

            Cursor = Cursors.Default;
            //listViewFilms.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void détailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewFilms.View = View.Details;
            Configuration.getInstance()[Configuration.CONFIGURATION_VUE] = Configuration.CONF_PARAM_DETAILS;
        }

        private void imagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewFilms.View = View.LargeIcon;
            Configuration.getInstance()[Configuration.CONFIGURATION_VUE] = Configuration.CONF_PARAM_LARGEICON;

        }



        private void onListFilmsSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                _selected = (Film)e.Item.Tag;
                updatePanneauInfo(getSelectedFilm());
            }
        }

        private Film getSelectedFilm()
        {
            return _selected;
        }

        /// <summary>
        /// Mise a jour du panneau d'informations en fonction du film selectionné
        /// </summary>
        /// <param name="film">film</param>
        private void updatePanneauInfo(Film film)
        {
            if (film == null)
            {
                // Pas de film selectionné
                flowLayoutPanelInfosFilm.Hide();
                return;
            }

            flowLayoutPanelInfosFilm.Show();
            flowLayoutPanelInfosFilm.SuspendLayout();
            labelEtat.Text = film.getTextEtat();
            labelTitre.Text = film.Titre;
            labelChemin.Text = film.Chemin;
            afficheInfo(labelKeyRealisateur, labelRealisateur, film.Realisateur);
            afficheInfo(labelKeyActeurs, labelActeurs, film.Acteurs);
            afficheInfo(labelKeyGenres, labelGenres, film.Genres);
            afficheInfo(labelKeyDateSortie, labelDateSortie, film.DateSortie);
            afficheInfo(labelKeyNationalite, labelNationalite, film.Nationalite);
            afficheInfo(labelKeyEtiquettes, labelEtiquettes, film._etiquettes);
            labelResume.Text = film.Resume;

            switch (film.Etat)
            {
                case Film.ETAT.OK:
                case Film.ETAT.NOUVEAU:
                case Film.ETAT.RECHERCHE:
                    flowLayoutPanelPasTrouve.Hide();
                    break;

                default:
                    flowLayoutPanelPasTrouve.Show();
                    textBoxTitrePasTrouve.Text = _selected.Titre;
                    break;
            }

            Image affiche = _selected.getImage();
            pictureBoxAffiche.Image = affiche;
            flowLayoutPanelInfosFilm.ResumeLayout();


            listViewAlternatives.Items.Clear();
            List<InfosFilm> alternatives = film.Alternatives;
            if (alternatives?.Count > 0)
            {
                if (tabControlAlternatives.TabPages.IndexOf(tabpageAlternatives) == -1)
                    tabControlAlternatives.TabPages.Add(tabpageAlternatives);
                foreach (InfosFilm a in alternatives)
                {
                    ListViewItem item = a.getListViewItem(listViewAlternatives);
                    listViewAlternatives.Items.Add(item);
                }
                listViewAlternatives.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            else
                tabControlAlternatives.TabPages.Remove(tabpageAlternatives);            
        }

        private void afficheInfo(Label key, Label value, string texte)
        {
            if (texte?.Length > 0)
            {
                if (key != null)
                {
                    //key.Show();
                    value.Text = texte;
                    //value.Show();
                }
            }
            else
            {
                //key?.Hide();
                //value?.Hide();
                value.Text = "";
            }
        }


        private void onClickValiderAlternative(object sender, EventArgs e)
        {
            // Retrouver le film selectionne
            if (!(_selected is Film))
                return;
            if (listViewAlternatives.SelectedIndices.Count < 1)
                return;

            var alternative = listViewAlternatives.SelectedIndices[0];

            _selected.setAlternative(alternative);
        }

        private void onListviewFilmsMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                if (_selected != null)
                {
                    if (listViewFilms.FocusedItem.Bounds.Contains(e.Location) == true)
                    {
                        contextMenuStripFilm.Show(Cursor.Position);
                    }
                }
        }

        private void lireLeFilmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selected == null)
                return;

            WriteMessageToConsole("Lecture du film " + _selected.Chemin);
            System.Diagnostics.Process.Start(_selected.Chemin);
        }


        public static void OpenFolderAndSelectItem(string file)
        {
            string folderPath = new FileInfo(file).DirectoryName;
            IntPtr nativeFolder;
            uint psfgaoOut;
            SHParseDisplayName(folderPath, IntPtr.Zero, out nativeFolder, 0, out psfgaoOut);

            if (nativeFolder == IntPtr.Zero)
            {
                // Log error, can't find folder
                return;
            }

            IntPtr nativeFile;
            SHParseDisplayName(Path.Combine(folderPath, file), IntPtr.Zero, out nativeFile, 0, out psfgaoOut);

            IntPtr[] fileArray;
            if (nativeFile == IntPtr.Zero)
            {
                // Open the folder without the file selected if we can't find the file
                fileArray = new IntPtr[0];
            }
            else
            {
                fileArray = new IntPtr[] { nativeFile };
            }

            SHOpenFolderAndSelectItems(nativeFolder, (uint)fileArray.Length, fileArray, 0);

            Marshal.FreeCoTaskMem(nativeFolder);
            if (nativeFile != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(nativeFile);
            }
        }

        private void afficherDansLExplorateurWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selected == null)
                return;

            WriteMessageToConsole("Ouverture du film " + _selected.Chemin + " dans l'explorateur Windows");
            OpenFolderAndSelectItem(_selected.Chemin);

        }

        private void onTextBoxFiltreTextChanged(object sender, EventArgs e)
        {
            ChangeRequete(toolStripTextBoxFiltre.Text);
        }


        private void ChangeRequete(string texte)
        {
            WriteMessageToConsole(texte);

            _filtre.Recherche = texte;
            _filtreChange = true;
            timerChangeFiltre.Enabled = true;
            timerChangeFiltre.Start();
        }

        /*
        private void onRetrieveListviewItemFilms(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (myCache != null && e.ItemIndex >= firstItem && e.ItemIndex < firstItem + myCache.Length)
            {
                System.Diagnostics.Debug.WriteLine("Cache");

                //A cache hit, so get the ListViewItem from the cache instead of making a new one.
                e.Item = myCache[e.ItemIndex - firstItem];
                return;
            }

            Film f = SqliteDatabase.getInstance().getFilm(e.ItemIndex);
            if (f == null)

            {
                WriteErrorToConsole("Impossible de retrouver le film no " + e.ItemIndex + " dans la base de données");
                e.Item = new ListViewItem("Non trouvé dans la base de données");
                e.Item.SubItems.Add(e.ItemIndex + "");
                e.Item.SubItems.Add(e.ItemIndex + "");
                e.Item.SubItems.Add(e.ItemIndex + "");
                e.Item.SubItems.Add(e.ItemIndex + "");
                e.Item.SubItems.Add(e.ItemIndex + "");
                e.Item.SubItems.Add(e.ItemIndex + "");
            }
            else
            {
                WriteMessageToConsole("itemIndex " + e.ItemIndex + ":" + f.Titre);

                ListViewItem item = new ListViewItem(f.Titre);
                item.Text = f.Titre;
                //int indiceImage = listViewFilms.LargeImageList.Images.Add(f.getImage(), Color.Transparent);
                //listViewFilms.SmallImageList.Images.Add(f.getImage(), Color.Transparent);
                //item.ImageIndex = indiceImage;
                item.SubItems.Add(f.Genres);
                item.SubItems.Add(f.Realisateur);
                item.SubItems.Add(f.Acteurs);
                item.SubItems.Add(f.DateSortie);
                item.SubItems.Add(f._etiquettes);
                item.SubItems.Add(f.Resume);

                item.ToolTipText = f.Tooltip();

                item.Tag = f;

                if (listViewFilms.Items.Count % 2 == 0)
                    item.BackColor = Color.White;
                f.setLVItem(item);
                e.Item = item;
            }
        }

        private ListViewItem[] myCache; //array to cache items for the virtual list
        private int firstItem; //stores the index of the first item in the cache
        */
        private void onClickRechargerInfos(object sender, EventArgs e)
        {
            if (_selected == null)
                return;

            _selected._titre = textBoxTitrePasTrouve.Text;
            WriteMessageToConsole("Recharger les informations de " + _selected.Titre);
            ajouteFilmATraiter(_selected);
        }

        private void onClickMenuRechargerInfos(object sender, EventArgs e)
        {
            if (_selected == null)
                return;

            WriteMessageToConsole("Recharger les informations de " + _selected.Titre);
            ajouteFilmATraiter(_selected);
        }

        private void onClicSupprimerDeLaBase(object sender, EventArgs e)
        {
            if (_selected == null)
                return;

            string message = string.Format("Supprimer le film  \"{0}\"\n({1})\nde la base?\nLe film n'est pas supprimé du disque", _selected.Titre, _selected.Chemin);
            if (MessageBox.Show(message, "Supprimer", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Database.BaseDonnees.getInstance().supprimeFilm(_selected);
                _selected = null;
                updateListeFilms();
            }
        }

        private void onDoubleClickListviewAlternatives(object sender, MouseEventArgs e)
        {
            // Retrouver le film selectionne
            if (!(_selected is Film))
                return;
            if (listViewAlternatives.SelectedIndices.Count < 1)
                return;

            var alternative = listViewAlternatives.SelectedIndices[0];

            _selected.setAlternative(alternative);
        }

        private void onTimerChangeFiltre(object sender, EventArgs e)
        {
            timerChangeFiltre.Enabled = false;
            timerChangeFiltre.Stop();

            Database.BaseDonnees.getInstance().creerVueFilms(_filtre);
            updateListeFilms();
        }

        private void onListviewFilmsDrawItem(object sender, DrawListViewItemEventArgs e)
        {
            switch (e.Item.ListView.View)
            {
                case View.Details:
                case View.List:
                case View.SmallIcon:

                    break;

                case View.Tile:
                case View.LargeIcon:
                    {
                        if ((e.State & ListViewItemStates.Selected) != 0)
                        {
                            // Draw the background and focus rectangle for a selected item.
                            using (Brush b = new SolidBrush(Color.FromArgb(250, 194, 87)))
                                e.Graphics.FillRectangle(b, e.Bounds);
                            e.DrawFocusRectangle();
                        }

                        SizeF s = e.Graphics.MeasureString(e.Item.Text, e.Item.ListView.Font, e.Bounds.Width);
                        Rectangle rImage = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height - (int)s.Height);
                        rImage.Inflate(-4, -4);

                        Image image = getImage((Film)e.Item.Tag, rImage);
                        if (image != null)
                        {
                            int dx = (rImage.Width - image.Width) / 2;
                            int dy = (rImage.Height - image.Height) / 2;
                            rImage.Offset(dx, dy);

                            Rectangle rShadow = new Rectangle(rImage.Left, rImage.Top, image.Width, image.Height);
                            rShadow.Offset(2, 2);
                            e.Graphics.FillRectangle(_brosseOmbre, rShadow);
                            e.Graphics.DrawImage(image, rImage.Left, rImage.Top);
                        }

                        using (Brush b = new SolidBrush(e.Item.ListView.ForeColor))
                            e.Graphics.DrawString(e.Item.Text, e.Item.ListView.Font, b, e.Bounds, _format);
                    }
                    break;
            }
        }


        private Image getImage(Film film, Rectangle bounds)
        {
            if (film == null)
                return null;

            Image image = film.getImage();
            if (image == null)
                if (film.NbAlternatives > 0)
                    image = imageListeAlternatives(film, bounds);
            if ( image == null)
                    image = Resources.Resources.film;

            Image etiquette;
            switch (film.Etat)
            {
                case Film.ETAT.NOUVEAU:
                    etiquette = Resources.Resources.film_recherche;
                    break;

                default:
                    etiquette = null;
                    break;
            }


            if (etiquette != null)
            {
                using (Graphics g = Graphics.FromImage(image))
                {
                    g.DrawImageUnscaled(etiquette, image.Width - etiquette.Width, image.Height - etiquette.Height);
                }
            }
            return Images.zoomImage(image, bounds);
        }

        private Image getImageSmall(Film film, Rectangle bounds)
        {
            if (film == null)
                return null;

            Image image = film.getImage();
            if (image == null)
                if (film.NbAlternatives > 0)
                    image = Resources.Resources.film_multiple;
            if (image == null)
                image = Resources.Resources.film;

            Image etiquette;
            switch (film.Etat)
            {
                case Film.ETAT.NOUVEAU:
                    etiquette = Resources.Resources.film_recherche;
                    break;

                default:
                    etiquette = null;
                    break;
            }


            if (etiquette != null)
            {
                using (Graphics g = Graphics.FromImage(image))
                {
                    g.DrawImageUnscaled(etiquette, image.Width - etiquette.Width, image.Height - etiquette.Height);
                }
            }
            return Images.zoomImage(image, bounds);
        }

        /// <summary>
        /// Dessine une image representant les alternatives d'un film
        /// </summary>
        /// <param name="film"></param>
        /// <param name="bounds"></param>
        /// <returns></returns>
        public static Image imageListeAlternatives(Film film, Rectangle bounds)
        {
            Image newImage = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                List<InfosFilm> alternatives = film.Alternatives;
                while (alternatives.Count > 8)
                {
                    int indice = alternatives.IndexOf(null);
                    if (indice == -1)
                        indice = alternatives.Count - 1;
                    alternatives.RemoveAt(indice);
                }

                int nbImages = alternatives.Count(s => s._affiche != null);
                if (nbImages == 0)
                    return null;

                int NB_COLONNES = (int)(Math.Ceiling(Math.Sqrt(nbImages)));
                int NB_LIGNES = (int)((nbImages + NB_COLONNES - 1) / NB_COLONNES);

                int LARGEUR_COLONNE = bounds.Width / NB_COLONNES;
                int HAUTEUR_COLONNE = bounds.Height / NB_LIGNES;

                for (int i = 0; i < alternatives.Count;i++)
                {
                    int x = (i / NB_COLONNES) * LARGEUR_COLONNE ;
                    int y = (i % NB_COLONNES) * HAUTEUR_COLONNE ;
                    Rectangle r = new Rectangle(x, y, LARGEUR_COLONNE, HAUTEUR_COLONNE);
                    r.Inflate(-4, -4);
                    Image img = Images.zoomImage(alternatives[i]._affiche, r);
                    if (img != null)
                        g.DrawImageUnscaled(img, r.Left + (r.Width-img.Width)/2, r.Top + (r.Height-img.Height)/2);
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


        private void onListviewFilmsDrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            ListViewSubItem subItem = e.Item.SubItems[e.ColumnIndex];
            switch (listViewFilms.Columns[e.ColumnIndex].TextAlign)
            {
                case HorizontalAlignment.Center:
                    _formatDetails.Alignment = StringAlignment.Center;
                    break;
                case HorizontalAlignment.Left:
                    _formatDetails.Alignment = StringAlignment.Near;
                    break;

                case HorizontalAlignment.Right:
                    _formatDetails.Alignment = StringAlignment.Far;
                    break;
            }

            if (e.Item.Selected)
            {
                // Draw the background and focus rectangle for a selected item.
                using (Brush b = new SolidBrush(Color.FromArgb(250, 194, 87)))
                    e.Graphics.FillRectangle(b, e.Bounds);
                e.DrawFocusRectangle(e.Bounds);
            }
            else
                e.Graphics.FillRectangle(e.ColumnIndex % 2 == 0 ? _brosseColonneClaire : _brosseColonneFoncee, e.Bounds);

            if (e.ColumnIndex == 0)
            {
                Rectangle rImage = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height);
                rImage.Inflate(-1, -1);

                Image image = getImageSmall((Film)e.Item.Tag, rImage);
                Rectangle rTexte;
                if (image != null)
                {
                    int dy = (rImage.Height - image.Height) / 2;
                    rImage.Offset(0, dy);

                    Rectangle rShadow = new Rectangle(rImage.Left, rImage.Top, image.Width, image.Height);
                    e.Graphics.DrawImage(image, rImage.Left, rImage.Top);

                    rTexte = new Rectangle(rImage.Left + image.Width, e.Bounds.Top, e.Bounds.Width - image.Width, e.Bounds.Height);
                }
                else
                    rTexte = new Rectangle(e.Bounds.Location, e.Bounds.Size);

                rTexte.Inflate(-2, -2);
                e.Graphics.DrawString(subItem.Text, subItem.Font, new SolidBrush(subItem.ForeColor), rTexte, _formatDetails);
            }
            else
            {
                e.Graphics.DrawString(subItem.Text, subItem.Font, new SolidBrush(subItem.ForeColor), e.Bounds, _formatDetails);
            }

        }

        private void onListviewFilmsDrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        break;
                }

                // Draw the standard header background.
                e.DrawBackground();
                e.DrawText();
            }
        }

        private void filmAvecInformationsManquantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filmAvecInformationsManquantesToolStripMenuItem.Checked = true;
            filmsAvecAlternativesToolStripMenuItem.Checked = false;
            filmTousToolStripMenuItem.Checked = false;
            _filtre.nonTrouves();
            _filtreChange = true;

            timerChangeFiltre.Enabled = true;
            timerChangeFiltre.Start();
        }

        private void filmsAvecAlternativesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filmAvecInformationsManquantesToolStripMenuItem.Checked = false;
            filmsAvecAlternativesToolStripMenuItem.Checked = true;
            filmTousToolStripMenuItem.Checked = false;
            _filtre.alternatives();
            _filtreChange = true;

            timerChangeFiltre.Enabled = true;
            timerChangeFiltre.Start();
        }


        private void filmsAvecAlternativesAucuneChoisieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filmAvecInformationsManquantesToolStripMenuItem.Checked = false;
            filmsAvecAlternativesToolStripMenuItem.Checked = true;
            filmTousToolStripMenuItem.Checked = false;
            _filtre.alternativesAucuneChoisie();
            _filtreChange = true;

            timerChangeFiltre.Enabled = true;
            timerChangeFiltre.Start();
        }
        private void filmsTousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filmAvecInformationsManquantesToolStripMenuItem.Checked = false;
            filmsAvecAlternativesToolStripMenuItem.Checked = false;
            filmTousToolStripMenuItem.Checked = true;
            _filtre.tous();
            _filtreChange = true;

            timerChangeFiltre.Enabled = true;
            timerChangeFiltre.Start();
        }

        private void editerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selected == null)
                return;

            EditeFilm dlg = new EditeFilm();
            dlg.film = _selected;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                _selected = dlg.film;
                updateListeFilms();
                updatePanneauInfo(_selected);
            }
        }
        /*
        private void onListviewFilmsCacheItems(object sender, CacheVirtualItemsEventArgs e)
        {
            //We've gotten a request to refresh the cache.
            //First check if it's really neccesary.
            if (myCache != null && e.StartIndex >= firstItem && e.EndIndex <= firstItem + myCache.Length)
            {
                //If the newly requested cache is a subset of the old cache, 
                //no need to rebuild everything, so do nothing.
                return;
            }

            //Now we need to rebuild the cache.
            firstItem = e.StartIndex;
            int length = e.EndIndex - e.StartIndex + 1; //indexes are inclusive
            myCache = new ListViewItem[length];

            //Fill the cache with the appropriate ListViewItems.
            int x = 0;
            BaseDonnees bd = BaseDonnees.getInstance();
            for (int i = 0; i < length; i++)
            {
                x = (i + firstItem) * (i + firstItem);
                ListViewItem item = new ListViewItem();
                Film film = bd.getFilm(i + firstItem);
                film.FillListviewItem(item);
                myCache[i] = item;

            }
        }
        */

        private void onClickCopierSurClefUSB(object sender, EventArgs e)
        {
            if (_selected == null)
                return;
            DestinationCopie dlg = new DestinationCopie();
            dlg.film = _selected;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                string source = _selected.Chemin;
                string destination = Path.Combine(dlg.destinationDevice.RootDirectory.FullName, Path.GetFileName(source));
                // Lancer la copie
                AjouteCopieFichier(source, destination);
            }
        }

        private void onClosing(object sender, FormClosingEventArgs e)
        {
            if (bgWorkerChargePages.IsBusy)
                bgWorkerChargePages.CancelAsync();

            if (bgWorkerCopie.IsBusy)
                bgWorkerCopie.CancelAsync();

            if ( Configuration.getInstance().getBoolValue(Configuration.CONFIGURATION_MENAGE_FIN, false))
            {
                using (MenageEnCours dlg = new MenageEnCours())
                {
                    dlg.Show(this);
                    dlg.Update();
                    BaseDonnees.getInstance().Menage(dlg);
                }
            }
        }

        private void onCliqueEffaceRequete(object sender, EventArgs e)
        {
            toolStripTextBoxFiltre.Text = ""; // Declenche l'evenement ontextboxfiltretextchanged
        }

        private void onClickColonneListFilms(object sender, ColumnClickEventArgs e)
        {
            // Déterminer si la colonne sélectionnée est déjà la colonne triée.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Inverser le sens de tri en cours pour cette colonne.
                if (lvwColumnSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                // Définir le numéro de colonne à trier ; par défaut sur croissant.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            }

            // Procéder au tri avec les nouvelles options.
            listViewFilms.Sort();
        }

        private void onClickConfiguration(object sender, EventArgs e)
        {
            ConfigurationDlg dlg = new ConfigurationDlg();
            if (dlg.ShowDialog(this) == DialogResult.OK)
                updateListeFilms();

        }

    }
}
