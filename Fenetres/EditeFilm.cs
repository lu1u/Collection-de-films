using CollectionDeFilms.Database;
using CollectionDeFilms.Films;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CollectionDeFilms.Fenetres
{

    public partial class EditeFilm : Form
    {
        public Film film;
        bool afficheChangee = false;
        public EditeFilm()
        {
            InitializeComponent();
        }

        private void EditeFilm_Load(object sender, System.EventArgs e)
        {
            if (film == null)
                return;

            labelId.Text = film.Id.ToString();
            labelChemin.Text = film.Chemin;
            textBoxTitre.Text = film.Titre;
            textBoxRealisateur.Text = film.Realisateur;
            textBoxGenres.Text = film.Genres;
            textBoxNationalite.Text = film.Nationalite;
            textBoxActeurs.Text = film.Acteurs;
            textBoxResume.Text = film.Resume;
            textBoxEtiquettes.Text = film.Etiquettes;

            // Etats
            for (int i = 0; i < Film.TEXTES_ETATS.Length; i++)
                comboBoxEtat.Items.Add(Film.TEXTES_ETATS[i]);

            comboBoxEtat.SelectedIndex = film.EtatInt ;
            
            Image image = film.Affiche;
            if (image != null)
                pictureBoxAffiche.Image = image;
        }

        /// <summary>
        /// Obtient le chemin du navigateur Internet
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultBrowserPath()
        {
            string urlAssociation = @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http";
            string browserPathKey = @"$BROWSER$\shell\open\command";

            try
            {
                //Read default browser path from userChoiceLKey
                RegistryKey userChoiceKey = Registry.CurrentUser.OpenSubKey(urlAssociation + @"\UserChoice", false);

                //If user choice was not found, try machine default
                if (userChoiceKey == null)
                {
                    //Read default browser path from Win XP registry key
                    var browserKey = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);

                    //If browser path wasn’t found, try Win Vista (and newer) registry key
                    if (browserKey == null)
                    {
                        browserKey =
                        Registry.CurrentUser.OpenSubKey(
                        urlAssociation, false);
                    }
                    var path = CleanifyBrowserPath(browserKey.GetValue(null) as string);
                    browserKey.Close();
                    return path;
                }
                else
                {
                    // user defined browser choice was found
                    string progId = (userChoiceKey.GetValue("ProgId").ToString());
                    userChoiceKey.Close();

                    // now look up the path of the executable
                    string concreteBrowserKey = browserPathKey.Replace("$BROWSER$", progId);
                    var kp = Registry.ClassesRoot.OpenSubKey(concreteBrowserKey, false);
                    string browserPath = CleanifyBrowserPath(kp.GetValue(null) as string);
                    kp.Close();
                    return browserPath;
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
        private static string CleanifyBrowserPath(string p)
        {
            string[] url = p.Split('"');
            string clean = url[1];
            return clean;
        }

        private void buttonRechercheInternetClick(object sender, EventArgs ev)
        {
            try
            {
                Process.Start(urlRecherche(textBoxTitre.Text));
            }
            catch (Exception e)
            {

                MainForm.WriteExceptionToConsole(e);
            }
        }


        public static string urlRecherche(string u)
        {
            return @"https://www.google.com/search?q=" + "film+" + u.Replace(" ", "+").Replace("/", "").Replace("&", "+").Replace("++", "+");

        }

        private void buttonColler_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                pictureBoxAffiche.Image = Images.retaille( Clipboard.GetImage(), Configuration.largeurMaxImages );
                afficheChangee = true;
            }
        }

        /// <summary>
        /// Clic sur le bouton OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Validation du film
            film.Titre = textBoxTitre.Text;
            film.Realisateur = textBoxRealisateur.Text;
            film.Acteurs = textBoxActeurs.Text;
            film.Genres = textBoxGenres.Text;
            film.DateSortie = textBoxDateSortie.Text;
            film.Nationalite = textBoxNationalite.Text;
            film.Etiquettes = textBoxEtiquettes.Text;
            film.Resume = textBoxResume.Text;
            film.Etat = Film.intToEtat(comboBoxEtat.SelectedIndex);

            BaseFilms.instance.update(film, afficheChangee? pictureBoxAffiche.Image : null );
            MainForm.changeEtat(film);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void onClickChargerFichier(object sender, EventArgs ex)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image i = Image.FromFile(openFileDialog.FileName);
                    if (i != null)
                    {
                        pictureBoxAffiche.Image = i;
                        afficheChangee = true;
                    }
                }
                catch (Exception e)
                {
                    MainForm.WriteExceptionToConsole(e);
                }
            }
        }
    }
}
