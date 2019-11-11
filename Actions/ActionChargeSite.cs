
using CollectionDeFilms.Database;
using CollectionDeFilms.Films;

namespace CollectionDeFilms.Actions
{
    class ActionChargeSite : ActionDifferee
    {
        Film _film;
        string _nomSite;

        public ActionChargeSite(Film film, string site)
        {
            _film = film;
            _nomSite = site;
        }

        void ActionDifferee.dansLaQueue(bool queued)
        {
            if (queued)
                _film.Etat = Film.ETAT.DANS_LA_QUEUE;
            else
                _film.Etat = Film.ETAT.OK;
        }

        async void ActionDifferee.execute()
        {
            if (_film == null)
                return;
            if (!await BaseFilms.instance.existe(_film.Id))
                return;

            _film.chargeDonneesSite(_nomSite);
        }



        string ActionDifferee.nom() => _film.Titre;
    }
}
