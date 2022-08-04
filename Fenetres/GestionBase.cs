using CollectionDeFilms.Database;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Gestion des collections: activer une collection, creer, supprimer
/// </summary>
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace CollectionDeFilms.Fenetres
{
    public partial class GestionBase : Form
    {
        public GestionBase()
        {
            InitializeComponent();
        }

        private void onLoad(object sender, EventArgs e)
        {
            remplitListeCollections();
        }

        /// <summary>
        /// 
        /// </summary>
        private void remplitListeCollections()
        {
            listViewBases.Items.Clear();
            string searchPattern = $"*.{BaseFilms.EXTENSION}";
            string[] fichiers = Directory.GetFiles(BaseFilms.baseDefaultLocation(), searchPattern);
            foreach (string fichier in fichiers)
            {
                string nomCollection = Path.GetFileNameWithoutExtension(fichier);
                FileInfo fi = new FileInfo(fichier);
                ListViewItem lv = new ListViewItem(nomCollection);

                bool Active = nomCollection.Equals(Path.GetFileNameWithoutExtension(BaseFilms.instance.name));

                lv.SubItems.Add(Active ? "Oui" : "Non");
                lv.SubItems.Add(FileDriveUtils.formateTailleFichier(fi.Length));
                lv.SubItems.Add(fi.CreationTime.ToShortDateString());
                if (Active)
                    lv.ForeColor = Color.Red;
                listViewBases.Items.Add(lv);
            }
        }

        /// <summary>
        /// Creer une nouvelle base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onBoutonNouvelleBase(object sender, EventArgs e)
        {
            // Demander nouveau nom
            NouveauNomBase dlg = new NouveauNomBase();
            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            BaseFilms.creerNouvelleBase(dlg.nom);
            remplitListeCollections();
        }

        private void onButtonActiver(object sender, EventArgs e)
        {
            if (listViewBases.SelectedItems.Count == 0)
                return;

            string selected = listViewBases.SelectedItems[0].Text;
            BaseFilms.selectionneNouvelleBase(selected);
            remplitListeCollections();
        }

        private void onListViewDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewBases.SelectedItems.Count == 0)
                return;

            string selected = listViewBases.SelectedItems[0].Text;
            BaseFilms.selectionneNouvelleBase(selected);
            //remplitListeCollections();
            this.Close();
        }

        private void onButtonSupprimer(object sender, EventArgs e)
        {
            if (listViewBases.SelectedItems.Count == 0)
                return;

            string selected = listViewBases.SelectedItems[0].Text;
            if (selected.Equals(Path.GetFileNameWithoutExtension(BaseFilms.instance.name)))
                MessageBox.Show("Vous ne pouvez pas supprimer la collection active", "Impossible de supprimer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (MessageBox.Show($"Voulez-vous vraiment supprimer la collection {selected}?\nToutes les données seront perdues sans possibilité de les retrouver.", "Supprimer la collection", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    if (MessageBox.Show($"Voulez-vous vraiment supprimer la collection {selected}?\nDernière chance de changer d'avis", "Dernière chance", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    == DialogResult.OK)
                    {
                        BaseFilms.supprimeCollection(selected);
                        remplitListeCollections();
                    }
                }
            }
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.columnHeaderNom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTaille = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCreeeLe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewBases = new System.Windows.Forms.ListView();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // columnHeaderNom
            // 
            this.columnHeaderNom.Text = "Nom";
            this.columnHeaderNom.Width = 156;
            // 
            // columnHeaderTaille
            // 
            this.columnHeaderTaille.Text = "Taille";
            this.columnHeaderTaille.Width = 112;
            // 
            // columnHeaderCreeeLe
            // 
            this.columnHeaderCreeeLe.Text = "Créée le";
            this.columnHeaderCreeeLe.Width = 111;
            // 
            // columnHeaderActive
            // 
            this.columnHeaderActive.Text = "Active";
            this.columnHeaderActive.Width = 73;
            // 
            // listViewBases
            // 
            this.listViewBases.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listViewBases.AllowColumnReorder = true;
            this.listViewBases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewBases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNom,
            this.columnHeaderActive,
            this.columnHeaderTaille,
            this.columnHeaderCreeeLe});
            this.listViewBases.FullRowSelect = true;
            this.listViewBases.GridLines = true;
            this.listViewBases.HideSelection = false;
            this.listViewBases.Location = new System.Drawing.Point(16, 12);
            this.listViewBases.MultiSelect = false;
            this.listViewBases.Name = "listViewBases";
            this.listViewBases.ShowGroups = false;
            this.listViewBases.Size = new System.Drawing.Size(459, 217);
            this.listViewBases.TabIndex = 1;
            this.listViewBases.UseCompatibleStateImageBehavior = false;
            this.listViewBases.View = System.Windows.Forms.View.Details;
            this.listViewBases.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.onListViewDoubleClick);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(481, 157);
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
            this.button1.Location = new System.Drawing.Point(481, 196);
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
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(481, 12);
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
            this.ClientSize = new System.Drawing.Size(597, 237);
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
        private ColumnHeader columnHeaderNom;
        private ColumnHeader columnHeaderTaille;
        private ColumnHeader columnHeaderCreeeLe;
        private ColumnHeader columnHeaderActive;
        private System.Windows.Forms.Button button2;
    }
}
