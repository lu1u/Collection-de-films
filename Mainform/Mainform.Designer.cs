using CollectionDeFilms;

namespace CollectionDeFilms
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
            if (disposing)
            {
                _copieFichiers?.Dispose();
                _actionsDifferees?.Dispose();
                components?.Dispose();
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
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.Windows.Forms.ColumnHeader columnHeader3;
            System.Windows.Forms.ColumnHeader columnHeader5;
            System.Windows.Forms.ColumnHeader columnHeader4;
            System.Windows.Forms.ColumnHeader columnHeader2;
            System.Windows.Forms.StatusStrip statusStrip1;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
            System.Windows.Forms.ToolStripMenuItem rechargerLesInformationsToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem;
            System.Windows.Forms.ColumnHeader columnHeader0;
            System.Windows.Forms.ToolStripMenuItem toolStripMenu;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ToolStripMenuItem filmsToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;
            System.Windows.Forms.ToolStripMenuItem separateurToolStripMenuItem;
            System.Windows.Forms.ToolStripLabel toolStripLabel1;
            System.Windows.Forms.Label label8;
            this.toolStripStatusLabelNbFilmsBD = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelNbAffiches = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFichiersACopier = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgressbarCopieEnCours = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripMenuCollections = new System.Windows.Forms.ToolStripMenuItem();
            this.exporterLaListeDesFilmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterDesFichiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnRépertoireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.labelTitre = new System.Windows.Forms.Label();
            this.tabControlAlternatives = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelInfos = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelInfosFilm = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSupprimerAlternatives = new System.Windows.Forms.Button();
            this.flowLayoutPanelPasTrouve = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxTitrePasTrouve = new System.Windows.Forms.TextBox();
            this.buttonRelancerPasTrouve = new System.Windows.Forms.Button();
            this.listeProprietesFilm = new CollectionDeFilms.ControlesUtilisateur.ListeProprietes();
            this.tabpageAlternatives = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.listViewAlternatives = new System.Windows.Forms.ListView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.labelEtat = new System.Windows.Forms.Label();
            this.listViewFilms = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.consoleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.timerChangeFiltre = new System.Windows.Forms.Timer(this.components);
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.rechargerLesInformationsDepuisLeSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allocinefrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.copierSurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFilm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.textboxFiltre = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.multiStateToolstripMenuItemVus = new CollectionDeFilms.MultistateToolstripMenuItem();
            this.multistateToolstripMenuItem2 = new CollectionDeFilms.MultistateToolstripMenuItem();
            this.genresToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxGenres = new System.Windows.Forms.ToolStripComboBox();
            this.etiquettesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxEtiquettes = new System.Windows.Forms.ToolStripComboBox();
            this.triToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxTri = new System.Windows.Forms.ToolStripComboBox();
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            rechargerLesInformationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            toolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            filmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            separateurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            label8 = new System.Windows.Forms.Label();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControlAlternatives.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanelInfos.SuspendLayout();
            this.flowLayoutPanelInfosFilm.SuspendLayout();
            this.flowLayoutPanelPasTrouve.SuspendLayout();
            this.tabpageAlternatives.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuFilm.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader1
            // 
            columnHeader1.Text = " Réalisateur";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Résumé";
            columnHeader3.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Genres";
            columnHeader5.Width = 96;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Acteurs";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Date de sortie";
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
            statusStrip1.Location = new System.Drawing.Point(0, 755);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(1754, 22);
            statusStrip1.TabIndex = 2;
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
            // toolStripStatusLabelFichiersACopier
            // 
            this.toolStripStatusLabelFichiersACopier.Name = "toolStripStatusLabelFichiersACopier";
            this.toolStripStatusLabelFichiersACopier.Size = new System.Drawing.Size(95, 17);
            this.toolStripStatusLabelFichiersACopier.Text = "Fichiers a copier:";
            this.toolStripStatusLabelFichiersACopier.Visible = false;
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
            this.tsProgressbarCopieEnCours.Click += new System.EventHandler(this.onClickProgressCopie);
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.ShortcutKeyDisplayString = "Alt+L";
            toolStripMenuItem5.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            toolStripMenuItem5.Size = new System.Drawing.Size(323, 22);
            toolStripMenuItem5.Text = "Lire le film";
            toolStripMenuItem5.Click += new System.EventHandler(this.onFilmContextMenuLireLeFilm);
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            toolStripMenuItem6.Size = new System.Drawing.Size(323, 22);
            toolStripMenuItem6.Text = "Marquer comme vu";
            toolStripMenuItem6.Click += new System.EventHandler(this.onFilmContextMenuLireMarquerVu);
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            toolStripMenuItem7.Size = new System.Drawing.Size(323, 22);
            toolStripMenuItem7.Text = "Marquer comme A voir";
            toolStripMenuItem7.Click += new System.EventHandler(this.onFilmContextMenuLireMarquerAVoir);
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            toolStripMenuItem8.Size = new System.Drawing.Size(323, 22);
            toolStripMenuItem8.Text = "Afficher dans l\'Explorateur Windows";
            toolStripMenuItem8.Click += new System.EventHandler(this.onFilmContextMenuLireExplorer);
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            toolStripMenuItem9.Size = new System.Drawing.Size(323, 22);
            toolStripMenuItem9.Text = "Editer";
            toolStripMenuItem9.Click += new System.EventHandler(this.onFilmContextMenuLireEditer);
            // 
            // toolStripMenuItem10
            // 
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            toolStripMenuItem10.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            toolStripMenuItem10.Size = new System.Drawing.Size(323, 22);
            toolStripMenuItem10.Text = "Supprimer de la base";
            toolStripMenuItem10.Click += new System.EventHandler(this.onFilmContextMenuLireSupprimer);
            // 
            // rechargerLesInformationsToolStripMenuItem
            // 
            rechargerLesInformationsToolStripMenuItem.Name = "rechargerLesInformationsToolStripMenuItem";
            rechargerLesInformationsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            rechargerLesInformationsToolStripMenuItem.Size = new System.Drawing.Size(323, 22);
            rechargerLesInformationsToolStripMenuItem.Text = "Recharger les informations";
            rechargerLesInformationsToolStripMenuItem.Click += new System.EventHandler(this.onFilmContextMenuLireRecharger);
            // 
            // copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem
            // 
            copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem.Name = "copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem";
            copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem.Size = new System.Drawing.Size(323, 22);
            copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem.Text = "Copier sur une clef USB ou support amovible";
            copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem.Click += new System.EventHandler(this.onFilmContextMenuLireCopierSurCle);
            // 
            // columnHeader0
            // 
            columnHeader0.Text = "Titre";
            // 
            // toolStripMenu
            // 
            toolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuCollections,
            this.exporterLaListeDesFilmsToolStripMenuItem});
            toolStripMenu.ForeColor = System.Drawing.Color.White;
            toolStripMenu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenu.Image")));
            toolStripMenu.Name = "toolStripMenu";
            toolStripMenu.Size = new System.Drawing.Size(78, 71);
            toolStripMenu.Text = "Collections";
            toolStripMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripMenuCollections
            // 
            this.toolStripMenuCollections.Name = "toolStripMenuCollections";
            this.toolStripMenuCollections.Size = new System.Drawing.Size(204, 22);
            this.toolStripMenuCollections.Text = "Gestion des collections";
            this.toolStripMenuCollections.Click += new System.EventHandler(this.onToolStripMenuCollections);
            // 
            // exporterLaListeDesFilmsToolStripMenuItem
            // 
            this.exporterLaListeDesFilmsToolStripMenuItem.Name = "exporterLaListeDesFilmsToolStripMenuItem";
            this.exporterLaListeDesFilmsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.exporterLaListeDesFilmsToolStripMenuItem.Text = "Exporter la liste des films";
            this.exporterLaListeDesFilmsToolStripMenuItem.Click += new System.EventHandler(this.onExporterListeFilmsMenuItem);
            // 
            // filmsToolStripMenuItem
            // 
            filmsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterDesFichiersToolStripMenuItem,
            this.ajouterUnRépertoireToolStripMenuItem});
            filmsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            filmsToolStripMenuItem.Image = global::CollectionDeFilms.Resources.ajouter;
            filmsToolStripMenuItem.Name = "filmsToolStripMenuItem";
            filmsToolStripMenuItem.Size = new System.Drawing.Size(58, 71);
            filmsToolStripMenuItem.Text = "Ajouter";
            filmsToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ajouterDesFichiersToolStripMenuItem
            // 
            this.ajouterDesFichiersToolStripMenuItem.Name = "ajouterDesFichiersToolStripMenuItem";
            this.ajouterDesFichiersToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.ajouterDesFichiersToolStripMenuItem.Text = "Ajouter des fichiers...";
            this.ajouterDesFichiersToolStripMenuItem.Click += new System.EventHandler(this.onMenuItemAjouterFichiers);
            // 
            // ajouterUnRépertoireToolStripMenuItem
            // 
            this.ajouterUnRépertoireToolStripMenuItem.Name = "ajouterUnRépertoireToolStripMenuItem";
            this.ajouterUnRépertoireToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.ajouterUnRépertoireToolStripMenuItem.Text = "Ajouter un répertoire...";
            this.ajouterUnRépertoireToolStripMenuItem.Click += new System.EventHandler(this.onMenuAjouterRepertoire);
            // 
            // configurationToolStripMenuItem
            // 
            configurationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            configurationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("configurationToolStripMenuItem.Image")));
            configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 71);
            configurationToolStripMenuItem.Text = "Configuration";
            configurationToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            configurationToolStripMenuItem.Click += new System.EventHandler(this.onToolStripMenuConfiguration);
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripMenuItem1,
            toolStripMenuItem2,
            toolStripMenuItem4,
            toolStripMenuItem12,
            this.toolStripSeparator1,
            toolStripMenuItem13,
            toolStripMenuItem14,
            this.toolStripSeparator2,
            toolStripMenuItem15,
            this.toolStripMenuItem16,
            this.toolStripSeparator6,
            toolStripMenuItem18});
            toolStripMenuItem3.ForeColor = System.Drawing.Color.White;
            toolStripMenuItem3.Image = global::CollectionDeFilms.Resources.menu_film;
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size(44, 71);
            toolStripMenuItem3.Text = "Film";
            toolStripMenuItem3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            toolStripMenuItem1.Size = new System.Drawing.Size(348, 22);
            toolStripMenuItem1.Text = "Lire le film";
            toolStripMenuItem1.Click += new System.EventHandler(this.onFilmContextMenuLireLeFilm);
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            toolStripMenuItem2.Size = new System.Drawing.Size(348, 22);
            toolStripMenuItem2.Text = "Marquer comme vu";
            toolStripMenuItem2.Click += new System.EventHandler(this.onFilmContextMenuLireMarquerVu);
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            toolStripMenuItem4.Size = new System.Drawing.Size(348, 22);
            toolStripMenuItem4.Text = "Marquer comme A voir";
            toolStripMenuItem4.Click += new System.EventHandler(this.onFilmContextMenuLireMarquerAVoir);
            // 
            // toolStripMenuItem12
            // 
            toolStripMenuItem12.Name = "toolStripMenuItem12";
            toolStripMenuItem12.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            toolStripMenuItem12.Size = new System.Drawing.Size(348, 22);
            toolStripMenuItem12.Text = "Afficher dans l\'Explorateur Windows";
            toolStripMenuItem12.Click += new System.EventHandler(this.onFilmContextMenuLireExplorer);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(345, 6);
            // 
            // toolStripMenuItem13
            // 
            toolStripMenuItem13.Name = "toolStripMenuItem13";
            toolStripMenuItem13.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            toolStripMenuItem13.Size = new System.Drawing.Size(348, 22);
            toolStripMenuItem13.Text = "Editer";
            toolStripMenuItem13.Click += new System.EventHandler(this.onFilmContextMenuLireEditer);
            // 
            // toolStripMenuItem14
            // 
            toolStripMenuItem14.Name = "toolStripMenuItem14";
            toolStripMenuItem14.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            toolStripMenuItem14.Size = new System.Drawing.Size(348, 22);
            toolStripMenuItem14.Text = "Supprimer de la base";
            toolStripMenuItem14.Click += new System.EventHandler(this.onFilmContextMenuLireSupprimer);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(345, 6);
            // 
            // toolStripMenuItem15
            // 
            toolStripMenuItem15.Name = "toolStripMenuItem15";
            toolStripMenuItem15.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            toolStripMenuItem15.Size = new System.Drawing.Size(348, 22);
            toolStripMenuItem15.Text = "Recharger les informations";
            toolStripMenuItem15.Click += new System.EventHandler(this.onFilmContextMenuLireRecharger);
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem17});
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(348, 22);
            this.toolStripMenuItem16.Text = "Recharger les informations depuis le site";
            this.toolStripMenuItem16.Click += new System.EventHandler(this.onContextMenuRechargerDepuisDropDownOpening);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem17.Text = "Allocine.fr";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(345, 6);
            // 
            // toolStripMenuItem18
            // 
            toolStripMenuItem18.Name = "toolStripMenuItem18";
            toolStripMenuItem18.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            toolStripMenuItem18.Size = new System.Drawing.Size(348, 22);
            toolStripMenuItem18.Text = "Copier sur une clef USB ou support amovible";
            toolStripMenuItem18.Click += new System.EventHandler(this.onFilmContextMenuLireCopierSurCle);
            // 
            // separateurToolStripMenuItem
            // 
            separateurToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            separateurToolStripMenuItem.Enabled = false;
            separateurToolStripMenuItem.Image = global::CollectionDeFilms.Resources.separateur;
            separateurToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            separateurToolStripMenuItem.Name = "separateurToolStripMenuItem";
            separateurToolStripMenuItem.Size = new System.Drawing.Size(21, 71);
            separateurToolStripMenuItem.Text = "separateur";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.AutoSize = false;
            toolStripLabel1.BackColor = System.Drawing.Color.Transparent;
            toolStripLabel1.ForeColor = System.Drawing.Color.White;
            toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            toolStripLabel1.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new System.Drawing.Size(101, 68);
            toolStripLabel1.Text = "Sélection:";
            toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            toolStripLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // label8
            // 
            label8.AutoSize = true;
            this.flowLayoutPanelPasTrouve.SetFlowBreak(label8, true);
            label8.Location = new System.Drawing.Point(3, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(315, 26);
            label8.TabIndex = 3;
            label8.Text = "Film non trouvé sur internet, vous pouvez tenter de corriger le titre et relancer" +
    " la recherche";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(120, 200);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(117)))), ((int)(((byte)(171)))));
            this.splitContainer2.Panel1.Controls.Add(this.labelTitre);
            this.splitContainer2.Panel1.Controls.Add(this.tabControlAlternatives);
            this.splitContainer2.Panel1.Controls.Add(this.labelEtat);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(8);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.LightGray;
            this.splitContainer2.Panel2.Controls.Add(this.listViewFilms);
            this.splitContainer2.Size = new System.Drawing.Size(1754, 543);
            this.splitContainer2.SplitterDistance = 341;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.onSplitContainer2Moved);
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitre.ForeColor = System.Drawing.Color.White;
            this.labelTitre.Location = new System.Drawing.Point(1, 0);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(70, 26);
            this.labelTitre.TabIndex = 27;
            this.labelTitre.Text = "label1";
            // 
            // tabControlAlternatives
            // 
            this.tabControlAlternatives.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAlternatives.Controls.Add(this.tabPage1);
            this.tabControlAlternatives.Controls.Add(this.tabpageAlternatives);
            this.tabControlAlternatives.HotTrack = true;
            this.tabControlAlternatives.Location = new System.Drawing.Point(0, 42);
            this.tabControlAlternatives.Name = "tabControlAlternatives";
            this.tabControlAlternatives.SelectedIndex = 0;
            this.tabControlAlternatives.Size = new System.Drawing.Size(339, 498);
            this.tabControlAlternatives.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanelInfos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(331, 472);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Film";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelInfos
            // 
            this.flowLayoutPanelInfos.AutoScroll = true;
            this.flowLayoutPanelInfos.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelInfos.Controls.Add(this.flowLayoutPanelInfosFilm);
            this.flowLayoutPanelInfos.Controls.Add(this.listeProprietesFilm);
            this.flowLayoutPanelInfos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelInfos.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelInfos.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.flowLayoutPanelInfos.Name = "flowLayoutPanelInfos";
            this.flowLayoutPanelInfos.Size = new System.Drawing.Size(325, 466);
            this.flowLayoutPanelInfos.TabIndex = 19;
            // 
            // flowLayoutPanelInfosFilm
            // 
            this.flowLayoutPanelInfosFilm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelInfosFilm.AutoSize = true;
            this.flowLayoutPanelInfosFilm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelInfosFilm.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelInfosFilm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.flowLayoutPanelInfosFilm.Controls.Add(this.buttonSupprimerAlternatives);
            this.flowLayoutPanelInfosFilm.Controls.Add(this.flowLayoutPanelPasTrouve);
            this.flowLayoutPanelInfosFilm.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelInfosFilm.Name = "flowLayoutPanelInfosFilm";
            this.flowLayoutPanelInfosFilm.Size = new System.Drawing.Size(328, 126);
            this.flowLayoutPanelInfosFilm.TabIndex = 7;
            // 
            // buttonSupprimerAlternatives
            // 
            this.flowLayoutPanelInfosFilm.SetFlowBreak(this.buttonSupprimerAlternatives, true);
            this.buttonSupprimerAlternatives.Location = new System.Drawing.Point(3, 3);
            this.buttonSupprimerAlternatives.Name = "buttonSupprimerAlternatives";
            this.buttonSupprimerAlternatives.Size = new System.Drawing.Size(218, 23);
            this.buttonSupprimerAlternatives.TabIndex = 8;
            this.buttonSupprimerAlternatives.Text = "Supprimer les autres alternatives";
            this.buttonSupprimerAlternatives.UseVisualStyleBackColor = true;
            this.buttonSupprimerAlternatives.Click += new System.EventHandler(this.ButtonSupprimerAlternatives_Click);
            // 
            // flowLayoutPanelPasTrouve
            // 
            this.flowLayoutPanelPasTrouve.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelPasTrouve.AutoScroll = true;
            this.flowLayoutPanelPasTrouve.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelPasTrouve.Controls.Add(label8);
            this.flowLayoutPanelPasTrouve.Controls.Add(this.textBoxTitrePasTrouve);
            this.flowLayoutPanelPasTrouve.Controls.Add(this.buttonRelancerPasTrouve);
            this.flowLayoutPanelInfosFilm.SetFlowBreak(this.flowLayoutPanelPasTrouve, true);
            this.flowLayoutPanelPasTrouve.Location = new System.Drawing.Point(3, 32);
            this.flowLayoutPanelPasTrouve.Name = "flowLayoutPanelPasTrouve";
            this.flowLayoutPanelPasTrouve.Size = new System.Drawing.Size(322, 91);
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
            this.buttonRelancerPasTrouve.Click += new System.EventHandler(this.ButtonRelancerPasTrouve_Click);
            // 
            // listeProprietesFilm
            // 
            this.listeProprietesFilm.Alternées = true;
            this.listeProprietesFilm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listeProprietesFilm.AutoSize = true;
            this.listeProprietesFilm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.listeProprietesFilm.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.listeProprietesFilm.CouleurLien = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.listeProprietesFilm.CouleurLienHover = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.listeProprietesFilm.CouleurLienVisite = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.listeProprietesFilm.CouleurTexte = System.Drawing.SystemColors.ControlText;
            this.listeProprietesFilm.DeuxiemeCouleur = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.flowLayoutPanelInfos.SetFlowBreak(this.listeProprietesFilm, true);
            this.listeProprietesFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listeProprietesFilm.Fonte = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.listeProprietesFilm.Interligne = 5;
            this.listeProprietesFilm.Location = new System.Drawing.Point(3, 135);
            this.listeProprietesFilm.MinimumSize = new System.Drawing.Size(327, 72);
            this.listeProprietesFilm.Name = "listeProprietesFilm";
            this.listeProprietesFilm.Size = new System.Drawing.Size(327, 72);
            this.listeProprietesFilm.TabIndex = 18;
            // 
            // tabpageAlternatives
            // 
            this.tabpageAlternatives.AccessibleName = "tabAlternatives";
            this.tabpageAlternatives.Controls.Add(this.label7);
            this.tabpageAlternatives.Controls.Add(this.listViewAlternatives);
            this.tabpageAlternatives.Location = new System.Drawing.Point(4, 22);
            this.tabpageAlternatives.Name = "tabpageAlternatives";
            this.tabpageAlternatives.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageAlternatives.Size = new System.Drawing.Size(331, 472);
            this.tabpageAlternatives.TabIndex = 1;
            this.tabpageAlternatives.Text = "Alternatives";
            this.tabpageAlternatives.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(325, 26);
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
            columnHeader0,
            columnHeader1,
            columnHeader2,
            columnHeader3,
            columnHeader4,
            columnHeader5});
            this.listViewAlternatives.FullRowSelect = true;
            this.listViewAlternatives.GridLines = true;
            this.listViewAlternatives.HideSelection = false;
            this.listViewAlternatives.Location = new System.Drawing.Point(3, 32);
            this.listViewAlternatives.MultiSelect = false;
            this.listViewAlternatives.Name = "listViewAlternatives";
            this.listViewAlternatives.ShowGroups = false;
            this.listViewAlternatives.ShowItemToolTips = true;
            this.listViewAlternatives.Size = new System.Drawing.Size(325, 437);
            this.listViewAlternatives.SmallImageList = this.imageList2;
            this.listViewAlternatives.TabIndex = 7;
            this.listViewAlternatives.UseCompatibleStateImageBehavior = false;
            this.listViewAlternatives.View = System.Windows.Forms.View.Details;
            this.listViewAlternatives.DoubleClick += new System.EventHandler(this.onListviewAlternativesDoubleClick);
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(96, 96);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // labelEtat
            // 
            this.labelEtat.AutoSize = true;
            this.labelEtat.Location = new System.Drawing.Point(3, 26);
            this.labelEtat.Name = "labelEtat";
            this.labelEtat.Size = new System.Drawing.Size(35, 13);
            this.labelEtat.TabIndex = 23;
            this.labelEtat.Text = "label9";
            // 
            // listViewFilms
            // 
            this.listViewFilms.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewFilms.BackColor = System.Drawing.Color.Gray;
            this.listViewFilms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewFilms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFilms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewFilms.ForeColor = System.Drawing.Color.White;
            this.listViewFilms.GridLines = true;
            this.listViewFilms.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewFilms.HideSelection = false;
            this.listViewFilms.HotTracking = true;
            this.listViewFilms.HoverSelection = true;
            this.listViewFilms.LargeImageList = this.imageList1;
            this.listViewFilms.Location = new System.Drawing.Point(0, 0);
            this.listViewFilms.MultiSelect = false;
            this.listViewFilms.Name = "listViewFilms";
            this.listViewFilms.OwnerDraw = true;
            this.listViewFilms.ShowGroups = false;
            this.listViewFilms.ShowItemToolTips = true;
            this.listViewFilms.Size = new System.Drawing.Size(1409, 543);
            this.listViewFilms.TabIndex = 0;
            this.listViewFilms.TileSize = new System.Drawing.Size(256, 256);
            this.listViewFilms.UseCompatibleStateImageBehavior = false;
            this.listViewFilms.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.onListviewFilmsDrawItem);
            this.listViewFilms.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.onListFilmsSelectionChanged);
            this.listViewFilms.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onListviewFilmsMouseClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.DimGray;
            this.splitContainer1.Location = new System.Drawing.Point(0, 71);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel2.Controls.Add(this.consoleRichTextBox);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(1754, 681);
            this.splitContainer1.SplitterDistance = 543;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.onSplitContainer1Moved);
            // 
            // consoleRichTextBox
            // 
            this.consoleRichTextBox.BackColor = System.Drawing.Color.Black;
            this.consoleRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleRichTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleRichTextBox.ForeColor = System.Drawing.Color.Lime;
            this.consoleRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.consoleRichTextBox.Name = "consoleRichTextBox";
            this.consoleRichTextBox.Size = new System.Drawing.Size(1754, 134);
            this.consoleRichTextBox.TabIndex = 1;
            this.consoleRichTextBox.Text = "=======================================\nCollection de fichier 0.1\n(c) Lucien Pill" +
    "oni 2016\n=======================================\n";
            // 
            // timerChangeFiltre
            // 
            this.timerChangeFiltre.Interval = 800;
            this.timerChangeFiltre.Tick += new System.EventHandler(this.TimerChangeFiltre_Tick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(320, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(320, 6);
            // 
            // rechargerLesInformationsDepuisLeSiteToolStripMenuItem
            // 
            this.rechargerLesInformationsDepuisLeSiteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allocinefrToolStripMenuItem});
            this.rechargerLesInformationsDepuisLeSiteToolStripMenuItem.Name = "rechargerLesInformationsDepuisLeSiteToolStripMenuItem";
            this.rechargerLesInformationsDepuisLeSiteToolStripMenuItem.Size = new System.Drawing.Size(323, 22);
            this.rechargerLesInformationsDepuisLeSiteToolStripMenuItem.Text = "Recharger les informations depuis le site";
            this.rechargerLesInformationsDepuisLeSiteToolStripMenuItem.Visible = false;
            this.rechargerLesInformationsDepuisLeSiteToolStripMenuItem.DropDownOpening += new System.EventHandler(this.onContextMenuRechargerDepuisDropDownOpening);
            // 
            // allocinefrToolStripMenuItem
            // 
            this.allocinefrToolStripMenuItem.Name = "allocinefrToolStripMenuItem";
            this.allocinefrToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.allocinefrToolStripMenuItem.Text = "Allocine.fr";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(320, 6);
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
            // contextMenuFilm
            // 
            this.contextMenuFilm.BackColor = System.Drawing.SystemColors.Menu;
            this.contextMenuFilm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripMenuItem5,
            toolStripMenuItem6,
            toolStripMenuItem7,
            toolStripMenuItem8,
            this.toolStripSeparator3,
            toolStripMenuItem9,
            toolStripMenuItem10,
            this.toolStripSeparator4,
            rechargerLesInformationsToolStripMenuItem,
            this.rechargerLesInformationsDepuisLeSiteToolStripMenuItem,
            this.toolStripSeparator5,
            copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem,
            this.copierSurToolStripMenuItem});
            this.contextMenuFilm.Name = "contextMenuStripFilm";
            this.contextMenuFilm.ShowImageMargin = false;
            this.contextMenuFilm.Size = new System.Drawing.Size(324, 242);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Fichiers films|*.avi;*.mkv;*.mp4|Tous les fichiers|*.*";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.SupportMultiDottedExtensions = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(117)))), ((int)(((byte)(171)))));
            this.menuStrip1.BackgroundImage = global::CollectionDeFilms.Resources.toolbar;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem11,
            toolStripMenu,
            filmsToolStripMenuItem,
            configurationToolStripMenuItem,
            toolStripMenuItem3,
            separateurToolStripMenuItem,
            toolStripLabel1,
            this.textboxFiltre,
            this.toolStripButton1,
            this.multiStateToolstripMenuItemVus,
            this.multistateToolstripMenuItem2,
            this.genresToolStripMenuItem1,
            this.toolStripComboBoxGenres,
            this.etiquettesToolStripMenuItem,
            this.toolStripComboBoxEtiquettes,
            this.triToolStripMenuItem,
            this.toolStripComboBoxTri});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(1754, 71);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.AutoSize = false;
            this.toolStripMenuItem11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem11.Image = global::CollectionDeFilms.Resources.logo;
            this.toolStripMenuItem11.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(200, 68);
            // 
            // textboxFiltre
            // 
            this.textboxFiltre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.textboxFiltre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textboxFiltre.HideSelection = false;
            this.textboxFiltre.Name = "textboxFiltre";
            this.textboxFiltre.ShortcutsEnabled = false;
            this.textboxFiltre.Size = new System.Drawing.Size(150, 71);
            this.textboxFiltre.ToolTipText = resources.GetString("textboxFiltre.ToolTipText");
            this.textboxFiltre.TextChanged += new System.EventHandler(this.onTextBoxFiltreTextChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 68);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.onCliqueEffaceRequete);
            // 
            // multiStateToolstripMenuItemVus
            // 
            this.multiStateToolstripMenuItemVus.AssociatedEnumValue = null;
            this.multiStateToolstripMenuItemVus.AutoSize = false;
            this.multiStateToolstripMenuItemVus.CheckOnClick = true;
            this.multiStateToolstripMenuItemVus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.multiStateToolstripMenuItemVus.ForeColor = System.Drawing.Color.White;
            this.multiStateToolstripMenuItemVus.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.multiStateToolstripMenuItemVus.Name = "multiStateToolstripMenuItemVus";
            this.multiStateToolstripMenuItemVus.Padding = new System.Windows.Forms.Padding(4);
            this.multiStateToolstripMenuItemVus.Size = new System.Drawing.Size(122, 71);
            this.multiStateToolstripMenuItemVus.States = new string[] {
        "Indifférent",
        "Vus",
        "Non vus"};
            this.multiStateToolstripMenuItemVus.Text = "Films vus:";
            this.multiStateToolstripMenuItemVus.EtatChange += new System.EventHandler(this.onClicFilmsVus);
            // 
            // multistateToolstripMenuItem2
            // 
            this.multistateToolstripMenuItem2.AssociatedEnumValue = null;
            this.multistateToolstripMenuItem2.AutoSize = false;
            this.multistateToolstripMenuItem2.CheckOnClick = true;
            this.multistateToolstripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.multistateToolstripMenuItem2.ForeColor = System.Drawing.Color.White;
            this.multistateToolstripMenuItem2.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.multistateToolstripMenuItem2.Name = "multistateToolstripMenuItem2";
            this.multistateToolstripMenuItem2.Padding = new System.Windows.Forms.Padding(4);
            this.multistateToolstripMenuItem2.Size = new System.Drawing.Size(122, 71);
            this.multistateToolstripMenuItem2.States = new string[] {
        "Indifférent",
        "A voir",
        "Pas à voir"};
            this.multistateToolstripMenuItem2.Text = "Films à voir:";
            this.multistateToolstripMenuItem2.EtatChange += new System.EventHandler(this.onClicFilmsAVoir);
            // 
            // genresToolStripMenuItem1
            // 
            this.genresToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.genresToolStripMenuItem1.Name = "genresToolStripMenuItem1";
            this.genresToolStripMenuItem1.Size = new System.Drawing.Size(58, 71);
            this.genresToolStripMenuItem1.Text = "Genres:";
            // 
            // toolStripComboBoxGenres
            // 
            this.toolStripComboBoxGenres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.toolStripComboBoxGenres.DropDownHeight = 600;
            this.toolStripComboBoxGenres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxGenres.DropDownWidth = 190;
            this.toolStripComboBoxGenres.IntegralHeight = false;
            this.toolStripComboBoxGenres.Name = "toolStripComboBoxGenres";
            this.toolStripComboBoxGenres.Size = new System.Drawing.Size(121, 71);
            this.toolStripComboBoxGenres.Sorted = true;
            this.toolStripComboBoxGenres.SelectedIndexChanged += new System.EventHandler(this.onToolStripComboBoxGenresSelectedIndexChanged);
            // 
            // etiquettesToolStripMenuItem
            // 
            this.etiquettesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.etiquettesToolStripMenuItem.Name = "etiquettesToolStripMenuItem";
            this.etiquettesToolStripMenuItem.Size = new System.Drawing.Size(74, 71);
            this.etiquettesToolStripMenuItem.Text = "Etiquettes:";
            // 
            // toolStripComboBoxEtiquettes
            // 
            this.toolStripComboBoxEtiquettes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.toolStripComboBoxEtiquettes.DropDownHeight = 600;
            this.toolStripComboBoxEtiquettes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxEtiquettes.IntegralHeight = false;
            this.toolStripComboBoxEtiquettes.Name = "toolStripComboBoxEtiquettes";
            this.toolStripComboBoxEtiquettes.Size = new System.Drawing.Size(181, 71);
            this.toolStripComboBoxEtiquettes.Sorted = true;
            this.toolStripComboBoxEtiquettes.SelectedIndexChanged += new System.EventHandler(this.onToolStripComboBoxEtiquettesSelectedChanged);
            // 
            // triToolStripMenuItem
            // 
            this.triToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.triToolStripMenuItem.Name = "triToolStripMenuItem";
            this.triToolStripMenuItem.Size = new System.Drawing.Size(34, 71);
            this.triToolStripMenuItem.Text = "Tri:";
            // 
            // toolStripComboBoxTri
            // 
            this.toolStripComboBoxTri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.toolStripComboBoxTri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxTri.Items.AddRange(new object[] {
            "▲ Titre",
            "▼ Titre",
            "▲ Durée",
            "▼ Durée",
            "▲ Date de vue",
            "▼ Date de vue",
            "▲ Date d\'ajout",
            "▼ Date d\'ajout"});
            this.toolStripComboBoxTri.Name = "toolStripComboBoxTri";
            this.toolStripComboBoxTri.Size = new System.Drawing.Size(121, 71);
            this.toolStripComboBoxTri.SelectedIndexChanged += new System.EventHandler(this.onTriSelectedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1754, 777);
            this.Controls.Add(statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Collection de films";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
            this.Load += new System.EventHandler(this.onFormLoad);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControlAlternatives.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.flowLayoutPanelInfos.ResumeLayout(false);
            this.flowLayoutPanelInfos.PerformLayout();
            this.flowLayoutPanelInfosFilm.ResumeLayout(false);
            this.flowLayoutPanelPasTrouve.ResumeLayout(false);
            this.flowLayoutPanelPasTrouve.PerformLayout();
            this.tabpageAlternatives.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuFilm.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listViewFilms;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelEtat;
        private System.Windows.Forms.TabControl tabControlAlternatives;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInfosFilm;
        private System.Windows.Forms.TabPage tabpageAlternatives;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listViewAlternatives;
        private System.Windows.Forms.Timer timerChangeFiltre;

        private System.Windows.Forms.RichTextBox consoleRichTextBox;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNbFilmsBD;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNbAffiches;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFichiersACopier;
        private System.Windows.Forms.ToolStripProgressBar tsProgressbarCopieEnCours;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem rechargerLesInformationsDepuisLeSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allocinefrToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem copierSurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usbToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuFilm;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuCollections;
        private System.Windows.Forms.ToolStripMenuItem exporterLaListeDesFilmsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterDesFichiersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnRépertoireToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripTextBox textboxFiltre;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private MultistateToolstripMenuItem multiStateToolstripMenuItemVus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private MultistateToolstripMenuItem multistateToolstripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem triToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxTri;
        private System.Windows.Forms.ToolStripMenuItem genresToolStripMenuItem1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxGenres;
        private System.Windows.Forms.ToolStripMenuItem etiquettesToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxEtiquettes;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInfos;
        private System.Windows.Forms.Button buttonSupprimerAlternatives;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPasTrouve;
        private System.Windows.Forms.TextBox textBoxTitrePasTrouve;
        private System.Windows.Forms.Button buttonRelancerPasTrouve;
        private ControlesUtilisateur.ListeProprietes listeProprietesFilm;
        private System.Windows.Forms.Label labelTitre;
    }
}

