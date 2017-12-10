using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collection_de_films.Fenetres
{
    public partial class AjouteRepertoire : Form
    {
        public enum ACTION_SI_DUPPLIQUE { IGNORER_NOUVEAU, AJOUTER_NOUVEAU, REMPLACER_ANCIEN };

        public string repertoire = @"E:\Films\Policier";
        public bool sousrepertoires = true;
        public bool tagrepertoire = true;
        public string etiquettes = "";
        public ACTION_SI_DUPPLIQUE actionSiDupplique = ACTION_SI_DUPPLIQUE.IGNORER_NOUVEAU;

        public AjouteRepertoire()
        {
            InitializeComponent();
        }

        private void onClickButtonBrowse(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = textBoxRepertoire.Text;
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.Cancel)
                return;

            repertoire = folderBrowserDialog.SelectedPath;
            textBoxRepertoire.Text = repertoire;
        }

        private void onFormLoad(object sender, EventArgs e)
        {
            textBoxRepertoire.Text = repertoire;
            checkBoxSousRepertoires.Checked = sousrepertoires;
            checkBoxTagRepertoire.Checked = tagrepertoire;
            textBoxEtiquettes.Text = etiquettes;
            switch( actionSiDupplique)
            {
                case ACTION_SI_DUPPLIQUE.IGNORER_NOUVEAU:
                    radioButtonIgnorerNouveau.Checked = true;
                    break;

                case ACTION_SI_DUPPLIQUE.AJOUTER_NOUVEAU:
                    radioButtonAjouter.Checked = true;
                    break;

                case ACTION_SI_DUPPLIQUE.REMPLACER_ANCIEN:
                    radioButtonRemplace.Checked = true;
                    break;
            }
        }

        private void onClickButtonOK(object sender, EventArgs e)
        {
            sousrepertoires = checkBoxSousRepertoires.Checked;
            tagrepertoire = checkBoxTagRepertoire.Checked;
            etiquettes = textBoxEtiquettes.Text;
            repertoire = textBoxRepertoire.Text;

            if (radioButtonIgnorerNouveau.Checked)
                actionSiDupplique = ACTION_SI_DUPPLIQUE.IGNORER_NOUVEAU;
            else
                if (radioButtonAjouter.Checked)
                actionSiDupplique = ACTION_SI_DUPPLIQUE.AJOUTER_NOUVEAU;
            else
                actionSiDupplique = ACTION_SI_DUPPLIQUE.REMPLACER_ANCIEN;
        }

        internal static ACTION_SI_DUPPLIQUE toACTION(int action)
        {
            switch(action)
            {
                case 0: return ACTION_SI_DUPPLIQUE.REMPLACER_ANCIEN;
                case 1: return ACTION_SI_DUPPLIQUE.IGNORER_NOUVEAU;
                default: return ACTION_SI_DUPPLIQUE.AJOUTER_NOUVEAU;
            }
        }

        internal static int toInt(ACTION_SI_DUPPLIQUE action)
        {
            switch( action)
            {
                case ACTION_SI_DUPPLIQUE.REMPLACER_ANCIEN:  return 0;
                case ACTION_SI_DUPPLIQUE.IGNORER_NOUVEAU: return 1 ;
                default: return 2 ;
            }
        }
    }
}
