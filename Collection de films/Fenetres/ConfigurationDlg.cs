using Collection_de_films.Database;
using Collection_de_films.Internet;
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
    public partial class ConfigurationDlg : Form
    {
        public ConfigurationDlg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onFormLoad(object sender, EventArgs e)
        {
            // Checkboxes: relancer automatiquement les recherche au demarrage
            checkBoxRelanceRecherche.Checked = Configuration.relancerRechercheAuto;
            checkBoxMenageFin.Checked = Configuration.menageALaFin;

            // Radio button: recherche les infos sur tous les sites ou s'arreter dès qu'on trouve
            if (Configuration.arretRecherchePremier)
            {
                radioButtonPremierSite.Checked = true;
                radioButtonTousLesSites.Checked = false;
            }
            else
            {
                radioButtonPremierSite.Checked = false;
                radioButtonTousLesSites.Checked = true;
            }

            // Liste des configurations de recherche
            remplitListeRecherches();

            // Retailler les images trop grandes
            int tailleImage = Configuration.largeurMaxImages ;
            int indiceSelection;
            switch( tailleImage)
            {
                case 0:  indiceSelection = 0; break;
                case 100: indiceSelection = 1; break;
                case 200: indiceSelection = 2; break;
                case 300: indiceSelection = 3; break;
                default:
                    indiceSelection = 0;
                    break;
            }

            comboBoxRetailleImages.SelectedIndex = indiceSelection;        
            checkBoxSupprimerAlternatives.Checked = Configuration.supprimerAutresAlternatives ;
        }

        /// <summary>
        /// Remplissage de la liste des recherche sur Internet
        /// </summary>
        private void remplitListeRecherches()
        {
            listViewRecherches.BeginUpdate();
            listViewRecherches.Items.Clear();
            List<RechercheInternet> recherches = BaseConfiguration.instance.getListeRechercheInternet();
            foreach (RechercheInternet r in recherches)
            {
                ListViewItem item = new ListViewItem(r.nom);
                item.SubItems.Add(r.rang.ToString());
                listViewRecherches.Items.Add(item);
            }
            listViewRecherches.EndUpdate();
        }

        /// <summary>
        /// Ajouter un site de recherche internet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddClick(object sender, EventArgs e)
        {
            EditeRechercheInternet dlg = new EditeRechercheInternet();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                RechercheInternet r = dlg.rechercheInternet;
                if (r != null)
                {
                    r.rang = listViewRecherches.Items.Count;
                    BaseConfiguration.instance.addRechercheInternet(r);
                    remplitListeRecherches();
                }
            }
        }

        /// <summary>
        /// Modifier un site de recherche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditClick(object sender, EventArgs e)
        {
            if (listViewRecherches.SelectedIndices.Count == 0)
                return;
            string nom = listViewRecherches.Items[listViewRecherches.SelectedIndices[0]].Text;
            if (nom == null)
                return;

            EditeRechercheInternet dlg = new EditeRechercheInternet();
            dlg.rechercheInternet = BaseConfiguration.instance.getRechercheInternet(nom);

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                RechercheInternet r = dlg.rechercheInternet;
                if (r != null)
                {
                    r.rang = listViewRecherches.Items.Count;
                    BaseConfiguration.instance.updateRechercheInternet(r);
                    remplitListeRecherches();
                }
            }
        }

        /// <summary>
        /// Remonter la recherche dans la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClickButtonPrev(object sender, EventArgs e)
        {
            if (listViewRecherches.SelectedIndices.Count == 0)
                return;

            int selected = listViewRecherches.SelectedIndices[0];
            if (selected > 0)
            {
                List<RechercheInternet> liste = BaseConfiguration.instance.getListeRechercheInternet();
                RechercheInternet r = liste[selected];
                liste.RemoveAt(selected);
                liste.Insert(selected - 1, r);
                for (int i = 0; i <= selected; i++)
                {
                    liste[i].rang = i;
                    BaseConfiguration.instance.updateRechercheInternet(liste[i]);
                }
                remplitListeRecherches();

                listViewRecherches.SelectedItems.Clear();
                listViewRecherches.Items[selected - 1].Selected = true; ;
            }
        }

        private void onClicButtonNext(object sender, EventArgs e)
        {
            if (listViewRecherches.SelectedIndices.Count == 0)
                return;

            int selected = listViewRecherches.SelectedIndices[0];
            if (selected < listViewRecherches.Items.Count - 1)
            {
                List<RechercheInternet> liste = BaseConfiguration.instance.getListeRechercheInternet();
                RechercheInternet r = liste[selected];
                liste.RemoveAt(selected);
                liste.Insert(selected + 1, r);
                for (int i = 0; i <= selected + 1; i++)
                {
                    liste[i].rang = i;
                    BaseConfiguration.instance.updateRechercheInternet(liste[i]);
                }
                remplitListeRecherches();

                listViewRecherches.SelectedItems.Clear();
                listViewRecherches.Items[selected + 1].Selected = true; ;
            }
        }

        private void onClickTousLesSites(object sender, EventArgs e)
        {
            Configuration.arretRecherchePremier = false ;
            radioButtonPremierSite.Checked = false;
            radioButtonTousLesSites.Checked = true;
        }

        private void onClickPremierSite(object sender, EventArgs e)
        {
            Configuration.arretRecherchePremier = true;
            radioButtonPremierSite.Checked = true;
            radioButtonTousLesSites.Checked = false;
        }


        private void buttonOK_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxRetailleImagesSelectedIndexChanged(object sender, EventArgs e)
        {
            int taille;
            switch( comboBoxRetailleImages.SelectedIndex)
            {
                case 0: taille = 0; break;
                case 1: taille = 100; break;
                case 2: taille = 200;break;

                case 3: taille = 300; break;
                default: taille = 0; break;
            }
            Configuration.largeurMaxImages = taille ;
        }

        private void onClickSupprimerAutresAlternatives(object sender, EventArgs e)
        {
            Configuration.supprimerAutresAlternatives = checkBoxSupprimerAlternatives.Checked ;
        }

        private void onClickRechercheDemarrage(object sender, EventArgs e)
        {
            Configuration.relancerRechercheAuto = checkBoxRelanceRecherche.Checked;
        }

        private void onClickMenageFin(object sender, EventArgs e)
        {
            Configuration.menageALaFin = checkBoxMenageFin.Checked ;
        }

    }
}
