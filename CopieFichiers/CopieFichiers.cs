using CollectionDeFilms.Database;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

/// <summary>
/// Gestion de la copie des films vers une clef USB
/// </summary>
namespace CollectionDeFilms
{
    class CopieFichiers : IDisposable
    {
        const Int64 MEGA_OCTET = 1024L * 1024L;

        BackgroundWorker _bgw;

        private long tailleTotaleACopier = 0;
        private long tailleTotaleCopiee = 0;
        private long tailleFichierEnCours = 0;
        private long tailleCopieFichierEnCours = 0;
        ToolStripStatusLabel _statusFichiersACopier;
        ToolStripProgressBar _statusProgressTotal;
        private bool _annule;

        /// <summary>
        /// Retourne vrai s'il y a des copies a faire
        /// </summary>
        public bool yaDesCopiesEnCours { get => BaseFilms.instance.getNbCopies() > 0; }

        public CopieFichiers(ToolStripStatusLabel statusLabelTotal, ToolStripProgressBar statusProgressTotal)
        {
            _statusFichiersACopier = statusLabelTotal;
            _statusProgressTotal = statusProgressTotal;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Ajoute une copie à la liste des fichiers à copier
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        ///////////////////////////////////////////////////////////////////////////////////////////
        public async void ajoute(string texte, string source, string destination)
        {
            if (BaseFilms.instance.getNbCopies() == 0)
                debutCopie();

            await BaseFilms.instance.ajouteCopie(texte, source, destination);
            tailleTotaleACopier += new FileInfo(source).Length;

            CopieEnCours.getInstance().updateListe();
            notifyProgress();
            // Lance la copie en tache de fond
            if (_bgw == null)
            {
                _bgw = new BackgroundWorker();
                _bgw.WorkerSupportsCancellation = true;
                _bgw.DoWork += doWork;
                _bgw.RunWorkerAsync();
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Actions pour la copie des fichiers
        /// </summary>
        ///////////////////////////////////////////////////////////////////////////////////////////
        private void debutCopie()
        {
            _statusFichiersACopier.Visible = true;
            _statusProgressTotal.Visible = true;
            _annule = false;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Actions pour la fin de copie des fichiers
        /// </summary>
        ///////////////////////////////////////////////////////////////////////////////////////////
        private void finCopie()
        {
            _bgw = null;
            tailleTotaleACopier = 0;
            tailleTotaleCopiee = 0;
            // On vient de copier le dernier fichier
            System.Media.SystemSounds.Beep.Play();
            notifyProgress();
            CopieEnCours.getInstance().updateListe();
        }

        delegate void updateDlgCopieDelegate();
        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Notifier la progression de la copie
        /// </summary>
        ///////////////////////////////////////////////////////////////////////////////////////////
        private void notifyProgress()
        {
            if (MainForm._instance.InvokeRequired)
                _statusProgressTotal.GetCurrentParent().Invoke(new updateDlgCopieDelegate(notifyProgress));
            else
            {
                CopieEnCours.getInstance().updateAll(tailleTotaleACopier, tailleTotaleCopiee, tailleFichierEnCours, tailleCopieFichierEnCours);

                if (tailleTotaleACopier > 0)
                {
                    _statusFichiersACopier.Visible = true;
                    _statusProgressTotal.Visible = true;
                    _statusFichiersACopier.Text = $"{BaseFilms.instance.getNbCopies() + 1} fichiers à copier: {FileDriveUtils.formateTailleFichier(tailleTotaleACopier)}";
                    _statusProgressTotal.Maximum = (int)(tailleTotaleACopier / MEGA_OCTET);
                    _statusProgressTotal.Value = (int)(Math.Min(tailleTotaleACopier, tailleTotaleCopiee) / MEGA_OCTET);
                    _statusProgressTotal.GetCurrentParent().Update();

                }
                else
                {
                    _statusFichiersACopier.Visible = false;
                    _statusFichiersACopier.Visible = false;
                }
            }
        }

        /// <summary>
        /// Thread de copie des fichiers en tache de fond
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        private void doWork(object sender, DoWorkEventArgs ev)
        {
            bool continuer = true;
            while (continuer)
            {
                string texte = "", source = "", destination = "";
                int id = 0;
                if (BaseFilms.instance.getCopie(ref texte, ref source, ref destination, ref id))
                {
                    try
                    {
                        CopieEnCours.getInstance().updateListe();
                        FileInfo sourceFi = new FileInfo(source);
                        FileInfo destinationFi = new FileInfo(destination);
                        tailleFichierEnCours = sourceFi.Length;
                        tailleCopieFichierEnCours = 0;

                        FileDriveUtils.copieFichier(sourceFi, destinationFi, annulationEnCours,
                            x => { tailleCopieFichierEnCours += x; tailleTotaleCopiee += x; notifyProgress(); });

                        BaseFilms.instance.supprimeCopie(id);
                        if (annulationEnCours())
                        {
                            continuer = false;
                            BaseFilms.instance.videTableCopies();
                            CopieEnCours.getInstance().signaleAnnulationTerminee();
                        }
                    }
                    catch (Exception e)
                    {
                        MainForm.WriteErrorToConsole($"Erreur lors de la copie de {source} vers {destination}");
                        MainForm.WriteExceptionToConsole(e);
                    }
                }
                else
                    // Plus de copies a faire
                    continuer = false;
            }

            finCopie();
        }




        /// <summary>
        /// Retourne true si on doit annuler les copies en cours
        /// </summary>
        /// <returns></returns>
        private bool annulationEnCours()
        {
            if (_annule)
                return true;

            // Annulation depuis la fenetre de copie en cours
            if (CopieEnCours.getInstance().Annule)
                _annule = true;

            if (_bgw.CancellationPending)
                _annule = true;

            return _annule;
        }

        private void progressChanged(object sender, ProgressChangedEventArgs e)
        {
            //SetStatusFilmATraiter( _actions.Count == 0 ? "" : $"{_actions.Count} actions à traiter" );
        }


        internal void onClickStatus()
        {
            CopieEnCours dlg = CopieEnCours.getInstance();
            if (dlg.Visible)
                dlg.Hide();
            else
            {
                dlg.clear();
                dlg.updateAll(tailleTotaleACopier, tailleTotaleCopiee, tailleFichierEnCours, tailleCopieFichierEnCours);
                dlg.updateListe();
                dlg.Show(MainForm._instance);
            }
        }

        public void Dispose()
        {
            _bgw?.CancelAsync();
            _bgw?.Dispose();
        }

        internal void stop()
        {
            _annule = true;
            BaseFilms.instance.videTableCopies();
        }
    }
}
