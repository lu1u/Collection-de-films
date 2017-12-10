using Collection_de_films.Actions;
using Collection_de_films.Database;
using Collection_de_films.Fenetres;
using Collection_de_films.Films;
using Collection_de_films.Internet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Collection_de_films.Program;
using static System.Windows.Forms.ListViewItem;

namespace Collection_de_films
{
    public partial class MainForm : Form
    {
        [DllImport("shell32.dll", SetLastError = true)]
        public static extern int SHOpenFolderAndSelectItems(IntPtr pidlFolder, uint cidl, [In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl, uint dwFlags);

        [DllImport("shell32.dll", SetLastError = true)]
        public static extern void SHParseDisplayName([MarshalAs(UnmanagedType.LPWStr)] string name, IntPtr bindingContext, [Out] out IntPtr pidl, uint sfgaoIn, [Out] out uint psfgaoOut);

        private Filtre _filtre = new Filtre();
        private ListViewColumnSorter listViewColonneSorter;
        ActionsDifferees _actionsDifferees;
        CopieFichiers _copieFichiers;
        private int _selectedId;
        private bool _filtreChange = false;
        private StringFormat _formatLargeIcones = new StringFormat();
        private StringFormat _formatDetails = new StringFormat();
        public static MainForm _instance;

        private Brush _brosseOmbre = new SolidBrush(Color.FromArgb(64, 0, 0, 0));

        public MainForm()
        {
            _formatLargeIcones.Alignment = StringAlignment.Center;
            _formatLargeIcones.LineAlignment = StringAlignment.Far;
            _formatLargeIcones.Trimming = StringTrimming.EllipsisWord;

            _formatDetails.Alignment = StringAlignment.Near;
            _formatDetails.LineAlignment = StringAlignment.Near;
            _formatDetails.Trimming = StringTrimming.EllipsisWord;

            _instance = this;
            InitializeComponent();

            // Créer une instance d'une méthode de trie de la colonne ListView et l'attribuer
            // au contrôle ListView.
            listViewColonneSorter = new ListViewColumnSorter();
            listViewFilms.ListViewItemSorter = listViewColonneSorter;
            _actionsDifferees = new ActionsDifferees(toolStripStatusLabel);
            _copieFichiers = new CopieFichiers(toolStripStatusLabelFichiersACopier, tsProgressbarCopieEnCours);
        }

        /// <summary>
        /// Clic sur l'option "Ajouter un repertoire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void onMenuAjouterRepertoire(object sender, EventArgs e)
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
            etiquettes = nettoieEtiquettes(etiquettes);
            await Task.Run(() => scruteRepertoire(repertoire, sousrepertoires, etiquettes, tagrepertoire, action));
        }

