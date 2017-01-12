using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_de_films.Films
{
    class CollectionFilms
    {
        static private CollectionFilms _instance = new CollectionFilms();
        List<Film> _films;

        private CollectionFilms()
        {
            _films = BaseDonnees.getInstance().getListFilms();
            foreach (Film f in _films)
                MainForm.ajouteFilm(f);

            MainForm.WriteMessageToConsole(_films.Count + " films dans la bibliothèque");
        }


        public static CollectionFilms getInstance()
        {
            return _instance;
        }

        internal bool Ajoute(Film film)
        {
            BaseDonnees bd = BaseDonnees.getInstance();


            return true;
        }
    }
}
