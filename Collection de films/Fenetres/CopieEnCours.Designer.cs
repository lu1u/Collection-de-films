namespace Collection_de_films.Fenetres
{
    partial class CopieEnCours
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            this.listBoxFichiersACopier = new System.Windows.Forms.ListBox();
            this.progressBarFichierEnCours = new System.Windows.Forms.ProgressBar();
            this.progressBarTotal = new System.Windows.Forms.ProgressBar();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(74, 13);
            label1.TabIndex = 0;
            label1.Text = "Films à copier:";
            // 
            // listBoxFichiersACopier
            // 
            this.listBoxFichiersACopier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFichiersACopier.FormattingEnabled = true;
            this.listBoxFichiersACopier.IntegralHeight = false;
            this.listBoxFichiersACopier.Location = new System.Drawing.Point(16, 30);
            this.listBoxFichiersACopier.Name = "listBoxFichiersACopier";
            this.listBoxFichiersACopier.Size = new System.Drawing.Size(527, 92);
            this.listBoxFichiersACopier.TabIndex = 1;
            // 
            // progressBarFichierEnCours
            // 
            this.progressBarFichierEnCours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarFichierEnCours.Location = new System.Drawing.Point(16, 197);
            this.progressBarFichierEnCours.Name = "progressBarFichierEnCours";
            this.progressBarFichierEnCours.Size = new System.Drawing.Size(527, 23);
            this.progressBarFichierEnCours.TabIndex = 9;
            // 
            // label3
            // 
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(16, 180);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(72, 13);
            label3.TabIndex = 8;
            label3.Text = "Film en cours:";
            // 
            // progressBarTotal
            // 
            this.progressBarTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarTotal.Location = new System.Drawing.Point(16, 150);
            this.progressBarTotal.Name = "progressBarTotal";
            this.progressBarTotal.Size = new System.Drawing.Size(527, 23);
            this.progressBarTotal.TabIndex = 7;
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(16, 133);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(66, 13);
            label2.TabIndex = 6;
            label2.Text = "Copie totale:";
            // 
            // CopieEnCours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(555, 229);
            this.Controls.Add(this.progressBarFichierEnCours);
            this.Controls.Add(label3);
            this.Controls.Add(this.progressBarTotal);
            this.Controls.Add(label2);
            this.Controls.Add(this.listBoxFichiersACopier);
            this.Controls.Add(label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CopieEnCours";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copie En Cours";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxFichiersACopier;
        private System.Windows.Forms.ProgressBar progressBarFichierEnCours;
        private System.Windows.Forms.ProgressBar progressBarTotal;
    }
}