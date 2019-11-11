using Collection_de_films.Fenetres;
using CollectionDeFilms.Actions;
using CollectionDeFilms.Database;
using CollectionDeFilms.Films;
using CollectionDeFilms.Internet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionDeFilms
{
    partial class MainForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Mise a jour du panneau d'informations en fonction du film selectionné
        /// </summary>
        /// <param name="film">film</param>
        ///////////////////////////////////////////////////////////////////////////////////////////
        async private void updatePanneauInfo(Film film = null)
        {
            if (film == null)
            {
                // Pas de film selectionné, cacher le panneau d'informations
                flowLayoutPanelInfosFilm.Hide();
                return;
            }

            WriteMessageToConsole($"Film: {film.Titre}, Id={film.Id}");

            flowLayoutPanelInfosFilm.Show();
            flowLayoutPanelInfosFilm.SuspendLayout();
            labelEtat.Text = film.getTextEtat();
            afficheInfoLink(null, linkLabelTitre, film.Titre, InternetUtils.urlRecherche(film.Titre));
            afficheInfoLink(null, linkLabelChemin, film.Chemin, new ProcessStartInfo(getExplorerPath(), " /select, \"" + film.Chemin + "\""));
            afficheInfoLinks(labelKeyRealisateur, linkLabelRealisateur, film.Realisateur);
            afficheInfoLinks(labelKeyActeurs, linkLabelActeurs, film.Acteurs);
            afficheInfoLinks(labelKeyGenres, linkLabelGenres, film.Genres);
            afficheInfo(labelKeyDateSortie, labelDateSortie, film.DateSortie);
            afficheInfo(labelKeyNationalite, labelNationalite, film.Nationalite);
            afficheInfo(labelKeyVuLe, labelVuLe, film.DateVu.Ticks == 0 ? null: film.DateVu.ToLongDateString());
            afficheInfoLinks(labelKeyEtiquettes, linkLabelEtiquettes, film.Etiquettes);
            labelResume.Text = film.Resume;

            switch (film.Etat)
            {
                case Film.ETAT.OK:
                case Film.ETAT.NOUVEAU:
                case Film.ETAT.RECHERCHE:
                    flowLayoutPanelPasTrouve.Hide();
                    break;

                default:
                    flowLayoutPanelPasTrouve.Show();
                    textBoxTitrePasTrouve.Text = film.Titre;
                    break;
            }

            pictureBoxAffiche.Image = film.Affiche;

            listViewAlternatives.Items.Clear();
            List<InfosFilm> alternatives = film.Alternatives();
            if (alternatives?.Count > 0)
            {
                WriteMessageToConsole($"Alternatives: {alternatives.Count}");
                foreach (InfosFilm i in alternatives)
                {
                    WriteMessageToConsole($"Alternative: imageId={i._image}, resumé={i._resume}");
                }

                if (tabControlAlternatives.TabPages.IndexOf(tabpageAlternatives) == -1)
                    tabControlAlternatives.TabPages.Add(tabpageAlternatives);
                foreach (InfosFilm a in alternatives)
                {
                    ListViewItem item = a.getListViewItem(listViewAlternatives);
                    listViewAlternatives.Items.Add(item);
                }

                listViewAlternatives.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                buttonSupprimerAlternatives.Show();
            }
            else
            {
                tabControlAlternatives.TabPages.Remove(tabpageAlternatives);
                buttonSupprimerAlternatives.Hide();
            }

            flowLayoutPanelInfosFilm.ResumeLayout();
        }

        /// <summary>
        /// Mettre a jour un film dans la liste
        /// </summary>
        /// <param name="f"></param>
        private async void updateFilm(Film f)
        {
            if (f != null)
            {
                if (listViewFilms.SelectedItems.Count > 0)
                {
                    listViewFilms.Invalidate(_instance.listViewFilms.SelectedItems[0].Bounds);
                    listViewFilms.SelectedItems[0].ToolTipText = f.getTooltip();
                }
            }
        }

        /// <summary>
        /// Affiche un champ contenant plusieurs informations, separes par SEPARATEUR_LISTE,
        /// un lien pour chaque morceau d'information
        /// </summary>
        /// <param name="key"></param>
        /// <param name="link"></param>
        /// <param name="texte"></param>
        private void afficheInfoLinks(Label key, LinkLabel link, string texte)
        {
            char[] SEPARATEURS = { ',' };
            if (texte?.Length > 0)
            {
                key.Show();
                link.Show();
                link.Links.Clear();
                string[] valeurs = texte.Split(BaseFilms.SEPARATEUR_LISTES_CHAR);
                string label = "";
                int start = 0;
                foreach (string url in valeurs)
                {
                    label += url + ", ";
                    int length = url.Length;
                    LinkLabel.Link lk = new LinkLabel.Link(start, length, $"https://www.google.com/search?q={InternetUtils.urlRecherche(url)}");
                    link.Links.Add(lk);
                    start += length + 2;
                }
                link.Text = label;
            }
            else
            {
                key?.Hide();
                link?.Hide();
            }
        }


        /// <summary>
        /// Montrer une valeur dans le panneau d'information, cacher le control si cette valeur est vide
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="texte"></param>
        private void afficheInfo(Label key, Label value, string texte)
        {
            if (texte?.Length > 0)
            {
                key.Visible = true;
                value.Visible = true;
                value.Text = texte;
            }
            else
            {
                key.Visible = false;
                value.Visible = false;
            }
        }

        /// <summary>
        /// Montrer une valeur avec un lien
        /// </summary>
        /// <param name="key"></param>
        /// <param name="link"></param>
        /// <param name="texte"></param>
        /// <param name="data"></param>
        private void afficheInfoLink(Label key, LinkLabel link, string texte, object data)
        {
            if (texte?.Length > 0)
            {
                key?.Show();
                link.Show();
                link.Links.Clear();
                link.Text = texte;
                link.Links.Add(0, texte.Length, data);
            }
            else
            {
                key?.Hide();
                link?.Hide();
            }
        }



        private string getExplorerPath()
        {
            return Path.Combine(Environment.GetEnvironmentVariable("WINDIR"), "explorer.exe");
        }

        /// <summary>
        /// Remplir la listview des films en fonction du filtre courant
        /// </summary>
        private void remplitListFilms()
        {
            Cursor c = Cursor;
            Cursor = Cursors.WaitCursor;
            listViewFilms.BeginUpdate();
            listViewFilms.Items.Clear();
            IEnumerator<Film> iFilms = BaseFilms.instance.getFilmEnumerator(_filtre);
            _filtre.change = false;

            while (iFilms.MoveNext())
            {
                if (_filtre.change)
                    // Le filtre a change depuis qu'on a commencé à remplir la liste
                    break;

                Film f = iFilms.Current;
                listViewFilms.Items.Add(f.createListviewItem());
            }

            // Selectionner un film
            if (listViewFilms.Items.Count > 0)
            {
                listViewFilms.FocusedItem = listViewFilms.Items[0];
                listViewFilms.Items[0].Selected = true;
                listViewFilms.Select();
            }

            listViewFilms.EndUpdate();
            listViewFilms.Invalidate();

            toolStripStatusLabelNbAffiches.Text = string.Format("{0} films affichés", listViewFilms.Items.Count);
            toolStripStatusLabelNbFilmsBD.Text = string.Format("{0} films dans la base", BaseFilms.instance.getNbFilms());

            Cursor = c;
        }



        /// <summary>
        /// Lors de l'ouverture d'une base, reprend les traitements en tache de fond
        /// </summary>
        public void reprendTraitementFilms()
        {
            _actionsDifferees.Clear();

            IEnumerator<Film> iFilms = BaseFilms.instance.getFilmEnumerator($" {BaseFilms.FILMS_ETAT}={Film.etatToInt(Film.ETAT.PAS_TROUVE)} OR {BaseFilms.FILMS_ETAT}={Film.etatToInt(Film.ETAT.NOUVEAU)} OR {BaseFilms.FILMS_ETAT}={Film.etatToInt(Film.ETAT.DANS_LA_QUEUE)}");
            while (iFilms.MoveNext())
            {
                Film f = iFilms.Current;
                _actionsDifferees.ajoute(new ActionNouveauFilm(f), ActionsDifferees.PRIORITE.BASSE);
            }
        }

        /// <summary>
        /// Retourne le film selectionne dans la liste, ou null
        /// </summary>
        /// <returns></returns>
        private Film getSelectedFilm()
        {
            if (listViewFilms.SelectedIndices.Count < 1)
                return null;

            return listViewFilms.Items[listViewFilms.SelectedIndices[0]].Tag as Film;
        }

        /// <summary>
        /// Scrute un repertoire a la recherche de films, scrute aussi les sous repertoire si sousrepertoire = true
        /// </summary>
        /// <param name="path"></param>
        /// <param name="sousrepertoires"></param>
        /// <param name="etiquettes"></param>
        /// <param name="tagrepertoire"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private async Task<bool> scruteRepertoire(string path, bool sousrepertoires, string etiquettes, bool tagrepertoire, AjouteRepertoire.ACTION_SI_DUPPLIQUE action)
        {
            BaseFilms bd = BaseFilms.instance;
            WriteMessageToConsole($"Parcours du répertoire {path}");
            try
            {
                string[] fichiers = Directory.GetFiles(path);
                foreach (string fichier in fichiers)
                {
                    WriteMessageToConsole($"Fichier {fichier}");
                    if (getCancel())
                        return false;

                    if (Film.fichierSupporte(fichier))
                    {
                        if (bd.filmExisteFichier(fichier))
                        {
                            // Le film existe deja, action a entreprendre en fonction du choix de l'utilisateur
                            switch (action)
                            {
                                case AjouteRepertoire.ACTION_SI_DUPPLIQUE.IGNORER_NOUVEAU:
                                    WriteMessageToConsole($"{fichier} déjà référencé, ignoré");
                                    break;

                                case AjouteRepertoire.ACTION_SI_DUPPLIQUE.AJOUTER_NOUVEAU:
                                    {
                                        WriteMessageToConsole($"{fichier} déjà référencé, ajouter le nouveau");
                                        Film film = new Film(fichier, etiquettes);
                                        bd.ajouteFilm(film);
                                        ajouteFilm(film);
                                        _actionsDifferees.ajoute(new ActionNouveauFilm(film));                                        
                                    }
                                    break;

                                case AjouteRepertoire.ACTION_SI_DUPPLIQUE.REMPLACER_ANCIEN:
                                    {
                                        Film f = await bd.getFilmFichier(Path.GetFileNameWithoutExtension(fichier));
                                        if (f != null)
                                        {
                                            WriteMessageToConsole($"{fichier} déjà référencé, remplacer l'ancien {f.Chemin}.");
                                            if (!f.Chemin.Equals(fichier))
                                            {
                                                f.Chemin = fichier;
                                                bd.update(f);
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            // Nouveau fichier non encore reference dans la base
                            Film film = new Film(fichier, etiquettes);
                            WriteMessageToConsole($"Ajout du film {fichier}");
                            bd.ajouteFilm(film);
                            ajouteFilm(film);
                            _actionsDifferees.ajoute(new ActionNouveauFilm(film));
                        }

                    }
                    else
                        WriteMessageToConsole("Pas un fichier film supporté");
                }

                if (getCancel())
                    return false;

                if (sousrepertoires)
                {
                    // Sous repertoires
                    WriteMessageToConsole($"Parcours des sous repertoires de {path}");
                    string[] directories = Directory.GetDirectories(path);
                    foreach (string repertoire in directories)
                    {
                        if (getCancel())
                            return false;
                        string etiq = etiquettes;
                        if (tagrepertoire)
                            etiq += (etiq.Length == 0 ? "" : BaseFilms.SEPARATEUR_LISTES) + new DirectoryInfo(repertoire).Name;
                        await scruteRepertoire(repertoire, sousrepertoires, etiq, tagrepertoire, action);
                    }
                }
            }
            catch (Exception e)
            {
                WriteErrorToConsole("Erreur lors de la scrutation du répertoire " + path);
                WriteExceptionToConsole(e);
            }
            return true;
        }

        public bool getCancel()
        {
            return false;
        }
    }
}
