using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionDeFilms
{
    class FileDriveUtils
    {
        const Int32 MEGA_OCTET = 1024 * 1024;

        [DllImport("shell32.dll", SetLastError = true)]
        public static extern int SHOpenFolderAndSelectItems(IntPtr pidlFolder, uint cidl, [In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl, uint dwFlags);

        [DllImport("shell32.dll", SetLastError = true)]
        public static extern int SHParseDisplayName([MarshalAs(UnmanagedType.LPWStr)] string name, IntPtr bindingContext, [Out] out IntPtr pidl, uint sfgaoIn, [Out] out uint psfgaoOut);

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

        public static string formateTailleFichier(long availableFreeSpace)
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
            hImgSmall = Win32.SHGetFileInfo(name, 0, ref shinfo,
                                           (uint)Marshal.SizeOf(shinfo),
                                            Win32.SHGFI_ICON |
                                            Win32.SHGFI_LARGEICON);

            return Icon.FromHandle(shinfo.hIcon);
        }

        /// <summary>
        /// Copier un fichier
        /// http://stackoverflow.com/questions/6044629/file-copy-with-progress-bar
        /// </summary>
        /// <param name="file"></param>
        /// <param name="destination"></param>
        /// <param name="progressCallback"></param>
        public static void copieFichier(FileInfo file, FileInfo destination, Func<bool> annulationEnCours, Action<long> progressCallback)
        {
            try
            {
                using (FileStream source = file.OpenRead())
                using (FileStream dest = destination.OpenWrite())
                {
                    byte[] buffer1 = new byte[MEGA_OCTET], buffer2 = new byte[MEGA_OCTET]; // Deux buffers utilises alternativement
                    bool swap = false;
                    int read;
                    long len = file.Length;
                    Task writer = null;

                    dest.SetLength(source.Length);
                    for (long size = 0; size < len; size += read)
                    {
                        if (annulationEnCours?.Invoke() == true)
                        {
                            source.Close();
                            dest.Close();
                            MainForm.WriteMessageToConsole($"Annulation de la copie de {file.FullName}");
                            destination.Delete();
                            return;
                        }
                        else
                        {
                            read = source.Read(swap ? buffer1 : buffer2, 0, MEGA_OCTET);
                            progressCallback?.Invoke(read);
                            writer?.Wait();
                            writer = dest.WriteAsync(swap ? buffer1 : buffer2, 0, read);
                            swap = !swap; // Utiliser alternativement buffer1 et buffer2
                        }
                    }

                    // Attente finale de la derniere ecriture
                    writer?.Wait();
                }
            }
            catch (Exception e)
            {
                MainForm.WriteErrorToConsole($"Erreur lors de la copie de {file.Name}");
                MainForm.WriteExceptionToConsole(e);
                System.Media.SystemSounds.Exclamation.Play();
                MessageBox.Show($"Erreur lors de la copie de {file.Name}", "Erreur de copie", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Montrer un fichier dans l'explorateur Windows
        /// </summary>
        /// <param name="file"></param>
        public static void OpenFolderAndSelectItem(string file)
        {
            string folderPath = new FileInfo(file).DirectoryName;
            IntPtr nativeFolder;
            uint psfgaoOut;
            SHParseDisplayName(folderPath, IntPtr.Zero, out nativeFolder, 0, out psfgaoOut);

            if (nativeFolder == IntPtr.Zero)
            {
                // Log error, can't find folder
                return;
            }

            IntPtr nativeFile;
            SHParseDisplayName(Path.Combine(folderPath, file), IntPtr.Zero, out nativeFile, 0, out psfgaoOut);

            IntPtr[] fileArray;
            if (nativeFile == IntPtr.Zero)
            {
                // Open the folder without the file selected if we can't find the file
                fileArray = new IntPtr[0];
            }
            else
            {
                fileArray = new IntPtr[] { nativeFile };
            }

            SHOpenFolderAndSelectItems(nativeFolder, (uint)fileArray.Length, fileArray, 0);

            Marshal.FreeCoTaskMem(nativeFolder);
            if (nativeFile != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(nativeFile);
            }
        }

    }
}
