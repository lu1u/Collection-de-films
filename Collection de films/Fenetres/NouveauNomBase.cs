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
    public partial class NouveauNomBase : Form
    {
        public string nom = "";
        public static readonly char[] INVALIDES = { '.', '\"', '<', '>', '\\', '/', ':',  '*',  '?',  '|' };
        public NouveauNomBase()
        {
            InitializeComponent();
        }

        private void buttonOK_Click( object sender, EventArgs e )
        {
            // Nouveau nom
            nom = textBoxNouveauNom.Text;

            // Nom correct ?
            if (! isValide(nom))
            {
                MessageBox.Show( $"Le nom '{nom} est invalide.\nLe nom de la collection ne doit pas comporter les caractères suivants:\n{concat(INVALIDES)}", "Nom invalide", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            // N'existe pas encore?
            if ( BaseFilms.Existe(nom))
            {
                MessageBox.Show( $"La collection {nom} existe déjà", "Nom invalide", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private object concat( char[] caracteres )
        {
            string res = "";
            foreach ( char c in caracteres )
                res += c;

            return res;
        }

        private bool isValide( string nom )
        {
            return !string.IsNullOrEmpty(nom) &&
              nom.IndexOfAny(INVALIDES) < 0 ;
        }
    }
}
