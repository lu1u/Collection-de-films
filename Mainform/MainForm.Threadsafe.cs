using CollectionDeFilms.Films;
using CollectionDeFilms.Filtre_et_tri;
using System.Windows.Forms;

namespace CollectionDeFilms
{
    partial class MainForm
    {
        // Thread-safe method of changing ListView
        public delegate void ChangeEtatDelegate(Film f);

        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Mise a jour d'un film dans la listview
        /// </summary>
        /// <param name="f">Film a mettre a jour</param>
        ///////////////////////////////////////////////////////////////////////////////////////////
        internal static void changeEtat(Film f)
        {
            if (_instance.InvokeRequired)
            {
                _instance.Invoke(new ChangeEtatDelegate(MainForm.changeEtat), new object[] { f });
            }
            else
            {
                Genres.updateGenres();
                Etiquettes.updateEtiquettes();
                Film selected = _instance.getSelectedFilm();
                _instance.updateFilm(f);
                if (f == selected)
                    _instance.updatePanneauInfo(f);
            }
        }

        public delegate void AjouteFilmDelegate(Film f);
        public static void ajouteFilm(Film film)
        {
            if (_instance.InvokeRequired)
            {
                _instance.Invoke(new AjouteFilmDelegate(MainForm.ajouteFilm), new object[] { film });
            }
            else
            {
                Genres.updateGenres();
                Etiquettes.updateEtiquettes();

                _instance.listViewFilms.Items.Add(film.createListviewItem());
                int index = _instance.listViewFilms.Items.Count - 1;
                //_instance.listViewFilms.EnsureVisible(index);
                _instance.listViewFilms.Items[index].Selected = true;

                _instance.listViewFilms.Select();
                _instance.listViewFilms.Invalidate(_instance.listViewFilms.Items[index].Bounds);
            }
        }

    }
}
