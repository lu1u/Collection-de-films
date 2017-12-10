namespace Collection_de_films.Fenetres
{
    partial class AjouteRepertoire
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxRepertoire = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.checkBoxSousRepertoires = new System.Windows.Forms.CheckBox();
            this.checkBoxTagRepertoire = new System.Windows.Forms.CheckBox();
            this.textBoxEtiquettes = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonIgnorerNouveau = new System.Windows.Forms.RadioButton();
            this.radioButtonAjouter = new System.Windows.Forms.RadioButton();
            this.radioButtonRemplace = new System.Windows.Forms.RadioButton();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(103, 13);
            label1.TabIndex = 0;
            label1.Text = "Répertoire à ajouter:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(label2, true);
            label2.Location = new System.Drawing.Point(3, 75);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(402, 13);
            label2.TabIndex = 4;
            label2.Text = "Etiquettes pour tous les films de ce répertoire (mots séparés par des points-virg" +
    "ules): ";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(label1);
            this.flowLayoutPanel1.Controls.Add(this.textBoxRepertoire);
            this.flowLayoutPanel1.Controls.Add(this.buttonBrowse);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxSousRepertoires);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxTagRepertoire);
            this.flowLayoutPanel1.Controls.Add(label2);
            this.flowLayoutPanel1.Controls.Add(this.textBoxEtiquettes);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Controls.Add(this.buttonOK);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(554, 251);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // textBoxRepertoire
            // 
            this.textBoxRepertoire.Location = new System.Drawing.Point(112, 3);
            this.textBoxRepertoire.Name = "textBoxRepertoire";
            this.textBoxRepertoire.ReadOnly = true;
            this.textBoxRepertoire.Size = new System.Drawing.Size(355, 20);
            this.textBoxRepertoire.TabIndex = 1;
            this.textBoxRepertoire.Text = "E:\\Films\\Aventure";
            // 
            // buttonBrowse
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.buttonBrowse, true);
            this.buttonBrowse.Location = new System.Drawing.Point(473, 3);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.onClickButtonBrowse);
            // 
            // checkBoxSousRepertoires
            // 
            this.checkBoxSousRepertoires.AutoSize = true;
            this.checkBoxSousRepertoires.Checked = true;
            this.checkBoxSousRepertoires.CheckState = System.Windows.Forms.CheckState.Checked;
            this.flowLayoutPanel1.SetFlowBreak(this.checkBoxSousRepertoires, true);
            this.checkBoxSousRepertoires.Location = new System.Drawing.Point(3, 32);
            this.checkBoxSousRepertoires.Name = "checkBoxSousRepertoires";
            this.checkBoxSousRepertoires.Size = new System.Drawing.Size(267, 17);
            this.checkBoxSousRepertoires.TabIndex = 5;
            this.checkBoxSousRepertoires.Text = "Rechercher aussi les films dans les sous répertoires";
            this.checkBoxSousRepertoires.UseVisualStyleBackColor = true;
            // 
            // checkBoxTagRepertoire
            // 
            this.checkBoxTagRepertoire.AutoSize = true;
            this.checkBoxTagRepertoire.Checked = true;
            this.checkBoxTagRepertoire.CheckState = System.Windows.Forms.CheckState.Checked;
            this.flowLayoutPanel1.SetFlowBreak(this.checkBoxTagRepertoire, true);
            this.checkBoxTagRepertoire.Location = new System.Drawing.Point(3, 55);
            this.checkBoxTagRepertoire.Name = "checkBoxTagRepertoire";
            this.checkBoxTagRepertoire.Size = new System.Drawing.Size(234, 17);
            this.checkBoxTagRepertoire.TabIndex = 3;
            this.checkBoxTagRepertoire.Text = "Utiliser le nom du répertoire comme étiquette";
            this.checkBoxTagRepertoire.UseVisualStyleBackColor = true;
            // 
            // textBoxEtiquettes
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.textBoxEtiquettes, true);
            this.textBoxEtiquettes.Location = new System.Drawing.Point(3, 91);
            this.textBoxEtiquettes.Name = "textBoxEtiquettes";
            this.textBoxEtiquettes.Size = new System.Drawing.Size(545, 20);
            this.textBoxEtiquettes.TabIndex = 6;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(84, 223);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.onClickButtonOK);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(3, 223);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Choisissez un répertoire";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonRemplace);
            this.groupBox1.Controls.Add(this.radioButtonAjouter);
            this.groupBox1.Controls.Add(this.radioButtonIgnorerNouveau);
            this.flowLayoutPanel1.SetFlowBreak(this.groupBox1, true);
            this.groupBox1.Location = new System.Drawing.Point(3, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Si le films existe déjà dans la base:";
            // 
            // radioButtonIgnorerNouveau
            // 
            this.radioButtonIgnorerNouveau.AutoSize = true;
            this.radioButtonIgnorerNouveau.Location = new System.Drawing.Point(7, 20);
            this.radioButtonIgnorerNouveau.Name = "radioButtonIgnorerNouveau";
            this.radioButtonIgnorerNouveau.Size = new System.Drawing.Size(114, 17);
            this.radioButtonIgnorerNouveau.TabIndex = 0;
            this.radioButtonIgnorerNouveau.TabStop = true;
            this.radioButtonIgnorerNouveau.Text = "Ignorer le nouveau";
            this.radioButtonIgnorerNouveau.UseVisualStyleBackColor = true;
            // 
            // radioButtonAjouter
            // 
            this.radioButtonAjouter.AutoSize = true;
            this.radioButtonAjouter.Location = new System.Drawing.Point(7, 44);
            this.radioButtonAjouter.Name = "radioButtonAjouter";
            this.radioButtonAjouter.Size = new System.Drawing.Size(205, 17);
            this.radioButtonAjouter.TabIndex = 1;
            this.radioButtonAjouter.TabStop = true;
            this.radioButtonAjouter.Text = "Ajouter le nouveau en plus de l\'ancien";
            this.radioButtonAjouter.UseVisualStyleBackColor = true;
            // 
            // radioButtonRemplace
            // 
            this.radioButtonRemplace.AutoSize = true;
            this.radioButtonRemplace.Location = new System.Drawing.Point(7, 68);
            this.radioButtonRemplace.Name = "radioButtonRemplace";
            this.radioButtonRemplace.Size = new System.Drawing.Size(189, 17);
            this.radioButtonRemplace.TabIndex = 2;
            this.radioButtonRemplace.TabStop = true;
            this.radioButtonRemplace.Text = "Remplacer l\'ancien par le nouveau";
            this.radioButtonRemplace.UseVisualStyleBackColor = true;
            // 
            // AjouteRepertoire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 267);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "AjouteRepertoire";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "AjouteRepertoire";
            this.Load += new System.EventHandler(this.onFormLoad);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxRepertoire;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.CheckBox checkBoxTagRepertoire;
        private System.Windows.Forms.CheckBox checkBoxSousRepertoires;
        private System.Windows.Forms.TextBox textBoxEtiquettes;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonRemplace;
        private System.Windows.Forms.RadioButton radioButtonAjouter;
        private System.Windows.Forms.RadioButton radioButtonIgnorerNouveau;
    }
}