        static private string nettoieEtiquettes(string etiquettes)
        {
            etiquettes.Trim();
            return etiquettes.Replace("    ", BaseFilms.SEPARATEUR_LISTES)
                .Replace("   ", BaseFilms.SEPARATEUR_LISTES)
                .Replace("  ", BaseFilms.SEPARATEUR_LISTES)
                .Replace(",", BaseFilms.SEPARATEUR_LISTES)
                .Replace(" ", BaseFilms.SEPARATEUR_LISTES);
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

            string[] fichiers = Directory.GetFiles(path);
            foreach (string fichier in fichiers)
            {
                WriteMessageToConsole($"Fichier {fichier}");
                if (getCancel())
                    return false;

                if (Film.fichierSupporte(fichier))
                {
                    if (bd.FilmExisteFichier(fichier))
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
                                    bd.ajouteFilm(film);
                                    AjouteFilm(film);
                                    _actionsDifferees.ajoute(new ActionNouveauFilm(film));
                                }
                                break;

                            case AjouteRepertoire.ACTION_SI_DUPPLIQUE.REMPLACER_ANCIEN:
                                {
                                    Film f = await bd.getFilmFichier(Path.GetFileNameWithoutExtension(fichier));
                                    if (f != null)
                                    {
                                        WriteMessageToConsole($"{fichier} déjà référencé, remplacer l'ancien {f.Chemin}.");
                                        if (!f.Chemin.Equals(fichier))
                                        {
                                            f.Chemin = fichier;
                                            bd.update(f);
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
                        bd.ajouteFilm(film);
                        AjouteFilm(film);
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

            return true;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
            }
            base.WndProc(ref m);
        }
        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }

        public bool getCancel()
        {
            return false;
        }

        /// <summary>
        /// Traitement en arriere plan des films de la liste _filmsATraiter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        /*private void bgWorkerChargePagesDoWork( object sender, DoWorkEventArgs ex )
        {
            while ( !bgWorkerChargePages.CancellationPending )
            {
                ActionDifferee action;
                action = _actionsDifferees.Pop();
                if ( action == null )
                    System.Threading.Thread.Sleep( 1000 );
                else
                    try
                    {
                        WriteMessageToConsole( "Background worker: traitement d'un film" );
                        action.execute();
                    }
                    catch ( Exception e )
                    {
                        WriteErrorToConsole( "Erreur lors du traitement de " + action.nom() );
                        WriteExceptionToConsole( e );
                    }                
            }
        }

        private void backgroundWorker_ProgressChanged( object sender, ProgressChangedEventArgs e )
        {
        }*/

        /// <summary>
        /// Chargement de la fenetre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onLoad(object sender, EventArgs e)
        {
            /// Ajoute les films deja dans la base de donnees
            using (Splashscreen s = new Splashscreen())
            {
                s.Show();
                s.Update();

                //if ( Configuration.relancerRechercheAuto )
                //   relanceRechercheFilms();

                Configuration conf = Configuration.instance;
                switchVueFilms(Configuration.CONF_PARAM_LARGEICON.Equals(conf.vue));

                updateListeFilms((x, y) =>
               {
                   s.setPourcent(x, y);
               });
                s.Close();
                //bgWorkerChargePages.RunWorkerAsync();
            }
        }

        private void ChangeTableFilms()
        {
            /// Ajoute les films deja dans la base de donnees
            using (Splashscreen s = new Splashscreen())
            {
                s.Show();
                s.Update();

                BaseFilms bd = BaseFilms.instance;
                // Changement de tables

                // Creer la table des images
                bd.creerTableImages();
                //bd.executeScalar("ALTER TABLE FILMS ADD COLUMN IMAGE_ID INTEGER REFERENCES IMAGES(IMAGE)");

                int nb = bd.getNbFilms();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT *, ROWID FROM FILMS"))
                using (SQLiteDataReader reader = bd.executeReader(cmd))
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        int no = 0;
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            s.setPourcent((int)(no++ * 100.0f / nb), "");
                            using (Image img = Film.getImage(reader, reader.GetOrdinal("affiche")))
                                if (img != null)
                                {
                                    using (SQLiteCommand c = new SQLiteCommand("INSERT INTO IMAGES (IMAGE) VALUES (@image)"))
                                    {
                                        c.Parameters.AddWithValue("@image", BaseFilms.SqlBinnaryPeutEtreNull(Images.imageToByteArray(img)));
                                        bd.executeNonQuery(c);
                                    }

                                    // Recuper l'id de l'image
                                    using (SQLiteCommand c = new SQLiteCommand("select last_insert_rowid() as id from FILMS;"))
                                    {
                                        object o = bd.executeScalar(c);
                                        int imageId = Convert.ToInt32(o);

                                        // Stocker l'id de l'image dans le film
                                        using (SQLiteCommand cd = new SQLiteCommand("update FILMS set IMAGE_ID = @imageId where ID = @filmId"))
                                        {
                                            cd.Parameters.AddWithValue("@imageId", imageId);
                                            cd.Parameters.AddWithValue("@filmId", reader.GetInt32(reader.GetOrdinal("Id")));
                                            bd.executeScalar(c);
                                        }
                                    }
                                }
                        }
                    }
                }
                s.Close();
            }
        }

