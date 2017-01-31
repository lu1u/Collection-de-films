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
    class CopieFichiers : IDisposable
    {
        const Int64 MEGA_OCTET = 1024L * 1024L;
        class Copie
        {
            public Copie( string s, string d )
            {
                source = s;
                destination = d;
            }
            public string source;
            public string destination;
        };
        private List<Copie> _copies = new List<Copie>();
        BackgroundWorker _bgw;

        private long tailleTotaleACopier = 0;
        private long tailleTotaleCopiee = 0;
        private long tailleFichierEnCours = 0;
        private long tailleCopieFichierEnCours = 0;
        ToolStripStatusLabel _statusFichiersACopier;
        ToolStripProgressBar _statusProgressTotal;
        private bool _annule;

        public CopieFichiers( ToolStripStatusLabel statusLabelTotal, ToolStripProgressBar statusProgressTotal )
        {
            _statusFichiersACopier = statusLabelTotal;
            _statusProgressTotal = statusProgressTotal;
        }

        public void ajoute( string source, string destination )
        {
            if ( _copies.Count == 0 )
                debutCopie();

            lock ( _copies )
                _copies.Add( new Copie( source, destination ) );

            tailleTotaleACopier += new FileInfo( source ).Length ;

            CopieEnCours.getInstance().addFichier( source );
            notifyProgress();

            if ( _bgw == null )
            {
                _bgw = new BackgroundWorker();
                _bgw.WorkerSupportsCancellation = true;
                _bgw.DoWork += doWork;

                _bgw.RunWorkerAsync();
            }
        }

        private void debutCopie()
        {
            _annule = false;
        }

        private void finCopie()
        {
            tailleTotaleACopier = 0;
            tailleTotaleCopiee = 0;
            // On vient de copier le dernier fichier
            System.Media.SystemSounds.Beep.Play();
            notifyProgress();
            CopieEnCours.getInstance().ClearAndHide();
        }

        delegate void updateDlgCopieDelegate();
        private void notifyProgress()
        {
            if ( MainForm._instance.InvokeRequired )
                _statusProgressTotal.GetCurrentParent().Invoke( new updateDlgCopieDelegate( notifyProgress ) );
            else
            {
                CopieEnCours.getInstance().updateAll( tailleTotaleACopier, tailleTotaleCopiee, tailleFichierEnCours, tailleCopieFichierEnCours );

                if ( tailleTotaleACopier > 0 )
                {
                    _statusFichiersACopier.Visible = true;
                    _statusProgressTotal.Visible = true;
                    _statusFichiersACopier.Text = $"{_copies.Count+1} fichiers à copier: {DestinationCopie.formateTailleFichier( tailleTotaleACopier )}";
                    _statusProgressTotal.Maximum = (int) (tailleTotaleACopier / MEGA_OCTET);
                    _statusProgressTotal.Value = (int) (Math.Min(tailleTotaleACopier,tailleTotaleCopiee) / MEGA_OCTET);
                    _statusProgressTotal.GetCurrentParent().Update();

                }
                else
                {
                    _statusFichiersACopier.Visible = false;
                    _statusFichiersACopier.Visible = false;
                }
            }
        }

        private void doWork( object sender, DoWorkEventArgs ev )
        {
            bool continuer = true;
            while ( continuer )
            {
                Copie copie = Pop();
                if ( copie == null )
                    continuer = false;
                else
                    try
                    {
                        FileInfo source = new FileInfo(copie.source);
                        FileInfo destination = new FileInfo(copie.destination);
                        tailleFichierEnCours = source.Length;
                        tailleCopieFichierEnCours = 0;

                        CopieFichier( source, destination, x =>
                        {
                            tailleCopieFichierEnCours += x;
                            tailleTotaleCopiee += x;
                            notifyProgress();
                        } );

                        CopieEnCours.getInstance().removeFichier( source.FullName );

                        if ( annulationEnCours() )
                        {
                            continuer = false;
                            _copies.Clear();
                        }
                    }
                    catch ( Exception e )
                    {
                        MainForm.WriteErrorToConsole( "Erreur lors de la copie de " + copie.source );
                        MainForm.WriteExceptionToConsole( e );
                    }                
            }

            finCopie();
        }


        /// <summary>
        /// Copier un fichier
        /// http://stackoverflow.com/questions/6044629/file-copy-with-progress-bar
        /// </summary>
        /// <param name="file"></param>
        /// <param name="destination"></param>
        /// <param name="progressCallback"></param>
        private void CopieFichier( FileInfo file, FileInfo destination, Action<long> progressCallback )
        {
            const int bufferSize = (int)MEGA_OCTET;  //1MB
            byte[] buffer = new byte[bufferSize], buffer2 = new byte[bufferSize];
            bool swap = false;
            long reportedProgress = 0;
            int read = 0;
            long len = file.Length;
            float flen = len;
            Task writer = null;

            using ( var source = file.OpenRead() )
            using ( var dest = destination.OpenWrite() )
            {
                dest.SetLength( source.Length );
                for ( long size = 0; size < len; size += read )
                {
                    //if ((progress = ((int)((size / flen) * 100))) != reportedProgress)
                    read = source.Read( swap ? buffer : buffer2, 0, bufferSize );
                    progressCallback?.Invoke( reportedProgress = read );
                    writer?.Wait();  // if < .NET4 // if (writer != null) writer.Wait(); 
                    writer = dest.WriteAsync( swap ? buffer : buffer2, 0, read );
                    swap = !swap;

                    if ( annulationEnCours() )
                    {
                        source.Close();
                        dest.Close();
                        MainForm.WriteMessageToConsole( $"Annulation de la copie de {file.FullName}" );
                        destination.Delete();
                        return;
                    }
                }
                writer?.Wait();
            }
        }

        /// <summary>
        /// Retourne true si on doit annuler les copies en cours
        /// </summary>
        /// <returns></returns>
        private bool annulationEnCours()
        {
            if ( ! _annule )
            { 
                if ( CopieEnCours.getInstance().Annule)
                    _annule = true;

                if ( _bgw.CancellationPending )
                    _annule = true;
            }
            return _annule;
        }

        private void progressChanged( object sender, ProgressChangedEventArgs e )
        {
            //SetStatusFilmATraiter( _actions.Count == 0 ? "" : $"{_actions.Count} actions à traiter" );
        }

        /// <summary>
        /// Retourne la prochaine copie a effectuer
        /// </summary>
        /// <returns></returns>
        private Copie Pop()
        {
            if ( _copies.Count > 0 )
                lock ( _copies )
                {
                    Copie copie = _copies[0];
                    _copies.RemoveAt( 0 );

                    return copie;
                }
            else
                return null;
        }

        internal void onClickStatus()
        {
            CopieEnCours dlg = CopieEnCours.getInstance();
            if ( dlg.Visible )
                dlg.Hide();
            else
            {
                dlg.Show( MainForm._instance );

                dlg.updateAll( tailleTotaleACopier, tailleTotaleCopiee, tailleFichierEnCours, tailleCopieFichierEnCours );
                foreach ( Copie c in _copies )
                    dlg.addFichier( c.source );
            }
        }

        public void Dispose()
        {
            _bgw?.CancelAsync();        
        }

        internal void Stop()
        {
            _annule = true;
        }
    }
}
