using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace CollectionDeFilms.Actions
{
    internal class ActionsDifferees : IDisposable
    {
        public enum PRIORITE { BASSE = 0, MOYENNE = 1, HAUTE = 2 };

        private class ActionPriorite
        {
            public ActionPriorite(PRIORITE p, ActionDifferee a)
            {
                priorite = p;
                action = a;
            }
            public PRIORITE priorite;
            public ActionDifferee action;
        }
        private List<ActionPriorite> _actions = new List<ActionPriorite>();
        private ToolStripStatusLabel _statusLabel;
        private BackgroundWorker _bgw;

        public ActionsDifferees(ToolStripStatusLabel statusLabel)
        {
            _statusLabel = statusLabel;
            SetStatusFilmATraiter("");
        }

        public void ajoute(ActionDifferee action, PRIORITE priorite = PRIORITE.MOYENNE)
        {
            action.dansLaQueue();
            lock (_actions)
            {
                int indice = 0;
                while (indice < _actions.Count)
                {
                    if (_actions[indice].priorite < priorite)
                    {
                        break;
                    }
                    indice++;
                }


                ActionPriorite p = new ActionPriorite(priorite, action);
                if (indice < _actions.Count)
                {
                    _actions.Insert(indice, p);
                }
                else
                {
                    _actions.Add(p);
                }
            }

            SetStatusFilmATraiter($"{_actions.Count} actions à traiter");
            if (_bgw == null)
            {
                _bgw = new BackgroundWorker();
                _bgw.WorkerSupportsCancellation = true;
                _bgw.ProgressChanged += progressChanged;
                _bgw.WorkerReportsProgress = true;
                _bgw.DoWork += doWork;

                _bgw.RunWorkerAsync();
            }
        }

        private void doWork(object sender, DoWorkEventArgs ev)
        {
            bool continuer = true;
            while (continuer)
            {
                ActionDifferee action;
                action = Pop();
                if (action == null)
                {
                    continuer = false;
                }
                else
                {
                    try
                    {
                        _bgw.ReportProgress(0);
                        //MainForm.WriteMessageToConsole( "Background worker: traitement d'un film" );
                        action.execute();
                    }
                    catch (Exception e)
                    {
                        MainForm.WriteErrorToConsole("Erreur lors du traitement de " + action.nom());
                        MainForm.WriteExceptionToConsole(e);
                    }
                }

                System.Threading.Thread.Sleep(100);
            }

            MainForm.WriteMessageToConsole("Toutes les actions différées ont été traitées");
            _bgw = null;
        }

        private void progressChanged(object sender, ProgressChangedEventArgs e)
        {
            SetStatusFilmATraiter(_actions.Count == 0 ? "" : $"{_actions.Count} actions à traiter");
        }

        private void supprimeAction(ActionDifferee action)
        {
            lock (_actions)
            {
                for (int i = 0; i < _actions.Count; i++)
                {
                    if (action == _actions[i].action)
                    {
                        _actions.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private delegate void SetStatusDelegate(string message);
        private void SetStatusFilmATraiter(string message)
        {
            try
            {
                if (_statusLabel.GetCurrentParent().InvokeRequired)
                {
                    if (!_statusLabel.IsDisposed)
                    {
                        _statusLabel.GetCurrentParent().Invoke(new SetStatusDelegate(SetStatusFilmATraiter), new object[] { message });
                    }
                }
                else
                {
                    if (message?.Length > 0)
                    {
                        _statusLabel.Visible = true;
                        _statusLabel.Text = message;
                    }
                    else
                    {
                        _statusLabel.Visible = false;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public ActionDifferee Pop()
        {
            if (_actions.Count > 0)
            {
                lock (_actions)
                {
                    ActionDifferee action = _actions[0].action;
                    _actions.RemoveAt(0);
                    return action;
                }
            }
            else
            {
                return null;
            }
        }

        public void Clear()
        {
            _actions.Clear();
        }

        internal void Stop()
        {
            if (_bgw != null && _bgw.IsBusy)
            {
                _bgw.CancelAsync();
            }
        }

        public void Dispose()
        {
            _bgw?.Dispose();
        }
    }
}
