using CollectionDeFilms.Films;
using CollectionDeFilms.Internet.TheMovieDBOrg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
/// <summary>
/// Recherche d'informations sur le site TheMovieDB.Org
/// Base libre d'informations cinematographique
/// L'utilisation de l'api necessite
/// </summary>
namespace CollectionDeFilms.Internet
{
    class RechercheTheMovieDBOrg : RechercheInternet
    {
        //public const string formatUrlRecherche = "https://api.themoviedb.org/3/search/movie?api_key={1}&language=fr&query={0}&page=1&include_adult=true";
        //public const string formatUrlFilm = "https://api.themoviedb.org/3/movie/{0}?api_key={1}&language=fr-FR";
        //public const string formatUrlImage = "https://image.tmdb.org/t/p/w500{0}";
        public RechercheTheMovieDBOrg()
        {
            nom = "The Movie DB";

        }
        internal async override Task<List<Films.InfosFilm>> recherche(Film film)
        {
            try
            {
                // Charger une liste des pages referencant ce film
                MainForm.WriteMessageToConsole("Recherche: " + nom);
                string url = string.Format(Configuration.urlTMDBChercherFilm, requete(film.Titre));
                List<int> ids = await getTMDBFilmIds(url);
                if (ids == null)
                    return null;
                if (ids.Count == 0)
                {
                    MainForm.WriteMessageToConsole($"{film.Titre}: non trouvé sur TMDB.org");
                    return null;
                }

                // Analyser chaque page referencant ce film
                List<Films.InfosFilm> infos = new List<Films.InfosFilm>();
                foreach (int id in ids)
                {
                    string urlIndfos = string.Format(Configuration.urlTMDBInfosFilm, id);
                    Films.InfosFilm info = await chargePageInfosFilm(urlIndfos);
                    if (!(info == null || info.estVide()))
                        infos.Add(info);
                }

                return infos;
            }
            catch (Exception e)
            {
                MainForm.WriteExceptionToConsole(e);
                return null;
            }
        }

        /// <summary>
        /// Lance une recherche sur TMDB.org pour retrouver les ID des films dont le titre correspond
        /// </summary>
        /// <param name="requete"></param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        private async Task<List<int>> getTMDBFilmIds(string requete)
        {
            MainForm.WriteMessageToConsole("Requete " + requete);
            HttpClient client = new HttpClient();

            try
            {
                TMDBListeFilms o = await JsonSerializer.DeserializeAsync<TMDBListeFilms>(await client.GetStreamAsync(requete));
                List<int> res = new List<int>();
                if (o != null)
                    foreach (Result r in o.results)
                        res.Add(r.id);
                return res;
            }
            catch (Exception e)
            {
                MainForm.WriteErrorToConsole("Erreur lors de la lecture de la liste de films " + requete);
                MainForm.WriteExceptionToConsole(e);
                return null;
            }

        }

        /// <summary>
        /// Charge la page d'information d'un film
        /// </summary>
        /// <param name="requete"></param>
        /// <returns></returns>
        private async Task<InfosFilm> chargePageInfosFilm(string requete)
        {
            MainForm.WriteMessageToConsole($"Requete {requete}");
            try
            {
                HttpClient client = new HttpClient();
                TMDBInfosFilm.Rootobject film = await JsonSerializer.DeserializeAsync<TMDBInfosFilm.Rootobject>(await client.GetStreamAsync(requete));
                InfosFilm info = new InfosFilm();
                if (film == null)
                    return null;

                info._titre = film.title; MainForm.WriteMessageToConsole("Genres: " + info._genres);
                info._realisateur = getRealisateur(film); MainForm.WriteMessageToConsole("Réalisateur: " + info._genres);
                info._genres = getGenres(film); MainForm.WriteMessageToConsole("Genres: " + info._genres);
                info._resume = film.overview; MainForm.WriteMessageToConsole("Résumé: " + info._resume);
                info._dateSortie = getDate(film.release_date); MainForm.WriteMessageToConsole("Date sortie: " + info._dateSortie);
                info._nationalite = getNationalite(film);
                info._acteurs = getActeurs(film);
                Image image = await getImage(film);
                MainForm.WriteMessageToConsole($"Genres {info._genres}");
                MainForm.WriteMessageToConsole($"Résumé {info._resume}");
                MainForm.WriteMessageToConsole($"Date sortie {info._dateSortie}");
                MainForm.WriteMessageToConsole($"Nationalité {info._nationalite}");
                MainForm.WriteMessageToConsole($"Acteurs {info._acteurs}");
                if (image != null)
                    info._image = ImagesUtils.retaille(image, Configuration.largeurMaxImages);
                return info;
            }
            catch (Exception e)
            {
                MainForm.WriteErrorToConsole("Erreur lors de la lecture de la liste de films " + requete);
                MainForm.WriteExceptionToConsole(e);
                return null;
            }
        }

