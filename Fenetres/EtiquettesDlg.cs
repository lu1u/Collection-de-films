using CollectionDeFilms.Database;
using CollectionDeFilms.Films;
using System;
using System.Windows.Forms;

///

namespace CollectionDeFilms.Fenetres
{
    /// <summary>
    /// Fenetre pour editer les etiquettes d'un film
    /// </summary>
    public partial class EtiquettesDlg : Form
    {
        // List<TextBox> _textBoxes = new List<TextBox>();
        // List<Button> _supprimer = new List<Button>();

        public Film film;
        AutoCompleteStringCollection _suggestions = new AutoCompleteStringCollection();

        public EtiquettesDlg()
        {
            InitializeComponent();
        }

        private void onLoad(object sender, EventArgs e)
        {
            //this.Text = film.Titre;
            labelTitre.Text = film.Titre;
            pictureBox.Image = film.Affiche;

            flowLayoutPanel.Controls.Clear();
            _suggestions.AddRange(Filtre_et_tri.Etiquettes.getEtiquettes().ToArray());
            // Creer une ligne de saisie pour chaque etiquette
            string etiquettes = film.Etiquettes;
            string[] valeurs = etiquettes.Split(BaseFilms.SEPARATEUR_LISTES_CHAR);
            if (valeurs?.Length > 0)
            {
                for (int i = 0; i < valeurs.Length; i++)
                {
                    TextBox tbEtiquette;
                    creerControles(out tbEtiquette);
                    tbEtiquette.Text = valeurs[i];
                }
            }
        }

        /// <summary>
        /// Creer une ligne de controle pour saisie d'une etiquette
        /// </summary>
        /// <param name="tbEtiquette"></param>
        private void creerControles(out TextBox tbEtiquette)
        {
            int largeurPanel = flowLayoutPanel.Width;
            int largeurBoutonSupp = bPlus.Width;
            int largeurEditBox = largeurPanel - largeurBoutonSupp - 20;

            tbEtiquette = new TextBox();
            tbEtiquette.Width = largeurEditBox;
            tbEtiquette.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbEtiquette.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbEtiquette.AutoCompleteCustomSource = _suggestions;
            tbEtiquette.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            Button bSupprimer = new Button();
            bSupprimer.Text = "-";
            bSupprimer.Width = largeurBoutonSupp;
            bSupprimer.Height = tbEtiquette.Height;
            bSupprimer.Tag = tbEtiquette;           // Textbox associee a ce bouton supprimer
            bSupprimer.Click += new EventHandler(onButtonSupprimerClick);
            bSupprimer.Anchor = AnchorStyles.Right | AnchorStyles.Top;

            flowLayoutPanel.Controls.Add(tbEtiquette);
            flowLayoutPanel.Controls.Add(bSupprimer);
            flowLayoutPanel.SetFlowBreak(bSupprimer, true);
        }

        /// <summary>
        /// Validation de la fenetre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bOk_Click(object sender, EventArgs e)
        {
            // Reconstitue l'etiquette
            string etiquettes = "";
            foreach (Control c in flowLayoutPanel.Controls)
                if (c is TextBox)
                {
                    string etiquette = c.Text;
                    if (etiquette?.Length > 0)
                    {
                        if (etiquettes.Length > 0)
                            etiquettes += BaseFilms.SEPARATEUR_LISTES_CHAR;
                        etiquettes += etiquette;
                    }
                }

            film.Etiquettes = etiquettes;
            BaseFilms.instance.update(film, null);
            MainForm.changeEtat(film);
        }

        private void onButtonPlusClick(object sender, EventArgs e)
        {
            TextBox tbEtiquette;
            creerControles(out tbEtiquette);
        }

        private void onButtonSupprimerClick(object sender, EventArgs e)
        {
            Button bSupprimer = sender as Button;
            if (bSupprimer != null)
                if (bSupprimer.Tag is TextBox)
                {
                    TextBox tbEtiquette = (TextBox)((Control)sender).Tag;

                    // Supprime la textbox et le bouton -
                    flowLayoutPanel.Controls.Remove(tbEtiquette);
                    flowLayoutPanel.Controls.Remove(bSupprimer);
                }
        }
    }
}
