using CollectionDeFilms.Internet;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CollectionDeFilms.Fenetres
{
    public partial class EditeRechercheSurSite : Form
    {
        public RechercheSurSite rechercheInternet;
        public EditeRechercheSurSite()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (valide())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool valide()
        {
            string message = "";
            if (textBoxNom.Text.Length == 0)
            {
                message += "Le nom ne doit pas être vide\n";
                textBoxNom.BackColor = Color.Salmon;
            }
            else
                textBoxNom.BackColor = SystemColors.Window;

            if (!textBoxFormatURLRecherche.Text.Contains("{0}"))
            {
                message += "Le format d'URL pour la recherche du fichier doit comporter {0} qui sera remplacé par le titre du film.\n";
                textBoxFormatURLRecherche.BackColor = Color.Salmon;
            }
            else
                textBoxFormatURLRecherche.BackColor = SystemColors.Window;

            if (textBoxXPathRecherche.Text.Length == 0)
            {
                message += "Le XPath de recherche ne doit pas être vide\n ";
                textBoxXPathRecherche.BackColor = Color.Salmon;
            }
            else
                textBoxXPathRecherche.BackColor = SystemColors.Window;

            if (!textBoxFormatUrlFilm.Text.Contains("{0}"))
            {
                message += "Le format d'URL pour la page du film doit comporter {0} qui sera remplacé par le titre du film.\n";
                textBoxFormatUrlFilm.BackColor = Color.Salmon;
            }
            else
                textBoxFormatUrlFilm.BackColor = SystemColors.Window;

            if (message.Length > 0)
            {
                MessageBox.Show(this, message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rechercheInternet == null)
                rechercheInternet = new RechercheSurSite();

            rechercheInternet.nom = textBoxNom.Text;
            rechercheInternet.formatUrlRecherche = textBoxFormatURLRecherche.Text;

            rechercheInternet.xpathRecherche = textBoxXPathRecherche.Text;
            rechercheInternet.formatUrlFilm = textBoxFormatUrlFilm.Text;
            rechercheInternet.xpathRealisateur = textBoxXPathRealisateur.Text;
            rechercheInternet.xpathActeurs = textBoxXPathActeurs.Text;
            rechercheInternet.xpathGenres = textBoxXPathGenres.Text;
            rechercheInternet.xpathNationalite = textBoxXPathNationalite.Text;
            rechercheInternet.xpathResume = textBoxXPathResume.Text;
            rechercheInternet.xpathDateSortie = textBoxXPathDateSortie.Text;
            rechercheInternet.xpathAffiche = textBoxXPathAffiche.Text;
            return true;
        }

        private void EditeRechercheInternet_Load(object sender, EventArgs e)
        {
            if (rechercheInternet != null)
            {
                textBoxNom.Text = rechercheInternet.nom;
                textBoxFormatURLRecherche.Text = rechercheInternet.formatUrlRecherche;
                textBoxXPathRecherche.Text = rechercheInternet.xpathRecherche;
                textBoxFormatUrlFilm.Text = rechercheInternet.formatUrlFilm;
                textBoxXPathRealisateur.Text = rechercheInternet.xpathRealisateur;
                textBoxXPathActeurs.Text = rechercheInternet.xpathActeurs;
                textBoxXPathGenres.Text = rechercheInternet.xpathGenres;
                textBoxXPathNationalite.Text = rechercheInternet.xpathNationalite;
                textBoxXPathResume.Text = rechercheInternet.xpathResume;
                textBoxXPathDateSortie.Text = rechercheInternet.xpathDateSortie;
                textBoxXPathAffiche.Text = rechercheInternet.xpathAffiche;
            }
        }
    }
}

