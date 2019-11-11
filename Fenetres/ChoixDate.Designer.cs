namespace CollectionDeFilms.Fenetres
{
    partial class ChoixDate
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.radioButtonVu = new System.Windows.Forms.RadioButton();
            this.radioButtonNonVu = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker.CalendarMonthBackground = System.Drawing.SystemColors.MenuHighlight;
            this.dateTimePicker.Location = new System.Drawing.Point(86, 13);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(272, 20);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.onDateTimePickerValueChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.Location = new System.Drawing.Point(12, 61);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.onClicBoutonOk);
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAnnuler.Location = new System.Drawing.Point(283, 61);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(75, 23);
            this.buttonAnnuler.TabIndex = 2;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            this.buttonAnnuler.Click += new System.EventHandler(this.onClicBoutonAnnuler);
            // 
            // radioButtonVu
            // 
            this.radioButtonVu.AutoSize = true;
            this.radioButtonVu.Location = new System.Drawing.Point(13, 13);
            this.radioButtonVu.Name = "radioButtonVu";
            this.radioButtonVu.Size = new System.Drawing.Size(58, 17);
            this.radioButtonVu.TabIndex = 3;
            this.radioButtonVu.TabStop = true;
            this.radioButtonVu.Text = "Film vu";
            this.radioButtonVu.UseVisualStyleBackColor = true;
            this.radioButtonVu.CheckedChanged += new System.EventHandler(this.onRadioVuChanged);
            // 
            // radioButtonNonVu
            // 
            this.radioButtonNonVu.AutoSize = true;
            this.radioButtonNonVu.Location = new System.Drawing.Point(13, 36);
            this.radioButtonNonVu.Name = "radioButtonNonVu";
            this.radioButtonNonVu.Size = new System.Drawing.Size(79, 17);
            this.radioButtonNonVu.TabIndex = 4;
            this.radioButtonNonVu.TabStop = true;
            this.radioButtonNonVu.Text = "Film non vu";
            this.radioButtonNonVu.UseVisualStyleBackColor = true;
            this.radioButtonNonVu.CheckedChanged += new System.EventHandler(this.onRadioNonVuChanged);
            // 
            // ChoixDate
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonAnnuler;
            this.ClientSize = new System.Drawing.Size(370, 96);
            this.ControlBox = false;
            this.Controls.Add(this.radioButtonNonVu);
            this.Controls.Add(this.radioButtonVu);
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.dateTimePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChoixDate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quand avez-vous vu ce film?";
            this.Load += new System.EventHandler(this.onLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.RadioButton radioButtonVu;
        private System.Windows.Forms.RadioButton radioButtonNonVu;
    }
}