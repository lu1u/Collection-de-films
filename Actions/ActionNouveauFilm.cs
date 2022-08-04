using CollectionDeFilms.Database;
using CollectionDeFilms.Films;

namespace CollectionDeFilms.Actions
{
    class ActionNouveauFilm : ActionDifferee
    {
        private Film _film;
        public ActionNouveauFilm(Film f)
        {
            _film = f;
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

            _film.chargeDonneesInternet();
        }
        string ActionDifferee.nom() => _film.Titre;
    }
}
