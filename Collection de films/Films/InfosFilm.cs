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

        private Image _affiche;

        public Image affiche
        {
            get
            {
                if (_affiche == null)
                    _affiche = BaseDonnees.getInstance().getImage(_imageId);
                return _affiche;
            }

            set
            {
                _affiche = value;
            }
        }

        public InfosFilm()
        {

        }


        public InfosFilm(SqlDataReader reader)
        {
            _realisateur = reader.GetString(reader.GetOrdinal(BaseDonnees.ALTERNATIVES_REALISATEUR));
            _acteurs = reader.GetString(reader.GetOrdinal((BaseDonnees.ALTERNATIVES_ACTEURS)));
            _genres = reader.GetString(reader.GetOrdinal((BaseDonnees.ALTERNATIVES_GENRES)));
            _nationalite = reader.GetString(reader.GetOrdinal((BaseDonnees.ALTERNATIVES_NATIONALITE)));
            _resume = reader.GetString(reader.GetOrdinal((BaseDonnees.ALTERNATIVES_RESUME)));
            _dateSortie = reader.GetString(reader.GetOrdinal((BaseDonnees.ALTERNATIVES_DATESORTIE)));
            _imageId = reader.GetInt32(reader.GetOrdinal((BaseDonnees.ALTERNATIVES_AFFICHE)));
        }

        public bool estVide()
        {
            if (_realisateur == null || _realisateur.Length > 0)
                return false;

            if (_acteurs == null || _acteurs.Length > 0)
                return false;
            if (_genres == null || _genres.Length > 0)
                return false;
            if (_nationalite == null || _nationalite.Length > 0)
                return false;
            if (_resume == null || _resume.Length > 0)
                return false;
            if (_dateSortie == null || _dateSortie.Length > 0)
                return false;
            if (_affiche != null)
                return false;
            return true;
        }

        /// <summary>
        /// Construire un ListviewItem
        /// </summary>
        /// <param name="listView"></param>
        /// <returns></returns>
        internal ListViewItem getListViewItem(ListView listView)
        {
            ListViewItem item = new ListViewItem(_realisateur);
            item.Text = _realisateur;
            item.SubItems.Add(_genres);
            item.SubItems.Add(_acteurs);
            item.SubItems.Add(_dateSortie);
            item.SubItems.Add(_resume);

            Image img = affiche;
            if (img != null)
            {
                int indiceImage = listView.SmallImageList.Images.Add(img, Color.Transparent);
                item.ImageIndex = indiceImage;
            }

            item.Tag = this;
            return item;
        }
    }
}
