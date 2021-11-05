namespace CollectionDeFilms.Fenetres
{
    partial class OldConfigurationDlg
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
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Button button4;
            this.radioButtonPremierSite = new System.Windows.Forms.RadioButton();
            this.radioButtonTousLesSites = new System.Windows.Forms.RadioButton();
            this.listViewRecherches = new System.Windows.Forms.ListView();
            this.columnHeaderNom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRang = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonEdit = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.checkBoxSupprimerAlternatives = new System.Windows.Forms.CheckBox();
            this.checkBoxRelanceRecherche = new System.Windows.Forms.CheckBox();
            this.checkBoxMenageFin = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxRetailleImages = new System.Windows.Forms.ComboBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            button4 = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            groupBox1.Controls.Add(this.radioButtonPremierSite);
            groupBox1.Controls.Add(this.radioButtonTousLesSites);
            groupBox1.Controls.Add(this.listViewRecherches);
            groupBox1.Controls.Add(this.buttonEdit);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(this.button3);
            groupBox1.Controls.Add(this.buttonNext);
            groupBox1.Controls.Add(this.buttonPrev);
            groupBox1.Location = new System.Drawing.Point(13, 61);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(709, 264);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Recherches:";
            // 
            // radioButtonPremierSite
            // 
            this.radioButtonPremierSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonPremierSite.AutoSize = true;
            this.radioButtonPremierSite.Location = new System.Drawing.Point(7, 214);
            this.radioButtonPremierSite.Name = "radioButtonPremierSite";
            this.radioButtonPremierSite.Size = new System.Drawing.Size(209, 17);
            this.radioButtonPremierSite.TabIndex = 8;
            this.radioButtonPremierSite.TabStop = true;
            this.radioButtonPremierSite.Text = "Arrêter la recherche dès que le film est trouvé sur un site";
            this.radioButtonPremierSite.UseVisualStyleBackColor = true;
            this.radioButtonPremierSite.Click += new System.EventHandler(this.onClickPremierSite);
            // 
            // radioButtonTousLesSites
            // 
            this.radioButtonTousLesSites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonTousLesSites.AutoSize = true;
            this.radioButtonTousLesSites.Location = new System.Drawing.Point(7, 236);
            this.radioButtonTousLesSites.Name = "radioButtonTousLesSites";
            this.radioButtonTousLesSites.Size = new System.Drawing.Size(216, 17);
            this.radioButtonTousLesSites.TabIndex = 9;
            this.radioButtonTousLesSites.TabStop = true;
            this.radioButtonTousLesSites.Text = "Chercher le film sur tous les sites Internet";
            this.radioButtonTousLesSites.UseVisualStyleBackColor = true;
            this.radioButtonTousLesSites.Click += new System.EventHandler(this.onClickTousLesSites);
            // 
            // listViewRecherches
            // 
            this.listViewRecherches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewRecherches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNom,
            this.columnHeaderRang});
            this.listViewRecherches.FullRowSelect = true;
            this.listViewRecherches.GridLines = true;
            this.listViewRecherches.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewRecherches.HideSelection = false;
            this.listViewRecherches.Location = new System.Drawing.Point(7, 20);
            this.listViewRecherches.MultiSelect = false;
            this.listViewRecherches.Name = "listViewRecherches";
            this.listViewRecherches.ShowGroups = false;
            this.listViewRecherches.ShowItemToolTips = true;
            this.listViewRecherches.Size = new System.Drawing.Size(626, 188);
            this.listViewRecherches.TabIndex = 2;
            this.listViewRecherches.UseCompatibleStateImageBehavior = false;
            this.listViewRecherches.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderNom
            // 
            this.columnHeaderNom.Text = "Nom";
            this.columnHeaderNom.Width = 293;
            // 
            // columnHeaderRang
            // 
            this.columnHeaderRang.Text = "Rang";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.Location = new System.Drawing.Point(639, 176);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(64, 33);
            this.buttonEdit.TabIndex = 7;
            this.buttonEdit.Text = "✎";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEditClick);
            // 
            // button4
            // 
            button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button4.Location = new System.Drawing.Point(639, 137);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(64, 33);
            button4.TabIndex = 6;
            button4.Text = "+";
            button4.UseVisualStyleBackColor = true;
            button4.Click += new System.EventHandler(this.buttonAddClick);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(639, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 33);
            this.button3.TabIndex = 5;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonDeleteClick);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNext.Location = new System.Drawing.Point(639, 59);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(64, 33);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.Text = "⏷";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.onClicButtonNext);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrev.Location = new System.Drawing.Point(639, 20);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(64, 33);
            this.buttonPrev.TabIndex = 3;
            this.buttonPrev.Text = "⏶";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.onClickButtonPrev);
            // 
            // checkBoxSupprimerAlternatives
            // 
            this.checkBoxSupprimerAlternatives.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxSupprimerAlternatives.AutoSize = true;
            this.checkBoxSupprimerAlternatives.Location = new System.Drawing.Point(12, 331);
            this.checkBoxSupprimerAlternatives.Name = "checkBoxSupprimerAlternatives";
            this.checkBoxSupprimerAlternatives.Size = new System.Drawing.Size(391, 17);
            this.checkBoxSupprimerAlternatives.TabIndex = 15;
            this.checkBoxSupprimerAlternatives.Text = "Quand je choisit une alternative pour un film, supprimer les autres alternatives " +
    "";
            this.checkBoxSupprimerAlternatives.UseVisualStyleBackColor = true;
            this.checkBoxSupprimerAlternatives.CheckedChanged += new System.EventHandler(this.onClickSupprimerAutresAlternatives);
            // 
            // checkBoxRelanceRecherche
            // 
            this.checkBoxRelanceRecherche.AutoSize = true;
            this.checkBoxRelanceRecherche.Location = new System.Drawing.Point(13, 13);
            this.checkBoxRelanceRecherche.Name = "checkBoxRelanceRecherche";
            this.checkBoxRelanceRecherche.Size = new System.Drawing.Size(373, 17);
            this.checkBoxRelanceRecherche.TabIndex = 0;
            this.checkBoxRelanceRecherche.Text = "Au démarrage, relancer une recherche pour tous les films sans information";
            this.checkBoxRelanceRecherche.UseVisualStyleBackColor = true;
            this.checkBoxRelanceRecherche.CheckStateChanged += new System.EventHandler(this.onClickRechercheDemarrage);
            // 
            // checkBoxMenageFin
            // 
            this.checkBoxMenageFin.AutoSize = true;
            this.checkBoxMenageFin.Location = new System.Drawing.Point(13, 37);
            this.checkBoxMenageFin.Name = "checkBoxMenageFin";
            this.checkBoxMenageFin.Size = new System.Drawing.Size(363, 17);
            this.checkBoxMenageFin.TabIndex = 1;
            this.checkBoxMenageFin.Text = "Faire un nettoyage/optimisation de la base à la fermeture du programme";
            this.checkBoxMenageFin.UseVisualStyleBackColor = true;
            this.checkBoxMenageFin.CheckedChanged += new System.EventHandler(this.onClickMenageFin);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Retailler les grandes affiches:";
            // 
            // comboBoxRetailleImages
            // 
            this.comboBoxRetailleImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxRetailleImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRetailleImages.FormattingEnabled = true;
            this.comboBoxRetailleImages.Items.AddRange(new object[] {
            "Ne pas retailler",
            "Petit: 100 pixels de large",
            "Moyen: 200 pixels de large",
            "Grand: 300 pixels de large"});
            this.comboBoxRetailleImages.Location = new System.Drawing.Point(166, 354);
            this.comboBoxRetailleImages.Name = "comboBoxRetailleImages";
            this.comboBoxRetailleImages.Size = new System.Drawing.Size(556, 21);
            this.comboBoxRetailleImages.TabIndex = 14;
            this.comboBoxRetailleImages.SelectedIndexChanged += new System.EventHandler(this.comboBoxRetailleImagesSelectedIndexChanged);
            // 
            // ConfigurationDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 387);
            this.Controls.Add(this.checkBoxSupprimerAlternatives);
            this.Controls.Add(this.comboBoxRetailleImages);
            this.Controls.Add(this.label1);
            this.Controls.Add(groupBox1);
            this.Controls.Add(this.checkBoxMenageFin);
            this.Controls.Add(this.checkBoxRelanceRecherche);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(750, 387);
            this.Name = "ConfigurationDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.onFormLoad);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxRelanceRecherche;
        private System.Windows.Forms.CheckBox checkBoxMenageFin;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ListView listViewRecherches;
        public System.Windows.Forms.ColumnHeader columnHeaderRang;
        public System.Windows.Forms.ColumnHeader columnHeaderNom;
        private System.Windows.Forms.RadioButton radioButtonPremierSite;
        private System.Windows.Forms.RadioButton radioButtonTousLesSites;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRetailleImages;
        private System.Windows.Forms.CheckBox checkBoxSupprimerAlternatives;
    }
}