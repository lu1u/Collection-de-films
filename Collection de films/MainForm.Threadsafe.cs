using Collection_de_films.Actions;
using Collection_de_films.Films;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collection_de_films
{
    partial class MainForm
    {
        // Thread-safe method of changing ListView
        delegate void AjouteFilmDelegate( Film f );
        private void AjouteFilm( Film f )
        {
            // Use a delegate if called from a different thread,
            // else just append the text directly
            if ( listViewFilms.InvokeRequired )
            {
                listViewFilms.Invoke( new AjouteFilmDelegate( this.AjouteFilm ), new object[] { f } );
            }
            else
            {
                ListViewItem item = f.getListviewItem(listViewFilms);
                listViewFilms.Items.Add( item );
            }
        }




        internal static void ajouteFilm( Film film )
        {
            _instance?.AjouteFilm( film );
        }

        // Thread-safe method of changing ListView
        delegate void ChangeAfficheDelegate( Image affiche, ListViewItem lvItem );
        public void ChangeAffiche( Image affiche, ListViewItem lvItem )
        {
            if ( affiche == null || lvItem == null )
                return;

            // Use a delegate if called from a different thread,
            // else just append the text directly
            if ( this.listViewFilms.InvokeRequired )
            {
                this.listViewFilms.Invoke( new ChangeAfficheDelegate( this.ChangeAffiche ), new object[] { affiche, lvItem } );
            }
            else
            {
                //listViewFilms.SmallImageList.Images.Add(affiche, Color.Transparent);
                //int indiceImage = listViewFilms.LargeImageList.Images.Add(affiche, Color.Transparent);
                //lvItem.ImageIndex = indiceImage;
                ((Film) lvItem.Tag).updateListviewItem( _instance.listViewFilms );
            }
        }

        internal static void changeAffiche( Image affiche, ListViewItem lvItem )
        {
            _instance?.ChangeAffiche( affiche, lvItem );
        }

        // Thread-safe method of changing ListView
        public delegate void UpdateDelegate( Film f );

        internal static void update( Film f )
        {
            if ( _instance.InvokeRequired )
            {
                _instance.Invoke( new UpdateDelegate( MainForm.update ), new object[] { f } );
            }
            else
            {
                f.updateListviewItem( _instance.listViewFilms );
                //_instance.listViewFilms.Invalidate();
                if ( f.Id == _instance._selectedId )
                    _instance.updatePanneauInfo( f );
            }

        }
    }
}
