namespace Collection_de_films.Fenetres
{
    partial class GestionBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ColumnHeader columnHeaderNom;
            System.Windows.Forms.ColumnHeader columnHeaderTaille;
            System.Windows.Forms.ColumnHeader columnHeaderCreeeLe;
            System.Windows.Forms.ColumnHeader columnHeaderActive;
            this.listViewBases = new System.Windows.Forms.ListView();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            columnHeaderNom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeaderTaille = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeaderCreeeLe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeaderActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // columnHeaderNom
            // 
            columnHeaderNom.Text = "Nom";
            columnHeaderNom.Width = 156;
            // 
            // columnHeaderTaille
            // 
            columnHeaderTaille.Text = "Taille";
            columnHeaderTaille.Width = 112;
            // 
            // columnHeaderCreeeLe
            // 
            columnHeaderCreeeLe.Text = "Créée le";
            columnHeaderCreeeLe.Width = 111;
            // 
            // columnHeaderActive
            // 
            columnHeaderActive.Text = "Active";
            columnHeaderActive.Width = 73;
            // 
            // listViewBases
            // 
            this.listViewBases.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listViewBases.AllowColumnReorder = true;
            this.listViewBases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewBases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeaderNom,
            columnHeaderActive,
            columnHeaderTaille,
            columnHeaderCreeeLe});
            this.listViewBases.FullRowSelect = true;
            this.listViewBases.GridLines = true;
            this.listViewBases.HideSelection = false;
            this.listViewBases.Location = new System.Drawing.Point(16, 12);
            this.listViewBases.MultiSelect = false;
            this.listViewBases.Name = "listViewBases";
            this.listViewBases.ShowGroups = false;
            this.listViewBases.Size = new System.Drawing.Size(416, 217);
            this.listViewBases.TabIndex = 1;
            this.listViewBases.UseCompatibleStateImageBehavior = false;
            this.listViewBases.View = System.Windows.Forms.View.Details;
            this.listViewBases.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.onListViewDoubleClick);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(438, 157);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 33);
            this.button3.TabIndex = 8;
            this.button3.Text = "- Supprimer";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.onButtonSupprimer);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(438, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 33);
            this.button1.TabIndex = 9;
            this.button1.Text = " Nouvelle";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.onBoutonNouvelleBase);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(438, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 33);
            this.button2.TabIndex = 10;
            this.button2.Text = "▶ Activer";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.onButtonActiver);
            // 
            // GestionBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 237);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listViewBases);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(570, 276);
            this.Name = "GestionBase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion des collections";
            this.Load += new System.EventHandler(this.onLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewBases;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}