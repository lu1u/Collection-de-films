﻿using Collection_de_films.Films;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_de_films.Actions
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

        void ActionDifferee.dansLaQueue( bool queued )
        {
            if ( queued )
                _film.Etat = Film.ETAT.DANS_LA_QUEUE;
            else
                _film.Etat = Film.ETAT.OK;
        }

        void ActionDifferee.execute() => _film.chargeDonneesSite( _nomSite );

        string ActionDifferee.nom() => _film.Titre;
    }
}
