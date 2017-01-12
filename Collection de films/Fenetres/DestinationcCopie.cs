using Collection_de_films.Films;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collection_de_films.Fenetres
{
    
    public partial class DestinationcCopie : Form
    {
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        class Win32
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
        public DriveInfo destinationDevice;
        public DestinationcCopie()
        {
            InitializeComponent();
        }

        private void onLoad(object sender, EventArgs e)
        {
            if (film != null)
            {
                labelTitre.Text = film.Titre();
                labelChemin.Text = film.Chemin;
                Image img = film.getImage();
                if (img != null)
                    pictureBoxAffiche.Image = img;
            }
            listViewDevices.Items.Clear();
            // List des devices
            _devices  = DriveInfo.GetDrives().Where(d => /*(d.DriveType == DriveType.Removable) && */ (d.IsReady));
            foreach ( DriveInfo drive in _devices)
            {
                ListViewItem item = new ListViewItem(drive.VolumeLabel);
                listViewDevices.SmallImageList.Images.Add(drive.Name, GetFileIcon(drive.Name));
                item.ImageKey = drive.Name;
                item.SubItems.Add(drive.RootDirectory+"");
                item.SubItems.Add(textTaille(drive.AvailableFreeSpace));

                listViewDevices.Items.Add(item);
            }
        }

        private string textTaille(long availableFreeSpace)
        {
            if (availableFreeSpace >= (1024L * 1024L * 1024L*1024L))
                return string.Format("{0:0.0} To", (double)availableFreeSpace / (1024L * 1024L * 1024L*1024L)) ;
            if (availableFreeSpace >= (1024L * 1024L * 1024L))
                return string.Format("{0:0.0} Go", (double)availableFreeSpace / (1024L * 1024L * 1024L));
            if (availableFreeSpace >= (1024L * 1024L))
                return string.Format("{0:0.0} Mo", (double)availableFreeSpace / (1024L * 1024L ));
            if (availableFreeSpace >= (1024L))
                return string.Format("{0:0.0} Ko", (double)availableFreeSpace / (1024L));

            return availableFreeSpace + " octets";
        }

        private static Icon GetFileIcon(string name)
        {
            IntPtr hImgSmall;    //the handle to the system image list
            SHFILEINFO shinfo = new SHFILEINFO();
            //Use this to get the small Icon
            hImgSmall = Win32.SHGetFileInfo(name, 0, ref shinfo,
                                           (uint)Marshal.SizeOf(shinfo),
                                            Win32.SHGFI_ICON |
                                            Win32.SHGFI_LARGEICON);

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
    }
}
