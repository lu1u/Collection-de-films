using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collection_de_films
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{C269DA99-CC11-4744-A23F-7B1DE944806A}");
        // this class just wraps some Win32 stuffthat we're going to use
        internal class NativeMethods
        {
            public const int HWND_BROADCAST = 0xffff;
            public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
            [DllImport( "user32" )]
            public static extern bool PostMessage( IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam );
            [DllImport( "user32" )]
            public static extern int RegisterWindowMessage( string message );
        }
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if ( mutex.WaitOne( TimeSpan.Zero, true ) )
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault( false );
                Application.Run( new MainForm() );
                mutex.ReleaseMutex();
            }
            else
            {
                // send our Win32 message to make the currently running instance
                // jump on top of all the other windows
                NativeMethods.PostMessage(
                    (IntPtr) NativeMethods.HWND_BROADCAST,
                    NativeMethods.WM_SHOWME,
                    IntPtr.Zero,
                    IntPtr.Zero );
            }
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());*/
        }
    }
}
