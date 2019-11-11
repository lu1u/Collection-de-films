using CollectionDeFilms.Database;
using CollectionDeFilms.Films;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// Export de la liste des films dans un fichier CSV
/// </summary>
namespace CollectionDeFilms.Fenetres
{
    public partial class ExporteFilms : Form
    {
        public ExporteFilms()
        {
            InitializeComponent();
        }

        private void onClicButtonFile(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                textBoxChemin.Text = saveFileDialog.FileName;
            }
        }

        private void onFormLoad(object sender, EventArgs e)
        {
            buttonOk.Enabled = textBoxChemin.Text.Length > 0;
        }

        private void onTextBoxCheminChanged(object sender, EventArgs e)
        {
            buttonOk.Enabled = textBoxChemin.Text.Length > 0;
        }

        private void onButtonOk(object sender, EventArgs ev)
        {
            buttonCancel.Enabled = false;
            buttonOk.Enabled = false;

            Cursor c = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // Sauvegarde dans un fichier CSV

            string filename = textBoxChemin.Text;
            try
            {
                // Creation du fichier
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename))
                {
                    if (checkBoxEntetes.Checked)
                        ecritEntetes(file);

                    Filtre filtre;
                    if (radioButtonTous.Checked)
                        // Tous les films
                        filtre = new Filtre();
                    else
                        // Films selectionnes dans l'interface
                        filtre = MainForm._instance._filtre;

                    IEnumerator<Film> iFilms = BaseFilms.instance.getFilmEnumerator(filtre);

                    while (iFilms.MoveNext())
                    {
                        ecritFilm(file, iFilms.Current);
                    }
                }
            }
            catch (Exception e)
            {
                MainForm.WriteErrorToConsole("Erreur lors de l'écriture du fichier " + filename);
                MainForm.WriteExceptionToConsole(e);
            }

            DialogResult = DialogResult.OK;
            Close();
            this.Cursor = c;
        }

        private void ecritFilm(StreamWriter file, Film film)
        {
            StringBuilder b = new StringBuilder();
            concat(b, toCSV(film.Id.ToString()), checkBoxId);
            concat(b, toCSV(film.Titre));
            concat(b, toCSV(film.Chemin), checkBoxCheminFichier);
            concat(b, toCSV(film.Resume), checkBoxResume);
            concat(b, toCSV(film.Realisateur), checkBoxRealisateur);
            concat(b, toCSV(film.Acteurs), checkBoxActeurs);
            concat(b, toCSV(film.Nationalite), checkBoxNationalite);
            concat(b, toCSV(film.Genres), checkBoxGenres);
            concat(b, toCSV(film.DateSortie), checkBoxDateSortie);
            concat(b, toCSV(film.DateVu.ToString()), checkBoxDateVue);

            file.WriteLine(b.ToString());
        }

        /// <summary>
        /// Convertir une chaine de caracteres au format CSV:
        /// - remplacer les " par des ""
        /// - mettre entre double cotes si besoin
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private string toCSV(string v)
        {
            string res = v;
            if (res.Length > 0)
            {
                res.Replace("\"", "\"\"");
                if (res.IndexOf(",") != -1 || res.IndexOf("\"") != -1 || res.IndexOf("\n") != -1 || res.StartsWith(" ") || res.EndsWith(" "))
                    res = "\"" + res + "\"";
            }
            return res;
        }

        /// <summary>
        /// Ecrit les entetes des colonnes
        /// </summary>
        /// <param name="file"></param>
        private void ecritEntetes(StreamWriter file)
        {
            StringBuilder b = new StringBuilder();
            concat(b, BaseFilms.FILMS_ID, checkBoxId);
            concat(b, BaseFilms.FILMS_TITRE);
            concat(b, BaseFilms.FILMS_CHEMIN, checkBoxCheminFichier);
            concat(b, BaseFilms.FILMS_RESUME, checkBoxResume);
            concat(b, BaseFilms.FILMS_REALISATEUR, checkBoxRealisateur);
            concat(b, BaseFilms.FILMS_ACTEURS, checkBoxActeurs);
            concat(b, BaseFilms.FILMS_NATIONALITE, checkBoxNationalite);
            concat(b, BaseFilms.FILMS_GENRES, checkBoxGenres);
            concat(b, BaseFilms.FILMS_DATESORTIE, checkBoxDateSortie);
            concat(b, BaseFilms.FILMS_DATEVU, checkBoxDateVue);

            file.WriteLine(b.ToString());
        }

        /// <summary>
        /// Concatene une chaine a celle donnée, en séparant par une virgule si besoin
        /// </summary>
        /// <param name="b"></param>
        /// <param name="chaine"></param>
        /// <param name="condition"></param>
        private void concat(StringBuilder b, string chaine, CheckBox cb = null)
        {
            if (cb?.Checked == false)
                return;

            if (b.Length > 0)
                    b.Append(",");
                b.Append(chaine);           
        }

        private void onButtonCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
