using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CollectionDeFilms
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip)]
    class MultiStateMenuItem : ToolStripMenuItem
    {
        private Image[] _images;
        private int _etat;

        internal int Etat { get => _etat; set { _etat = value; setImageFromState(); } }
        public void setImages(Image[] images)
        {
            _images = new Image[images.Length];
            for ( int i = 0;i<images.Length;i++)
            {
                _images[i] = images[i];
            }

            _etat = 0;
            setImageFromState();
        }

        private async void setImageFromState()
        {
            if (_etat >= 0 && _etat < _images.Length)
                Image = _images[_etat];
        }

        protected override void OnClick(EventArgs e)
        {
            if (_images != null)
            {
                if (_etat < _images.Length - 1)
                    _etat++;
                else
                    _etat = 0;
                setImageFromState();
            }
            base.OnClick(e);
        }
    }
}
