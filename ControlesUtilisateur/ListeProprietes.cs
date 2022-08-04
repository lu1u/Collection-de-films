using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CollectionDeFilms.ControlesUtilisateur
{
    public partial class ListeProprietes : UserControl
    {
        public class Attributs
        {
            public int _interligne;
            public bool _alternee = true;
            public Color _couleurDeuxieme = SystemColors.ControlLight;
            public Color _couleurLien = Color.FromArgb(255, 0, 0, 255);
            public Color _couleurHover = Color.FromArgb(255, 170, 210, 238);
            public Color _couleurVisite = Color.FromArgb(255, 128, 0, 128);
            public Color _couleurTexte = SystemColors.ControlText;
            public Brush _BrushDeuxieme;
            public Brush _BrushLien;
            public Brush _BrushHover;
            public Brush _BrushText;
            public Brush _BrushVisite = new SolidBrush(Color.FromArgb(255, 128, 0, 128));
            public Pen _penHover;
            public Font _fonte;
            public Attributs()
            {
                _alternee = true;
                _BrushDeuxieme = new SolidBrush(_couleurDeuxieme);
                _BrushLien = new SolidBrush(_couleurLien);
                _BrushHover = new SolidBrush(_couleurHover);
                _BrushVisite = new SolidBrush(_couleurVisite);
                _BrushText = new SolidBrush(_couleurTexte);
                _penHover = new Pen(Color.Black);
                _penHover.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                _fonte = SystemFonts.DialogFont;
            }
        };
        private Attributs _attributs = new Attributs();

        [Description("Interligne"), Category("Apparence")] public int Interligne { get => _attributs._interligne; set { _attributs._interligne = value; Invalidate(); } }
        [Description("Lignes alternées"), Category("Apparence")] public bool Alternées { get => _attributs._alternee; set { _attributs._alternee = value; Invalidate(); } }

        [Description("Deuxième couleur"), Category("Apparence")] public Color DeuxiemeCouleur { get => _attributs._couleurDeuxieme; set { _attributs._couleurDeuxieme = value; _attributs._BrushDeuxieme = new SolidBrush(_attributs._couleurDeuxieme); Invalidate(); } }
        [Description("Couleur Liens"), Category("Apparence")] public Color CouleurLien { get => _attributs._couleurLien; set { _attributs._couleurLien = value; _attributs._BrushLien = new SolidBrush(_attributs._couleurLien); Invalidate(); } }
        [Description("Couleur Liens Hover"), Category("Apparence")] public Color CouleurLienHover { get => _attributs._couleurHover; set { _attributs._couleurHover = value; _attributs._BrushHover = new SolidBrush(_attributs._couleurHover); Invalidate(); } }
        [Description("Couleur Liens Visité"), Category("Apparence")] public Color CouleurLienVisite { get => _attributs._couleurVisite; set { _attributs._couleurVisite = value; _attributs._BrushVisite = new SolidBrush(_attributs._couleurVisite); Invalidate(); } }
        [Description("Couleur Texte"), Category("Apparence")] public Color CouleurTexte { get => _attributs._couleurTexte; set { _attributs._couleurTexte = value; _attributs._BrushText = new SolidBrush(_attributs._couleurTexte); Invalidate(); } }
        [Description("Fonte texte"), Category("Apparence")] public Font Fonte { get => _attributs._fonte; set { _attributs._fonte = value; Invalidate(); } }

        private List<Propriete> _listeProprietes = new List<Propriete>();

        private bool _placerProprietes = true;
        public ListeProprietes()
        {
            InitializeComponent();
        }

        private void ListeProprietes_Load(object sender, EventArgs e)
        {

            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            //Brush b = new SolidBrush(this.ForeColor);
            //AjoutePropriete(new ProprieteTexte("Un:", "1"));
            //AjoutePropriete(new ProprieteTexte("Deux:", "22"));
            //AjoutePropriete(new ProprieteTexte("Trois:", "333"));
            //
            //ProprieteLink.Link[] links = new ProprieteLink.Link[3];
            //links[0] = new ProprieteLink.Link("Un", "un_link", (a) => { MainForm.WriteMessageToConsole("A: " + a); });
            //links[1] = new ProprieteLink.Link("Deux", "deux_link", (a) => { MainForm.WriteMessageToConsole("A: " + a); });
            //links[2] = new ProprieteLink.Link("Trois", "trois_link", (a) => { MainForm.WriteMessageToConsole("A: " + a); });
            //AjoutePropriete(new ProprieteLink("Link:", links));            
        }

        public void Clear()
        {
            _listeProprietes.Clear();
            Invalidate();
        }

        public void StartAjouteProprietes()
        {
            _placerProprietes = false;
        }

        public void StopAjouteProprietes()
        {
            _placerProprietes = true;
            CalculeDeuxiemeColonne();
            PlaceProprietes();
        }

        public void AjoutePropriete(Propriete propriete)
        {
            _listeProprietes.Add(propriete);
            if (_placerProprietes)
            {
                CalculeDeuxiemeColonne();
                PlaceProprietes();
            }
        }

        private void CalculeDeuxiemeColonne()
        {
            float xLabel = 0;
            foreach (Propriete p in _listeProprietes)
            {
                SizeF s = p.GetLargeurLabel(_attributs);
                float label = s.Width;
                if (label > xLabel)
                    xLabel = label;

            }

            foreach (Propriete p in _listeProprietes)
                p.SetLargeurLabel(xLabel + 10, ClientRectangle.Width);
        }

        private void PlaceProprietes()
        {
            int hauteurTotale = 0;
            int largeurClient = ClientRectangle.Width - 2;
            foreach (Propriete p in _listeProprietes)
            {
                Size taillePropriete = p.getTaille(largeurClient, _attributs);
                p.SetRectangle(new Rectangle(0, hauteurTotale, largeurClient, (int)taillePropriete.Height));
                hauteurTotale += taillePropriete.Height;
            }

            MinimumSize = new Size(MinimumSize.Width, (int)hauteurTotale);
            Size = new Size(Size.Width, (int)hauteurTotale);
            Invalidate();
        }

        private void onPaint(object sender, PaintEventArgs e)
        {
            float y = 0;

            bool unSurDeux = true;
            foreach (Propriete p in _listeProprietes)
            {
                SizeF s = p.getTaille(ClientRectangle.Width, _attributs);
                RectangleF bounds = new RectangleF(0, y, this.ClientRectangle.Width, s.Height);

                if (_attributs._alternee)
                {
                    unSurDeux = !unSurDeux;
                    if (unSurDeux)
                    {
                        e.Graphics.FillRectangle(_attributs._BrushDeuxieme, bounds);
                    }
                }

                p.Dessine(e.Graphics, bounds, _attributs);
                y += s.Height;
            }
        }

        /// <summary>
        /// Deplacement de la souris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onMouseMove(object sender, MouseEventArgs e)
        {
            bool invalidate = false;
            Cursor change = Cursors.Default;
            foreach (Propriete p in _listeProprietes)
            {
                Cursor c = p.OnMouseMove(e.X, e.Y, ref invalidate);
                if (c != null)
                    change = c;
            }

            if (invalidate)
                Invalidate();

            Cursor = change;
        }

        /// <summary>
        /// Retrouve la propriete qui est aux coordonnees
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="rPropriete"></param>
        /// <returns></returns>
        private Propriete getPropriete(int x, int y, out RectangleF rPropriete)
        {
            float py = 0;
            foreach (Propriete p in _listeProprietes)
            {
                SizeF s = p.getTaille(ClientRectangle.Width, _attributs);
                rPropriete = new RectangleF(0, py, this.ClientRectangle.Width, s.Height);
                if (rPropriete.Contains(x, y))
                {
                    return p;
                }
                py += s.Height;
            }

            rPropriete = new RectangleF();
            return null;
        }

        /// <summary>
        /// Appui sur le bouton de la souris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListeProprietes_MouseDown(object sender, MouseEventArgs e)
        {
            RectangleF rProp;
            Propriete p = getPropriete(e.X, e.Y, out rProp);
            if (p != null)
                if (p.OnClick(e.X, e.Y))
                    Invalidate();
        }

        private void ListeProprietes_Resize(object sender, EventArgs e)
        {
            PlaceProprietes();
        }
    }
}
