namespace XPath_Editor
{
    partial class Form1
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
            System.Windows.Forms.Label label3;
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.consoleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeViewRecherche = new System.Windows.Forms.TreeView();
            this.button2 = new System.Windows.Forms.Button();
            this.treeViewXPath = new System.Windows.Forms.TreeView();
            this.textBoxXPathRecherche = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxURLRecherche = new System.Windows.Forms.TextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(-3, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(74, 13);
            label3.TabIndex = 15;
            label3.Text = "Url recherche:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Fichiers vidéos (*.AVI;*.MKV;*.MP4,*.TS)|*.AVI;*.MKV;*.MP4;*.TS|All files (*.*)|*" +
    ".*";
            // 
            // consoleRichTextBox
            // 
            this.consoleRichTextBox.BackColor = System.Drawing.Color.Black;
            this.consoleRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleRichTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleRichTextBox.ForeColor = System.Drawing.Color.Lime;
            this.consoleRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.consoleRichTextBox.Name = "consoleRichTextBox";
            this.consoleRichTextBox.Size = new System.Drawing.Size(567, 126);
            this.consoleRichTextBox.TabIndex = 10;
            this.consoleRichTextBox.Text = "=======================================\nCollection de fichier 0.1\n(c) Lucien Pill" +
    "oni 2016\n=======================================\n";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxURLRecherche);
            this.splitContainer1.Panel1.Controls.Add(label3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.consoleRichTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(567, 460);
            this.splitContainer1.SplitterDistance = 330;
            this.splitContainer1.TabIndex = 11;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(0, 29);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeViewRecherche);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.button2);
            this.splitContainer2.Panel2.Controls.Add(this.treeViewXPath);
            this.splitContainer2.Panel2.Controls.Add(this.textBoxXPathRecherche);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Size = new System.Drawing.Size(564, 298);
            this.splitContainer2.SplitterDistance = 147;
            this.splitContainer2.TabIndex = 23;
            // 
            // treeViewRecherche
            // 
            this.treeViewRecherche.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewRecherche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewRecherche.Location = new System.Drawing.Point(0, 0);
            this.treeViewRecherche.Name = "treeViewRecherche";
            this.treeViewRecherche.Size = new System.Drawing.Size(564, 147);
            this.treeViewRecherche.TabIndex = 19;
            this.treeViewRecherche.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ontreeviewRechercheNodeDoubleClick);
            this.treeViewRecherche.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeViewRecherche_MouseDoubleClick);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(472, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "change XPath";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // treeViewXPath
            // 
            this.treeViewXPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewXPath.Location = new System.Drawing.Point(0, 26);
            this.treeViewXPath.Name = "treeViewXPath";
            this.treeViewXPath.Size = new System.Drawing.Size(564, 122);
            this.treeViewXPath.TabIndex = 22;
            // 
            // textBoxXPathRecherche
            // 
            this.textBoxXPathRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxXPathRecherche.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxXPathRecherche.Location = new System.Drawing.Point(100, 0);
            this.textBoxXPathRecherche.Name = "textBoxXPathRecherche";
            this.textBoxXPathRecherche.Size = new System.Drawing.Size(374, 23);
            this.textBoxXPathRecherche.TabIndex = 21;
            this.textBoxXPathRecherche.Text = "//div[@class=\'poster\']//img";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "XPath recherche:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(446, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Charger la page";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.onClickChargerPageRecherche);
            // 
            // textBoxURLRecherche
            // 
            this.textBoxURLRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxURLRecherche.Location = new System.Drawing.Point(77, 0);
            this.textBoxURLRecherche.Name = "textBoxURLRecherche";
            this.textBoxURLRecherche.Size = new System.Drawing.Size(363, 20);
            this.textBoxURLRecherche.TabIndex = 16;
            this.textBoxURLRecherche.Text = "http://www.imdb.com/title/tt0287978/?ref_=fn_tt_tt_2";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(8, 8);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.webBrowser);
            this.splitContainer3.Size = new System.Drawing.Size(971, 460);
            this.splitContainer3.SplitterDistance = 567;
            this.splitContainer3.TabIndex = 12;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(400, 460);
            this.webBrowser.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 476);
            this.Controls.Add(this.splitContainer3);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox consoleRichTextBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewRecherche;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxURLRecherche;
        private System.Windows.Forms.TextBox textBoxXPathRecherche;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView treeViewXPath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}

