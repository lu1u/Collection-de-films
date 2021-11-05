using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionDeFilms.Fenetres
{
    public partial class ConfigurationDlg : Form
    {
        public ConfigurationDlg()
        {
            InitializeComponent();
        }

        private void onFormLoad(object sender, EventArgs e)
        {
            // Checkboxes: relancer automatiquement les recherche au demarrage
            checkBoxRelanceRecherche.Checked = Configuration.relancerRechercheAuto;
            checkBoxMenageFin.Checked = Configuration.menageALaFin;
            textBoxChercherFilm.Text = Configuration.urlTMDBChercherFilm;
            textBoxInfosFilm.Text = Configuration.urlTMDBInfosFilm;
            textBoxAfficheFilm.Text = Configuration.urlTMDBAfficheFilm;

            // Retailler les images trop grandes
            int tailleImage = Configuration.largeurMaxImages;
            int indiceSelection;
            switch (tailleImage)
            {
                case 0: indiceSelection = 0; break;
                case 100: indiceSelection = 1; break;
                case 200: indiceSelection = 2; break;
                case 300: indiceSelection = 3; break;
                default:
                    indiceSelection = 0;
                    break;
            }

            comboBoxRetailleImages.SelectedIndex = indiceSelection;
            checkBoxSupprimerAlternatives.Checked = Configuration.supprimerAutresAlternatives;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!controleUrlListeFilms())
            {
                textBoxChercherFilm.Focus();
                return;
            }
            if (!controleUrlInfosFilm())
            {
                textBoxInfosFilm.Focus();
                return;
            }
            if (!controleUrlAfficheFilm())
            {
                textBoxAfficheFilm.Focus();
                return;
            }
            Configuration.relancerRechercheAuto = checkBoxRelanceRecherche.Checked;
            Configuration.menageALaFin = checkBoxMenageFin.Checked;
            Configuration.supprimerAutresAlternatives = checkBoxSupprimerAlternatives.Checked;
            Configuration.urlTMDBChercherFilm = textBoxChercherFilm.Text;
            Configuration.urlTMDBInfosFilm = textBoxInfosFilm.Text;
            Configuration.urlTMDBAfficheFilm = textBoxAfficheFilm.Text;
            
            int taille;
            switch (comboBoxRetailleImages.SelectedIndex)
            {
                case 0: taille = 0; break;
                case 1: taille = 100; break;
                case 2: taille = 200; break;

                case 3: taille = 300; break;
                default: taille = 0; break;
            }
            Configuration.largeurMaxImages = taille;
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool controleUrlAfficheFilm()
        {
            string url = textBoxAfficheFilm.Text;
            // Verifier qu'il y a bien http: ou https:
            if (!url.StartsWith("http:") && !url.StartsWith("https:"))
            {
                MessageBox.Show("L'url doit commencer par http:// ou https://", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verifier que la clef a ete inserée
            if (url.IndexOf("VOTRE_CLEF_TMDB") != -1)
                if (!url.StartsWith("http:") && !url.StartsWith("https:"))
                {
                    MessageBox.Show("Vous devez intégrer votre clef TMDB dans l'url", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            // Verifier que le placeholder pour le parametre de recherche a bien ete inséré
            if (url.IndexOf("{0}") == -1)
                if (!url.StartsWith("http:") && !url.StartsWith("https:"))
                {
                    MessageBox.Show("L'url doit comporter la séquence '{0}' pour intégrer le film à rechercher", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            return true;
        }

        private bool controleUrlInfosFilm()
        {
            string url = textBoxInfosFilm.Text;
            // Verifier qu'il y a bien http: ou https:
            if (!url.StartsWith("http:") && !url.StartsWith("https:"))
            {
                MessageBox.Show("L'url doit commencer par http:// ou https://", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verifier que la clef a ete inserée
            if (url.IndexOf("VOTRE_CLEF_TMDB") != -1)
                if (!url.StartsWith("http:") && !url.StartsWith("https:"))
                {
                    MessageBox.Show("Vous devez intégrer votre clef TMDB dans l'url", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            // Verifier que le placeholder pour le parametre de recherche a bien ete inséré
            if (url.IndexOf("{0}") == -1)
                if (!url.StartsWith("http:") && !url.StartsWith("https:"))
                {
                    MessageBox.Show("L'url doit comporter la séquence '{0}' pour intégrer le film à rechercher", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            return true;
        }

        private bool controleUrlListeFilms()
        {
            string url = textBoxChercherFilm.Text;
            // Verifier qu'il y a bien http: ou https:
            if ( ! url.StartsWith("http:") && ! url.StartsWith("https:"))
            {
                MessageBox.Show("L'url doit commencer par http:// ou https://", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Verifier que la clef a ete inserée
            if ( url.IndexOf("VOTRE_CLEF_TMDB") != -1)
                if (!url.StartsWith("http:") && !url.StartsWith("https:"))
                {
                    MessageBox.Show("Vous devez intégrer votre clef TMDB dans l'ur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            // Verifier que le placeholder pour le parametre de recherche a bien ete inséré
            if (url.IndexOf("{0}") == -1)
                if (!url.StartsWith("http:") && !url.StartsWith("https:"))
                {
                    MessageBox.Show("L'url doit comporter la séquence '{0}' pour intégrer le film à rechercher", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            return true;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var si = new ProcessStartInfo("https://www.themoviedb.org");
            Process.Start(si);
            linkLabelTMDB.LinkVisited = true;
        }
    }
}
