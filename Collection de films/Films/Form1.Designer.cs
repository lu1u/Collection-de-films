namespace Collection_de_films.Films
{
    partial class Form1
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
            this.flowLayoutPanelAlternatives = new System.Windows.Forms.FlowLayoutPanel();
            this.labelTitre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewFilms = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonValiderAlternative = new System.Windows.Forms.Button();
            this.flowLayoutPanelAlternatives.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelAlternatives
            // 
            this.flowLayoutPanelAlternatives.Controls.Add(this.labelTitre);
            this.flowLayoutPanelAlternatives.Controls.Add(this.label1);
            this.flowLayoutPanelAlternatives.Controls.Add(this.listViewFilms);
            this.flowLayoutPanelAlternatives.Controls.Add(this.buttonValiderAlternative);
            this.flowLayoutPanelAlternatives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelAlternatives.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelAlternatives.Name = "flowLayoutPanelAlternatives";
            this.flowLayoutPanelAlternatives.Size = new System.Drawing.Size(941, 623);
            this.flowLayoutPanelAlternatives.TabIndex = 0;
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelAlternatives.SetFlowBreak(this.labelTitre, true);
            this.labelTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitre.ForeColor = System.Drawing.Color.Teal;
            this.labelTitre.Location = new System.Drawing.Point(3, 0);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(59, 26);
            this.labelTitre.TabIndex = 1;
            this.labelTitre.Text = "Titre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Plusieurs films ont été trouvés, veuillez choisir celui qui correspond:";
            // 
            // listViewFilms
            // 
            this.listViewFilms.BackColor = System.Drawing.Color.Silver;
            this.listViewFilms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewFilms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewFilms.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewFilms.FullRowSelect = true;
            this.listViewFilms.GridLines = true;
            this.listViewFilms.Location = new System.Drawing.Point(3, 42);
            this.listViewFilms.MultiSelect = false;
            this.listViewFilms.Name = "listViewFilms";
            this.listViewFilms.ShowGroups = false;
            this.listViewFilms.ShowItemToolTips = true;
            this.listViewFilms.Size = new System.Drawing.Size(761, 534);
            this.listViewFilms.TabIndex = 3;
            this.listViewFilms.UseCompatibleStateImageBehavior = false;
            this.listViewFilms.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = " ";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Genres";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Réalisateur";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Acteurs";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Résumé";
            this.columnHeader5.Width = 300;
            // 
            // buttonValiderAlternative
            // 
            this.buttonValiderAlternative.Location = new System.Drawing.Point(770, 42);
            this.buttonValiderAlternative.Name = "buttonValiderAlternative";
            this.buttonValiderAlternative.Size = new System.Drawing.Size(75, 23);
            this.buttonValiderAlternative.TabIndex = 4;
            this.buttonValiderAlternative.Text = "Valider";
            this.buttonValiderAlternative.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 623);
            this.Controls.Add(this.flowLayoutPanelAlternatives);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanelAlternatives.ResumeLayout(false);
            this.flowLayoutPanelAlternatives.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAlternatives;
        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewFilms;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button buttonValiderAlternative;
    }
}