        /// <summary>
        /// Change le style de vue de la liste des films
        /// </summary>
        /// <param name="v"></param>
        private void switchVueFilms(bool vueLarge)
        {
            if (vueLarge)
            {
                listViewFilms.View = View.LargeIcon;
                listViewFilms.BackColor = Color.DimGray;
            }
            else
            {
                listViewFilms.View = View.Details;
                listViewFilms.BackColor = Color.WhiteSmoke;
            }
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
                BaseDonnees bd = BaseDonnees.instance;
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
        /// Mise a jour de la liste des films
        /// </summary>
        public void updateListeFilms(Action<int, string> action = null)
        {
            using (new CursorChanger(Cursors.WaitCursor))
            {
                _filtreChange = false;

                action?.Invoke(0, "Ouverture de la base de données");
                BaseFilms bd = BaseFilms.instance;

                bool relancer = Configuration.relancerRechercheAuto;

                listViewFilms.BeginUpdate();
                listViewFilms.Items.Clear();
                action?.Invoke(10, "Lecture des films ");
                List<Film> films = BaseFilms.instance.getListFilms(_filtre);
                action?.Invoke(40, "Mise a jour de l'interface utilisateur ");
                toolStripStatusLabelNbAffiches.Text = string.Format("{0} films affichés", films.Count);
                toolStripStatusLabelNbFilmsBD.Text = string.Format("{0} films dans la base", BaseFilms.instance.getNbFilms());
                WriteMessageToConsole(_filtre.Recherche + ":" + films.Count + " films affichés");
                int n = 0;
                foreach (Film f in films)
                {
                    Application.DoEvents();
                    if (_filtreChange)
                    {
                        listViewFilms.Items.Clear();
                        break;
                    }
                    n++;
                    if (n % 10 == 0)
                        action?.Invoke((int)(50 + (int)(listViewFilms.Items.Count * 100.0f / films.Count) / 2.0f), f.Titre);
                    AjouteFilm(f);

                    if (relancer && (f.Etat == Film.ETAT.NOUVEAU || f.Etat == Film.ETAT.PAS_TROUVE))
                        _actionsDifferees.ajoute(new ActionNouveauFilm(f));
                }

                listViewFilms.SelectedIndices.Clear();
                if (listViewFilms.Items.Count > 0)
                    listViewFilms.Items[0].Selected = true;
                listViewFilms.EndUpdate();
            }
        }

        private void onClickMenuVueDetails(object sender, EventArgs e)
        {
            switchVueFilms(false);
            Configuration.instance.vue = Configuration.CONF_PARAM_DETAILS;
        }

        private void onclickMenuVueLarge(object sender, EventArgs e)
        {
            switchVueFilms(true);
            Configuration.instance.vue = Configuration.CONF_PARAM_LARGEICON;
        }

        private async void onListFilmsSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                _selectedId = (int)e.Item.Tag;
                Film f = await getSelectedFilm();
                updatePanneauInfo(f);
            }
        }

        private async Task<Film> getSelectedFilm()
        {
            return await BaseFilms.instance.getFilm(_selectedId);
        }

        /// <summary>
        /// Mise a jour du panneau d'informations en fonction du film selectionné
        /// </summary>
        /// <param name="film">film</param>
        async private void updatePanneauInfo(Film film)
        {
            if (film == null)
            {
                // Pas de film selectionné
                flowLayoutPanelInfosFilm.Hide();
                return;
            }

            WriteMessageToConsole($"Film: {film.Titre}, Id={film.Id}, ImageId={film.imageId}");

            flowLayoutPanelInfosFilm.Show();
            flowLayoutPanelInfosFilm.SuspendLayout();
            labelEtat.Text = film.getTextEtat();
            afficheInfoLink(null, linkLabelTitre, film.Titre, EditeFilm.urlRecherche(film.Titre));
            afficheInfoLink(null, linkLabelChemin, film.Chemin, new ProcessStartInfo(getExplorerPath(), " /select, \"" + film.Chemin + "\""));
            afficheInfoLinks(labelKeyRealisateur, linkLabelRealisateur, film.Realisateur);
            afficheInfoLinks(labelKeyActeurs, linkLabelActeurs, film.Acteurs);
            afficheInfoLinks(labelKeyGenres, linkLabelGenres, film.Genres);
            afficheInfo(labelKeyDateSortie, labelDateSortie, film.DateSortie);
            afficheInfo(labelKeyNationalite, labelNationalite, film.Nationalite);
            afficheInfoLinks(labelKeyEtiquettes, linkLabelEtiquettes, film._etiquettes);
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
                    textBoxTitrePasTrouve.Text = film.Titre;
                    break;
            }

            Image affiche = film.getAffiche();
            pictureBoxAffiche.Image = affiche;

            listViewAlternatives.Items.Clear();
            List<InfosFilm> alternatives = await film.Alternatives();
            if (alternatives?.Count > 0)
            {
                WriteMessageToConsole($"Alternatives: {alternatives.Count}");
                foreach (InfosFilm i in alternatives)
                {
                    WriteMessageToConsole($"Alternative: imageId={i._imageId}, resumé={i._resume}");
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

        private string getExplorerPath()
        {
            return Path.Combine(Environment.GetEnvironmentVariable("WINDIR"), "explorer.exe");
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

        /// <summary>
        /// Affiche un champ contenant plusieurs informations, separes par SEPARATEUR_LISTE,
        /// un lien pour chaque morceau d'information
        /// </summary>
        /// <param name="key"></param>
        /// <param name="link"></param>
        /// <param name="texte"></param>
        private void afficheInfoLinks(Label key, LinkLabel link, string texte)
        {
            char[] SEPARATEURS = { ',' };
            if (texte?.Length > 0)
            {
                key.Show();
                link.Show();
                link.Links.Clear();
                string[] valeurs = texte.Split(BaseFilms.SEPARATEUR_LISTES_CHAR);
                string label = "";
                int start = 0;
                foreach (string url in valeurs)
                {
                    label += url + ", ";
                    int length = url.Length;
                    LinkLabel.Link lk = new LinkLabel.Link(start, length, $"https://www.google.com/search?q={EditeFilm.urlRecherche(url)}");
                    link.Links.Add(lk);
                    start += length + 2;
                }
                link.Text = label;
            }
            else
            {
                key?.Hide();
                link?.Hide();
            }
        }

        private void afficheInfoLink(Label key, LinkLabel link, string texte, object data)
        {
            if (texte?.Length > 0)
            {
                key?.Show();
                link.Links.Clear();
                link.Text = texte;
                link.Links.Add(0, texte.Length, data);
            }
            else
            {
                key?.Hide();
                link?.Hide();
            }
        }

        private async void onClickValiderAlternative(object sender, EventArgs e)
        {
            Film selected = await getSelectedFilm();
            // Retrouver le film selectionne
            if (!(selected is Film))
                return;
            if (listViewAlternatives.SelectedIndices.Count < 1)
                return;

            var alternative = listViewAlternatives.SelectedIndices[0];

            selected.setAlternative(alternative);
        }

        private async void onListviewFilmsMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Film selected = await getSelectedFilm();
                if (selected == null)
                    return;

                if (listViewFilms.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuFilm.Show(Cursor.Position);
                }
            }
        }

        private async void onMenuLireLeFilm(object sender, EventArgs e)
        {
            Film selected = await getSelectedFilm();
            if (selected == null)
                return;

            WriteMessageToConsole("Lecture du film " + selected.Chemin);
            Process.Start(selected.Chemin);
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

        private async void onMenuAfficherDansRepertoire(object sender, EventArgs e)
        {
            Film selected = await getSelectedFilm();
            if (selected == null)
                return;

            WriteMessageToConsole($"Ouverture du film {selected.Chemin} dans l'explorateur Windows");
            OpenFolderAndSelectItem(selected.Chemin);
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

        private async void onClickRechargerInfos(object sender, EventArgs e)
        {
            Film selected = await getSelectedFilm();
            if (selected == null)
                return;

            selected._titre = textBoxTitrePasTrouve.Text;
            WriteMessageToConsole($"Recharger les informations de {selected.Titre}");
            _actionsDifferees.ajoute(new ActionNouveauFilm(selected));
        }

        private async void onMenuRechargerInfos(object sender, EventArgs e)
        {
            Film selected = await getSelectedFilm();
            if (selected == null)
                return;

            WriteMessageToConsole($"Recharger les informations de {selected.Titre}");
            _actionsDifferees.ajoute(new ActionNouveauFilm(selected)); ;
        }

        private async void onMenuSupprimerFilm(object sender, EventArgs e)
        {
            Film selected = await getSelectedFilm();
            if (selected == null)
                return;

            string message = string.Format("Supprimer le film  \"{0}\"\n({1})\nde la base?\nLe film n'est pas supprimé du disque", selected.Titre, selected.Chemin);
            if (MessageBox.Show(message, "Supprimer", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                BaseFilms.instance.supprimeFilm(_selectedId);
                _selectedId = -1;
                updateListeFilms();
            }
        }

        private async void onDoubleClickListviewAlternatives(object sender, MouseEventArgs e)
        {
            Film selected = await getSelectedFilm();
            // Retrouver le film selectionne
            if (!(selected is Film))
                return;
            if (listViewAlternatives.SelectedIndices.Count < 1)
                return;

            int alternative = listViewAlternatives.SelectedIndices[0];
            selected.setAlternative(alternative);
        }

        private void onTimerChangeFiltre(object sender, EventArgs e)
        {
            timerChangeFiltre.Enabled = false;
            timerChangeFiltre.Stop();

            Database.BaseFilms.instance.creerVueFilms(_filtre);
            updateListeFilms();
        }

        async private void onListviewFilmsDrawItem(object sender, DrawListViewItemEventArgs e)
        {
            switch (e.Item.ListView.View)
            {
                case View.Details:
                    if ((e.State & ListViewItemStates.Selected) != 0)
                    {
                        // Draw the background and focus rectangle for a selected item.
                        using (Brush b = new SolidBrush(Color.FromArgb(250, 194, 87)))
                            e.Graphics.FillRectangle(b, e.Bounds);
                        e.DrawFocusRectangle();
                    }

                    break;
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

                        Film f = await getFilm(e.Item);
                        Image image = await f.getImage(rImage);// await ((Film)e.Item.Tag).getImage(rImage);
                        if (image != null)
                        {
                            int dx = (rImage.Width - image.Width) / 2;
                            int dy = (rImage.Height - image.Height) / 2;
                            rImage.Offset(dx, dy);

                            //Rectangle rShadow = new Rectangle(rImage.Left, rImage.Top, image.Width, image.Height);
                            //rShadow.Offset( 2, 2 );
                            //e.Graphics.FillRectangle( _brosseOmbre, rShadow );
                            e.Graphics.DrawImage(image, rImage.Left, rImage.Top);
                        }

                        using (Brush b = new SolidBrush(e.Item.ListView.ForeColor))
                            e.Graphics.DrawString(e.Item.Text, e.Item.ListView.Font, b, e.Bounds, _formatLargeIcones);
                    }
                    break;
            }
        }

        /// <summary>
        /// Retrouve le films a partir du ListViewItem
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Task<Film> getFilm(ListViewItem item)
        {
            return BaseFilms.instance.getFilm((int)item.Tag);
        }

        async private void onListviewFilmsDrawSubItem(object sender, DrawListViewSubItemEventArgs e)
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

            if (!e.Item.Selected)
                e.DrawBackground();

            if (e.ColumnIndex == 0)
            {
                Rectangle rImage = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height);
                rImage.Inflate(-1, -1);

                Film film = await BaseFilms.instance.getFilm((int)e.Item.Tag);
                Image image = await film.getImageSmall(rImage);
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
            _filtre.nonTrouves();
            _filtreChange = true;

            timerChangeFiltre.Enabled = true;
            timerChangeFiltre.Start();
        }

        private void onMenuFiltreAlternatives(object sender, EventArgs e)
        {
            _filtre.alternatives();
            _filtreChange = true;

            timerChangeFiltre.Enabled = true;
            timerChangeFiltre.Start();
        }

        private void onMenuFiltreAvecAlternativeNonChoisie(object sender, EventArgs e)
        {
            _filtre.alternativesAucuneChoisie();
            _filtreChange = true;

            timerChangeFiltre.Enabled = true;
            timerChangeFiltre.Start();
        }

        private void onMenuFiltreTous(object sender, EventArgs e)
        {
            _filtre.tous();
            _filtreChange = true;

            timerChangeFiltre.Enabled = true;
            timerChangeFiltre.Start();
        }

        private async void onMenuEditerFilm(object sender, EventArgs e)
        {
            Film selected = await getSelectedFilm();
            if (selected == null)
                return;

            EditeFilm dlg = new EditeFilm();
            dlg.film = selected;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                update(selected);
                updatePanneauInfo(selected);
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
            BaseDonnees bd = BaseDonnees.instance;
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

        private async void onMenuCopierSurClefUSB(object sender, EventArgs e)
        {
            Film selected = await getSelectedFilm();
            if (selected == null)
                return;
            DestinationCopie dlg = new DestinationCopie();
            dlg.film = selected;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                string source = selected.Chemin;
                string destination = Path.Combine(dlg.destinationDevice.RootDirectory.FullName, Path.GetFileName(source));
                // Lancer la copie
                _copieFichiers.ajoute(source, destination);
            }
        }

        private void onClosing(object sender, FormClosingEventArgs e)
        {
            _actionsDifferees.Stop();

            /*if ( bgWorkerCopie.IsBusy )
                bgWorkerCopie.CancelAsync();*/
            _copieFichiers.Stop();

            if (Configuration.menageALaFin)
            {
                using (MenageEnCours dlg = new MenageEnCours())
                {
                    dlg.Show(this);
                    dlg.Update();
                    BaseFilms.instance.Menage(dlg);
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
            if (e.Column == listViewColonneSorter.SortColumn)
            {
                // Inverser le sens de tri en cours pour cette colonne.
                if (listViewColonneSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    listViewColonneSorter.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    listViewColonneSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                // Définir le numéro de colonne à trier ; par défaut sur croissant.
                listViewColonneSorter.SortColumn = e.Column;
                listViewColonneSorter.Order = System.Windows.Forms.SortOrder.Ascending;
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

        private void onLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link.LinkData is ProcessStartInfo)
            {
                Process p = new Process();
                p.StartInfo = (ProcessStartInfo)e.Link.LinkData;
                p.Start();
            }
            else
                Process.Start(e.Link.LinkData.ToString());
        }

        private async void onMenuMarquerVu(object sender, EventArgs e)
        {
            Film selected = await getSelectedFilm();
            if (selected == null)
                return;

            selected.Vu = !selected.Vu;
            BaseFilms.instance.update(selected);
            update(selected);
        }

        private async void onMenuMarquerAVoir(object sender, EventArgs e)
        {
            Film selected = await getSelectedFilm();
            if (selected == null)
                return;

            selected.aVoir = !selected.aVoir;
            BaseFilms.instance.update(selected);
            update(selected);
        }

        private void onMenuFiltreVus(object sender, EventArgs e)
        {
            _filtre.Vus();
            _filtreChange = true;

            timerChangeFiltre.Enabled = true;
            timerChangeFiltre.Start();
        }

        private void onMenuFiltreNonVus(object sender, EventArgs e)
        {
            _filtre.NonVus();
            _filtreChange = true;

            timerChangeFiltre.Enabled = true;
            timerChangeFiltre.Start();
        }

        private void onMenuFiltreAVoir(object sender, EventArgs e)
        {
            _filtre.AVoir();
            _filtreChange = true;

            timerChangeFiltre.Enabled = true;
            timerChangeFiltre.Start();
        }

        private void onDropDownRechargerDepuis(object sender, EventArgs e)
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

        private async void onClickItemRechargerDepuis(object sender, EventArgs e)
        {
            Film selected = await getSelectedFilm();
            if (selected == null)
                return;

            ToolStripLabel l = sender as ToolStripLabel;
            if (l != null)
            {
                RechercheInternet ri = l.Tag as RechercheInternet;
                if (ri != null)
                {
                    WriteMessageToConsole($"Recherche de {selected.Titre} sur {ri.nom}");
                    // Ajouter recherche internet forcee sur ce site
                    _actionsDifferees.ajoute(new ActionChargeSite(selected, ri.nom));
                }
            }

        }

        private async void onClickItemCopierSur(object sender, EventArgs e)
        {
            Film selected = await getSelectedFilm();
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
                    _copieFichiers.ajoute(source, destination);
                }
            }

        }


        private void onClicProgressCopie(object sender, EventArgs e)
        {
            _copieFichiers.onClickStatus();
        }
        private void onMenuAjouteFichiers(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                BaseFilms bd = BaseFilms.instance;
                foreach (string fichier in openFileDialog.FileNames)
                {
                    Film film = new Film(fichier, "");

                    if (!bd.FilmExiste(film))
                    {
                        WriteMessageToConsole("Ajout du film " + fichier);
                        bd.ajouteFilm(film);
                        AjouteFilm(film);
                        _actionsDifferees.ajoute(new ActionNouveauFilm(film));
                    }
                    else
                        WriteMessageToConsole(fichier + " déjà référencé");
                }
            }
        }

        private void onMenuLogo(object sender, EventArgs e)
        {
            APropos dlg = new APropos();
            dlg.ShowDialog(this);
        }

        private void onMenuCollections(object sender, EventArgs e)
        {
            string baseCourante = BaseFilms.instance.name;
            GestionBase dlg = new GestionBase();

            dlg.ShowDialog(this);
            if (!baseCourante.Equals(BaseFilms.instance.name))
            {
                _actionsDifferees.Clear();
                updateListeFilms();
            }
        }

        private async void onClickSupprimerAlternatives(object sender, EventArgs e)
        {
            Film selected = await getSelectedFilm();
            if (selected == null)
                return;

            // Suppression des alternatives dans la base
            selected.supprimeAlternatives();
        }
    }
}