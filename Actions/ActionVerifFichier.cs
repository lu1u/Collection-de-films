using CollectionDeFilms.Films;
using System;
using System.IO;

namespace CollectionDeFilms.Actions
{
    class ActionVerifFichier : ActionDifferee
    {
        Film _film;

        public ActionVerifFichier(Film film)
        {
            _film = film;
        }

        public void dansLaQueue(bool queued = true)
        {
            if (queued)
                _film.Etat = Film.ETAT.DANS_LA_QUEUE;
            else
                _film.Etat = Film.ETAT.OK;
        }

        public void execute()
        {
            try
            {
                MainForm.WriteMessageToConsole($"Vérification du fichier {_film.Chemin}");
                if (!File.Exists(_film.Chemin))
                    _film.FichierNonTrouve = true;
            }
            catch (Exception e)
            {
                MainForm.WriteExceptionToConsole(e);
            }
        }

        string ActionDifferee.nom() => _film.Titre;
    }
}
