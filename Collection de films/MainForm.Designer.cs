namespace Collection_de_films
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            _brosseOmbre.Dispose();
            _formatDetails.Dispose();
            _formatLargeIcones.Dispose();
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label8;
            System.Windows.Forms.ColumnHeader columnHeaderTitre;
            System.Windows.Forms.ColumnHeader columnHeaderREalisateur;
            System.Windows.Forms.ColumnHeader columnHeaderActeurs;
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.Windows.Forms.ColumnHeader columnHeader6;
            System.Windows.Forms.ColumnHeader columnHeader8;
            System.Windows.Forms.ColumnHeader columnHeader10;
            System.Windows.Forms.ColumnHeader columnHeader9;
            System.Windows.Forms.ColumnHeader columnHeaderREsume;
            System.Windows.Forms.ColumnHeader columnHeaderGenres;
            System.Windows.Forms.ColumnHeader columnHeaderDateSortie;
            System.Windows.Forms.ColumnHeader columnHeaderEtiquettes;
            System.Windows.Forms.ColumnHeader columnHeaderVu;
            System.Windows.Forms.ColumnHeader columnHeaderAVoir;
            System.Windows.Forms.MenuStrip menuStrip1;
            System.Windows.Forms.ToolStripMenuItem logoToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem collectionsToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem ajouterDesFichiersToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem ajouterUnRépertoireToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
            System.Windows.Forms.ToolStripMenuItem vueToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem filtreToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem effacerToolStripMenuItem1;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
            System.Windows.Forms.ToolStripMenuItem filmTousToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem aVoirToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem vusToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem pasEncoreVusToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem filmAvecInformationsManquantesToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem filmsAvecAlternativesToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem filmsAvecAlternativesAucuneChoisieToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
            System.Windows.Forms.StatusStrip statusStrip1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.détailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxFiltre = new System.Windows.Forms.ToolStripTextBox();
            this.effacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripStatusLabelFichiersACopier = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelNbFilmsBD = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelNbAffiches = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgressbarCopieEnCours = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listViewFilms = new System.Windows.Forms.ListView();
            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.linkLabelChemin = new System.Windows.Forms.LinkLabel();
            this.linkLabelTitre = new System.Windows.Forms.LinkLabel();
            this.labelEtat = new System.Windows.Forms.Label();
            this.tabControlAlternatives = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelInfosFilm = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelPasTrouve = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxTitrePasTrouve = new System.Windows.Forms.TextBox();
            this.buttonRelancerPasTrouve = new System.Windows.Forms.Button();
            this.pictureBoxAffiche = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelInfos = new System.Windows.Forms.FlowLayoutPanel();
            this.labelKeyRealisateur = new System.Windows.Forms.Label();
            this.linkLabelRealisateur = new System.Windows.Forms.LinkLabel();
            this.labelKeyActeurs = new System.Windows.Forms.Label();
            this.linkLabelActeurs = new System.Windows.Forms.LinkLabel();
            this.labelKeyGenres = new System.Windows.Forms.Label();
            this.linkLabelGenres = new System.Windows.Forms.LinkLabel();
            this.labelKeyDateSortie = new System.Windows.Forms.Label();
            this.labelDateSortie = new System.Windows.Forms.Label();
            this.labelKeyNationalite = new System.Windows.Forms.Label();
            this.labelNationalite = new System.Windows.Forms.Label();
            this.labelKeyEtiquettes = new System.Windows.Forms.Label();
            this.linkLabelEtiquettes = new System.Windows.Forms.LinkLabel();
            this.labelResume = new System.Windows.Forms.Label();
            this.tabpageAlternatives = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.listViewAlternatives = new System.Windows.Forms.ListView();
            this.imageListAlternatives = new System.Windows.Forms.ImageList(this.components);
            this.consoleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuFilm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lireLeFilmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marquerCommeVuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marquerCommeAVoirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afficherDansLExplorateurWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.rechargerLesInformationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rechargerLesInformationsDepuisLeSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allocinefrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copierSurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerChangeFiltre = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            label8 = new System.Windows.Forms.Label();
            columnHeaderTitre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeaderREalisateur = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeaderActeurs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeaderREsume = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeaderGenres = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeaderDateSortie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeaderEtiquettes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeaderVu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeaderAVoir = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            logoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            collectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ajouterDesFichiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ajouterUnRépertoireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            vueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            filtreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            effacerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            filmTousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aVoirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            vusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            pasEncoreVusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            filmAvecInformationsManquantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            filmsAvecAlternativesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            filmsAvecAlternativesAucuneChoisieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControlAlternatives.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanelInfosFilm.SuspendLayout();
            this.flowLayoutPanelPasTrouve.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAffiche)).BeginInit();
            this.flowLayoutPanelInfos.SuspendLayout();
            this.tabpageAlternatives.SuspendLayout();
            this.contextMenuFilm.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            this.flowLayoutPanelPasTrouve.SetFlowBreak(label8, true);
            label8.Location = new System.Drawing.Point(3, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(330, 26);
            label8.TabIndex = 3;
            label8.Text = "Film non trouvé sur internet, vous pouvez tenter de corriger le titre et relancer" +
    " la recherche";
            // 
            // columnHeaderTitre
            // 
            columnHeaderTitre.Text = "Titre";
            columnHeaderTitre.Width = 183;
            // 
            // columnHeaderREalisateur
            // 
            columnHeaderREalisateur.Text = "Réalisateur";
            // 
            // columnHeaderActeurs
            // 
            columnHeaderActeurs.Text = "Acteurs";
            // 
            // columnHeader1
            // 
            columnHeader1.Text = " Réalisateur";
            columnHeader1.Width = 103;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Genres";
            columnHeader6.Width = 96;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Acteurs";
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Date de sortie";
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Résumé";
            columnHeader9.Width = 100;
            // 
            // columnHeaderREsume
            // 
            columnHeaderREsume.Text = "Résumé";
            columnHeaderREsume.Width = 500;
            // 
            // columnHeaderGenres
            // 
            columnHeaderGenres.Text = "Genres";
            // 
            // columnHeaderDateSortie
            // 
            columnHeaderDateSortie.Text = "Date de sortie";
            // 
            // columnHeaderEtiquettes
            // 
            columnHeaderEtiquettes.Text = "Etiquettes";
            // 
            // columnHeaderVu
            // 
            columnHeaderVu.Text = "Vu";
            columnHeaderVu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeaderAVoir
            // 
            columnHeaderAVoir.Text = "A voir";
            columnHeaderAVoir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.BackColor = System.Drawing.Color.DarkRed;
            menuStrip1.BackgroundImage = global::Collection_de_films.Properties.Resources.fondtoolbar;
            menuStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            logoToolStripMenuItem,
            collectionsToolStripMenuItem,
            ajouterToolStripMenuItem,
            toolStripMenuItem3,
            vueToolStripMenuItem,
            this.toolStripMenuItem1,
            filtreToolStripMenuItem,
            this.toolStripTextBoxFiltre,
            this.effacerToolStripMenuItem,
            effacerToolStripMenuItem1,
            this.toolStripMenuItem18,
            toolStripMenuItem2,
            configurationToolStripMenuItem});
            menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(4);
            menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            menuStrip1.ShowItemToolTips = true;
            menuStrip1.Size = new System.Drawing.Size(1288, 72);
            menuStrip1.TabIndex = 0;
            // 
            // logoToolStripMenuItem
            // 
            logoToolStripMenuItem.Image = global::Collection_de_films.Properties.Resources.logo;
            logoToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            logoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            logoToolStripMenuItem.Name = "logoToolStripMenuItem";
            logoToolStripMenuItem.Size = new System.Drawing.Size(177, 64);
            logoToolStripMenuItem.Click += new System.EventHandler(this.onMenuLogo);
            // 
            // collectionsToolStripMenuItem
            // 
            collectionsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            collectionsToolStripMenuItem.Image = global::Collection_de_films.Properties.Resources.collections;
            collectionsToolStripMenuItem.Name = "collectionsToolStripMenuItem";
            collectionsToolStripMenuItem.Size = new System.Drawing.Size(126, 64);
            collectionsToolStripMenuItem.Text = "Collections";
            collectionsToolStripMenuItem.Click += new System.EventHandler(this.onMenuCollections);
            // 
            // ajouterToolStripMenuItem
            // 
            ajouterToolStripMenuItem.AutoSize = false;
            ajouterToolStripMenuItem.AutoToolTip = true;
            ajouterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            ajouterDesFichiersToolStripMenuItem,
            ajouterUnRépertoireToolStripMenuItem});
            ajouterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            ajouterToolStripMenuItem.Image = global::Collection_de_films.Properties.Resources.ajouter;
            ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            ajouterToolStripMenuItem.Size = new System.Drawing.Size(106, 52);
            ajouterToolStripMenuItem.Text = "Ajouter";
            ajouterToolStripMenuItem.ToolTipText = "Ajouter un fichier ou un répertoire";
            // 
            // ajouterDesFichiersToolStripMenuItem
            // 
            ajouterDesFichiersToolStripMenuItem.Name = "ajouterDesFichiersToolStripMenuItem";
            ajouterDesFichiersToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            ajouterDesFichiersToolStripMenuItem.Text = "Ajouter des fichiers";
            ajouterDesFichiersToolStripMenuItem.Click += new System.EventHandler(this.onMenuAjouteFichiers);
            // 
            // ajouterUnRépertoireToolStripMenuItem
            // 
            ajouterUnRépertoireToolStripMenuItem.Name = "ajouterUnRépertoireToolStripMenuItem";
            ajouterUnRépertoireToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            ajouterUnRépertoireToolStripMenuItem.Text = "Ajouter un répertoire";
            ajouterUnRépertoireToolStripMenuItem.Click += new System.EventHandler(this.onMenuAjouterRepertoire);
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripMenuItem5,
            toolStripMenuItem6,
            toolStripMenuItem7,
            toolStripMenuItem8,
            this.toolStripSeparator4,
            toolStripMenuItem9,
            toolStripMenuItem10,
            this.toolStripSeparator5,
            toolStripMenuItem11,
            this.toolStripMenuItem12,
            this.toolStripSeparator6,
            toolStripMenuItem16});
            toolStripMenuItem3.ForeColor = System.Drawing.Color.White;
            toolStripMenuItem3.Image = global::Collection_de_films.Properties.Resources.menu_film;
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size(90, 64);
            toolStripMenuItem3.Text = "Film";
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            toolStripMenuItem5.Size = new System.Drawing.Size(348, 22);
            toolStripMenuItem5.Text = "Lire le film";
            toolStripMenuItem5.Click += new System.EventHandler(this.onMenuLireLeFilm);
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            toolStripMenuItem6.Size = new System.Drawing.Size(348, 22);
            toolStripMenuItem6.Text = "Marquer comme vu";
            toolStripMenuItem6.Click += new System.EventHandler(this.onMenuMarquerVu);
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            toolStripMenuItem7.Size = new System.Drawing.Size(348, 22);
            toolStripMenuItem7.Text = "Marquer comme A voir";
            toolStripMenuItem7.Click += new System.EventHandler(this.onMenuMarquerAVoir);
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            toolStripMenuItem8.Size = new System.Drawing.Size(348, 22);
            toolStripMenuItem8.Text = "Afficher dans l\'Explorateur Windows";
            toolStripMenuItem8.Click += new System.EventHandler(this.onMenuAfficherDansRepertoire);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(345, 6);
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            toolStripMenuItem9.Size = new System.Drawing.Size(348, 22);
            toolStripMenuItem9.Text = "Editer";
            // 
            // toolStripMenuItem10
            // 
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            toolStripMenuItem10.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            toolStripMenuItem10.Size = new System.Drawing.Size(348, 22);
            toolStripMenuItem10.Text = "Supprimer de la base";
            toolStripMenuItem10.Click += new System.EventHandler(this.onMenuSupprimerFilm);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(345, 6);
            // 
            // toolStripMenuItem11
            // 
            toolStripMenuItem11.Name = "toolStripMenuItem11";
            toolStripMenuItem11.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            toolStripMenuItem11.Size = new System.Drawing.Size(348, 22);
            toolStripMenuItem11.Text = "Recharger les informations";
            toolStripMenuItem11.Click += new System.EventHandler(this.onMenuRechargerInfos);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem13});
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(348, 22);
            this.toolStripMenuItem12.Text = "Recharger les informations depuis le site";
            this.toolStripMenuItem12.DropDownOpening += new System.EventHandler(this.onDropDownRechargerDepuis);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem13.Text = "Allocine.fr";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(345, 6);
            // 
            // toolStripMenuItem16
            // 
            toolStripMenuItem16.Name = "toolStripMenuItem16";
            toolStripMenuItem16.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            toolStripMenuItem16.Size = new System.Drawing.Size(348, 22);
            toolStripMenuItem16.Text = "Copier sur une clef USB ou support amovible";
            toolStripMenuItem16.Click += new System.EventHandler(this.onMenuCopierSurClefUSB);
            // 
            // vueToolStripMenuItem
            // 
            vueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.détailToolStripMenuItem,
            this.imagesToolStripMenuItem});
            vueToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            vueToolStripMenuItem.Image = global::Collection_de_films.Properties.Resources.vues;
            vueToolStripMenuItem.Name = "vueToolStripMenuItem";
            vueToolStripMenuItem.Size = new System.Drawing.Size(87, 64);
            vueToolStripMenuItem.Text = "Vue";
            // 
            // détailToolStripMenuItem
            // 
            this.détailToolStripMenuItem.Image = global::Collection_de_films.Properties.Resources.vuedetails;
            this.détailToolStripMenuItem.Name = "détailToolStripMenuItem";
            this.détailToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.détailToolStripMenuItem.Text = "Détail";
            this.détailToolStripMenuItem.Click += new System.EventHandler(this.onClickMenuVueDetails);
            // 
            // imagesToolStripMenuItem
            // 
            this.imagesToolStripMenuItem.Image = global::Collection_de_films.Properties.Resources.vuelarge;
            this.imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
            this.imagesToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.imagesToolStripMenuItem.Text = "Images";
            this.imagesToolStripMenuItem.Click += new System.EventHandler(this.onclickMenuVueLarge);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(40, 64);
            this.toolStripMenuItem1.Text = "       ";
            // 
            // filtreToolStripMenuItem
            // 
            filtreToolStripMenuItem.AutoSize = false;
            filtreToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            filtreToolStripMenuItem.Image = global::Collection_de_films.Properties.Resources.recherche1;
            filtreToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            filtreToolStripMenuItem.Name = "filtreToolStripMenuItem";
            filtreToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            filtreToolStripMenuItem.Size = new System.Drawing.Size(92, 52);
            filtreToolStripMenuItem.Text = "Filtre:";
            // 
            // toolStripTextBoxFiltre
            // 
            this.toolStripTextBoxFiltre.AutoSize = false;
            this.toolStripTextBoxFiltre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.toolStripTextBoxFiltre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripTextBoxFiltre.Margin = new System.Windows.Forms.Padding(1, 0, -20, 0);
            this.toolStripTextBoxFiltre.Name = "toolStripTextBoxFiltre";
            this.toolStripTextBoxFiltre.Padding = new System.Windows.Forms.Padding(8);
            this.toolStripTextBoxFiltre.Size = new System.Drawing.Size(200, 52);
            this.toolStripTextBoxFiltre.ToolTipText = "Tapez un texte pour filtrer les films";
            this.toolStripTextBoxFiltre.TextChanged += new System.EventHandler(this.onTextBoxFiltreTextChanged);
            // 
            // effacerToolStripMenuItem
            // 
            this.effacerToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.effacerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.effacerToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.effacerToolStripMenuItem.Margin = new System.Windows.Forms.Padding(-10, 0, 10, 0);
            this.effacerToolStripMenuItem.Name = "effacerToolStripMenuItem";
            this.effacerToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.effacerToolStripMenuItem.Size = new System.Drawing.Size(4, 64);
            this.effacerToolStripMenuItem.Text = "effacer";
            this.effacerToolStripMenuItem.ToolTipText = "Effacer la requête";
            this.effacerToolStripMenuItem.Click += new System.EventHandler(this.onCliqueEffaceRequete);
            // 
            // effacerToolStripMenuItem1
            // 
            effacerToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            effacerToolStripMenuItem1.Image = global::Collection_de_films.Properties.Resources.effacer;
            effacerToolStripMenuItem1.Name = "effacerToolStripMenuItem1";
            effacerToolStripMenuItem1.Padding = new System.Windows.Forms.Padding(0);
            effacerToolStripMenuItem1.Size = new System.Drawing.Size(52, 64);
            effacerToolStripMenuItem1.ToolTipText = "Effacer le filtre";
            effacerToolStripMenuItem1.Click += new System.EventHandler(this.onCliqueEffaceRequete);
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(40, 64);
            this.toolStripMenuItem18.Text = "       ";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.AutoSize = false;
            toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            filmTousToolStripMenuItem,
            aVoirToolStripMenuItem,
            vusToolStripMenuItem,
            pasEncoreVusToolStripMenuItem,
            this.toolStripSeparator7,
            filmAvecInformationsManquantesToolStripMenuItem,
            filmsAvecAlternativesToolStripMenuItem,
            filmsAvecAlternativesAucuneChoisieToolStripMenuItem});
            toolStripMenuItem2.ForeColor = System.Drawing.Color.White;
            toolStripMenuItem2.Image = global::Collection_de_films.Properties.Resources.selection;
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(94, 52);
            toolStripMenuItem2.Text = "Sélection";
            // 
            // filmTousToolStripMenuItem
            // 
            filmTousToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            filmTousToolStripMenuItem.Name = "filmTousToolStripMenuItem";
            filmTousToolStripMenuItem.ShowShortcutKeys = false;
            filmTousToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            filmTousToolStripMenuItem.Text = "Tous";
            filmTousToolStripMenuItem.Click += new System.EventHandler(this.onMenuFiltreTous);
            // 
            // aVoirToolStripMenuItem
            // 
            aVoirToolStripMenuItem.Name = "aVoirToolStripMenuItem";
            aVoirToolStripMenuItem.ShowShortcutKeys = false;
            aVoirToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            aVoirToolStripMenuItem.Text = "A voir";
            aVoirToolStripMenuItem.Click += new System.EventHandler(this.onMenuFiltreAVoir);
            // 
            // vusToolStripMenuItem
            // 
            vusToolStripMenuItem.Name = "vusToolStripMenuItem";
            vusToolStripMenuItem.ShowShortcutKeys = false;
            vusToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            vusToolStripMenuItem.Text = "Vus";
            vusToolStripMenuItem.Click += new System.EventHandler(this.onMenuFiltreVus);
            // 
            // pasEncoreVusToolStripMenuItem
            // 
            pasEncoreVusToolStripMenuItem.Name = "pasEncoreVusToolStripMenuItem";
            pasEncoreVusToolStripMenuItem.ShowShortcutKeys = false;
            pasEncoreVusToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            pasEncoreVusToolStripMenuItem.Text = "Pas encore vus";
            pasEncoreVusToolStripMenuItem.Click += new System.EventHandler(this.onMenuFiltreNonVus);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(267, 6);
            // 
            // filmAvecInformationsManquantesToolStripMenuItem
            // 
            filmAvecInformationsManquantesToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            filmAvecInformationsManquantesToolStripMenuItem.Name = "filmAvecInformationsManquantesToolStripMenuItem";
            filmAvecInformationsManquantesToolStripMenuItem.ShowShortcutKeys = false;
            filmAvecInformationsManquantesToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            filmAvecInformationsManquantesToolStripMenuItem.Text = "Films non trouvés";
            filmAvecInformationsManquantesToolStripMenuItem.Click += new System.EventHandler(this.filmAvecInformationsManquantesToolStripMenuItem_Click);
            // 
            // filmsAvecAlternativesToolStripMenuItem
            // 
            filmsAvecAlternativesToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            filmsAvecAlternativesToolStripMenuItem.Name = "filmsAvecAlternativesToolStripMenuItem";
            filmsAvecAlternativesToolStripMenuItem.ShowShortcutKeys = false;
            filmsAvecAlternativesToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            filmsAvecAlternativesToolStripMenuItem.Text = "Films avec alternatives";
            filmsAvecAlternativesToolStripMenuItem.Click += new System.EventHandler(this.onMenuFiltreAlternatives);
            // 
            // filmsAvecAlternativesAucuneChoisieToolStripMenuItem
            // 
            filmsAvecAlternativesAucuneChoisieToolStripMenuItem.Name = "filmsAvecAlternativesAucuneChoisieToolStripMenuItem";
            filmsAvecAlternativesAucuneChoisieToolStripMenuItem.ShowShortcutKeys = false;
            filmsAvecAlternativesAucuneChoisieToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            filmsAvecAlternativesAucuneChoisieToolStripMenuItem.Text = "Films avec alternatives, aucune choisie";
            filmsAvecAlternativesAucuneChoisieToolStripMenuItem.Click += new System.EventHandler(this.onMenuFiltreAvecAlternativeNonChoisie);
            // 
            // configurationToolStripMenuItem
            // 
            configurationToolStripMenuItem.AutoSize = false;
            configurationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            configurationToolStripMenuItem.Image = global::Collection_de_films.Properties.Resources.configuration;
            configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            configurationToolStripMenuItem.Size = new System.Drawing.Size(141, 52);
            configurationToolStripMenuItem.Text = "Configuration";
            configurationToolStripMenuItem.Click += new System.EventHandler(this.onClickConfiguration);
            // 
            // toolStripStatusLabelFichiersACopier
            // 
            this.toolStripStatusLabelFichiersACopier.Name = "toolStripStatusLabelFichiersACopier";
            this.toolStripStatusLabelFichiersACopier.Size = new System.Drawing.Size(95, 17);
            this.toolStripStatusLabelFichiersACopier.Text = "Fichiers a copier:";
            this.toolStripStatusLabelFichiersACopier.Visible = false;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelNbFilmsBD,
            this.toolStripStatusLabelNbAffiches,
            this.toolStripStatusLabel,
            this.toolStripStatusLabelFichiersACopier,
            this.tsProgressbarCopieEnCours});
            statusStrip1.Location = new System.Drawing.Point(0, 719);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(1288, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelNbFilmsBD
            // 
            this.toolStripStatusLabelNbFilmsBD.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripStatusLabelNbFilmsBD.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabelNbFilmsBD.Name = "toolStripStatusLabelNbFilmsBD";
            this.toolStripStatusLabelNbFilmsBD.Size = new System.Drawing.Size(114, 17);
            this.toolStripStatusLabelNbFilmsBD.Text = "Films dans la base: 0";
            // 
            // toolStripStatusLabelNbAffiches
            // 
            this.toolStripStatusLabelNbAffiches.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripStatusLabelNbAffiches.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabelNbAffiches.Name = "toolStripStatusLabelNbAffiches";
            this.toolStripStatusLabelNbAffiches.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusLabelNbAffiches.Text = "Films affichés: 0";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(90, 17);
            this.toolStripStatusLabel.Text = "Films à traiter: 0";
            // 
            // tsProgressbarCopieEnCours
            // 
            this.tsProgressbarCopieEnCours.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tsProgressbarCopieEnCours.Name = "tsProgressbarCopieEnCours";
            this.tsProgressbarCopieEnCours.Size = new System.Drawing.Size(100, 16);
            this.tsProgressbarCopieEnCours.Step = 1;
            this.tsProgressbarCopieEnCours.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.tsProgressbarCopieEnCours.ToolTipText = "Cliquez pour ouvrir la fenêtre de copie";
            this.tsProgressbarCopieEnCours.Visible = false;
            this.tsProgressbarCopieEnCours.Click += new System.EventHandler(this.onClicProgressCopie);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Maroon;
            this.splitContainer1.BackgroundImage = global::Collection_de_films.Properties.Resources.fondtoolbar;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 72);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.consoleRichTextBox);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(1288, 647);
            this.splitContainer1.SplitterDistance = 540;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.DarkRed;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listViewFilms);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.splitContainer2.Panel2.Controls.Add(this.linkLabelChemin);
            this.splitContainer2.Panel2.Controls.Add(this.linkLabelTitre);
            this.splitContainer2.Panel2.Controls.Add(this.labelEtat);
            this.splitContainer2.Panel2.Controls.Add(this.tabControlAlternatives);
            this.splitContainer2.Size = new System.Drawing.Size(1288, 540);
            this.splitContainer2.SplitterDistance = 862;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // listViewFilms
            // 
            this.listViewFilms.AllowColumnReorder = true;
            this.listViewFilms.BackColor = System.Drawing.Color.DimGray;
            this.listViewFilms.BackgroundImageTiled = true;
            this.listViewFilms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewFilms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeaderTitre,
            columnHeaderREsume,
            columnHeaderVu,
            columnHeaderAVoir,
            columnHeaderGenres,
            columnHeaderREalisateur,
            columnHeaderActeurs,
            columnHeaderDateSortie,
            columnHeaderEtiquettes});
            this.listViewFilms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFilms.FullRowSelect = true;
            this.listViewFilms.LargeImageList = this.imageListLarge;
            this.listViewFilms.Location = new System.Drawing.Point(0, 0);
            this.listViewFilms.MultiSelect = false;
            this.listViewFilms.Name = "listViewFilms";
            this.listViewFilms.OwnerDraw = true;
            this.listViewFilms.ShowGroups = false;
            this.listViewFilms.ShowItemToolTips = true;
            this.listViewFilms.Size = new System.Drawing.Size(862, 540);
            this.listViewFilms.SmallImageList = this.imageListSmall;
            this.listViewFilms.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewFilms.TabIndex = 0;
            this.listViewFilms.UseCompatibleStateImageBehavior = false;
            this.listViewFilms.View = System.Windows.Forms.View.Details;
            this.listViewFilms.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.onClickColonneListFilms);
            this.listViewFilms.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.onListviewFilmsDrawColumnHeader);
            this.listViewFilms.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.onListviewFilmsDrawItem);
            this.listViewFilms.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.onListviewFilmsDrawSubItem);
            this.listViewFilms.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.onListFilmsSelectionChanged);
            this.listViewFilms.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onListviewFilmsMouseClick);
            // 
            // imageListLarge
            // 
            this.imageListLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListLarge.ImageSize = new System.Drawing.Size(120, 200);
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageListSmall
            // 
            this.imageListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListSmall.ImageSize = new System.Drawing.Size(64, 64);
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // linkLabelChemin
            // 
            this.linkLabelChemin.AutoSize = true;
            this.linkLabelChemin.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelChemin.LinkColor = System.Drawing.Color.Black;
            this.linkLabelChemin.Location = new System.Drawing.Point(11, 32);
            this.linkLabelChemin.Name = "linkLabelChemin";
            this.linkLabelChemin.Size = new System.Drawing.Size(55, 13);
            this.linkLabelChemin.TabIndex = 22;
            this.linkLabelChemin.TabStop = true;
            this.linkLabelChemin.Text = "linkLabel1";
            this.linkLabelChemin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.onLinkClicked);
            // 
            // linkLabelTitre
            // 
            this.linkLabelTitre.AutoSize = true;
            this.linkLabelTitre.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelTitre.ForeColor = System.Drawing.Color.White;
            this.linkLabelTitre.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelTitre.LinkColor = System.Drawing.Color.White;
            this.linkLabelTitre.Location = new System.Drawing.Point(11, 4);
            this.linkLabelTitre.Name = "linkLabelTitre";
            this.linkLabelTitre.Size = new System.Drawing.Size(59, 26);
            this.linkLabelTitre.TabIndex = 21;
            this.linkLabelTitre.TabStop = true;
            this.linkLabelTitre.Text = "Titre";
            this.linkLabelTitre.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.onLinkClicked);
            // 
            // labelEtat
            // 
            this.labelEtat.AutoSize = true;
            this.labelEtat.Location = new System.Drawing.Point(11, 47);
            this.labelEtat.Name = "labelEtat";
            this.labelEtat.Size = new System.Drawing.Size(35, 13);
            this.labelEtat.TabIndex = 19;
            this.labelEtat.Text = "label9";
            // 
            // tabControlAlternatives
            // 
            this.tabControlAlternatives.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAlternatives.Controls.Add(this.tabPage1);
            this.tabControlAlternatives.Controls.Add(this.tabpageAlternatives);
            this.tabControlAlternatives.HotTrack = true;
            this.tabControlAlternatives.Location = new System.Drawing.Point(0, 64);
            this.tabControlAlternatives.Name = "tabControlAlternatives";
            this.tabControlAlternatives.SelectedIndex = 0;
            this.tabControlAlternatives.Size = new System.Drawing.Size(410, 479);
            this.tabControlAlternatives.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControlAlternatives.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanelInfosFilm);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(402, 453);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Film";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelInfosFilm
            // 
            this.flowLayoutPanelInfosFilm.AutoSize = true;
            this.flowLayoutPanelInfosFilm.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelInfosFilm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanelInfosFilm.Controls.Add(this.flowLayoutPanelPasTrouve);
            this.flowLayoutPanelInfosFilm.Controls.Add(this.pictureBoxAffiche);
            this.flowLayoutPanelInfosFilm.Controls.Add(this.flowLayoutPanelInfos);
            this.flowLayoutPanelInfosFilm.Controls.Add(this.labelResume);
            this.flowLayoutPanelInfosFilm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelInfosFilm.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelInfosFilm.Name = "flowLayoutPanelInfosFilm";
            this.flowLayoutPanelInfosFilm.Size = new System.Drawing.Size(396, 447);
            this.flowLayoutPanelInfosFilm.TabIndex = 7;
            // 
            // flowLayoutPanelPasTrouve
            // 
            this.flowLayoutPanelPasTrouve.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelPasTrouve.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelPasTrouve.Controls.Add(label8);
            this.flowLayoutPanelPasTrouve.Controls.Add(this.textBoxTitrePasTrouve);
            this.flowLayoutPanelPasTrouve.Controls.Add(this.buttonRelancerPasTrouve);
            this.flowLayoutPanelInfosFilm.SetFlowBreak(this.flowLayoutPanelPasTrouve, true);
            this.flowLayoutPanelPasTrouve.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelPasTrouve.Name = "flowLayoutPanelPasTrouve";
            this.flowLayoutPanelPasTrouve.Size = new System.Drawing.Size(350, 91);
            this.flowLayoutPanelPasTrouve.TabIndex = 16;
            // 
            // textBoxTitrePasTrouve
            // 
            this.flowLayoutPanelPasTrouve.SetFlowBreak(this.textBoxTitrePasTrouve, true);
            this.textBoxTitrePasTrouve.Location = new System.Drawing.Point(3, 29);
            this.textBoxTitrePasTrouve.Name = "textBoxTitrePasTrouve";
            this.textBoxTitrePasTrouve.Size = new System.Drawing.Size(220, 20);
            this.textBoxTitrePasTrouve.TabIndex = 4;
            // 
            // buttonRelancerPasTrouve
            // 
            this.buttonRelancerPasTrouve.Location = new System.Drawing.Point(3, 58);
            this.buttonRelancerPasTrouve.Name = "buttonRelancerPasTrouve";
            this.buttonRelancerPasTrouve.Size = new System.Drawing.Size(75, 23);
            this.buttonRelancerPasTrouve.TabIndex = 5;
            this.buttonRelancerPasTrouve.Text = "Relancer";
            this.buttonRelancerPasTrouve.UseVisualStyleBackColor = true;
            this.buttonRelancerPasTrouve.Click += new System.EventHandler(this.onClickRechargerInfos);
            // 
            // pictureBoxAffiche
            // 
            this.pictureBoxAffiche.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxAffiche.Location = new System.Drawing.Point(3, 100);
            this.pictureBoxAffiche.Name = "pictureBoxAffiche";
            this.pictureBoxAffiche.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxAffiche.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxAffiche.TabIndex = 17;
            this.pictureBoxAffiche.TabStop = false;
            // 
            // flowLayoutPanelInfos
            // 
            this.flowLayoutPanelInfos.AutoSize = true;
            this.flowLayoutPanelInfos.Controls.Add(this.labelKeyRealisateur);
            this.flowLayoutPanelInfos.Controls.Add(this.linkLabelRealisateur);
            this.flowLayoutPanelInfos.Controls.Add(this.labelKeyActeurs);
            this.flowLayoutPanelInfos.Controls.Add(this.linkLabelActeurs);
            this.flowLayoutPanelInfos.Controls.Add(this.labelKeyGenres);
            this.flowLayoutPanelInfos.Controls.Add(this.linkLabelGenres);
            this.flowLayoutPanelInfos.Controls.Add(this.labelKeyDateSortie);
            this.flowLayoutPanelInfos.Controls.Add(this.labelDateSortie);
            this.flowLayoutPanelInfos.Controls.Add(this.labelKeyNationalite);
            this.flowLayoutPanelInfos.Controls.Add(this.labelNationalite);
            this.flowLayoutPanelInfos.Controls.Add(this.labelKeyEtiquettes);
            this.flowLayoutPanelInfos.Controls.Add(this.linkLabelEtiquettes);
            this.flowLayoutPanelInfosFilm.SetFlowBreak(this.flowLayoutPanelInfos, true);
            this.flowLayoutPanelInfos.Location = new System.Drawing.Point(109, 100);
            this.flowLayoutPanelInfos.Name = "flowLayoutPanelInfos";
            this.flowLayoutPanelInfos.Size = new System.Drawing.Size(124, 82);
            this.flowLayoutPanelInfos.TabIndex = 19;
            // 
            // labelKeyRealisateur
            // 
            this.labelKeyRealisateur.AutoSize = true;
            this.labelKeyRealisateur.BackColor = System.Drawing.Color.Transparent;
            this.labelKeyRealisateur.Location = new System.Drawing.Point(3, 0);
            this.labelKeyRealisateur.Name = "labelKeyRealisateur";
            this.labelKeyRealisateur.Size = new System.Drawing.Size(24, 13);
            this.labelKeyRealisateur.TabIndex = 19;
            this.labelKeyRealisateur.Text = "De:";
            // 
            // linkLabelRealisateur
            // 
            this.linkLabelRealisateur.AutoSize = true;
            this.flowLayoutPanelInfos.SetFlowBreak(this.linkLabelRealisateur, true);
            this.linkLabelRealisateur.Location = new System.Drawing.Point(33, 0);
            this.linkLabelRealisateur.Name = "linkLabelRealisateur";
            this.linkLabelRealisateur.Size = new System.Drawing.Size(55, 13);
            this.linkLabelRealisateur.TabIndex = 32;
            this.linkLabelRealisateur.TabStop = true;
            this.linkLabelRealisateur.Text = "linkLabel1";
            this.linkLabelRealisateur.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.onLinkClicked);
            // 
            // labelKeyActeurs
            // 
            this.labelKeyActeurs.AutoSize = true;
            this.labelKeyActeurs.BackColor = System.Drawing.Color.Transparent;
            this.labelKeyActeurs.Location = new System.Drawing.Point(3, 13);
            this.labelKeyActeurs.Name = "labelKeyActeurs";
            this.labelKeyActeurs.Size = new System.Drawing.Size(32, 13);
            this.labelKeyActeurs.TabIndex = 21;
            this.labelKeyActeurs.Text = "Avec";
            // 
            // linkLabelActeurs
            // 
            this.linkLabelActeurs.AutoSize = true;
            this.flowLayoutPanelInfos.SetFlowBreak(this.linkLabelActeurs, true);
            this.linkLabelActeurs.LinkArea = new System.Windows.Forms.LinkArea(5, 10);
            this.linkLabelActeurs.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelActeurs.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.linkLabelActeurs.Location = new System.Drawing.Point(41, 13);
            this.linkLabelActeurs.Name = "linkLabelActeurs";
            this.linkLabelActeurs.Size = new System.Drawing.Size(55, 17);
            this.linkLabelActeurs.TabIndex = 31;
            this.linkLabelActeurs.TabStop = true;
            this.linkLabelActeurs.Text = "linkLabel1";
            this.linkLabelActeurs.UseCompatibleTextRendering = true;
            this.linkLabelActeurs.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.linkLabelActeurs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.onLinkClicked);
            // 
            // labelKeyGenres
            // 
            this.labelKeyGenres.AutoSize = true;
            this.labelKeyGenres.BackColor = System.Drawing.Color.Transparent;
            this.labelKeyGenres.Location = new System.Drawing.Point(3, 30);
            this.labelKeyGenres.Name = "labelKeyGenres";
            this.labelKeyGenres.Size = new System.Drawing.Size(39, 13);
            this.labelKeyGenres.TabIndex = 23;
            this.labelKeyGenres.Text = "Genre:";
            // 
            // linkLabelGenres
            // 
            this.linkLabelGenres.AutoSize = true;
            this.flowLayoutPanelInfos.SetFlowBreak(this.linkLabelGenres, true);
            this.linkLabelGenres.Location = new System.Drawing.Point(48, 30);
            this.linkLabelGenres.Name = "linkLabelGenres";
            this.linkLabelGenres.Size = new System.Drawing.Size(55, 13);
            this.linkLabelGenres.TabIndex = 33;
            this.linkLabelGenres.TabStop = true;
            this.linkLabelGenres.Text = "linkLabel1";
            this.linkLabelGenres.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.onLinkClicked);
            // 
            // labelKeyDateSortie
            // 
            this.labelKeyDateSortie.AutoSize = true;
            this.labelKeyDateSortie.BackColor = System.Drawing.Color.Transparent;
            this.labelKeyDateSortie.Location = new System.Drawing.Point(3, 43);
            this.labelKeyDateSortie.Name = "labelKeyDateSortie";
            this.labelKeyDateSortie.Size = new System.Drawing.Size(37, 13);
            this.labelKeyDateSortie.TabIndex = 25;
            this.labelKeyDateSortie.Text = "Sortie:";
            // 
            // labelDateSortie
            // 
            this.labelDateSortie.AutoSize = true;
            this.labelDateSortie.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelInfos.SetFlowBreak(this.labelDateSortie, true);
            this.labelDateSortie.Location = new System.Drawing.Point(46, 43);
            this.labelDateSortie.Name = "labelDateSortie";
            this.labelDateSortie.Size = new System.Drawing.Size(47, 13);
            this.labelDateSortie.TabIndex = 26;
            this.labelDateSortie.Text = "xxxxxxxx";
            // 
            // labelKeyNationalite
            // 
            this.labelKeyNationalite.AutoSize = true;
            this.labelKeyNationalite.BackColor = System.Drawing.Color.Transparent;
            this.labelKeyNationalite.Location = new System.Drawing.Point(3, 56);
            this.labelKeyNationalite.Name = "labelKeyNationalite";
            this.labelKeyNationalite.Size = new System.Drawing.Size(60, 13);
            this.labelKeyNationalite.TabIndex = 27;
            this.labelKeyNationalite.Text = "Nationalité:";
            // 
            // labelNationalite
            // 
            this.labelNationalite.AutoSize = true;
            this.labelNationalite.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelInfos.SetFlowBreak(this.labelNationalite, true);
            this.labelNationalite.Location = new System.Drawing.Point(69, 56);
            this.labelNationalite.Name = "labelNationalite";
            this.labelNationalite.Size = new System.Drawing.Size(47, 13);
            this.labelNationalite.TabIndex = 28;
            this.labelNationalite.Text = "xxxxxxxx";
            // 
            // labelKeyEtiquettes
            // 
            this.labelKeyEtiquettes.AutoSize = true;
            this.labelKeyEtiquettes.BackColor = System.Drawing.Color.Transparent;
            this.labelKeyEtiquettes.Location = new System.Drawing.Point(3, 69);
            this.labelKeyEtiquettes.Name = "labelKeyEtiquettes";
            this.labelKeyEtiquettes.Size = new System.Drawing.Size(57, 13);
            this.labelKeyEtiquettes.TabIndex = 29;
            this.labelKeyEtiquettes.Text = "Etiquettes:";
            // 
            // linkLabelEtiquettes
            // 
            this.linkLabelEtiquettes.AutoSize = true;
            this.flowLayoutPanelInfos.SetFlowBreak(this.linkLabelEtiquettes, true);
            this.linkLabelEtiquettes.Location = new System.Drawing.Point(66, 69);
            this.linkLabelEtiquettes.Name = "linkLabelEtiquettes";
            this.linkLabelEtiquettes.Size = new System.Drawing.Size(55, 13);
            this.linkLabelEtiquettes.TabIndex = 34;
            this.linkLabelEtiquettes.TabStop = true;
            this.linkLabelEtiquettes.Text = "linkLabel1";
            this.linkLabelEtiquettes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.onLinkClicked);
            // 
            // labelResume
            // 
            this.labelResume.AutoSize = true;
            this.flowLayoutPanelInfosFilm.SetFlowBreak(this.labelResume, true);
            this.labelResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResume.Location = new System.Drawing.Point(3, 185);
            this.labelResume.Name = "labelResume";
            this.labelResume.Size = new System.Drawing.Size(46, 17);
            this.labelResume.TabIndex = 32;
            this.labelResume.Text = "label1";
            // 
            // tabpageAlternatives
            // 
            this.tabpageAlternatives.AccessibleName = "tabAlternatives";
            this.tabpageAlternatives.Controls.Add(this.label7);
            this.tabpageAlternatives.Controls.Add(this.listViewAlternatives);
            this.tabpageAlternatives.Location = new System.Drawing.Point(4, 22);
            this.tabpageAlternatives.Name = "tabpageAlternatives";
            this.tabpageAlternatives.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageAlternatives.Size = new System.Drawing.Size(402, 453);
            this.tabpageAlternatives.TabIndex = 1;
            this.tabpageAlternatives.Text = "Alternatives";
            this.tabpageAlternatives.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(0, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(402, 26);
            this.label7.TabIndex = 2;
            this.label7.Text = "Plusieurs alternatives ont été trouvées pour ce film, veuillez choisir celle qui " +
    "correspond le mieux en double-cliquant sur la ligne";
            // 
            // listViewAlternatives
            // 
            this.listViewAlternatives.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewAlternatives.BackColor = System.Drawing.Color.Silver;
            this.listViewAlternatives.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewAlternatives.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1,
            columnHeader9,
            columnHeader6,
            columnHeader8,
            columnHeader10});
            this.listViewAlternatives.FullRowSelect = true;
            this.listViewAlternatives.GridLines = true;
            this.listViewAlternatives.Location = new System.Drawing.Point(3, 32);
            this.listViewAlternatives.MultiSelect = false;
            this.listViewAlternatives.Name = "listViewAlternatives";
            this.listViewAlternatives.ShowGroups = false;
            this.listViewAlternatives.ShowItemToolTips = true;
            this.listViewAlternatives.Size = new System.Drawing.Size(393, 428);
            this.listViewAlternatives.SmallImageList = this.imageListAlternatives;
            this.listViewAlternatives.TabIndex = 7;
            this.listViewAlternatives.UseCompatibleStateImageBehavior = false;
            this.listViewAlternatives.View = System.Windows.Forms.View.Details;
            this.listViewAlternatives.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.onDoubleClickListviewAlternatives);
            // 
            // imageListAlternatives
            // 
            this.imageListAlternatives.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListAlternatives.ImageSize = new System.Drawing.Size(64, 64);
            this.imageListAlternatives.TransparentColor = System.Drawing.Color.Fuchsia;
            // 
            // consoleRichTextBox
            // 
            this.consoleRichTextBox.BackColor = System.Drawing.Color.Black;
            this.consoleRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleRichTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleRichTextBox.ForeColor = System.Drawing.Color.Lime;
            this.consoleRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.consoleRichTextBox.Name = "consoleRichTextBox";
            this.consoleRichTextBox.Size = new System.Drawing.Size(1288, 101);
            this.consoleRichTextBox.TabIndex = 0;
            this.consoleRichTextBox.Text = "=======================================\nCollection de fichier 0.1\n(c) Lucien Pill" +
    "oni 2016\n=======================================\n";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Choisissez un répertoire";
            this.folderBrowserDialog1.SelectedPath = "E:\\Films\\Aventure";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // contextMenuFilm
            // 
            this.contextMenuFilm.BackColor = System.Drawing.SystemColors.Menu;
            this.contextMenuFilm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lireLeFilmToolStripMenuItem,
            this.marquerCommeVuToolStripMenuItem,
            this.marquerCommeAVoirToolStripMenuItem,
            this.afficherDansLExplorateurWindowsToolStripMenuItem,
            this.toolStripSeparator1,
            this.editerToolStripMenuItem,
            this.supprimerToolStripMenuItem,
            this.toolStripSeparator2,
            this.rechargerLesInformationsToolStripMenuItem,
            this.rechargerLesInformationsDepuisLeSiteToolStripMenuItem,
            this.toolStripSeparator3,
            this.copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem,
            this.copierSurToolStripMenuItem});
            this.contextMenuFilm.Name = "contextMenuStripFilm";
            this.contextMenuFilm.ShowImageMargin = false;
            this.contextMenuFilm.Size = new System.Drawing.Size(324, 242);
            // 
            // lireLeFilmToolStripMenuItem
            // 
            this.lireLeFilmToolStripMenuItem.Name = "lireLeFilmToolStripMenuItem";
            this.lireLeFilmToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.lireLeFilmToolStripMenuItem.Size = new System.Drawing.Size(323, 22);
            this.lireLeFilmToolStripMenuItem.Text = "Lire le film";
            this.lireLeFilmToolStripMenuItem.Click += new System.EventHandler(this.onMenuLireLeFilm);
            // 
            // marquerCommeVuToolStripMenuItem
            // 
            this.marquerCommeVuToolStripMenuItem.Name = "marquerCommeVuToolStripMenuItem";
            this.marquerCommeVuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.marquerCommeVuToolStripMenuItem.Size = new System.Drawing.Size(323, 22);
            this.marquerCommeVuToolStripMenuItem.Text = "Marquer comme vu";
            this.marquerCommeVuToolStripMenuItem.Click += new System.EventHandler(this.onMenuMarquerVu);
            // 
            // marquerCommeAVoirToolStripMenuItem
            // 
            this.marquerCommeAVoirToolStripMenuItem.Name = "marquerCommeAVoirToolStripMenuItem";
            this.marquerCommeAVoirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.marquerCommeAVoirToolStripMenuItem.Size = new System.Drawing.Size(323, 22);
            this.marquerCommeAVoirToolStripMenuItem.Text = "Marquer comme A voir";
            this.marquerCommeAVoirToolStripMenuItem.Click += new System.EventHandler(this.onMenuMarquerAVoir);
            // 
            // afficherDansLExplorateurWindowsToolStripMenuItem
            // 
            this.afficherDansLExplorateurWindowsToolStripMenuItem.Name = "afficherDansLExplorateurWindowsToolStripMenuItem";
            this.afficherDansLExplorateurWindowsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.afficherDansLExplorateurWindowsToolStripMenuItem.Size = new System.Drawing.Size(323, 22);
            this.afficherDansLExplorateurWindowsToolStripMenuItem.Text = "Afficher dans l\'Explorateur Windows";
            this.afficherDansLExplorateurWindowsToolStripMenuItem.Click += new System.EventHandler(this.onMenuAfficherDansRepertoire);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(320, 6);
            // 
            // editerToolStripMenuItem
            // 
            this.editerToolStripMenuItem.Name = "editerToolStripMenuItem";
            this.editerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.editerToolStripMenuItem.Size = new System.Drawing.Size(323, 22);
            this.editerToolStripMenuItem.Text = "Editer";
            this.editerToolStripMenuItem.Click += new System.EventHandler(this.onMenuEditerFilm);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(323, 22);
            this.supprimerToolStripMenuItem.Text = "Supprimer de la base";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.onMenuSupprimerFilm);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(320, 6);
            // 
            // rechargerLesInformationsToolStripMenuItem
            // 
            this.rechargerLesInformationsToolStripMenuItem.Name = "rechargerLesInformationsToolStripMenuItem";
            this.rechargerLesInformationsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.rechargerLesInformationsToolStripMenuItem.Size = new System.Drawing.Size(323, 22);
            this.rechargerLesInformationsToolStripMenuItem.Text = "Recharger les informations";
            this.rechargerLesInformationsToolStripMenuItem.Click += new System.EventHandler(this.onMenuRechargerInfos);
            // 
            // rechargerLesInformationsDepuisLeSiteToolStripMenuItem
            // 
            this.rechargerLesInformationsDepuisLeSiteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allocinefrToolStripMenuItem});
            this.rechargerLesInformationsDepuisLeSiteToolStripMenuItem.Name = "rechargerLesInformationsDepuisLeSiteToolStripMenuItem";
            this.rechargerLesInformationsDepuisLeSiteToolStripMenuItem.Size = new System.Drawing.Size(323, 22);
            this.rechargerLesInformationsDepuisLeSiteToolStripMenuItem.Text = "Recharger les informations depuis le site";
            this.rechargerLesInformationsDepuisLeSiteToolStripMenuItem.DropDownOpening += new System.EventHandler(this.onDropDownRechargerDepuis);
            // 
            // allocinefrToolStripMenuItem
            // 
            this.allocinefrToolStripMenuItem.Name = "allocinefrToolStripMenuItem";
            this.allocinefrToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.allocinefrToolStripMenuItem.Text = "Allocine.fr";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(320, 6);
            // 
            // copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem
            // 
            this.copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem.Name = "copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem";
            this.copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem.Size = new System.Drawing.Size(323, 22);
            this.copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem.Text = "Copier sur une clef USB ou support amovible";
            this.copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem.Click += new System.EventHandler(this.onMenuCopierSurClefUSB);
            // 
            // copierSurToolStripMenuItem
            // 
            this.copierSurToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usbToolStripMenuItem});
            this.copierSurToolStripMenuItem.Name = "copierSurToolStripMenuItem";
            this.copierSurToolStripMenuItem.Size = new System.Drawing.Size(323, 22);
            this.copierSurToolStripMenuItem.Text = "Copier sur";
            this.copierSurToolStripMenuItem.DropDownOpening += new System.EventHandler(this.onDropdownCopierSur);
            // 
            // usbToolStripMenuItem
            // 
            this.usbToolStripMenuItem.Name = "usbToolStripMenuItem";
            this.usbToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            this.usbToolStripMenuItem.Text = "usbusbusbusbusbusbusbusbusbusbusbusb";
            // 
            // timerChangeFiltre
            // 
            this.timerChangeFiltre.Interval = 700;
            this.timerChangeFiltre.Tick += new System.EventHandler(this.onTimerChangeFiltre);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Fichiers films|*.avi;*.mkv;*.mp4|Tous les fichiers|*.*";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.SupportMultiDottedExtensions = true;
            this.openFileDialog.Title = "Choisissez des films à ajouter à la collection";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 741);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(statusStrip1);
            this.Controls.Add(menuStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = menuStrip1;
            this.Name = "MainForm";
            this.Text = "Collection de films";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onClosing);
            this.Load += new System.EventHandler(this.onLoad);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControlAlternatives.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.flowLayoutPanelInfosFilm.ResumeLayout(false);
            this.flowLayoutPanelInfosFilm.PerformLayout();
            this.flowLayoutPanelPasTrouve.ResumeLayout(false);
            this.flowLayoutPanelPasTrouve.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAffiche)).EndInit();
            this.flowLayoutPanelInfos.ResumeLayout(false);
            this.flowLayoutPanelInfos.PerformLayout();
            this.tabpageAlternatives.ResumeLayout(false);
            this.contextMenuFilm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listViewFilms;
        private System.Windows.Forms.RichTextBox consoleRichTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ImageList imageListLarge;
        //private System.ComponentModel.BackgroundWorker bgWorkerChargePages;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.ToolStripMenuItem détailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagesToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListAlternatives;
        private System.Windows.Forms.ContextMenuStrip contextMenuFilm;
        private System.Windows.Forms.ToolStripMenuItem editerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rechargerLesInformationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lireLeFilmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afficherDansLExplorateurWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxFiltre;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TabControl tabControlAlternatives;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInfosFilm;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPasTrouve;
        private System.Windows.Forms.TextBox textBoxTitrePasTrouve;
        private System.Windows.Forms.Button buttonRelancerPasTrouve;
        private System.Windows.Forms.TabPage tabpageAlternatives;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listViewAlternatives;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNbFilmsBD;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNbAffiches;
        private System.Windows.Forms.Timer timerChangeFiltre;
        private System.Windows.Forms.Label labelEtat;
        private System.Windows.Forms.ToolStripMenuItem copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar tsProgressbarCopieEnCours;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFichiersACopier;
        private System.Windows.Forms.ToolStripMenuItem effacerToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxAffiche;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInfos;
        private System.Windows.Forms.Label labelKeyRealisateur;
        private System.Windows.Forms.Label labelKeyActeurs;
        private System.Windows.Forms.Label labelKeyGenres;
        private System.Windows.Forms.Label labelKeyDateSortie;
        private System.Windows.Forms.Label labelDateSortie;
        private System.Windows.Forms.Label labelKeyNationalite;
        private System.Windows.Forms.Label labelNationalite;
        private System.Windows.Forms.Label labelKeyEtiquettes;
        private System.Windows.Forms.Label labelResume;
        private System.Windows.Forms.LinkLabel linkLabelActeurs;
        private System.Windows.Forms.LinkLabel linkLabelRealisateur;
        private System.Windows.Forms.LinkLabel linkLabelGenres;
        private System.Windows.Forms.LinkLabel linkLabelChemin;
        private System.Windows.Forms.LinkLabel linkLabelTitre;
        private System.Windows.Forms.LinkLabel linkLabelEtiquettes;
        private System.Windows.Forms.ToolStripMenuItem marquerCommeVuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marquerCommeAVoirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem rechargerLesInformationsDepuisLeSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allocinefrToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem copierSurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usbToolStripMenuItem;
    }
}

