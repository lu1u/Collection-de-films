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
            System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
            System.Windows.Forms.MenuStrip menuStrip1;
            System.Windows.Forms.ToolStripMenuItem vueToolStripMenuItem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ToolStripMenuItem filtreToolStripMenuItem;
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnFichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnRépertoireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.détailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxFiltre = new System.Windows.Forms.ToolStripTextBox();
            this.effacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.filmTousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filmAvecInformationsManquantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filmsAvecAlternativesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabelFichiersACopier = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelNbFilmsBD = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelNbAffiches = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgressbarTotalCopie = new System.Windows.Forms.ToolStripProgressBar();
            this.tsProgressbarCopieEnCours = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listViewFilms = new System.Windows.Forms.ListView();
            this.columnHeaderGenres = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDateSortie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEtiquettes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderREsume = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.labelChemin = new System.Windows.Forms.Label();
            this.labelEtat = new System.Windows.Forms.Label();
            this.labelTitre = new System.Windows.Forms.Label();
            this.tabControlAlternatives = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelInfosFilm = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelPasTrouve = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxTitrePasTrouve = new System.Windows.Forms.TextBox();
            this.buttonRelancerPasTrouve = new System.Windows.Forms.Button();
            this.pictureBoxAffiche = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelKeyRealisateur = new System.Windows.Forms.Label();
            this.labelRealisateur = new System.Windows.Forms.Label();
            this.labelKeyActeurs = new System.Windows.Forms.Label();
            this.labelActeurs = new System.Windows.Forms.Label();
            this.labelKeyGenres = new System.Windows.Forms.Label();
            this.labelGenres = new System.Windows.Forms.Label();
            this.labelKeyDateSortie = new System.Windows.Forms.Label();
            this.labelDateSortie = new System.Windows.Forms.Label();
            this.labelKeyNationalite = new System.Windows.Forms.Label();
            this.labelNationalite = new System.Windows.Forms.Label();
            this.labelKeyEtiquettes = new System.Windows.Forms.Label();
            this.labelEtiquettes = new System.Windows.Forms.Label();
            this.labelResume = new System.Windows.Forms.Label();
            this.tabpageAlternatives = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listViewAlternatives = new System.Windows.Forms.ListView();
            this.imageListAlternatives = new System.Windows.Forms.ImageList(this.components);
            this.consoleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.bgWorkerChargePages = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStripFilm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rechargerLesInformationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lireLeFilmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afficherDansLExplorateurWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerChangeFiltre = new System.Windows.Forms.Timer(this.components);
            this.bgWorkerCopie = new System.ComponentModel.BackgroundWorker();
            this.filmsAvecAlternativesAucuneChoisieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            label8 = new System.Windows.Forms.Label();
            columnHeaderTitre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeaderREalisateur = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeaderActeurs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            vueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            filtreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.flowLayoutPanel1.SuspendLayout();
            this.tabpageAlternatives.SuspendLayout();
            this.contextMenuStripFilm.SuspendLayout();
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
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(89, 17);
            toolStripStatusLabel1.Text = "Copie en cours:";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = System.Drawing.Color.CornflowerBlue;
            menuStrip1.BackgroundImage = global::Collection_de_films.Properties.Resources.fondtoolbar;
            menuStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem,
            vueToolStripMenuItem,
            this.toolStripMenuItem1,
            filtreToolStripMenuItem,
            this.toolStripTextBoxFiltre,
            this.effacerToolStripMenuItem,
            this.toolStripMenuItem2,
            this.configurationToolStripMenuItem});
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(8);
            menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            menuStrip1.ShowItemToolTips = true;
            menuStrip1.Size = new System.Drawing.Size(1288, 68);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.AutoToolTip = true;
            this.ajouterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterUnFichierToolStripMenuItem,
            this.ajouterUnRépertoireToolStripMenuItem});
            this.ajouterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ajouterToolStripMenuItem.Image = global::Collection_de_films.Properties.Resources.ajouter;
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(106, 52);
            this.ajouterToolStripMenuItem.Text = "Ajouter";
            this.ajouterToolStripMenuItem.ToolTipText = "Ajouter un fichier ou un répertoire";
            // 
            // ajouterUnFichierToolStripMenuItem
            // 
            this.ajouterUnFichierToolStripMenuItem.Image = global::Collection_de_films.Properties.Resources.add_file;
            this.ajouterUnFichierToolStripMenuItem.Name = "ajouterUnFichierToolStripMenuItem";
            this.ajouterUnFichierToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.ajouterUnFichierToolStripMenuItem.Text = "Ajouter un fichier";
            // 
            // ajouterUnRépertoireToolStripMenuItem
            // 
            this.ajouterUnRépertoireToolStripMenuItem.Image = global::Collection_de_films.Properties.Resources.add_folder;
            this.ajouterUnRépertoireToolStripMenuItem.Name = "ajouterUnRépertoireToolStripMenuItem";
            this.ajouterUnRépertoireToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.ajouterUnRépertoireToolStripMenuItem.Text = "Ajouter un répertoire";
            this.ajouterUnRépertoireToolStripMenuItem.Click += new System.EventHandler(this.onClickMenuAjouterRepertoire);
            // 
            // vueToolStripMenuItem
            // 
            vueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.détailToolStripMenuItem,
            this.imagesToolStripMenuItem});
            vueToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            vueToolStripMenuItem.Image = global::Collection_de_films.Properties.Resources.vues;
            vueToolStripMenuItem.Name = "vueToolStripMenuItem";
            vueToolStripMenuItem.Size = new System.Drawing.Size(87, 52);
            vueToolStripMenuItem.Text = "Vue";
            // 
            // détailToolStripMenuItem
            // 
            this.détailToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("détailToolStripMenuItem.Image")));
            this.détailToolStripMenuItem.Name = "détailToolStripMenuItem";
            this.détailToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.détailToolStripMenuItem.Text = "Détail";
            this.détailToolStripMenuItem.Click += new System.EventHandler(this.détailToolStripMenuItem_Click);
            // 
            // imagesToolStripMenuItem
            // 
            this.imagesToolStripMenuItem.Image = global::Collection_de_films.Properties.Resources.thumbnails;
            this.imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
            this.imagesToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.imagesToolStripMenuItem.Text = "Images";
            this.imagesToolStripMenuItem.Click += new System.EventHandler(this.imagesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(40, 52);
            this.toolStripMenuItem1.Text = "       ";
            // 
            // filtreToolStripMenuItem
            // 
            filtreToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            filtreToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("filtreToolStripMenuItem.Image")));
            filtreToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            filtreToolStripMenuItem.Name = "filtreToolStripMenuItem";
            filtreToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            filtreToolStripMenuItem.Size = new System.Drawing.Size(92, 52);
            filtreToolStripMenuItem.Text = "Filtre:";
            // 
            // toolStripTextBoxFiltre
            // 
            this.toolStripTextBoxFiltre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.toolStripTextBoxFiltre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripTextBoxFiltre.Name = "toolStripTextBoxFiltre";
            this.toolStripTextBoxFiltre.Padding = new System.Windows.Forms.Padding(8);
            this.toolStripTextBoxFiltre.Size = new System.Drawing.Size(184, 52);
            this.toolStripTextBoxFiltre.ToolTipText = "Tapez un texte pour filtrer les films";
            this.toolStripTextBoxFiltre.TextChanged += new System.EventHandler(this.onTextBoxFiltreTextChanged);
            // 
            // effacerToolStripMenuItem
            // 
            this.effacerToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.effacerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.effacerToolStripMenuItem.Image = global::Collection_de_films.Properties.Resources.effacer;
            this.effacerToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.effacerToolStripMenuItem.Margin = new System.Windows.Forms.Padding(-10, 0, 10, 0);
            this.effacerToolStripMenuItem.Name = "effacerToolStripMenuItem";
            this.effacerToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.effacerToolStripMenuItem.Size = new System.Drawing.Size(52, 52);
            this.effacerToolStripMenuItem.Text = "effacer";
            this.effacerToolStripMenuItem.ToolTipText = "Effacer la requête";
            this.effacerToolStripMenuItem.Click += new System.EventHandler(this.onCliqueEffaceRequete);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filmTousToolStripMenuItem,
            this.filmAvecInformationsManquantesToolStripMenuItem,
            this.filmsAvecAlternativesToolStripMenuItem,
            this.filmsAvecAlternativesAucuneChoisieToolStripMenuItem});
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem2.Image = global::Collection_de_films.Properties.Resources.selection;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(115, 52);
            this.toolStripMenuItem2.Text = "Sélection";
            // 
            // filmTousToolStripMenuItem
            // 
            this.filmTousToolStripMenuItem.Checked = true;
            this.filmTousToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.filmTousToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.filmTousToolStripMenuItem.Name = "filmTousToolStripMenuItem";
            this.filmTousToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.filmTousToolStripMenuItem.Text = "Tous";
            this.filmTousToolStripMenuItem.Click += new System.EventHandler(this.filmsTousToolStripMenuItem_Click);
            // 
            // filmAvecInformationsManquantesToolStripMenuItem
            // 
            this.filmAvecInformationsManquantesToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.filmAvecInformationsManquantesToolStripMenuItem.Name = "filmAvecInformationsManquantesToolStripMenuItem";
            this.filmAvecInformationsManquantesToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.filmAvecInformationsManquantesToolStripMenuItem.Text = "Films non trouvés";
            this.filmAvecInformationsManquantesToolStripMenuItem.Click += new System.EventHandler(this.filmAvecInformationsManquantesToolStripMenuItem_Click);
            // 
            // filmsAvecAlternativesToolStripMenuItem
            // 
            this.filmsAvecAlternativesToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.filmsAvecAlternativesToolStripMenuItem.Name = "filmsAvecAlternativesToolStripMenuItem";
            this.filmsAvecAlternativesToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.filmsAvecAlternativesToolStripMenuItem.Text = "Films avec alternatives";
            this.filmsAvecAlternativesToolStripMenuItem.Click += new System.EventHandler(this.filmsAvecAlternativesToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.configurationToolStripMenuItem.Image = global::Collection_de_films.Properties.Resources.configuration;
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(141, 52);
            this.configurationToolStripMenuItem.Text = "Configuration";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.onClickConfiguration);
            // 
            // toolStripStatusLabelFichiersACopier
            // 
            this.toolStripStatusLabelFichiersACopier.Name = "toolStripStatusLabelFichiersACopier";
            this.toolStripStatusLabelFichiersACopier.Size = new System.Drawing.Size(95, 17);
            this.toolStripStatusLabelFichiersACopier.Text = "Fichiers a copier:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelNbFilmsBD,
            this.toolStripStatusLabelNbAffiches,
            this.toolStripStatusLabel,
            this.toolStripStatusLabelFichiersACopier,
            this.tsProgressbarTotalCopie,
            toolStripStatusLabel1,
            this.tsProgressbarCopieEnCours});
            this.statusStrip1.Location = new System.Drawing.Point(0, 719);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1288, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
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
            // tsProgressbarTotalCopie
            // 
            this.tsProgressbarTotalCopie.Name = "tsProgressbarTotalCopie";
            this.tsProgressbarTotalCopie.Size = new System.Drawing.Size(100, 16);
            this.tsProgressbarTotalCopie.ToolTipText = "Cliquez pour ouvrir la fenêtre de copie";
            this.tsProgressbarTotalCopie.Click += new System.EventHandler(this.onClicProgressCopie);
            // 
            // tsProgressbarCopieEnCours
            // 
            this.tsProgressbarCopieEnCours.Name = "tsProgressbarCopieEnCours";
            this.tsProgressbarCopieEnCours.Size = new System.Drawing.Size(100, 16);
            this.tsProgressbarCopieEnCours.Step = 1;
            this.tsProgressbarCopieEnCours.ToolTipText = "Cliquez pour ouvrir la fenêtre de copie";
            this.tsProgressbarCopieEnCours.Click += new System.EventHandler(this.onClicProgressCopie);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.DimGray;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 68);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.consoleRichTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(1288, 651);
            this.splitContainer1.SplitterDistance = 545;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.DimGray;
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
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.labelChemin);
            this.splitContainer2.Panel2.Controls.Add(this.labelEtat);
            this.splitContainer2.Panel2.Controls.Add(this.labelTitre);
            this.splitContainer2.Panel2.Controls.Add(this.tabControlAlternatives);
            this.splitContainer2.Size = new System.Drawing.Size(1288, 545);
            this.splitContainer2.SplitterDistance = 862;
            this.splitContainer2.TabIndex = 0;
            // 
            // listViewFilms
            // 
            this.listViewFilms.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewFilms.BackColor = System.Drawing.Color.DimGray;
            this.listViewFilms.BackgroundImageTiled = true;
            this.listViewFilms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewFilms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeaderTitre,
            this.columnHeaderGenres,
            columnHeaderREalisateur,
            columnHeaderActeurs,
            this.columnHeaderDateSortie,
            this.columnHeaderEtiquettes,
            this.columnHeaderREsume});
            this.listViewFilms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFilms.FullRowSelect = true;
            this.listViewFilms.LargeImageList = this.imageListLarge;
            this.listViewFilms.Location = new System.Drawing.Point(0, 0);
            this.listViewFilms.MultiSelect = false;
            this.listViewFilms.Name = "listViewFilms";
            this.listViewFilms.OwnerDraw = true;
            this.listViewFilms.ShowGroups = false;
            this.listViewFilms.ShowItemToolTips = true;
            this.listViewFilms.Size = new System.Drawing.Size(862, 545);
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
            // columnHeaderGenres
            // 
            this.columnHeaderGenres.Text = "Genres";
            // 
            // columnHeaderDateSortie
            // 
            this.columnHeaderDateSortie.Text = "Date de sortie";
            // 
            // columnHeaderEtiquettes
            // 
            this.columnHeaderEtiquettes.Text = "Etiquettes";
            // 
            // columnHeaderREsume
            // 
            this.columnHeaderREsume.Text = "Résumé";
            this.columnHeaderREsume.Width = 300;
            // 
            // imageListLarge
            // 
            this.imageListLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListLarge.ImageSize = new System.Drawing.Size(120, 160);
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageListSmall
            // 
            this.imageListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListSmall.ImageSize = new System.Drawing.Size(40, 40);
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // labelChemin
            // 
            this.labelChemin.AutoSize = true;
            this.labelChemin.Location = new System.Drawing.Point(13, 48);
            this.labelChemin.Name = "labelChemin";
            this.labelChemin.Size = new System.Drawing.Size(27, 13);
            this.labelChemin.TabIndex = 20;
            this.labelChemin.Text = "xxxx";
            // 
            // labelEtat
            // 
            this.labelEtat.AutoSize = true;
            this.labelEtat.Location = new System.Drawing.Point(13, 35);
            this.labelEtat.Name = "labelEtat";
            this.labelEtat.Size = new System.Drawing.Size(35, 13);
            this.labelEtat.TabIndex = 19;
            this.labelEtat.Text = "label9";
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.BackColor = System.Drawing.Color.Transparent;
            this.labelTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitre.ForeColor = System.Drawing.Color.DarkRed;
            this.labelTitre.Location = new System.Drawing.Point(13, 9);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(59, 26);
            this.labelTitre.TabIndex = 1;
            this.labelTitre.Text = "Titre";
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
            this.tabControlAlternatives.Size = new System.Drawing.Size(419, 478);
            this.tabControlAlternatives.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControlAlternatives.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanelInfosFilm);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(411, 452);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Film";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelInfosFilm
            // 
            this.flowLayoutPanelInfosFilm.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelInfosFilm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanelInfosFilm.Controls.Add(this.flowLayoutPanelPasTrouve);
            this.flowLayoutPanelInfosFilm.Controls.Add(this.pictureBoxAffiche);
            this.flowLayoutPanelInfosFilm.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanelInfosFilm.Controls.Add(this.labelResume);
            this.flowLayoutPanelInfosFilm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelInfosFilm.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelInfosFilm.Name = "flowLayoutPanelInfosFilm";
            this.flowLayoutPanelInfosFilm.Size = new System.Drawing.Size(405, 446);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.labelKeyRealisateur);
            this.flowLayoutPanel1.Controls.Add(this.labelRealisateur);
            this.flowLayoutPanel1.Controls.Add(this.labelKeyActeurs);
            this.flowLayoutPanel1.Controls.Add(this.labelActeurs);
            this.flowLayoutPanel1.Controls.Add(this.labelKeyGenres);
            this.flowLayoutPanel1.Controls.Add(this.labelGenres);
            this.flowLayoutPanel1.Controls.Add(this.labelKeyDateSortie);
            this.flowLayoutPanel1.Controls.Add(this.labelDateSortie);
            this.flowLayoutPanel1.Controls.Add(this.labelKeyNationalite);
            this.flowLayoutPanel1.Controls.Add(this.labelNationalite);
            this.flowLayoutPanel1.Controls.Add(this.labelKeyEtiquettes);
            this.flowLayoutPanel1.Controls.Add(this.labelEtiquettes);
            this.flowLayoutPanelInfosFilm.SetFlowBreak(this.flowLayoutPanel1, true);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(109, 100);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(119, 78);
            this.flowLayoutPanel1.TabIndex = 19;
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
            // labelRealisateur
            // 
            this.labelRealisateur.AutoSize = true;
            this.labelRealisateur.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.SetFlowBreak(this.labelRealisateur, true);
            this.labelRealisateur.Location = new System.Drawing.Point(33, 0);
            this.labelRealisateur.Name = "labelRealisateur";
            this.labelRealisateur.Size = new System.Drawing.Size(47, 13);
            this.labelRealisateur.TabIndex = 20;
            this.labelRealisateur.Text = "xxxxxxxx";
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
            // labelActeurs
            // 
            this.labelActeurs.AutoSize = true;
            this.labelActeurs.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.SetFlowBreak(this.labelActeurs, true);
            this.labelActeurs.Location = new System.Drawing.Point(41, 13);
            this.labelActeurs.Name = "labelActeurs";
            this.labelActeurs.Size = new System.Drawing.Size(47, 13);
            this.labelActeurs.TabIndex = 22;
            this.labelActeurs.Text = "xxxxxxxx";
            // 
            // labelKeyGenres
            // 
            this.labelKeyGenres.AutoSize = true;
            this.labelKeyGenres.BackColor = System.Drawing.Color.Transparent;
            this.labelKeyGenres.Location = new System.Drawing.Point(3, 26);
            this.labelKeyGenres.Name = "labelKeyGenres";
            this.labelKeyGenres.Size = new System.Drawing.Size(39, 13);
            this.labelKeyGenres.TabIndex = 23;
            this.labelKeyGenres.Text = "Genre:";
            // 
            // labelGenres
            // 
            this.labelGenres.AutoSize = true;
            this.labelGenres.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.SetFlowBreak(this.labelGenres, true);
            this.labelGenres.Location = new System.Drawing.Point(48, 26);
            this.labelGenres.Name = "labelGenres";
            this.labelGenres.Size = new System.Drawing.Size(47, 13);
            this.labelGenres.TabIndex = 24;
            this.labelGenres.Text = "xxxxxxxx";
            // 
            // labelKeyDateSortie
            // 
            this.labelKeyDateSortie.AutoSize = true;
            this.labelKeyDateSortie.BackColor = System.Drawing.Color.Transparent;
            this.labelKeyDateSortie.Location = new System.Drawing.Point(3, 39);
            this.labelKeyDateSortie.Name = "labelKeyDateSortie";
            this.labelKeyDateSortie.Size = new System.Drawing.Size(37, 13);
            this.labelKeyDateSortie.TabIndex = 25;
            this.labelKeyDateSortie.Text = "Sortie:";
            // 
            // labelDateSortie
            // 
            this.labelDateSortie.AutoSize = true;
            this.labelDateSortie.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.SetFlowBreak(this.labelDateSortie, true);
            this.labelDateSortie.Location = new System.Drawing.Point(46, 39);
            this.labelDateSortie.Name = "labelDateSortie";
            this.labelDateSortie.Size = new System.Drawing.Size(47, 13);
            this.labelDateSortie.TabIndex = 26;
            this.labelDateSortie.Text = "xxxxxxxx";
            // 
            // labelKeyNationalite
            // 
            this.labelKeyNationalite.AutoSize = true;
            this.labelKeyNationalite.BackColor = System.Drawing.Color.Transparent;
            this.labelKeyNationalite.Location = new System.Drawing.Point(3, 52);
            this.labelKeyNationalite.Name = "labelKeyNationalite";
            this.labelKeyNationalite.Size = new System.Drawing.Size(60, 13);
            this.labelKeyNationalite.TabIndex = 27;
            this.labelKeyNationalite.Text = "Nationalité:";
            // 
            // labelNationalite
            // 
            this.labelNationalite.AutoSize = true;
            this.labelNationalite.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.SetFlowBreak(this.labelNationalite, true);
            this.labelNationalite.Location = new System.Drawing.Point(69, 52);
            this.labelNationalite.Name = "labelNationalite";
            this.labelNationalite.Size = new System.Drawing.Size(47, 13);
            this.labelNationalite.TabIndex = 28;
            this.labelNationalite.Text = "xxxxxxxx";
            // 
            // labelKeyEtiquettes
            // 
            this.labelKeyEtiquettes.AutoSize = true;
            this.labelKeyEtiquettes.BackColor = System.Drawing.Color.Transparent;
            this.labelKeyEtiquettes.Location = new System.Drawing.Point(3, 65);
            this.labelKeyEtiquettes.Name = "labelKeyEtiquettes";
            this.labelKeyEtiquettes.Size = new System.Drawing.Size(57, 13);
            this.labelKeyEtiquettes.TabIndex = 29;
            this.labelKeyEtiquettes.Text = "Etiquettes:";
            // 
            // labelEtiquettes
            // 
            this.labelEtiquettes.AutoSize = true;
            this.labelEtiquettes.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.SetFlowBreak(this.labelEtiquettes, true);
            this.labelEtiquettes.Location = new System.Drawing.Point(66, 65);
            this.labelEtiquettes.Name = "labelEtiquettes";
            this.labelEtiquettes.Size = new System.Drawing.Size(47, 13);
            this.labelEtiquettes.TabIndex = 30;
            this.labelEtiquettes.Text = "xxxxxxxx";
            // 
            // labelResume
            // 
            this.labelResume.AutoSize = true;
            this.flowLayoutPanelInfosFilm.SetFlowBreak(this.labelResume, true);
            this.labelResume.Location = new System.Drawing.Point(3, 181);
            this.labelResume.Name = "labelResume";
            this.labelResume.Size = new System.Drawing.Size(35, 13);
            this.labelResume.TabIndex = 32;
            this.labelResume.Text = "label1";
            // 
            // tabpageAlternatives
            // 
            this.tabpageAlternatives.AccessibleName = "tabAlternatives";
            this.tabpageAlternatives.Controls.Add(this.checkBox1);
            this.tabpageAlternatives.Controls.Add(this.label7);
            this.tabpageAlternatives.Controls.Add(this.listViewAlternatives);
            this.tabpageAlternatives.Location = new System.Drawing.Point(4, 22);
            this.tabpageAlternatives.Name = "tabpageAlternatives";
            this.tabpageAlternatives.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageAlternatives.Size = new System.Drawing.Size(411, 452);
            this.tabpageAlternatives.TabIndex = 1;
            this.tabpageAlternatives.Text = "Alternatives";
            this.tabpageAlternatives.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(0, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(365, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Supprimer les autres alternatives quand j\'en sélectionne une pour ce film";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(0, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(411, 26);
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
            columnHeader6,
            columnHeader8,
            columnHeader10,
            columnHeader9});
            this.listViewAlternatives.FullRowSelect = true;
            this.listViewAlternatives.GridLines = true;
            this.listViewAlternatives.Location = new System.Drawing.Point(3, 62);
            this.listViewAlternatives.MultiSelect = false;
            this.listViewAlternatives.Name = "listViewAlternatives";
            this.listViewAlternatives.ShowGroups = false;
            this.listViewAlternatives.ShowItemToolTips = true;
            this.listViewAlternatives.Size = new System.Drawing.Size(402, 397);
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
            this.imageListAlternatives.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // consoleRichTextBox
            // 
            this.consoleRichTextBox.BackColor = System.Drawing.Color.Black;
            this.consoleRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleRichTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleRichTextBox.ForeColor = System.Drawing.Color.Lime;
            this.consoleRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.consoleRichTextBox.Name = "consoleRichTextBox";
            this.consoleRichTextBox.Size = new System.Drawing.Size(1288, 98);
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
            // bgWorkerChargePages
            // 
            this.bgWorkerChargePages.WorkerReportsProgress = true;
            this.bgWorkerChargePages.WorkerSupportsCancellation = true;
            this.bgWorkerChargePages.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerChargePagesDoWork);
            this.bgWorkerChargePages.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            // 
            // contextMenuStripFilm
            // 
            this.contextMenuStripFilm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editerToolStripMenuItem,
            this.supprimerToolStripMenuItem,
            this.rechargerLesInformationsToolStripMenuItem,
            this.lireLeFilmToolStripMenuItem,
            this.afficherDansLExplorateurWindowsToolStripMenuItem,
            this.copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem});
            this.contextMenuStripFilm.Name = "contextMenuStripFilm";
            this.contextMenuStripFilm.Size = new System.Drawing.Size(311, 136);
            // 
            // editerToolStripMenuItem
            // 
            this.editerToolStripMenuItem.Name = "editerToolStripMenuItem";
            this.editerToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.editerToolStripMenuItem.Text = "Editer";
            this.editerToolStripMenuItem.Click += new System.EventHandler(this.editerToolStripMenuItem_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.supprimerToolStripMenuItem.Text = "Supprimer de la base";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.onClicSupprimerDeLaBase);
            // 
            // rechargerLesInformationsToolStripMenuItem
            // 
            this.rechargerLesInformationsToolStripMenuItem.Name = "rechargerLesInformationsToolStripMenuItem";
            this.rechargerLesInformationsToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.rechargerLesInformationsToolStripMenuItem.Text = "Recharger les informations";
            this.rechargerLesInformationsToolStripMenuItem.Click += new System.EventHandler(this.onClickMenuRechargerInfos);
            // 
            // lireLeFilmToolStripMenuItem
            // 
            this.lireLeFilmToolStripMenuItem.Name = "lireLeFilmToolStripMenuItem";
            this.lireLeFilmToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.lireLeFilmToolStripMenuItem.Text = "Lire le film";
            this.lireLeFilmToolStripMenuItem.Click += new System.EventHandler(this.lireLeFilmToolStripMenuItem_Click);
            // 
            // afficherDansLExplorateurWindowsToolStripMenuItem
            // 
            this.afficherDansLExplorateurWindowsToolStripMenuItem.Name = "afficherDansLExplorateurWindowsToolStripMenuItem";
            this.afficherDansLExplorateurWindowsToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.afficherDansLExplorateurWindowsToolStripMenuItem.Text = "Afficher dans l\'Explorateur Windows";
            this.afficherDansLExplorateurWindowsToolStripMenuItem.Click += new System.EventHandler(this.afficherDansLExplorateurWindowsToolStripMenuItem_Click);
            // 
            // copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem
            // 
            this.copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem.Name = "copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem";
            this.copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem.Text = "Copier sur une clef USB ou support amovible";
            this.copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem.Click += new System.EventHandler(this.onClickCopierSurClefUSB);
            // 
            // timerChangeFiltre
            // 
            this.timerChangeFiltre.Interval = 500;
            this.timerChangeFiltre.Tick += new System.EventHandler(this.onTimerChangeFiltre);
            // 
            // bgWorkerCopie
            // 
            this.bgWorkerCopie.WorkerSupportsCancellation = true;
            this.bgWorkerCopie.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerCopieDoWork);
            // 
            // filmsAvecAlternativesAucuneChoisieToolStripMenuItem
            // 
            this.filmsAvecAlternativesAucuneChoisieToolStripMenuItem.Name = "filmsAvecAlternativesAucuneChoisieToolStripMenuItem";
            this.filmsAvecAlternativesAucuneChoisieToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.filmsAvecAlternativesAucuneChoisieToolStripMenuItem.Text = "Films avec alternatives, aucune choisie";
            this.filmsAvecAlternativesAucuneChoisieToolStripMenuItem.Click += new System.EventHandler(this.filmsAvecAlternativesAucuneChoisieToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 741);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(menuStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = menuStrip1;
            this.Name = "MainForm";
            this.Text = "Collection de films";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onClosing);
            this.Load += new System.EventHandler(this.onLoad);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
            this.flowLayoutPanelInfosFilm.ResumeLayout(false);
            this.flowLayoutPanelInfosFilm.PerformLayout();
            this.flowLayoutPanelPasTrouve.ResumeLayout(false);
            this.flowLayoutPanelPasTrouve.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAffiche)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabpageAlternatives.ResumeLayout(false);
            this.tabpageAlternatives.PerformLayout();
            this.contextMenuStripFilm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listViewFilms;
        private System.Windows.Forms.RichTextBox consoleRichTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ColumnHeader columnHeaderREsume;
        private System.Windows.Forms.ColumnHeader columnHeaderGenres;
        private System.Windows.Forms.ImageList imageListLarge;
        private System.ComponentModel.BackgroundWorker bgWorkerChargePages;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.ToolStripMenuItem détailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagesToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListAlternatives;
        private System.Windows.Forms.ColumnHeader columnHeaderDateSortie;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFilm;
        private System.Windows.Forms.ToolStripMenuItem editerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rechargerLesInformationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lireLeFilmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afficherDansLExplorateurWindowsToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeaderEtiquettes;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxFiltre;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnFichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnRépertoireToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem filmAvecInformationsManquantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filmsAvecAlternativesToolStripMenuItem;
        private System.Windows.Forms.Label labelChemin;
        private System.Windows.Forms.Label labelEtat;
        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.ToolStripMenuItem filmTousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar tsProgressbarCopieEnCours;
        private System.ComponentModel.BackgroundWorker bgWorkerCopie;
        private System.Windows.Forms.ToolStripProgressBar tsProgressbarTotalCopie;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFichiersACopier;
        private System.Windows.Forms.ToolStripMenuItem effacerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pictureBoxAffiche;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelKeyRealisateur;
        private System.Windows.Forms.Label labelRealisateur;
        private System.Windows.Forms.Label labelKeyActeurs;
        private System.Windows.Forms.Label labelActeurs;
        private System.Windows.Forms.Label labelKeyGenres;
        private System.Windows.Forms.Label labelGenres;
        private System.Windows.Forms.Label labelKeyDateSortie;
        private System.Windows.Forms.Label labelDateSortie;
        private System.Windows.Forms.Label labelKeyNationalite;
        private System.Windows.Forms.Label labelNationalite;
        private System.Windows.Forms.Label labelKeyEtiquettes;
        private System.Windows.Forms.Label labelEtiquettes;
        private System.Windows.Forms.Label labelResume;
        private System.Windows.Forms.ToolStripMenuItem filmsAvecAlternativesAucuneChoisieToolStripMenuItem;
    }
}

