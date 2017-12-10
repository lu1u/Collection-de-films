using Collection_de_films.Database;
using System;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using SqlDataReader = System.Data.SQLite.SQLiteDataReader;

namespace Collection_de_films.Films
{
    public class InfosFilm
    {
        public string _realisateur = "";
        public string _acteurs = "";
        public string _genres = "";
        public string _nationalite = "";
        public string _resume = "";
        public string _dateSortie = "";
        public int _imageId = -1;
        private Image _affiche = null;

        public Image affiche
        {
            get
            {
                if ( _affiche == null && _imageId != -1 )
                    _affiche = BaseFilms.instance.getImage( _imageId );
                return _affiche;
            }

            set
            {
                _affiche = value;
                if ( _imageId != -1 )
                    BaseFilms.instance.supprimeImage( _imageId );

                if ( _affiche != null )
                    _imageId = BaseFilms.instance.ajouteImage( _affiche );
            }
        }

        public InfosFilm()
        {

        }


        public InfosFilm( SqlDataReader reader )
        {
            _realisateur = reader.GetString( reader.GetOrdinal( BaseFilms.ALTERNATIVES_REALISATEUR ) );
            _acteurs = reader.GetString( reader.GetOrdinal( (BaseFilms.ALTERNATIVES_ACTEURS) ) );
            _genres = reader.GetString( reader.GetOrdinal( (BaseFilms.ALTERNATIVES_GENRES) ) );
            _nationalite = reader.GetString( reader.GetOrdinal( (BaseFilms.ALTERNATIVES_NATIONALITE) ) );
            _resume = reader.GetString( reader.GetOrdinal( (BaseFilms.ALTERNATIVES_RESUME) ) );
            _dateSortie = reader.GetString( reader.GetOrdinal( (BaseFilms.ALTERNATIVES_DATESORTIE) ) );
            _imageId = reader.GetInt32( reader.GetOrdinal( (BaseFilms.ALTERNATIVES_AFFICHE) ) );
        }

        /// <summary>
        /// Retourne true si l'info est vide (aucune info presente)
        /// </summary>
        /// <returns></returns>
        public bool estVide()
        {
            if ( _realisateur?.Length > 0 ) return false;
            if ( _acteurs?.Length > 0 ) return false;
            if ( _genres?.Length > 0 ) return false;
            if ( _nationalite?.Length > 0 ) return false;
            if ( _resume?.Length > 0 ) return false;
            if ( _dateSortie?.Length > 0 )
                return false;
            if ( _affiche != null )
                return false;
            if ( _imageId != -1 )
                return false;
            return true;
        }

        /// <summary>
        /// Construire un ListviewItem
        /// </summary>
        /// <param name="listView"></param>
        /// <returns></returns>
        internal ListViewItem getListViewItem( ListView listView )
        {
            ListViewItem item = new ListViewItem(_realisateur);
            item.Text = _realisateur;
            item.SubItems.Add( _resume );
            item.SubItems.Add( _genres );
            item.SubItems.Add( _acteurs );
            item.SubItems.Add( _dateSortie );

            Image img = affiche;
            if ( img != null )
            {
                try
                {
                    item.ImageIndex = listView.SmallImageList.Images.Add(img, Color.Transparent);
                }
                catch ( Exception e )
                {
                    MainForm.WriteExceptionToConsole( e );
                }
            }

            item.Tag = this;
            return item;
        }

        internal void copie( InfosFilm autre )
        {
            _realisateur = autre._realisateur;
            _acteurs = autre._acteurs;
            _genres = autre._genres;
            _nationalite = autre._nationalite;
            _resume = autre._resume;
            _dateSortie = autre._dateSortie;
            _imageId = autre._imageId;
            _affiche = autre._affiche;

        }
    }
}


