using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collection_de_films.Actions
{
    class ActionsDifferees
    {
        private List<ActionDifferee> _actions = new List<ActionDifferee>();
        ToolStripStatusLabel _statusLabel;
        BackgroundWorker _bgw;

        public ActionsDifferees( ToolStripStatusLabel statusLabel )
        {
            _statusLabel = statusLabel;
            SetStatusFilmATraiter( "" );
        }

        public void ajoute( ActionDifferee action )
        {
            {
                action.dansLaQueue();
                lock ( _actions )
                    _actions.Add( action );

                SetStatusFilmATraiter( $"{_actions.Count} actions à traiter" );
                if ( _bgw == null)
                {
                    _bgw = new BackgroundWorker();
                    _bgw.WorkerSupportsCancellation = true;
                    _bgw.ProgressChanged += progressChanged;
                    _bgw.WorkerReportsProgress = true;
                    _bgw.DoWork += doWork;

                    _bgw.RunWorkerAsync();
                }
            }
        }

        private void doWork( object sender, DoWorkEventArgs ev )
        {
            bool continuer = true;
            while ( continuer )
            {
                ActionDifferee action;
                action = Pop();
                if ( action == null )
                {
                    continuer = false;                   
                }
                else
                    try
                    {
                        _bgw.ReportProgress( 0 );
                        MainForm.WriteMessageToConsole( "Background worker: traitement d'un film" );
                        action.execute();
                    }
                    catch ( Exception e )
                    {
                        MainForm.WriteErrorToConsole( "Erreur lors du traitement de " + action.nom() );
                        MainForm.WriteExceptionToConsole( e );
                    }

                System.Threading.Thread.Sleep( 100 );
            }

            MainForm.WriteMessageToConsole( "Toutes les actions différées ont été traitées");
            _bgw = null;
        }

        private void progressChanged( object sender, ProgressChangedEventArgs e )
        {
            SetStatusFilmATraiter( _actions.Count == 0 ? "" : $"{_actions.Count} actions à traiter" );
        }

        void supprimeAction( ActionDifferee action )
        {
            lock ( _actions )
            {
                _actions.Remove( action );                
            }
        }

        delegate void SetStatusDelegate( string message );
        private void SetStatusFilmATraiter( string message )
        {
            try
            {
                if ( _statusLabel.GetCurrentParent().InvokeRequired )
                {
                    if ( !_statusLabel.IsDisposed )
                        _statusLabel.GetCurrentParent().Invoke( new SetStatusDelegate( SetStatusFilmATraiter ), new object[] { message } );
                }
                else
                {
                    if ( message?.Length > 0 )
                    {
                        _statusLabel.Visible = true;
                        _statusLabel.Text = message;
                    }
                    else
                        _statusLabel.Visible = false;
                }
            }
            catch ( Exception )
            {

            }
        }

        public ActionDifferee Pop()
        {
            if ( _actions.Count > 0 )
                lock ( _actions )
                {
                    ActionDifferee action = _actions[0];
                    _actions.RemoveAt( 0 );

                    return action;
                }
            else
                return null;
        }

        public void Clear()
        {
            _actions.Clear();
        }

        internal void Stop()
        {
            if ( _bgw!= null && _bgw.IsBusy )
                _bgw.CancelAsync();
        }
    }
}
