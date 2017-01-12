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
        public string repertoire = @"E:\Films\Policier";
        public bool sousrepertoires = true;
        public bool tagrepertoire = true;
        public string etiquettes = "";
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
        }

        private void onClickButtonOK(object sender, EventArgs e)
        {
            sousrepertoires = checkBoxSousRepertoires.Checked;
            tagrepertoire = checkBoxTagRepertoire.Checked;
            etiquettes = textBoxEtiquettes.Text;
            repertoire = textBoxRepertoire.Text;
        }
    }
}
