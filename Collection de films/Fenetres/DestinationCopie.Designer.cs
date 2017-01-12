namespace Collection_de_films.Fenetres
{
    partial class DestinationCopie
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
            this.components = new System.ComponentModel.Container();
            this.pictureBoxAffiche = new System.Windows.Forms.PictureBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.listViewDevices = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelChemin = new System.Windows.Forms.Label();
            this.labelTitre = new System.Windows.Forms.Label();
            this.checkBoxAmovibles = new System.Windows.Forms.CheckBox();
            this.labelTaille = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAffiche)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxAffiche
            // 
            this.pictureBoxAffiche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxAffiche.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxAffiche.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxAffiche.Name = "pictureBoxAffiche";
            this.pictureBoxAffiche.Size = new System.Drawing.Size(193, 289);
            this.pictureBoxAffiche.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAffiche.TabIndex = 13;
            this.pictureBoxAffiche.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCancel.Location = new System.Drawing.Point(130, 311);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonOk.Location = new System.Drawing.Point(12, 311);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 11;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click_1);
            // 
            // listViewDevices
            // 
            this.listViewDevices.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewDevices.FullRowSelect = true;
            this.listViewDevices.GridLines = true;
            this.listViewDevices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDevices.HoverSelection = true;
            this.listViewDevices.Location = new System.Drawing.Point(216, 105);
            this.listViewDevices.MultiSelect = false;
            this.listViewDevices.Name = "listViewDevices";
            this.listViewDevices.ShowGroups = false;
            this.listViewDevices.Size = new System.Drawing.Size(425, 196);
            this.listViewDevices.SmallImageList = this.imageList1;
            this.listViewDevices.TabIndex = 10;
            this.listViewDevices.UseCompatibleStateImageBehavior = false;
            this.listViewDevices.View = System.Windows.Forms.View.Details;
            this.listViewDevices.DoubleClick += new System.EventHandler(this.listViewDevices_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Volume";
            this.columnHeader1.Width = 139;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nom";
            this.columnHeader2.Width = 122;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Place disponible";
            this.columnHeader3.Width = 157;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // labelChemin
            // 
            this.labelChemin.AutoSize = true;
            this.labelChemin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelChemin.Location = new System.Drawing.Point(213, 44);
            this.labelChemin.Name = "labelChemin";
            this.labelChemin.Size = new System.Drawing.Size(35, 13);
            this.labelChemin.TabIndex = 9;
            this.labelChemin.Text = "label1";
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.BackColor = System.Drawing.Color.Transparent;
            this.labelTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitre.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelTitre.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelTitre.Location = new System.Drawing.Point(211, 12);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(59, 26);
            this.labelTitre.TabIndex = 8;
            this.labelTitre.Text = "Titre";
            // 
            // checkBoxAmovibles
            // 
            this.checkBoxAmovibles.AutoSize = true;
            this.checkBoxAmovibles.Checked = true;
            this.checkBoxAmovibles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAmovibles.Location = new System.Drawing.Point(216, 82);
            this.checkBoxAmovibles.Name = "checkBoxAmovibles";
            this.checkBoxAmovibles.Size = new System.Drawing.Size(172, 17);
            this.checkBoxAmovibles.TabIndex = 14;
            this.checkBoxAmovibles.Text = "Disques amovibles uniquement";
            this.checkBoxAmovibles.UseVisualStyleBackColor = true;
            this.checkBoxAmovibles.CheckedChanged += new System.EventHandler(this.checkBoxAmovibles_CheckedChanged);
            // 
            // labelTaille
            // 
            this.labelTaille.AutoSize = true;
            this.labelTaille.Location = new System.Drawing.Point(213, 63);
            this.labelTaille.Name = "labelTaille";
            this.labelTaille.Size = new System.Drawing.Size(35, 13);
            this.labelTaille.TabIndex = 15;
            this.labelTaille.Text = "Taille:";
            // 
            // DestinationCopie
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(653, 346);
            this.ControlBox = false;
            this.Controls.Add(this.labelTaille);
            this.Controls.Add(this.checkBoxAmovibles);
            this.Controls.Add(this.pictureBoxAffiche);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.listViewDevices);
            this.Controls.Add(this.labelChemin);
            this.Controls.Add(this.labelTitre);
            this.Name = "DestinationCopie";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "DestinationCopie";
            this.Load += new System.EventHandler(this.onLoad);
            this.DoubleClick += new System.EventHandler(this.listViewDevices_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAffiche)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxAffiche;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ListView listViewDevices;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label labelChemin;
        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.CheckBox checkBoxAmovibles;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label labelTaille;
    }
}