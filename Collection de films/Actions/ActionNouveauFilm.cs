using Collection_de_films.Films;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_de_films.Actions
{
    class ActionNouveauFilm : ActionDifferee
    {
        private Film _film;
        public ActionNouveauFilm(Film f)
        {
            _film = f;
        }

        void ActionDifferee.dansLaQueue( bool queued )
        {
            if ( queued )
                _film.Etat = Film.ETAT.DANS_LA_QUEUE;
            else
                _film.Etat = Film.ETAT.OK;
        }

        void ActionDifferee.execute()
        {
                _film.chargeDonnees();
        }
        string ActionDifferee.nom() => _film.Titre;
    }
}
