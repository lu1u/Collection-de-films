namespace CollectionDeFilms.Fenetres
{
    partial class ExporteFilms
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxChemin = new System.Windows.Forms.TextBox();
            this.buttonFile = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonSelection = new System.Windows.Forms.RadioButton();
            this.radioButtonTous = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxCheminFichier = new System.Windows.Forms.CheckBox();
            this.checkBoxResume = new System.Windows.Forms.CheckBox();
            this.checkBoxRealisateur = new System.Windows.Forms.CheckBox();
            this.checkBoxActeurs = new System.Windows.Forms.CheckBox();
            this.checkBoxNationalite = new System.Windows.Forms.CheckBox();
            this.checkBoxGenres = new System.Windows.Forms.CheckBox();
            this.checkBoxDateSortie = new System.Windows.Forms.CheckBox();
            this.checkBoxDateVue = new System.Windows.Forms.CheckBox();
            this.checkBoxEntetes = new System.Windows.Forms.CheckBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.checkBoxId = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exporter les films dans un fichier au format CSV (séparés par une virgule)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fichier:";
            // 
            // textBoxChemin
            // 
            this.textBoxChemin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxChemin.Location = new System.Drawing.Point(64, 30);
            this.textBoxChemin.Name = "textBoxChemin";
            this.textBoxChemin.ReadOnly = true;
            this.textBoxChemin.Size = new System.Drawing.Size(355, 20);
            this.textBoxChemin.TabIndex = 2;
            this.textBoxChemin.TextChanged += new System.EventHandler(this.onTextBoxCheminChanged);
            // 
            // buttonFile
            // 
            this.buttonFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFile.Location = new System.Drawing.Point(425, 28);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(42, 23);
            this.buttonFile.TabIndex = 3;
            this.buttonFile.Text = "...";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.onClicButtonFile);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOk.Location = new System.Drawing.Point(13, 231);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.onButtonOk);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(95, 231);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.onButtonCancel);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButtonSelection);
            this.groupBox1.Controls.Add(this.radioButtonTous);
            this.groupBox1.Location = new System.Drawing.Point(13, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 66);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Films à exporter:";
            // 
            // radioButtonSelection
            // 
            this.radioButtonSelection.AutoSize = true;
            this.radioButtonSelection.Location = new System.Drawing.Point(7, 43);
            this.radioButtonSelection.Name = "radioButtonSelection";
            this.radioButtonSelection.Size = new System.Drawing.Size(173, 17);
            this.radioButtonSelection.TabIndex = 1;
            this.radioButtonSelection.Text = "Films actuellement sélectionnés";
            this.radioButtonSelection.UseVisualStyleBackColor = true;
            // 
            // radioButtonTous
            // 
            this.radioButtonTous.AutoSize = true;
            this.radioButtonTous.Checked = true;
            this.radioButtonTous.Location = new System.Drawing.Point(7, 20);
            this.radioButtonTous.Name = "radioButtonTous";
            this.radioButtonTous.Size = new System.Drawing.Size(140, 17);
            this.radioButtonTous.TabIndex = 0;
            this.radioButtonTous.TabStop = true;
            this.radioButtonTous.Text = "Tous les films de la base";
            this.radioButtonTous.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(13, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 73);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Colonnes";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.checkBoxId);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxCheminFichier);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxResume);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxRealisateur);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxActeurs);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxNationalite);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxGenres);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxDateSortie);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxDateVue);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(447, 48);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // checkBoxCheminFichier
            // 
            this.checkBoxCheminFichier.AutoSize = true;
            this.checkBoxCheminFichier.Checked = true;
            this.checkBoxCheminFichier.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCheminFichier.Location = new System.Drawing.Point(96, 3);
            this.checkBoxCheminFichier.Name = "checkBoxCheminFichier";
            this.checkBoxCheminFichier.Size = new System.Drawing.Size(107, 17);
            this.checkBoxCheminFichier.TabIndex = 5;
            this.checkBoxCheminFichier.Text = "Chemin du fichier";
            this.checkBoxCheminFichier.UseVisualStyleBackColor = true;
            // 
            // checkBoxResume
            // 
            this.checkBoxResume.AutoSize = true;
            this.checkBoxResume.Checked = true;
            this.checkBoxResume.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxResume.Location = new System.Drawing.Point(209, 3);
            this.checkBoxResume.Name = "checkBoxResume";
            this.checkBoxResume.Size = new System.Drawing.Size(65, 17);
            this.checkBoxResume.TabIndex = 10;
            this.checkBoxResume.Text = "Résumé";
            this.checkBoxResume.UseVisualStyleBackColor = true;
            // 
            // checkBoxRealisateur
            // 
            this.checkBoxRealisateur.AutoSize = true;
            this.checkBoxRealisateur.Checked = true;
            this.checkBoxRealisateur.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRealisateur.Location = new System.Drawing.Point(280, 3);
            this.checkBoxRealisateur.Name = "checkBoxRealisateur";
            this.checkBoxRealisateur.Size = new System.Drawing.Size(79, 17);
            this.checkBoxRealisateur.TabIndex = 6;
            this.checkBoxRealisateur.Text = "Réalisateur";
            this.checkBoxRealisateur.UseVisualStyleBackColor = true;
            // 
            // checkBoxActeurs
            // 
            this.checkBoxActeurs.AutoSize = true;
            this.checkBoxActeurs.Checked = true;
            this.checkBoxActeurs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActeurs.Location = new System.Drawing.Point(365, 3);
            this.checkBoxActeurs.Name = "checkBoxActeurs";
            this.checkBoxActeurs.Size = new System.Drawing.Size(62, 17);
            this.checkBoxActeurs.TabIndex = 7;
            this.checkBoxActeurs.Text = "Acteurs";
            this.checkBoxActeurs.UseVisualStyleBackColor = true;
            // 
            // checkBoxNationalite
            // 
            this.checkBoxNationalite.AutoSize = true;
            this.checkBoxNationalite.Checked = true;
            this.checkBoxNationalite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNationalite.Location = new System.Drawing.Point(3, 26);
            this.checkBoxNationalite.Name = "checkBoxNationalite";
            this.checkBoxNationalite.Size = new System.Drawing.Size(76, 17);
            this.checkBoxNationalite.TabIndex = 9;
            this.checkBoxNationalite.Text = "Nationalité";
            this.checkBoxNationalite.UseVisualStyleBackColor = true;
            // 
            // checkBoxGenres
            // 
            this.checkBoxGenres.AutoSize = true;
            this.checkBoxGenres.Checked = true;
            this.checkBoxGenres.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGenres.Location = new System.Drawing.Point(85, 26);
            this.checkBoxGenres.Name = "checkBoxGenres";
            this.checkBoxGenres.Size = new System.Drawing.Size(60, 17);
            this.checkBoxGenres.TabIndex = 8;
            this.checkBoxGenres.Text = "Genres";
            this.checkBoxGenres.UseVisualStyleBackColor = true;
            // 
            // checkBoxDateSortie
            // 
            this.checkBoxDateSortie.AutoSize = true;
            this.checkBoxDateSortie.Checked = true;
            this.checkBoxDateSortie.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDateSortie.Location = new System.Drawing.Point(151, 26);
            this.checkBoxDateSortie.Name = "checkBoxDateSortie";
            this.checkBoxDateSortie.Size = new System.Drawing.Size(92, 17);
            this.checkBoxDateSortie.TabIndex = 11;
            this.checkBoxDateSortie.Text = "Date de sortie";
            this.checkBoxDateSortie.UseVisualStyleBackColor = true;
            // 
            // checkBoxDateVue
            // 
            this.checkBoxDateVue.AutoSize = true;
            this.checkBoxDateVue.Checked = true;
            this.checkBoxDateVue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDateVue.Location = new System.Drawing.Point(249, 26);
            this.checkBoxDateVue.Name = "checkBoxDateVue";
            this.checkBoxDateVue.Size = new System.Drawing.Size(70, 17);
            this.checkBoxDateVue.TabIndex = 12;
            this.checkBoxDateVue.Text = "Date vue";
            this.checkBoxDateVue.UseVisualStyleBackColor = true;
            // 
            // checkBoxEntetes
            // 
            this.checkBoxEntetes.AutoSize = true;
            this.checkBoxEntetes.Checked = true;
            this.checkBoxEntetes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEntetes.Location = new System.Drawing.Point(13, 129);
            this.checkBoxEntetes.Name = "checkBoxEntetes";
            this.checkBoxEntetes.Size = new System.Drawing.Size(123, 17);
            this.checkBoxEntetes.TabIndex = 8;
            this.checkBoxEntetes.Text = "Entêtes de colonnes";
            this.checkBoxEntetes.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "csv";
            this.saveFileDialog.Filter = "Fichiers CSV|*.csv|Tous les fichiers|*.*";
            this.saveFileDialog.RestoreDirectory = true;
            this.saveFileDialog.SupportMultiDottedExtensions = true;
            // 
            // checkBoxId
            // 
            this.checkBoxId.AutoSize = true;
            this.checkBoxId.Checked = true;
            this.checkBoxId.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxId.Location = new System.Drawing.Point(3, 3);
            this.checkBoxId.Name = "checkBoxId";
            this.checkBoxId.Size = new System.Drawing.Size(87, 17);
            this.checkBoxId.TabIndex = 13;
            this.checkBoxId.Text = "Identificateur";
            this.checkBoxId.UseVisualStyleBackColor = true;
            // 
            // ExporteFilms
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(479, 266);
            this.Controls.Add(this.checkBoxEntetes);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.textBoxChemin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(486, 297);
            this.Name = "ExporteFilms";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exporter les films";
            this.Load += new System.EventHandler(this.onFormLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxChemin;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonSelection;
        private System.Windows.Forms.RadioButton radioButtonTous;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxCheminFichier;
        private System.Windows.Forms.CheckBox checkBoxNationalite;
        private System.Windows.Forms.CheckBox checkBoxGenres;
        private System.Windows.Forms.CheckBox checkBoxActeurs;
        private System.Windows.Forms.CheckBox checkBoxRealisateur;
        private System.Windows.Forms.CheckBox checkBoxResume;
        private System.Windows.Forms.CheckBox checkBoxDateSortie;
        private System.Windows.Forms.CheckBox checkBoxDateVue;
        private System.Windows.Forms.CheckBox checkBoxEntetes;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox checkBoxId;
    }
}