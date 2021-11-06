namespace CollectionDeFilms.Fenetres
{
    partial class ConfigurationDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxRelanceRecherche = new System.Windows.Forms.CheckBox();
            this.checkBoxMenageFin = new System.Windows.Forms.CheckBox();
            this.checkBoxSupprimerAlternatives = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxRetailleImages = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxAfficheFilm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxInfosFilm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabelTMDB = new System.Windows.Forms.LinkLabel();
            this.textBoxChercherFilm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxRelanceRecherche
            // 
            this.checkBoxRelanceRecherche.AutoSize = true;
            this.checkBoxRelanceRecherche.Location = new System.Drawing.Point(13, 13);
            this.checkBoxRelanceRecherche.Name = "checkBoxRelanceRecherche";
            this.checkBoxRelanceRecherche.Size = new System.Drawing.Size(403, 17);
            this.checkBoxRelanceRecherche.TabIndex = 0;
            this.checkBoxRelanceRecherche.Text = "Au démarrage, relancer la recherche pour tous les films n\'ayant pas d\'information" +
    "";
            this.checkBoxRelanceRecherche.UseVisualStyleBackColor = true;
            // 
            // checkBoxMenageFin
            // 
            this.checkBoxMenageFin.AutoSize = true;
            this.checkBoxMenageFin.Location = new System.Drawing.Point(13, 37);
            this.checkBoxMenageFin.Name = "checkBoxMenageFin";
            this.checkBoxMenageFin.Size = new System.Drawing.Size(294, 17);
            this.checkBoxMenageFin.TabIndex = 1;
            this.checkBoxMenageFin.Text = "Optimiser la base de données à la fermeture du programe";
            this.checkBoxMenageFin.UseVisualStyleBackColor = true;
            // 
            // checkBoxSupprimerAlternatives
            // 
            this.checkBoxSupprimerAlternatives.AutoSize = true;
            this.checkBoxSupprimerAlternatives.Location = new System.Drawing.Point(13, 61);
            this.checkBoxSupprimerAlternatives.Name = "checkBoxSupprimerAlternatives";
            this.checkBoxSupprimerAlternatives.Size = new System.Drawing.Size(360, 17);
            this.checkBoxSupprimerAlternatives.TabIndex = 2;
            this.checkBoxSupprimerAlternatives.Text = "Quand je choisis une alternative, supprimer les autres automatiquement";
            this.checkBoxSupprimerAlternatives.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Retailler les images:";
            // 
            // comboBoxRetailleImages
            // 
            this.comboBoxRetailleImages.FormattingEnabled = true;
            this.comboBoxRetailleImages.Items.AddRange(new object[] {
            "Ne pas retailler",
            "Petit: 100 pixels de large",
            "Moyen: 200 pixels de large",
            "Grand: 300 pixels de large"});
            this.comboBoxRetailleImages.Location = new System.Drawing.Point(120, 85);
            this.comboBoxRetailleImages.Name = "comboBoxRetailleImages";
            this.comboBoxRetailleImages.Size = new System.Drawing.Size(296, 21);
            this.comboBoxRetailleImages.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxAfficheFilm);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxInfosFilm);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.linkLabelTMDB);
            this.groupBox1.Controls.Add(this.textBoxChercherFilm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(791, 137);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "The Movie Database.Org";
            // 
            // textBoxAfficheFilm
            // 
            this.textBoxAfficheFilm.Location = new System.Drawing.Point(99, 77);
            this.textBoxAfficheFilm.Name = "textBoxAfficheFilm";
            this.textBoxAfficheFilm.Size = new System.Drawing.Size(686, 20);
            this.textBoxAfficheFilm.TabIndex = 6;
            this.textBoxAfficheFilm.Text = "https://image.tmdb.org/t/p/w500{0}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Affiche du film:";
            // 
            // textBoxInfosFilm
            // 
            this.textBoxInfosFilm.Location = new System.Drawing.Point(99, 45);
            this.textBoxInfosFilm.Name = "textBoxInfosFilm";
            this.textBoxInfosFilm.Size = new System.Drawing.Size(686, 20);
            this.textBoxInfosFilm.TabIndex = 4;
            this.textBoxInfosFilm.Text = "https://api.themoviedb.org/3/movie/{0}?api_key=[VOTRE_CLEF_TMDB]&language=fr";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Infos du film:";
            // 
            // linkLabelTMDB
            // 
            this.linkLabelTMDB.AutoSize = true;
            this.linkLabelTMDB.Location = new System.Drawing.Point(6, 109);
            this.linkLabelTMDB.Name = "linkLabelTMDB";
            this.linkLabelTMDB.Size = new System.Drawing.Size(354, 13);
            this.linkLabelTMDB.TabIndex = 2;
            this.linkLabelTMDB.TabStop = true;
            this.linkLabelTMDB.Text = "Obtenir une clef d\'accès sur https://www.themoviedb.org  (indispensable)";
            this.linkLabelTMDB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // textBoxChercherFilm
            // 
            this.textBoxChercherFilm.Location = new System.Drawing.Point(99, 17);
            this.textBoxChercherFilm.Name = "textBoxChercherFilm";
            this.textBoxChercherFilm.Size = new System.Drawing.Size(686, 20);
            this.textBoxChercherFilm.TabIndex = 1;
            this.textBoxChercherFilm.Text = "https://api.themoviedb.org/3/search/movie?api_key=[VOTRE_CLEF_TMDB]&language=fr&q" +
    "uery={0}&page=1&include_adult=true";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chercher un film:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(103, 258);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ConfigurationDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 294);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxRetailleImages);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxSupprimerAlternatives);
            this.Controls.Add(this.checkBoxMenageFin);
            this.Controls.Add(this.checkBoxRelanceRecherche);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.onFormLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxRelanceRecherche;
        private System.Windows.Forms.CheckBox checkBoxMenageFin;
        private System.Windows.Forms.CheckBox checkBoxSupprimerAlternatives;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRetailleImages;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkLabelTMDB;
        private System.Windows.Forms.TextBox textBoxChercherFilm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxInfosFilm;
        private System.Windows.Forms.TextBox textBoxAfficheFilm;
        private System.Windows.Forms.Label label4;
    }
}