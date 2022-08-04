using CollectionDeFilms.Database;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CollectionDeFilms
{
    public partial class CopieEnCours : Form
    {
        private static CopieEnCours _instance = new CopieEnCours();
        private bool _annule = false;

        public bool Annule
        {
            get
            {
                return _annule;
            }
        }

        public static CopieEnCours getInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new CopieEnCours();

            return _instance;
        }

        const long MEGA_OCTETS = 1024L * 1024L;
        private CopieEnCours()
        {
            InitializeComponent();
        }


        delegate void updateAllDelegate(long totalACopier, long totalCopié, long encoursACopier, long encoursCopié);
        public void updateAll(long totalACopier, long totalCopié, long encoursACopier, long encoursCopié)
        {
            if (InvokeRequired)
                Invoke(new updateAllDelegate(updateAll), new object[] { totalACopier, totalCopié, encoursACopier, encoursCopié });
            else
            {
                progressBarTotal.Maximum = (int)(totalACopier / MEGA_OCTETS);
                progressBarTotal.Value = (int)(Math.Min(totalACopier, totalCopié) / MEGA_OCTETS);
                progressBarFichierEnCours.Maximum = (int)(encoursACopier / MEGA_OCTETS);
                progressBarFichierEnCours.Value = (int)(encoursCopié / MEGA_OCTETS);
            }
        }


        delegate void Clear();
        public void clear()
        {
            if (InvokeRequired)
                Invoke(new Clear(updateListe), new object[] { });
            else
            {
                listBoxFichiersACopier.Items.Clear();
            }
        }

        delegate void updateListeDelegate();
        public void updateListe()
        {
            if (InvokeRequired)
                Invoke(new updateListeDelegate(updateListe), new object[] { });
            else
            {
                listBoxFichiersACopier.BeginUpdate();
                listBoxFichiersACopier.Items.Clear();
                IEnumerator<(string, string, string)> iCopies = BaseFilms.instance.getCopiesEnumerator();

                while (iCopies.MoveNext())
                {
                    (string texte, string source, string destination) = iCopies.Current;
                    ListViewItem item = new ListViewItem(texte);
                    item.SubItems.Add(source);
                    item.SubItems.Add(destination);
                    listBoxFichiersACopier.Items.Add(item);
                }

                listBoxFichiersACopier.EndUpdate();
                buttonCancel.Enabled = listBoxFichiersACopier.Items.Count > 0;
            }
        }

        private void onClickCancel(object sender, EventArgs e)
        {
            _annule = true;
            System.Media.SystemSounds.Exclamation.Play();
            buttonCancel.Text = "Annulation en cours...";
            buttonCancel.Enabled = false;
        }

        delegate void signaleAnnulationTermineeDelegate();
        /// <summary>
        /// La demande d'annulation demandée a été prise en compte
        /// </summary>
        internal void signaleAnnulationTerminee()
        {
            if (InvokeRequired)
                Invoke(new signaleAnnulationTermineeDelegate(signaleAnnulationTerminee), new object[] { });
            else
            {
                buttonCancel.Text = "Annulé";
            }

        }
    }
}

