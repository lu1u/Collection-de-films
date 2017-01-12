using Collection_de_films.Fenetres;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collection_de_films
{
    partial class MainForm
    {
        const long MEGA_OCTET = 1024L * 1024L;
        class Copie
        {
            public Copie(string s, string d)
            {
                source = s;
                destination = d;
            }
            public string source;
            public string destination;
        };
        private List<Copie> _copies = new List<Copie>();
        private long tailleTotaleACopier = 0;
        private long tailleFichierEnCours = 0;

        private long tailleTotaleCopiee = 0;
        private long tailleCopieFichierEnCours = 0;

        
        private void bgWorkerCopieDoWork(object sender, DoWorkEventArgs e)
        {
            while (!bgWorkerCopie.CancellationPending)
            {
                if (_copies.Count > 0)
                {
                    Copie copie = _copies[0];
                    _copies.RemoveAt(0);
                    try
                    {
                        WriteMessageToConsole("Copie du fichier " + copie.source + " vers " + copie.destination);
                        FileInfo source = new FileInfo(copie.source);
                        FileInfo destination = new FileInfo(copie.destination);
                        tailleFichierEnCours = source.Length;

                        setCopieMax(tsProgressbarTotalCopie, tailleTotaleACopier);
                        setCopieMax(tsProgressbarCopieEnCours, tailleFichierEnCours);

                        tailleCopieFichierEnCours = 0;

                        CopieFichier(source, destination, x =>
                                   {
                                       tailleCopieFichierEnCours = x;
                                       //setCopieCopieValue(tsProgressbarCopieEnCours, x);
                                       //setCopieCopieValue(tsProgressbarTotalCopie, tailleTotaleCopiee + x);
                                       UpdateDlgCopie();
                                   });

                        tailleTotaleCopiee += tailleFichierEnCours;
                        CopieEnCours.getInstance().removeFichier(source.FullName);

                        if (_copies.Count == 0)
                        {
                            tailleTotaleACopier = 0;
                            tailleTotaleCopiee = 0;

                            // On vient de copier le dernier fichier
                            System.Media.SystemSounds.Asterisk.Play();
                            WriteMessageToConsole("Copie terminée");
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteExceptionToConsole(ex);
                    }
                }
                else
                    System.Threading.Thread.Sleep(500);
            }
        }

        delegate void progressCopieValue(ToolStripProgressBar t, long val);
        private void setCopieMax(ToolStripProgressBar t, long v)
        {
            if (t.GetCurrentParent().InvokeRequired)
                t.GetCurrentParent().Invoke(new progressCopieValue(this.setCopieMax), new object[] { t, v });
            else
            {
                t.Maximum = (int)(v / MEGA_OCTET);
            }
        }

        private void setCopieCopieValue(ToolStripProgressBar t, long v)
        {
            if (t.GetCurrentParent().InvokeRequired)
                t.GetCurrentParent().Invoke(new progressCopieValue(this.setCopieCopieValue), new object[] { t, v });
            else
                t.Value = Math.Min(t.Maximum, (int)(v / MEGA_OCTET));
        }

        /// <summary>
        /// Copier un fichier
        /// http://stackoverflow.com/questions/6044629/file-copy-with-progress-bar
        /// </summary>
        /// <param name="file"></param>
        /// <param name="destination"></param>
        /// <param name="progressCallback"></param>
        private void CopieFichier(FileInfo file, FileInfo destination, Action<long> progressCallback)
        {
            const int bufferSize = (int)MEGA_OCTET;  //1MB
            byte[] buffer = new byte[bufferSize], buffer2 = new byte[bufferSize];
            bool swap = false;
            long reportedProgress = 0;
            int read = 0;
            long len = file.Length;
            float flen = len;
            Task writer = null;

            using (var source = file.OpenRead())
            using (var dest = destination.OpenWrite())
            {
                dest.SetLength(source.Length);
                for (long size = 0; size < len; size += read)
                {
                    //if ((progress = ((int)((size / flen) * 100))) != reportedProgress)
                    progressCallback(reportedProgress = size);
                    read = source.Read(swap ? buffer : buffer2, 0, bufferSize);
                    writer?.Wait();  // if < .NET4 // if (writer != null) writer.Wait(); 
                    writer = dest.WriteAsync(swap ? buffer : buffer2, 0, read);
                    swap = !swap;

                    if (bgWorkerCopie.CancellationPending)
                    {
                        source.Close();
                        dest.Close();
                        destination.Delete();
                        return;
                    }
                }
                writer?.Wait();
            }
        }

        delegate void updateDlgCopieDelegate();
        private void UpdateDlgCopie()
        {
            if (InvokeRequired)
                Invoke(new updateDlgCopieDelegate(UpdateDlgCopie));
            else
            {
                CopieEnCours.getInstance().updateAll(tailleTotaleACopier, tailleTotaleCopiee + tailleCopieFichierEnCours, tailleFichierEnCours, tailleCopieFichierEnCours);
                toolStripStatusLabelFichiersACopier.Text = _copies.Count + "Fichiers à copier + (" + tailleTotaleACopier + "Mo)";
                tsProgressbarCopieEnCours.Maximum = (int)(tailleFichierEnCours/MEGA_OCTET);
                tsProgressbarCopieEnCours.Value = (int)(tailleCopieFichierEnCours / MEGA_OCTET);
                tsProgressbarTotalCopie.Maximum = (int)(tailleTotaleACopier / MEGA_OCTET);
                tsProgressbarTotalCopie.Value = (int)((tailleTotaleCopiee+tailleCopieFichierEnCours) / MEGA_OCTET);
            }
        }

        private void AjouteCopieFichier(string source, string destination)
        {
            FileInfo fi = new FileInfo(source);

            tailleTotaleACopier += fi.Length;
             _copies.Add(new Copie(source, destination));
            
            UpdateDlgCopie();
            CopieEnCours.getInstance().addFichier(source);
            
            if (!bgWorkerCopie.IsBusy)
                bgWorkerCopie.RunWorkerAsync();
        }


        private void onClicProgressCopie(object sender, EventArgs e)
        {
            CopieEnCours dlg = CopieEnCours.getInstance();


            if (dlg.Visible)
                dlg.Hide();
            else
            {
                dlg.Show(this);

                dlg.updateAll(tailleTotaleACopier, tailleTotaleCopiee + tailleCopieFichierEnCours, tailleFichierEnCours, tailleCopieFichierEnCours);
                foreach (Copie c in _copies)
                    dlg.addFichier(c.source);
            }
        }
    }
}
