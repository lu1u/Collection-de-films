using Collection_de_films.Database;
using Collection_de_films.Films;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Collection_de_films.Fenetres
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

            labelChemin.Text = film.Chemin;
            textBoxTitre.Text = film.Titre;
            textBoxRealisateur.Text = film.Realisateur;
            textBoxGenres.Text = film.Genres;
            textBoxNationalite.Text = film.Nationalite;
            textBoxActeurs.Text = film.Acteurs;
            textBoxResume.Text = film.Resume;
            textBoxEtiquettes.Text = film._etiquettes;
            Image image = film.getAffiche();
            if (image != null)
                pictureBoxAffiche.Image = image;
        }

        public static string GetDefaultBrowserPath()
        {
            string urlAssociation = @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http";
            string browserPathKey = @"$BROWSER$\shell\open\command";

            RegistryKey userChoiceKey = null;
            string browserPath = "";

            try
            {
                //Read default browser path from userChoiceLKey
                userChoiceKey = Registry.CurrentUser.OpenSubKey(urlAssociation + @"\UserChoice", false);

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
                    browserPath = CleanifyBrowserPath(kp.GetValue(null) as string);
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
            return @"https://www.google.com/search?q=" + "film+" + u.Replace(" ", "+").Replace("/", "").Replace("&", "+").Replace("++","+") ;

        }

        private void buttonColler_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                pictureBoxAffiche.Image = Clipboard.GetImage();
                afficheChangee = true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Validation du film
            film.Titre = textBoxTitre.Text ;
            film.Realisateur = textBoxRealisateur.Text;
            film.Acteurs = textBoxActeurs.Text;
            film.Genres = textBoxGenres.Text;
            film.DateSortie = textBoxDateSortie.Text;
            film.Nationalite = textBoxNationalite.Text;
            film._etiquettes = textBoxEtiquettes.Text;
            film.Resume = textBoxResume.Text;
            if (afficheChangee)
                film.affiche = pictureBoxAffiche.Image;

            BaseFilms.instance.update(film);
            MainForm.update(film);

            DialogResult = DialogResult.OK;
            Close() ;
        }

        private void onClickChargerFichier(object sender, EventArgs ex)
        {
            if ( openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image i = Image.FromFile(openFileDialog.FileName);
                    if( i!=null)
                    {
                        pictureBoxAffiche.Image = i;
                        afficheChangee = true;
                    }
                }
                catch(Exception e)
                {
                    MainForm.WriteExceptionToConsole(e);
                }
            }
        }
    }
}
