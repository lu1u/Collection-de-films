using Collection_de_films.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collection_de_films.Fenetres
{
    public partial class GestionBase : Form
    {
        public GestionBase()
        {
            InitializeComponent();
        }

        private void onLoad( object sender, EventArgs e )
        {
            remplitListeCollections();
        }

        private void remplitListeCollections()
        {
            listViewBases.Items.Clear();
            string searchPattern = $"*.{BaseFilms.EXTENSION}";
            string[] fichiers = Directory.GetFiles(BaseFilms.baseDefaultLocation(), searchPattern);
            foreach ( string fichier in fichiers )
            {
                string nomCollection = Path.GetFileNameWithoutExtension(fichier);
                FileInfo fi = new FileInfo(fichier);
                ListViewItem lv = new ListViewItem(nomCollection);

                bool Active = nomCollection.Equals(Path.GetFileNameWithoutExtension( BaseFilms.instance.name ));

                lv.SubItems.Add( Active ? "Oui" : "Non" );
                lv.SubItems.Add( DestinationCopie.formateTailleFichier( fi.Length ) );
                lv.SubItems.Add( fi.CreationTime.ToShortDateString() );
                if ( Active )
                    lv.BackColor = Color.LightGray ;
                listViewBases.Items.Add( lv );
            }
        }

        private void onBoutonNouvelleBase( object sender, EventArgs e )
        {
            // Demander nouveau nom
            NouveauNomBase dlg = new NouveauNomBase();
            if ( dlg.ShowDialog( this ) != DialogResult.OK )
                return;

            BaseFilms.creerNouvelleBase( dlg.nom );
            remplitListeCollections();
        }

        private void onButtonActiver( object sender, EventArgs e )
        {
            if ( listViewBases.SelectedItems.Count == 0 )
                return;

            string selected = listViewBases.SelectedItems[0].Text;
            BaseFilms.selectionneNouvelleBase( selected );
            remplitListeCollections();
        }

        private void onListViewDoubleClick( object sender, MouseEventArgs e )
        {
            if ( listViewBases.SelectedItems.Count == 0 )
                return;

            string selected = listViewBases.SelectedItems[0].Text;
            BaseFilms.selectionneNouvelleBase( selected );
            remplitListeCollections();
        }

        private void onButtonSupprimer( object sender, EventArgs e )
        {
            if ( listViewBases.SelectedItems.Count == 0 )
                return;

            string selected = listViewBases.SelectedItems[0].Text;
            if ( selected.Equals( Path.GetFileNameWithoutExtension( BaseFilms.instance.name ) ) )
                MessageBox.Show( "Vous ne pouvez pas supprimer la collection active", "Impossible de supprimer", MessageBoxButtons.OK, MessageBoxIcon.Error );
            else
            {
                if (MessageBox.Show($"Voulez-vous vraiment supprimer la collection {selected}?\nToutes les données seront perdues sans possibilité de les retrouver.", "Supprimer la collection", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    if ( MessageBox.Show( $"Voulez-vous vraiment supprimer la collection {selected}?\nDernière chance de changer d'avis", "Dernière chance", MessageBoxButtons.OKCancel, MessageBoxIcon.Question )
                    == DialogResult.OK )
                    {
                        BaseFilms.supprimeCollection( selected );
                        remplitListeCollections();
                    }
                }
            }
        }
    }
}
