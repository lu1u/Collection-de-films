using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CollectionDeFilms.ControlesUtilisateur
{
    public partial class ListeProprietes : UserControl
    {
        int _interligne;
        bool _alternee = true;
        Color _deuxiemeCouleur = SystemColors.ControlLight;

        [Description("Interligne"), Category("Apparence")]
        public int Interligne { get => _interligne; set { _interligne = value; Invalidate(); } }


        [Description("Lignes alternées"), Category("Apparence")]
        public bool Alternées { get => _alternee; set { _alternee = value; Invalidate(); } }

        [Description("Deuxième couleur"), Category("Apparence")]
        public Color DeuxiemeCouleur { get => _deuxiemeCouleur; set { _deuxiemeCouleur = value; Invalidate(); } }

        private List<Propriete> _listeProprietes = new List<Propriete>();

        public ListeProprietes()
        {
            InitializeComponent();
        }

        public void onClickLink(string link)
        {
            MainForm.WriteMessageToConsole(link);
        }
        private void ListeProprietes_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.DoubleBuffer |ControlStyles.UserPaint |ControlStyles.AllPaintingInWmPaint,true);
            UpdateStyles();
            Brush b = new SolidBrush(this.ForeColor);
            AjoutePropriete(new ProprieteTexte("Un:", "1"));
            AjoutePropriete(new ProprieteTexte("Deux:", "22"));
            AjoutePropriete(new ProprieteTexte("Trois:", "333"));

            ProprieteLink.Link[] links = new ProprieteLink.Link[3];
            links[0] = new ProprieteLink.Link("Un", "un_link", (a) => { MainForm.WriteMessageToConsole("A: " + a); });
            links[1] = new ProprieteLink.Link("Deux", "deux_link", onClickLink);
            links[2] = new ProprieteLink.Link("Trois", "trois_link", onClickLink);
            AjoutePropriete(new ProprieteLink("Link:", links));
        }

        internal void Clear()
        {
            _listeProprietes.Clear();
            Invalidate();
        }

        public void AjoutePropriete(Propriete propriete)
        {
            propriete.setFont(Font, new SolidBrush(ForeColor));
            _listeProprietes.Add(propriete);
            float xLabel = 0;
            foreach (Propriete p in _listeProprietes)
            {
                SizeF s = p.GetLargeurLabel();
                float label = s.Width;
                if (label > xLabel)
                    xLabel = label;

            }

            foreach (Propriete p in _listeProprietes)
                p.SetLargeurLabel(xLabel + 10, ClientRectangle.Width);

            PlaceProprietes();
            Invalidate();
        }

        private void PlaceProprietes()
        {
            int hauteurTotale = 0;
            int largeurClient = ClientRectangle.Width - 2;
            foreach (Propriete p in _listeProprietes)
            {
                Size taillePropriete = p.getTaille(largeurClient);
                p.SetRectangle(new Rectangle(0, hauteurTotale, largeurClient, (int)taillePropriete.Height));
                hauteurTotale += _interligne + taillePropriete.Height ;
            }

            MinimumSize = new Size(MinimumSize.Width, (int)hauteurTotale);
            Size = new Size(Size.Width, (int)hauteurTotale);
        }

        private void onPaint(object sender, PaintEventArgs e)
        {
            float y = 0;

            Brush alternee = new SolidBrush(_deuxiemeCouleur);
            bool unSurDeux = false;
            foreach (Propriete p in _listeProprietes)
            {
                SizeF s = p.getTaille(ClientRectangle.Width);
                RectangleF bounds = new RectangleF(0, y, this.ClientRectangle.Width, s.Height);

                if (_alternee)
                {
                    unSurDeux = !unSurDeux;
                    if (unSurDeux)
                    {
                        e.Graphics.FillRectangle(alternee, bounds);
                    }
                }

                p.Dessine(e.Graphics, bounds);
                y += s.Height + _interligne;
            }
        }


        private void onMouseMove(object sender, MouseEventArgs e)
        {
            RectangleF rPropriete;
            float py = 0;
            bool invalidate;
            Cursor change = Cursors.Default ;
            foreach (Propriete p in _listeProprietes)
            {
                invalidate = false;
                SizeF s = p.getTaille(ClientRectangle.Width);
                rPropriete = new RectangleF(0, py, this.ClientRectangle.Width, s.Height);
                Cursor c = p.OnMouseMove(rPropriete, e.X, e.Y, out invalidate);
                if (c != null)
                    change = c;
                
                if (invalidate)
                    Invalidate();

                py += s.Height + _interligne;
            }

            Cursor = change;
        }

        // Retrouve la propriete qui est aux coordonnees
        private Propriete getPropriete(int x, int y, out RectangleF rPropriete)
        {
            float py = 0;
            foreach (Propriete p in _listeProprietes)
            {
                SizeF s = p.getTaille(ClientRectangle.Width);
                rPropriete = new RectangleF(0, py, this.ClientRectangle.Width, s.Height);
                if (rPropriete.Contains(x, y))
                {
                    return p;
                }
                py += s.Height + _interligne;
            }

            rPropriete = new RectangleF();
            return null;
        }

        private void ListeProprietes_MouseDown(object sender, MouseEventArgs e)
        {
            RectangleF rProp;
            Propriete p = getPropriete(e.X, e.Y, out rProp);
            if (p != null)
            {
                bool update = p.OnClick(rProp, e.X, e.Y);
                if (update)
                    Invalidate();
            }
        }

        private void ListeProprietes_Resize(object sender, EventArgs e)
        {
            PlaceProprietes();
        }
    }
}
