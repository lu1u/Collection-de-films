namespace Collection_de_films.Fenetres
{
    partial class DestinationcCopie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DestinationcCopie));
            this.labelTitre = new System.Windows.Forms.Label();
            this.labelChemin = new System.Windows.Forms.Label();
            this.listViewDevices = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.pictureBoxAffiche = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAffiche)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitre
            // 
            resources.ApplyResources(this.labelTitre, "labelTitre");
            this.labelTitre.BackColor = System.Drawing.Color.Transparent;
            this.labelTitre.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelTitre.Name = "labelTitre";
            // 
            // labelChemin
            // 
            resources.ApplyResources(this.labelChemin, "labelChemin");
            this.labelChemin.Name = "labelChemin";
            // 
            // listViewDevices
            // 
            resources.ApplyResources(this.listViewDevices, "listViewDevices");
            this.listViewDevices.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewDevices.FullRowSelect = true;
            this.listViewDevices.GridLines = true;
            this.listViewDevices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDevices.HotTracking = true;
            this.listViewDevices.HoverSelection = true;
            this.listViewDevices.MultiSelect = false;
            this.listViewDevices.Name = "listViewDevices";
            this.listViewDevices.ShowGroups = false;
            this.listViewDevices.SmallImageList = this.imageList1;
            this.listViewDevices.UseCompatibleStateImageBehavior = false;
            this.listViewDevices.View = System.Windows.Forms.View.Details;
            this.listViewDevices.SelectedIndexChanged += new System.EventHandler(this.listViewDevices_SelectedIndexChanged);
            this.listViewDevices.DoubleClick += new System.EventHandler(this.listViewDevices_DoubleClick);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.imageList1, "imageList1");
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // buttonOk
            // 
            resources.ApplyResources(this.buttonOk, "buttonOk");
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // pictureBoxAffiche
            // 
            resources.ApplyResources(this.pictureBoxAffiche, "pictureBoxAffiche");
            this.pictureBoxAffiche.Name = "pictureBoxAffiche";
            this.pictureBoxAffiche.TabStop = false;
            // 
            // DestinationCopie
            // 
            this.AcceptButton = this.buttonOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.pictureBoxAffiche);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.listViewDevices);
            this.Controls.Add(this.labelChemin);
            this.Controls.Add(this.labelTitre);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DestinationCopie";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.onLoad);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAffiche)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.Label labelChemin;
        private System.Windows.Forms.ListView listViewDevices;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBoxAffiche;
    }
}