        /// <summary>
        /// Retrouve le realisateur dans la liste Crew
        /// </summary>
        /// <param name="film"></param>
        /// <returns></returns>
        private string getRealisateur(TMDBInfosFilm.Rootobject film)
        {
            if (film.credits.crew == null)
                return "";
            foreach (TMDBInfosFilm.Crew c in film.credits.crew)
                if ("director".Equals(c.job.ToLower()))
                    return c.name;
            
            return "";
        }

        private string getActeurs(TMDBInfosFilm.Rootobject film)
        {
            string res = "";
            int nbActeurs = 0;
            foreach (TMDBInfosFilm.Cast c in film.credits.cast)
            {
                if (res.Length > 0)
                    res += "|";

                res += c.name;
                nbActeurs++;
                if (nbActeurs > 4) // Seulement les acteurs principaux
                    break;
            }

            return res;
        }

        private static string getDate(string release_date)
        {
            string[] tokens = release_date.Split('-');
            if (tokens?.Length > 0)
                return tokens[0];

            return release_date;
        }

        private static string getNationalite(TMDBInfosFilm.Rootobject ob)
        {
            if (ob.production_countries?.Length > 0)
            {
                return getTraduction(ob.production_countries[0]);
            }
            else
                return "";
        }

        private static string getTraduction(TMDBInfosFilm.Production_Countries name)
        {
            try
            {
                RegionInfo rInfo = new RegionInfo(name.iso_3166_1);
                return rInfo.DisplayName;
            }
            catch
            {
                // Recupération standard échouée, on peut peut être faire qq chose
                switch (name.iso_3166_1.ToUpper())
                {
                    case "GB": return "Angleterre";
                    case "US": return "Etats unis";
                    case "FR": return "France";
                    case "DE": return "Allemagne";
                    case "HK": return "Hong Kong";
                    case "CN": return "Chine";
                    case "IT": return "Italie";
                    case "JP": return "Japon";
                    case "KP": return "Corée du Nord";
                    case "KR": return "Corée du sud";
                    case "NZ": return "Nouvelle Zélande";
                    case "ES": return "Espagne";
                    case "MX": return "Mexique";
                }
                return name.name;
            }
        }

        /// <summary>
        /// Retrouver l'image du film: le poster si possible, sinon le fond
        /// </summary>
        /// <param name="ob"></param>
        /// <returns></returns>
        private async Task<Image> getImage(TMDBInfosFilm.Rootobject ob)
        {
            string urlFormat = Configuration.urlTMDBAfficheFilm;
            Image img = await InternetUtils.loadImage(string.Format(urlFormat, ob.poster_path));
            if (img != null)
                return img;

            return await InternetUtils.loadImage(string.Format(urlFormat, ob.backdrop_path));
        }

        private static string getGenres(TMDBInfosFilm.Rootobject film)
        {
            string res = "";
            foreach (TMDBInfosFilm.Genre genre in film.genres)
            {
                if (res.Length > 0)
                    res += "|";
                res += genre.name;
            }
            return res;
        }
    }
}
