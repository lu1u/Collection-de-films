using Collection_de_films.Films;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collection_de_films
{
    partial class MainForm
    {
        // Thread-safe method of changing ListView
        delegate void AjouteFilmDelegate(Film f);
        private void AjouteFilm(Film f)
        {
            // Use a delegate if called from a different thread,
            // else just append the text directly
            if (listViewFilms.InvokeRequired)
            {
                listViewFilms.Invoke(new AjouteFilmDelegate(this.AjouteFilm), new object[] { f });
            }
            else
            {
                 ListViewItem item = new ListViewItem(f.Titre);
                item.Text = f.Titre;
                //int indiceImage = listViewFilms.LargeImageList.Images.Add(f.getImage(), Color.Transparent);
                //listViewFilms.SmallImageList.Images.Add(f.getImage(), Color.Transparent);
                //item.ImageIndex = indiceImage;
                item.SubItems.Add(f.Genres);
                item.SubItems.Add(f.Realisateur);
                item.SubItems.Add(f.Acteurs);
                item.SubItems.Add(f.DateSortie);
                item.SubItems.Add(f._etiquettes);
                item.SubItems.Add(f.Resume);
                item.ToolTipText = f.Tooltip();

                item.Tag = f;

                /*if (listViewFilms.Items.Count % 2 == 0)
                    item.BackColor = Color.White;*/

                listViewFilms.Items.Add(item);
                f.setLVItem(item);
            }
        }

        delegate void SetStatusDelegate(string message);

        private void SetStatus(string message)
        {
            // Use a delegate if called from a different thread,
            // else just append the text directly
            try
            {
                if (InvokeRequired)
                {
                    if (!this.IsDisposed)
                        this.Invoke(new SetStatusDelegate(this.SetStatus), new object[] { message });
                }
                else
                {
                    toolStripStatusLabel.Text = message;
                }
            }
            catch(Exception)
            {

            }
        }


        internal static void ajouteFilm(Film film)
        {
            _instance?.AjouteFilm(film);
        }

        // Thread-safe method of changing ListView
        delegate void ChangeAfficheDelegate(Image affiche, ListViewItem lvItem);
        public void ChangeAffiche(Image affiche, ListViewItem lvItem)
        {
            if (affiche == null || lvItem == null)
                return;

            // Use a delegate if called from a different thread,
            // else just append the text directly
            if (this.listViewFilms.InvokeRequired)
            {
                this.listViewFilms.Invoke(new ChangeAfficheDelegate(this.ChangeAffiche), new object[] { affiche, lvItem });
            }
            else
            {
                //listViewFilms.SmallImageList.Images.Add(affiche, Color.Transparent);
                //int indiceImage = listViewFilms.LargeImageList.Images.Add(affiche, Color.Transparent);
                //lvItem.ImageIndex = indiceImage;
                listViewFilms.Invalidate();
            }
        }

        internal static void changeAffiche(Image affiche, ListViewItem lvItem)
        {
            _instance?.ChangeAffiche(affiche, lvItem);
        }

        // Thread-safe method of changing ListView
        public delegate void UpdateDelegate(Film f);
        public void Update(Film f)
        {
            // Use a delegate if called from a different thread,
            // else just append the text directly
            if (this.listViewFilms.InvokeRequired)
            {
                this.listViewFilms.Invoke(new UpdateDelegate(this.Update), new object[] { f });
            }
            else
            {
                ListViewItem item = f.getLVItem();
                if (item == null)
                    item = new ListViewItem();

                while (item.SubItems.Count < 7)
                    item.SubItems.Add("");

                item.Text = f.Titre;
                /*Image image = f.getImage();
                if (image == null)
                    image = Resources.film_nouveau;
                listViewFilms.SmallImageList.Images.Add(image, Color.Transparent);
                int indiceImage = listViewFilms.LargeImageList.Images.Add(image, Color.Transparent);
                item.ImageIndex = indiceImage;
                */
                //item.SubItems[0].Text = f.Titre();
                item.SubItems[1].Text = f.Genres;
                item.SubItems[2].Text = f.Realisateur;
                item.SubItems[3].Text = f.Acteurs;
                item.SubItems[4].Text = f.DateSortie;
                item.SubItems[5].Text = f._etiquettes;
                item.SubItems[6].Text = f.Resume;

                item.ToolTipText = f.Tooltip();
                item.Tag = f;

                f.setLVItem(item);
                listViewFilms.Invalidate();

                if (f == _selected)
                    updatePanneauInfo(f);
            }
        }

        internal static void update(Film f)
        {
            if (f != null)
                _instance?.Update(f);
        }

        // Thread-safe method of changing ListView
        delegate void AjouteFilmATraiterDelegate(Film film);
        void AjouteFilmATraiter(Film film)
        {
            if (film == null)
                return;

            // Use a delegate if called from a different thread,
            // else just append the text directly
            if (this.InvokeRequired)
            {
                this.Invoke(new AjouteFilmATraiterDelegate(this.AjouteFilmATraiter), new object[] { film });
            }
            else
            {
                _filmsATraiter.Add(film);
                SetStatus(_filmsATraiter.Count + " films à traiter");
            }
        }


        internal static void ajouteFilmATraiter(Film film)
        {
            _instance?.AjouteFilmATraiter(film);
        }
    }
}
