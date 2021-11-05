﻿namespace CollectionDeFilms.Internet.TheMovieDBOrg
{
    // Structure du JSON fourni par The Movie DB Org
    public class TMDBInfosFilm
    {
        public class Rootobject
        {
            public bool adult { get; set; }
            public string backdrop_path { get; set; }
            public object belongs_to_collection { get; set; }
            public int budget { get; set; }
            public Genre[] genres { get; set; }
            public object homepage { get; set; }
            public int id { get; set; }
            public object imdb_id { get; set; }
            public string original_language { get; set; }
            public string original_title { get; set; }
            public string overview { get; set; }
            public float popularity { get; set; }
            public string poster_path { get; set; }
            public Production_Companies[] production_companies { get; set; }
            public Production_Countries[] production_countries { get; set; }
            public string release_date { get; set; }
            public int revenue { get; set; }
            public object runtime { get; set; }
            public Spoken_Languages[] spoken_languages { get; set; }
            public string status { get; set; }
            public string tagline { get; set; }
            public string title { get; set; }
            public bool video { get; set; }
            public float vote_average { get; set; }
            public int vote_count { get; set; }
            public Credits credits { get; set; }
        }

        public class Credits
        {
            public Cast[] cast { get; set; }
            public Crew[] crew { get; set; }
        }

        public class Cast
        {
            public bool adult { get; set; }
            public int gender { get; set; }
            public int id { get; set; }
            public string known_for_department { get; set; }
            public string name { get; set; }
            public string original_name { get; set; }
            public float popularity { get; set; }
            public object profile_path { get; set; }
            public int cast_id { get; set; }
            public string character { get; set; }
            public string credit_id { get; set; }
            public int order { get; set; }
        }

        public class Crew
        {
            public bool adult { get; set; }
            public int gender { get; set; }
            public int id { get; set; }
            public string known_for_department { get; set; }
            public string name { get; set; }
            public string original_name { get; set; }
            public float popularity { get; set; }
            public object profile_path { get; set; }
            public string credit_id { get; set; }
            public string department { get; set; }
            public string job { get; set; }
        }

        public class Genre
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Production_Companies
        {
            public int id { get; set; }
            public object logo_path { get; set; }
            public string name { get; set; }
            public string origin_country { get; set; }
        }

        public class Production_Countries
        {
            public string iso_3166_1 { get; set; }
            public string name { get; set; }
        }

        public class Spoken_Languages
        {
            public string english_name { get; set; }
            public string iso_639_1 { get; set; }
            public string name { get; set; }
        }

    }
}
