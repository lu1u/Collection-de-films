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
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.Windows.Forms.ColumnHeader columnHeader9;
            System.Windows.Forms.ColumnHeader columnHeader6;
            System.Windows.Forms.ColumnHeader columnHeader8;
            System.Windows.Forms.ColumnHeader columnHeader10;
            System.Windows.Forms.StatusStrip statusStrip1;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
            System.Windows.Forms.ToolStripMenuItem rechargerLesInformationsToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem filmsToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;
            System.Windows.Forms.ToolStripMenuItem toolStripMenu;
            this.toolStripStatusLabelNbFilmsBD = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelNbAffiches = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFichiersACopier = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgressbarCopieEnCours = new System.Windows.Forms.ToolStripProgressBar();
            this.ajouterDesFichiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnRépertoireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuCollections = new System.Windows.Forms.ToolStripMenuItem();
            this.exporterLaListeDesFilmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControlAlternatives = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelInfosFilm = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelPasTrouve = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxTitrePasTrouve = new System.Windows.Forms.TextBox();
            this.buttonRelancerPasTrouve = new System.Windows.Forms.Button();
            this.pictureBoxAffiche = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelInfos = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSupprimerAlternatives = new System.Windows.Forms.Button();
            this.labelKeyVuLe = new System.Windows.Forms.Label();
            this.labelVuLe = new System.Windows.Forms.Label();
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
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.linkLabelChemin = new System.Windows.Forms.LinkLabel();
            this.linkLabelTitre = new System.Windows.Forms.LinkLabel();
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
            this.separateurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.textboxFiltre = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripMenuSelectionVus = new CollectionDeFilms.MultiStateMenuItem();
            this.indifférentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nonVusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSelectionAVoir = new CollectionDeFilms.MultiStateMenuItem();
            this.aVoirIndifferentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aVoirOuiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aVoirNonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSelectionAlternatives = new CollectionDeFilms.MultiStateMenuItem();
            this.genresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEtiquettes = new System.Windows.Forms.ToolStripMenuItem();
            label8 = new System.Windows.Forms.Label();
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            rechargerLesInformationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            copierSurUneClefUSBOuSupportAmovibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            toolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip1.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuFilm.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            // columnHeader1
            // 
            columnHeader1.Text = " Réalisateur";
            columnHeader1.Width = 103;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Résumé";
            columnHeader9.Width = 100;
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
            // statusStrip1
            // 
            statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelNbFilmsBD,
            this.toolStripStatusLabelNbAffiches,
            this.toolStripStatusLabel,
            this.toolStripStatusLabelFichiersACopier,
            this.tsProgressbarCopieEnCours});
            statusStrip1.Location = new System.Drawing.Point(0, 862);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(1583, 22);
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
            // filmsToolStripMenuItem
            // 
            filmsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterDesFichiersToolStripMenuItem,
            this.ajouterUnRépertoireToolStripMenuItem});
            filmsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            filmsToolStripMenuItem.Image = global::CollectionDeFilms.Resources.ajouter;
            filmsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            filmsToolStripMenuItem.Name = "filmsToolStripMenuItem";
            filmsToolStripMenuItem.Size = new System.Drawing.Size(117, 71);
            filmsToolStripMenuItem.Text = "Ajouter";
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
            configurationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            configurationToolStripMenuItem.Size = new System.Drawing.Size(150, 71);
            configurationToolStripMenuItem.Text = "Configuration";
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
            toolStripMenuItem3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size(94, 71);
            toolStripMenuItem3.Text = "Film";
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
            // toolStripMenu
            // 
            toolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuCollections,
            this.exporterLaListeDesFilmsToolStripMenuItem});
            toolStripMenu.ForeColor = System.Drawing.Color.White;
            toolStripMenu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenu.Image")));
            toolStripMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripMenu.Name = "toolStripMenu";
            toolStripMenu.Size = new System.Drawing.Size(138, 71);
            toolStripMenu.Text = "Collections";
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
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
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
            this.splitContainer2.Panel1.Controls.Add(this.tabControlAlternatives);
            this.splitContainer2.Panel1.Controls.Add(this.linkLabelChemin);
            this.splitContainer2.Panel1.Controls.Add(this.linkLabelTitre);
            this.splitContainer2.Panel1.Controls.Add(this.labelEtat);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(8);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.LightGray;
            this.splitContainer2.Panel2.Controls.Add(this.listViewFilms);
            this.splitContainer2.Size = new System.Drawing.Size(1583, 630);
            this.splitContainer2.SplitterDistance = 308;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer2_SplitterMoved);
            // 
            // tabControlAlternatives
            // 
            this.tabControlAlternatives.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAlternatives.Controls.Add(this.tabPage1);
            this.tabControlAlternatives.Controls.Add(this.tabpageAlternatives);
            this.tabControlAlternatives.HotTrack = true;
            this.tabControlAlternatives.Location = new System.Drawing.Point(0, 55);
            this.tabControlAlternatives.Name = "tabControlAlternatives";
            this.tabControlAlternatives.SelectedIndex = 0;
            this.tabControlAlternatives.Size = new System.Drawing.Size(306, 572);
            this.tabControlAlternatives.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControlAlternatives.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanelInfosFilm);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(298, 546);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Film";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelInfosFilm
            // 
            this.flowLayoutPanelInfosFilm.AutoScroll = true;
            this.flowLayoutPanelInfosFilm.AutoSize = true;
            this.flowLayoutPanelInfosFilm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelInfosFilm.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelInfosFilm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.flowLayoutPanelInfosFilm.Controls.Add(this.flowLayoutPanelPasTrouve);
            this.flowLayoutPanelInfosFilm.Controls.Add(this.pictureBoxAffiche);
            this.flowLayoutPanelInfosFilm.Controls.Add(this.flowLayoutPanelInfos);
            this.flowLayoutPanelInfosFilm.Controls.Add(this.labelResume);
            this.flowLayoutPanelInfosFilm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelInfosFilm.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelInfosFilm.Name = "flowLayoutPanelInfosFilm";
            this.flowLayoutPanelInfosFilm.Size = new System.Drawing.Size(292, 540);
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
            // 
            // pictureBoxAffiche
            // 
            this.pictureBoxAffiche.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxAffiche.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelInfosFilm.SetFlowBreak(this.pictureBoxAffiche, true);
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
            this.flowLayoutPanelInfos.Controls.Add(this.buttonSupprimerAlternatives);
            this.flowLayoutPanelInfos.Controls.Add(this.labelKeyVuLe);
            this.flowLayoutPanelInfos.Controls.Add(this.labelVuLe);
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
            this.flowLayoutPanelInfos.Location = new System.Drawing.Point(3, 156);
            this.flowLayoutPanelInfos.Name = "flowLayoutPanelInfos";
            this.flowLayoutPanelInfos.Size = new System.Drawing.Size(264, 120);
            this.flowLayoutPanelInfos.TabIndex = 19;
            // 
            // buttonSupprimerAlternatives
            // 
            this.flowLayoutPanelInfos.SetFlowBreak(this.buttonSupprimerAlternatives, true);
            this.buttonSupprimerAlternatives.Location = new System.Drawing.Point(3, 3);
            this.buttonSupprimerAlternatives.Name = "buttonSupprimerAlternatives";
            this.buttonSupprimerAlternatives.Size = new System.Drawing.Size(218, 23);
            this.buttonSupprimerAlternatives.TabIndex = 8;
            this.buttonSupprimerAlternatives.Text = "Supprimer les autres alternatives";
            this.buttonSupprimerAlternatives.UseVisualStyleBackColor = true;
            this.buttonSupprimerAlternatives.Click += new System.EventHandler(this.ButtonSupprimerAlternatives_Click);
            // 
            // labelKeyVuLe
            // 
            this.labelKeyVuLe.AutoSize = true;
            this.labelKeyVuLe.Location = new System.Drawing.Point(3, 29);
            this.labelKeyVuLe.Name = "labelKeyVuLe";
            this.labelKeyVuLe.Size = new System.Drawing.Size(34, 13);
            this.labelKeyVuLe.TabIndex = 35;
            this.labelKeyVuLe.Text = "Vu le:";
            // 
            // labelVuLe
            // 
            this.labelVuLe.AutoSize = true;
            this.flowLayoutPanelInfos.SetFlowBreak(this.labelVuLe, true);
            this.labelVuLe.Location = new System.Drawing.Point(43, 29);
            this.labelVuLe.Name = "labelVuLe";
            this.labelVuLe.Size = new System.Drawing.Size(54, 13);
            this.labelVuLe.TabIndex = 36;
            this.labelVuLe.Text = "labelVuLe";
            // 
            // labelKeyRealisateur
            // 
            this.labelKeyRealisateur.AutoSize = true;
            this.labelKeyRealisateur.BackColor = System.Drawing.Color.Transparent;
            this.labelKeyRealisateur.Location = new System.Drawing.Point(3, 42);
            this.labelKeyRealisateur.Name = "labelKeyRealisateur";
            this.labelKeyRealisateur.Size = new System.Drawing.Size(24, 13);
            this.labelKeyRealisateur.TabIndex = 37;
            this.labelKeyRealisateur.Text = "De:";
            // 
            // linkLabelRealisateur
            // 
            this.linkLabelRealisateur.AutoSize = true;
            this.flowLayoutPanelInfos.SetFlowBreak(this.linkLabelRealisateur, true);
            this.linkLabelRealisateur.Location = new System.Drawing.Point(33, 42);
            this.linkLabelRealisateur.Name = "linkLabelRealisateur";
            this.linkLabelRealisateur.Size = new System.Drawing.Size(55, 13);
            this.linkLabelRealisateur.TabIndex = 38;
            this.linkLabelRealisateur.TabStop = true;
            this.linkLabelRealisateur.Text = "linkLabel1";
            // 
            // labelKeyActeurs
            // 
            this.labelKeyActeurs.AutoSize = true;
            this.labelKeyActeurs.BackColor = System.Drawing.Color.Transparent;
            this.labelKeyActeurs.Location = new System.Drawing.Point(3, 55);
            this.labelKeyActeurs.Name = "labelKeyActeurs";
            this.labelKeyActeurs.Size = new System.Drawing.Size(32, 13);
            this.labelKeyActeurs.TabIndex = 21;
            this.labelKeyActeurs.Text = "Avec";
            // 
            // linkLabelActeurs
            // 
            this.linkLabelActeurs.AutoSize = true;
            this.flowLayoutPanelInfos.SetFlowBreak(this.linkLabelActeurs, true);
            this.linkLabelActeurs.LinkArea = new System.Windows.Forms.LinkArea(0, 10);
            this.linkLabelActeurs.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelActeurs.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.linkLabelActeurs.Location = new System.Drawing.Point(41, 55);
            this.linkLabelActeurs.Name = "linkLabelActeurs";
            this.linkLabelActeurs.Size = new System.Drawing.Size(55, 13);
            this.linkLabelActeurs.TabIndex = 31;
            this.linkLabelActeurs.TabStop = true;
            this.linkLabelActeurs.Text = "linkLabel1";
            // 
            // labelKeyGenres
            // 
            this.labelKeyGenres.AutoSize = true;
            this.labelKeyGenres.BackColor = System.Drawing.Color.Transparent;
            this.labelKeyGenres.Location = new System.Drawing.Point(3, 68);
            this.labelKeyGenres.Name = "labelKeyGenres";
            this.labelKeyGenres.Size = new System.Drawing.Size(39, 13);
            this.labelKeyGenres.TabIndex = 23;
            this.labelKeyGenres.Text = "Genre:";
            // 
            // linkLabelGenres
            // 
            this.linkLabelGenres.AutoSize = true;
            this.flowLayoutPanelInfos.SetFlowBreak(this.linkLabelGenres, true);
            this.linkLabelGenres.Location = new System.Drawing.Point(48, 68);
            this.linkLabelGenres.Name = "linkLabelGenres";
            this.linkLabelGenres.Size = new System.Drawing.Size(55, 13);
            this.linkLabelGenres.TabIndex = 33;
            this.linkLabelGenres.TabStop = true;
            this.linkLabelGenres.Text = "linkLabel1";
            // 
            // labelKeyDateSortie
            // 
            this.labelKeyDateSortie.AutoSize = true;
            this.labelKeyDateSortie.BackColor = System.Drawing.Color.Transparent;
            this.labelKeyDateSortie.Location = new System.Drawing.Point(3, 81);
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
            this.labelDateSortie.Location = new System.Drawing.Point(46, 81);
            this.labelDateSortie.Name = "labelDateSortie";
            this.labelDateSortie.Size = new System.Drawing.Size(47, 13);
            this.labelDateSortie.TabIndex = 26;
            this.labelDateSortie.Text = "xxxxxxxx";
            // 
            // labelKeyNationalite
            // 
            this.labelKeyNationalite.AutoSize = true;
            this.labelKeyNationalite.BackColor = System.Drawing.Color.Transparent;
            this.labelKeyNationalite.Location = new System.Drawing.Point(3, 94);
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
            this.labelNationalite.Location = new System.Drawing.Point(69, 94);
            this.labelNationalite.Name = "labelNationalite";
            this.labelNationalite.Size = new System.Drawing.Size(47, 13);
            this.labelNationalite.TabIndex = 28;
            this.labelNationalite.Text = "xxxxxxxx";
            // 
            // labelKeyEtiquettes
            // 
            this.labelKeyEtiquettes.AutoSize = true;
            this.labelKeyEtiquettes.BackColor = System.Drawing.Color.Transparent;
            this.labelKeyEtiquettes.Location = new System.Drawing.Point(3, 107);
            this.labelKeyEtiquettes.Name = "labelKeyEtiquettes";
            this.labelKeyEtiquettes.Size = new System.Drawing.Size(57, 13);
            this.labelKeyEtiquettes.TabIndex = 29;
            this.labelKeyEtiquettes.Text = "Etiquettes:";
            // 
            // linkLabelEtiquettes
            // 
            this.linkLabelEtiquettes.AutoSize = true;
            this.flowLayoutPanelInfos.SetFlowBreak(this.linkLabelEtiquettes, true);
            this.linkLabelEtiquettes.Location = new System.Drawing.Point(66, 107);
            this.linkLabelEtiquettes.Name = "linkLabelEtiquettes";
            this.linkLabelEtiquettes.Size = new System.Drawing.Size(55, 13);
            this.linkLabelEtiquettes.TabIndex = 34;
            this.linkLabelEtiquettes.TabStop = true;
            this.linkLabelEtiquettes.Text = "linkLabel1";
            // 
            // labelResume
            // 
            this.labelResume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelResume.AutoSize = true;
            this.labelResume.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelInfosFilm.SetFlowBreak(this.labelResume, true);
            this.labelResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResume.Location = new System.Drawing.Point(3, 279);
            this.labelResume.Name = "labelResume";
            this.labelResume.Size = new System.Drawing.Size(49, 15);
            this.labelResume.TabIndex = 32;
            this.labelResume.Text = "résumé";
            // 
            // tabpageAlternatives
            // 
            this.tabpageAlternatives.AccessibleName = "tabAlternatives";
            this.tabpageAlternatives.Controls.Add(this.label7);
            this.tabpageAlternatives.Controls.Add(this.listViewAlternatives);
            this.tabpageAlternatives.Location = new System.Drawing.Point(4, 22);
            this.tabpageAlternatives.Name = "tabpageAlternatives";
            this.tabpageAlternatives.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageAlternatives.Size = new System.Drawing.Size(298, 546);
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
            this.label7.Size = new System.Drawing.Size(288, 26);
            this.label7.TabIndex = 2;
            this.label7.Text = "Plusieurs alternatives ont été trouvées pour ce film, veuillez choisir celle qui " +
    "correspond le mieux en double-cliquant sur la ligne";
            // 
            // listViewAlternatives
            // 
            this.listViewAlternatives.BackColor = System.Drawing.Color.Silver;
            this.listViewAlternatives.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewAlternatives.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1,
            columnHeader9,
            columnHeader6,
            columnHeader8,
            columnHeader10});
            this.listViewAlternatives.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewAlternatives.FullRowSelect = true;
            this.listViewAlternatives.GridLines = true;
            this.listViewAlternatives.HideSelection = false;
            this.listViewAlternatives.Location = new System.Drawing.Point(3, 42);
            this.listViewAlternatives.MultiSelect = false;
            this.listViewAlternatives.Name = "listViewAlternatives";
            this.listViewAlternatives.ShowGroups = false;
            this.listViewAlternatives.ShowItemToolTips = true;
            this.listViewAlternatives.Size = new System.Drawing.Size(292, 501);
            this.listViewAlternatives.SmallImageList = this.imageList2;
            this.listViewAlternatives.TabIndex = 7;
            this.listViewAlternatives.UseCompatibleStateImageBehavior = false;
            this.listViewAlternatives.View = System.Windows.Forms.View.Details;
            this.listViewAlternatives.DoubleClick += new System.EventHandler(this.onListviewAlternativesDoubleClick);
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(96, 96);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // linkLabelChemin
            // 
            this.linkLabelChemin.AutoSize = true;
            this.linkLabelChemin.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelChemin.LinkColor = System.Drawing.Color.Black;
            this.linkLabelChemin.Location = new System.Drawing.Point(2, 26);
            this.linkLabelChemin.Name = "linkLabelChemin";
            this.linkLabelChemin.Size = new System.Drawing.Size(55, 13);
            this.linkLabelChemin.TabIndex = 25;
            this.linkLabelChemin.TabStop = true;
            this.linkLabelChemin.Text = "linkLabel1";
            // 
            // linkLabelTitre
            // 
            this.linkLabelTitre.AutoSize = true;
            this.linkLabelTitre.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelTitre.ForeColor = System.Drawing.Color.White;
            this.linkLabelTitre.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelTitre.LinkColor = System.Drawing.Color.White;
            this.linkLabelTitre.Location = new System.Drawing.Point(2, 0);
            this.linkLabelTitre.Name = "linkLabelTitre";
            this.linkLabelTitre.Size = new System.Drawing.Size(59, 26);
            this.linkLabelTitre.TabIndex = 24;
            this.linkLabelTitre.TabStop = true;
            this.linkLabelTitre.Text = "Titre";
            // 
            // labelEtat
            // 
            this.labelEtat.AutoSize = true;
            this.labelEtat.Location = new System.Drawing.Point(2, 39);
            this.labelEtat.Name = "labelEtat";
            this.labelEtat.Size = new System.Drawing.Size(35, 13);
            this.labelEtat.TabIndex = 23;
            this.labelEtat.Text = "label9";
            // 
            // listViewFilms
            // 
            this.listViewFilms.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewFilms.BackColor = System.Drawing.Color.DimGray;
            this.listViewFilms.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.listViewFilms.Size = new System.Drawing.Size(1271, 630);
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
            this.splitContainer1.Size = new System.Drawing.Size(1583, 788);
            this.splitContainer1.SplitterDistance = 630;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer1_SplitterMoved);
            // 
            // consoleRichTextBox
            // 
            this.consoleRichTextBox.BackColor = System.Drawing.Color.Black;
            this.consoleRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleRichTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleRichTextBox.ForeColor = System.Drawing.Color.Lime;
            this.consoleRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.consoleRichTextBox.Name = "consoleRichTextBox";
            this.consoleRichTextBox.Size = new System.Drawing.Size(1583, 154);
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
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem11,
            toolStripMenu,
            filmsToolStripMenuItem,
            configurationToolStripMenuItem,
            toolStripMenuItem3,
            this.separateurToolStripMenuItem,
            this.toolStripLabel1,
            this.textboxFiltre,
            this.toolStripButton1,
            this.toolStripMenuSelectionVus,
            this.toolStripMenuSelectionAVoir,
            this.toolStripMenuSelectionAlternatives,
            this.genresToolStripMenuItem,
            this.toolStripMenuItemEtiquettes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Size = new System.Drawing.Size(1583, 71);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
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
            // separateurToolStripMenuItem
            // 
            this.separateurToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.separateurToolStripMenuItem.Enabled = false;
            this.separateurToolStripMenuItem.Image = global::CollectionDeFilms.Resources.separateur;
            this.separateurToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.separateurToolStripMenuItem.Name = "separateurToolStripMenuItem";
            this.separateurToolStripMenuItem.Size = new System.Drawing.Size(21, 71);
            this.separateurToolStripMenuItem.Text = "separateur";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            this.toolStripLabel1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.toolStripLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(121, 68);
            this.toolStripLabel1.Text = "Sélection:";
            this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(40, 68);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.onCliqueEffaceRequete);
            // 
            // toolStripMenuSelectionVus
            // 
            this.toolStripMenuSelectionVus.Checked = true;
            this.toolStripMenuSelectionVus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuSelectionVus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.indifférentToolStripMenuItem,
            this.vusToolStripMenuItem,
            this.nonVusToolStripMenuItem});
            this.toolStripMenuSelectionVus.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuSelectionVus.Image = global::CollectionDeFilms.Resources.genres;
            this.toolStripMenuSelectionVus.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripMenuSelectionVus.Name = "toolStripMenuSelectionVus";
            this.toolStripMenuSelectionVus.Size = new System.Drawing.Size(84, 71);
            this.toolStripMenuSelectionVus.Text = "Films vus";
            this.toolStripMenuSelectionVus.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripMenuSelectionVus.ToolTipText = "Sélectionne uniquement les films vus, non vus, ou indifférents";
            // 
            // indifférentToolStripMenuItem
            // 
            this.indifférentToolStripMenuItem.Checked = true;
            this.indifférentToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.indifférentToolStripMenuItem.Name = "indifférentToolStripMenuItem";
            this.indifférentToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.indifférentToolStripMenuItem.Text = "Indifférent";
            this.indifférentToolStripMenuItem.Click += new System.EventHandler(this.IndifférentToolStripMenuItem_Click);
            // 
            // vusToolStripMenuItem
            // 
            this.vusToolStripMenuItem.Name = "vusToolStripMenuItem";
            this.vusToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.vusToolStripMenuItem.Text = "Vus";
            this.vusToolStripMenuItem.Click += new System.EventHandler(this.onToolStripFilmsVu);
            // 
            // nonVusToolStripMenuItem
            // 
            this.nonVusToolStripMenuItem.Name = "nonVusToolStripMenuItem";
            this.nonVusToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.nonVusToolStripMenuItem.Text = "Non vus";
            this.nonVusToolStripMenuItem.Click += new System.EventHandler(this.NonVusToolStripMenuItem_Click);
            // 
            // toolStripMenuSelectionAVoir
            // 
            this.toolStripMenuSelectionAVoir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aVoirIndifferentToolStripMenuItem,
            this.aVoirOuiToolStripMenuItem,
            this.aVoirNonToolStripMenuItem});
            this.toolStripMenuSelectionAVoir.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuSelectionAVoir.Image = global::CollectionDeFilms.Resources.genres;
            this.toolStripMenuSelectionAVoir.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripMenuSelectionAVoir.Name = "toolStripMenuSelectionAVoir";
            this.toolStripMenuSelectionAVoir.Size = new System.Drawing.Size(95, 71);
            this.toolStripMenuSelectionAVoir.Text = "Films à voir";
            this.toolStripMenuSelectionAVoir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripMenuSelectionAVoir.ToolTipText = "Sélectionne uniquement les films marqués \"A voir\", non marqués, ou indifférents";
            // 
            // aVoirIndifferentToolStripMenuItem
            // 
            this.aVoirIndifferentToolStripMenuItem.Checked = true;
            this.aVoirIndifferentToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aVoirIndifferentToolStripMenuItem.Name = "aVoirIndifferentToolStripMenuItem";
            this.aVoirIndifferentToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.aVoirIndifferentToolStripMenuItem.Text = "Indifférent";
            this.aVoirIndifferentToolStripMenuItem.Click += new System.EventHandler(this.onToolStripMenuAVoirIndiferrent);
            // 
            // aVoirOuiToolStripMenuItem
            // 
            this.aVoirOuiToolStripMenuItem.Name = "aVoirOuiToolStripMenuItem";
            this.aVoirOuiToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.aVoirOuiToolStripMenuItem.Text = "A voir";
            this.aVoirOuiToolStripMenuItem.Click += new System.EventHandler(this.onToolStripMenuAVoirOui);
            // 
            // aVoirNonToolStripMenuItem
            // 
            this.aVoirNonToolStripMenuItem.Name = "aVoirNonToolStripMenuItem";
            this.aVoirNonToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.aVoirNonToolStripMenuItem.Text = "Non à voir";
            this.aVoirNonToolStripMenuItem.Click += new System.EventHandler(this.onToolStripMenuAVoirNon);
            // 
            // toolStripMenuSelectionAlternatives
            // 
            this.toolStripMenuSelectionAlternatives.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuSelectionAlternatives.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripMenuSelectionAlternatives.Name = "toolStripMenuSelectionAlternatives";
            this.toolStripMenuSelectionAlternatives.Size = new System.Drawing.Size(81, 71);
            this.toolStripMenuSelectionAlternatives.Text = "Alternatives";
            this.toolStripMenuSelectionAlternatives.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripMenuSelectionAlternatives.ToolTipText = "Sélectionne uniquement les films ayant des alternatives trouvées sur Internet";
            // 
            // genresToolStripMenuItem
            // 
            this.genresToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.genresToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("genresToolStripMenuItem.Image")));
            this.genresToolStripMenuItem.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.genresToolStripMenuItem.Name = "genresToolStripMenuItem";
            this.genresToolStripMenuItem.Size = new System.Drawing.Size(71, 71);
            this.genresToolStripMenuItem.Text = "Genres";
            this.genresToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.genresToolStripMenuItem.DropDownOpening += new System.EventHandler(this.onGenresToolStripMenuItemDropDownOpening);
            // 
            // toolStripMenuItemEtiquettes
            // 
            this.toolStripMenuItemEtiquettes.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItemEtiquettes.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemEtiquettes.Image")));
            this.toolStripMenuItemEtiquettes.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripMenuItemEtiquettes.Name = "toolStripMenuItemEtiquettes";
            this.toolStripMenuItemEtiquettes.Size = new System.Drawing.Size(87, 71);
            this.toolStripMenuItemEtiquettes.Text = "Etiquettes";
            this.toolStripMenuItemEtiquettes.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripMenuItemEtiquettes.DropDownOpening += new System.EventHandler(this.onEtiquettesToolStripMenuItemDropDownOpening);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1583, 884);
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
            this.tabPage1.PerformLayout();
            this.flowLayoutPanelInfosFilm.ResumeLayout(false);
            this.flowLayoutPanelInfosFilm.PerformLayout();
            this.flowLayoutPanelPasTrouve.ResumeLayout(false);
            this.flowLayoutPanelPasTrouve.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAffiche)).EndInit();
            this.flowLayoutPanelInfos.ResumeLayout(false);
            this.flowLayoutPanelInfos.PerformLayout();
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
        private System.Windows.Forms.LinkLabel linkLabelChemin;
        private System.Windows.Forms.LinkLabel linkLabelTitre;
        private System.Windows.Forms.Label labelEtat;
        private System.Windows.Forms.TabControl tabControlAlternatives;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInfosFilm;
        private System.Windows.Forms.TextBox textBoxTitrePasTrouve;
        private System.Windows.Forms.Button buttonRelancerPasTrouve;
        private System.Windows.Forms.PictureBox pictureBoxAffiche;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInfos;
        private System.Windows.Forms.Label labelKeyActeurs;
        private System.Windows.Forms.LinkLabel linkLabelActeurs;
        private System.Windows.Forms.Label labelKeyGenres;
        private System.Windows.Forms.LinkLabel linkLabelGenres;
        private System.Windows.Forms.Label labelKeyDateSortie;
        private System.Windows.Forms.Label labelDateSortie;
        private System.Windows.Forms.Label labelKeyNationalite;
        private System.Windows.Forms.Label labelNationalite;
        private System.Windows.Forms.Label labelKeyEtiquettes;
        private System.Windows.Forms.LinkLabel linkLabelEtiquettes;
        private System.Windows.Forms.Label labelResume;
        private System.Windows.Forms.Button buttonSupprimerAlternatives;
        private System.Windows.Forms.TabPage tabpageAlternatives;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listViewAlternatives;
        private System.Windows.Forms.Timer timerChangeFiltre;
        private System.Windows.Forms.ToolStripMenuItem ajouterDesFichiersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnRépertoireToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox textboxFiltre;
        private System.Windows.Forms.ToolStripButton toolStripButton1;

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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPasTrouve;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem separateurToolStripMenuItem;
        private System.Windows.Forms.Label labelKeyVuLe;
        private System.Windows.Forms.Label labelVuLe;
        private System.Windows.Forms.Label labelKeyRealisateur;
        private System.Windows.Forms.LinkLabel linkLabelRealisateur;
        private System.Windows.Forms.ToolStripMenuItem genresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEtiquettes;
        private System.Windows.Forms.ToolStripMenuItem indifférentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nonVusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aVoirIndifferentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aVoirOuiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aVoirNonToolStripMenuItem;
        private MultiStateMenuItem toolStripMenuSelectionAVoir;
        private MultiStateMenuItem toolStripMenuSelectionAlternatives;
        private MultiStateMenuItem toolStripMenuSelectionVus;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuCollections;
        private System.Windows.Forms.ToolStripMenuItem exporterLaListeDesFilmsToolStripMenuItem;
    }
}

