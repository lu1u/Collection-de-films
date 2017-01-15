using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collection_de_films.Fenetres
{
    public partial class MenageEnCours : Form
    {
        public MenageEnCours()
        {
            InitializeComponent();
        }

        public delegate void pourcentageDelegate(int v);
        public void pourcentage(int v)
        {
            if ( InvokeRequired )
            {
                Invoke(new pourcentageDelegate(pourcentage), new object[] { v });
            }
            else
            {
                progressBar.Value = v;
                progressBar.Invalidate();
                progressBar.Update();
                Invalidate();
                Update();                
            }
        }
    }
}
