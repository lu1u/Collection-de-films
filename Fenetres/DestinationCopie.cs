using CollectionDeFilms.Films;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CollectionDeFilms.Fenetres
{

    public partial class DestinationCopie : Form
    {
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        class NativeMethods
        {
            public const uint SHGFI_ICON = 0x100;
            public const uint SHGFI_LARGEICON = 0x0;    // 'Large icon
            public const uint SHGFI_SMALLICON = 0x1;    // 'Small icon

            [DllImport("shell32.dll")]
            public static extern IntPtr SHGetFileInfo(string pszPath,
                uint dwFileAttributes,
                ref SHFILEINFO psfi,
                uint cbSizeFileInfo,
                uint uFlags);
        }
        public Film film;
        private IEnumerable<DriveInfo> _devices;
        private PictureBox pictureBoxAffiche;
        private Button buttonCancel;
        private Button buttonOk;
        private ListView listViewDevices;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ImageList imageList1;
        private IContainer components;
        private Label labelTaille;
        private CheckBox checkBoxAmovibles;
        private Label labelChemin;
        private Label labelTitre;
        public DriveInfo destinationDevice;
        public DestinationCopie()
        {
            InitializeComponent();
        }

        private void onLoad(object sender, EventArgs e)
        {
            if (film != null)
            {
                labelTitre.Text = film.Titre;
                labelChemin.Text = film.Chemin;
                Image img = film.Affiche;
                if (img != null)
                    pictureBoxAffiche.Image = img;
            }

            remplitListDevices();
            
        }

        private void remplitListDevices()
        {
            listViewDevices.Items.Clear();
            // List des devices
            _devices = checkBoxAmovibles.Checked ? DriveInfo.GetDrives().Where(d => (d.DriveType == DriveType.Removable) && (d.IsReady))
                : DriveInfo.GetDrives().Where(d => (d.IsReady));
            foreach (DriveInfo drive in _devices)
            {
                ListViewItem item = new ListViewItem(drive.VolumeLabel);
                listViewDevices.SmallImageList.Images.Add(drive.Name, GetFileIcon(drive.Name));
                item.ImageKey = drive.Name;
                item.SubItems.Add(drive.RootDirectory + "");
                item.SubItems.Add(textTaille(drive.AvailableFreeSpace));

                listViewDevices.Items.Add(item);
            }
        }

        private string textTaille(long availableFreeSpace)
        {
            if (availableFreeSpace >= (1024L * 1024L * 1024L * 1024L))
                return string.Format("{0:0.0} To", (double)availableFreeSpace / (1024L * 1024L * 1024L * 1024L));
            if (availableFreeSpace >= (1024L * 1024L * 1024L))
                return string.Format("{0:0.0} Go", (double)availableFreeSpace / (1024L * 1024L * 1024L));
            if (availableFreeSpace >= (1024L * 1024L))
                return string.Format("{0:0.0} Mo", (double)availableFreeSpace / (1024L * 1024L));
            if (availableFreeSpace >= (1024L))
                return string.Format("{0:0.0} Ko", (double)availableFreeSpace / (1024L));

            return availableFreeSpace + " octets";
        }

        public static Icon GetFileIcon(string name)
        {
            IntPtr hImgSmall;    //the handle to the system image list
            SHFILEINFO shinfo = new SHFILEINFO();
            //Use this to get the small Icon
            hImgSmall = NativeMethods.SHGetFileInfo(name, 0, ref shinfo,
                                           (uint)Marshal.SizeOf(shinfo),
                                            NativeMethods.SHGFI_ICON |
                                            NativeMethods.SHGFI_LARGEICON);

            return Icon.FromHandle(shinfo.hIcon);
        }

        private void listViewDevices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewDevices_DoubleClick(object sender, EventArgs e)
        {
            valide();
        }

        private void valide()
        {
            if (listViewDevices.SelectedIndices.Count == 0)
                return;

            int selected = listViewDevices.SelectedIndices[0];
            destinationDevice = _devices.ElementAt(selected);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            valide();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.listViewDevices = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelTaille = new System.Windows.Forms.Label();
            this.checkBoxAmovibles = new System.Windows.Forms.CheckBox();
            this.labelChemin = new System.Windows.Forms.Label();
            this.labelTitre = new System.Windows.Forms.Label();
            this.pictureBoxAffiche = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAffiche)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCancel.Location = new System.Drawing.Point(93, 315);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 20;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonOk.Location = new System.Drawing.Point(12, 315);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 19;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
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
            this.listViewDevices.HideSelection = false;
            this.listViewDevices.HoverSelection = true;
            this.listViewDevices.Location = new System.Drawing.Point(216, 105);
            this.listViewDevices.MultiSelect = false;
            this.listViewDevices.Name = "listViewDevices";
            this.listViewDevices.ShowGroups = false;
            this.listViewDevices.Size = new System.Drawing.Size(440, 200);
            this.listViewDevices.SmallImageList = this.imageList1;
            this.listViewDevices.TabIndex = 18;
            this.listViewDevices.UseCompatibleStateImageBehavior = false;
            this.listViewDevices.View = System.Windows.Forms.View.Details;
            this.listViewDevices.SelectedIndexChanged += new System.EventHandler(this.listViewDevices_SelectedIndexChanged);
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
            // labelTaille
            // 
            this.labelTaille.AutoSize = true;
            this.labelTaille.Location = new System.Drawing.Point(213, 63);
            this.labelTaille.Name = "labelTaille";
            this.labelTaille.Size = new System.Drawing.Size(35, 13);
            this.labelTaille.TabIndex = 23;
            this.labelTaille.Text = "Taille:";
            // 
            // checkBoxAmovibles
            // 
            this.checkBoxAmovibles.AutoSize = true;
            this.checkBoxAmovibles.Checked = true;
            this.checkBoxAmovibles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAmovibles.Location = new System.Drawing.Point(216, 82);
            this.checkBoxAmovibles.Name = "checkBoxAmovibles";
            this.checkBoxAmovibles.Size = new System.Drawing.Size(172, 17);
            this.checkBoxAmovibles.TabIndex = 22;
            this.checkBoxAmovibles.Text = "Disques amovibles uniquement";
            this.checkBoxAmovibles.UseVisualStyleBackColor = true;
            this.checkBoxAmovibles.CheckedChanged += new System.EventHandler(this.CheckBoxAmovibles_CheckedChanged);
            // 
            // labelChemin
            // 
            this.labelChemin.AutoSize = true;
            this.labelChemin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelChemin.Location = new System.Drawing.Point(213, 44);
            this.labelChemin.Name = "labelChemin";
            this.labelChemin.Size = new System.Drawing.Size(35, 13);
            this.labelChemin.TabIndex = 17;
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
            this.labelTitre.TabIndex = 16;
            this.labelTitre.Text = "Titre";
            // 
            // pictureBoxAffiche
            // 
            this.pictureBoxAffiche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxAffiche.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxAffiche.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxAffiche.Name = "pictureBoxAffiche";
            this.pictureBoxAffiche.Size = new System.Drawing.Size(193, 293);
            this.pictureBoxAffiche.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAffiche.TabIndex = 21;
            this.pictureBoxAffiche.TabStop = false;
            // 
            // DestinationCopie
            // 
            this.ClientSize = new System.Drawing.Size(668, 362);
            this.Controls.Add(this.pictureBoxAffiche);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.listViewDevices);
            this.Controls.Add(this.labelTaille);
            this.Controls.Add(this.checkBoxAmovibles);
            this.Controls.Add(this.labelChemin);
            this.Controls.Add(this.labelTitre);
            this.Name = "DestinationCopie";
            this.Load += new System.EventHandler(this.onLoad);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAffiche)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void CheckBoxAmovibles_CheckedChanged(object sender, EventArgs e)
        {
            remplitListDevices();
        }
    }
}
