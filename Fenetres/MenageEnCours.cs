using System.Windows.Forms;

namespace CollectionDeFilms.Fenetres
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
            if (InvokeRequired)
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
