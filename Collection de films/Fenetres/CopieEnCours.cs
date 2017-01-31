using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collection_de_films.Fenetres
{
    public partial class CopieEnCours : Form
    {
        private static CopieEnCours _instance = new CopieEnCours();
        private bool _annule = false ;

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
        List<string> fichiers = new List<string>();
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
                progressBarTotal.Value = (int)(Math.Min(totalACopier,totalCopié) / MEGA_OCTETS);
                progressBarFichierEnCours.Maximum = (int)(encoursACopier / MEGA_OCTETS);
                progressBarFichierEnCours.Value = (int)(encoursCopié / MEGA_OCTETS);
            }
        }

        public void addFichier(string Fichier)
        {
            fichiers.Add(Path.GetFileNameWithoutExtension(Fichier));
            updateListe();
        }

        public void removeFichier(string Fichier)
        {
            string nom = Path.GetFileNameWithoutExtension(Fichier);
            int indice = fichiers.IndexOf(nom);
            if (indice != -1)
            {
                fichiers.RemoveAt(indice);
                fichiers.Insert(indice, "Copié " + nom);
                updateListe();
            }
        }

        delegate void updateListeDelegate();
        private void updateListe()
        {
            if (InvokeRequired)
                Invoke(new updateListeDelegate(updateListe), new object[] { });
            else
            {
                listBoxFichiersACopier.BeginUpdate();
                listBoxFichiersACopier.Items.Clear();

                foreach (string s in fichiers)
                    listBoxFichiersACopier.Items.Add(s);
                listBoxFichiersACopier.EndUpdate();
            }
        }

        delegate void ClearAndHideDelegate();
        internal void ClearAndHide()
        {
            if ( InvokeRequired )
                Invoke( new ClearAndHideDelegate( ClearAndHide ), new object[] { } );
            else
            {
                fichiers.Clear();
                updateListe();
            }
        }

        private void buttonCancel_Click( object sender, EventArgs e )
        {
            _annule = true;
            buttonCancel.Text = "Annulation en cours...";
            buttonCancel.Enabled = false;
        }
    }
}
