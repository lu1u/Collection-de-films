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

        private void ConfigurationDlg_Load(object sender, EventArgs e)
        {
            Configuration conf = Configuration.getInstance();
            checkBoxRelanceRecherche.Checked = conf.getBoolValue(Configuration.CONFIGURATION_RELANCE_RECHERCHE, false);
            checkBoxMenageFin.Checked = conf.getBoolValue(Configuration.CONFIGURATION_MENAGE_FIN);

            if (conf.getBoolValue(Configuration.CONFIGURATION_ARRET_RECHERCHE_PREMIER))
            {
                radioButtonPremierSite.Checked = true;
                radioButtonTousLesSites.Checked = false;
            }
            else
            {
                radioButtonPremierSite.Checked = false;
                radioButtonTousLesSites.Checked = true;
            }

            remplitListeRecherches();
        }

        private void remplitListeRecherches()
        {
            listViewRecherches.BeginUpdate();
            listViewRecherches.Items.Clear();
            List<RechercheInternet> recherches = BaseDonnees.getInstance().getListeRechercheInternet();
            foreach (RechercheInternet r in recherches)
            {
                ListViewItem item = new ListViewItem(r.nom);
                item.SubItems.Add(r.rang.ToString());
                listViewRecherches.Items.Add(item);
            }
            listViewRecherches.EndUpdate();
        }

        private void buttonAddClick(object sender, EventArgs e)
        {
            EditeRechercheInternet dlg = new EditeRechercheInternet();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                RechercheInternet r = dlg.rechercheInternet;
                if (r != null)
                {
                    r.rang = listViewRecherches.Items.Count;
                    BaseDonnees.getInstance().addRechercheInternet(r);
                    remplitListeRecherches();
                }
            }
        }

        private void buttonEditClick(object sender, EventArgs e)
        {
            if (listViewRecherches.SelectedIndices.Count == 0)
                return;
            string nom = listViewRecherches.Items[listViewRecherches.SelectedIndices[0]].Text;
            if (nom == null)
                return;

            EditeRechercheInternet dlg = new EditeRechercheInternet();
            dlg.rechercheInternet = BaseDonnees.getInstance().getRechercheInternet(nom);

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                RechercheInternet r = dlg.rechercheInternet;
                if (r != null)
                {
                    r.rang = listViewRecherches.Items.Count;
                    BaseDonnees.getInstance().updateRechercheInternet(r);
                    remplitListeRecherches();
                }
            }
        }

        private void onClickButtonPrev(object sender, EventArgs e)
        {
            if (listViewRecherches.SelectedIndices.Count == 0)
                return;

            int selected = listViewRecherches.SelectedIndices[0];
            if (selected > 0)
            {
                List<RechercheInternet> liste = BaseDonnees.getInstance().getListeRechercheInternet();
                RechercheInternet r = liste[selected];
                liste.RemoveAt(selected);
                liste.Insert(selected - 1, r);
                for (int i = 0; i <= selected; i++)
                {
                    liste[i].rang = i;
                    BaseDonnees.getInstance().updateRechercheInternet(liste[i]);
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
                List<RechercheInternet> liste = BaseDonnees.getInstance().getListeRechercheInternet();
                RechercheInternet r = liste[selected];
                liste.RemoveAt(selected);
                liste.Insert(selected + 1, r);
                for (int i = 0; i <= selected + 1; i++)
                {
                    liste[i].rang = i;
                    BaseDonnees.getInstance().updateRechercheInternet(liste[i]);
                }
                remplitListeRecherches();

                listViewRecherches.SelectedItems.Clear();
                listViewRecherches.Items[selected + 1].Selected = true; ;
            }
        }

        private void onClickTousLesSites(object sender, EventArgs e)
        {
            Configuration.getInstance().setValue(Configuration.CONFIGURATION_ARRET_RECHERCHE_PREMIER, false);
            radioButtonPremierSite.Checked = false;
            radioButtonTousLesSites.Checked = true;
        }

        private void onClickPremierSite(object sender, EventArgs e)
        {
            Configuration.getInstance().setValue(Configuration.CONFIGURATION_ARRET_RECHERCHE_PREMIER, true);
            radioButtonPremierSite.Checked = true;
            radioButtonTousLesSites.Checked = false;
        }

        private void onClickRechercheDemarrage(object sender, EventArgs e)
        {
            Configuration.getInstance().setValue(Configuration.CONFIGURATION_RELANCE_RECHERCHE, checkBoxRelanceRecherche.Checked);
        }

        private void onClickMenageFin(object sender, EventArgs e)
        {
            Configuration.getInstance().setValue(Configuration.CONFIGURATION_MENAGE_FIN, checkBoxMenageFin.Checked);
        }
    }
}
