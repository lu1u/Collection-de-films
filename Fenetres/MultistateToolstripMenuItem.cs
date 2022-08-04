using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CollectionDeFilms
{


    /// <summary>
    /// Toolstrip item avec plusieurs RadioButtons
    /// </summary>
    [ToolboxBitmap(typeof(ToolStripMenuItem))]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public class MultistateToolstripMenuItem : ToolStripMenuItem
    {
        #region Private fields

        int _etat = 0;
        string[] _etats;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor: initiates default settings. By default CheckOnClick is set to 'true'
        /// and CheckMarkDisplayStyle is RadioButtom.
        /// </summary>
        public MultistateToolstripMenuItem()
        {
            //CheckMarkDisplayStyle = CheckMarkDisplayStyle.RadioButton;
            //CheckOnClick = true;
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Menu items with radio button display can be used to bind enum values.
        /// This property can be used to store associated Enum value.
        /// </summary>
        public Enum AssociatedEnumValue { set; get; }

        /// <summary>
        /// Switches between CheckkBox or RadioButton style.
        /// </summary>
        [RefreshProperties(RefreshProperties.Repaint)]
        [NotifyParentProperty(true)]
        [DefaultValue(0)]
        public int Etat
        {
            set
            {
                if (_etats != null)
                    if (value >= _etats.Length)
                        value = _etats.Length - 1;

                _etat = value;
                Invalidate();
            }
            get { return _etat; }
        }

        /// <summary>
        /// Etats
        /// </summary>
        [RefreshProperties(RefreshProperties.Repaint)]
        [NotifyParentProperty(true)]
        [DefaultValue(null)]
        public string[] States
        {
            set
            {
                _etats = value;
                Invalidate();
            }
            get { return _etats; }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler EtatChange;


        #endregion

        #region Overrides

        bool _mouseDown = false;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _mouseDown = true;
            base.OnMouseDown(e);
        }


        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_mouseDown)
                if (_etats != null)
                {
                    int NbLignes = _etats.Length + 1;
                    int HauteurLigne = Height / NbLignes;
                    int NoLigne = (e.Y / HauteurLigne) - 1;
                    if (NoLigne >= 0 && NoLigne < _etats.Length)
                    {
                        Etat = NoLigne;

                        if (this.EtatChange != null)
                            this.EtatChange(this, e);
                    }
                    _mouseDown = false;
                }
            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _mouseDown = false;
            base.OnMouseLeave(e);
        }
        /// <summary>
        /// Dessiner le controle
        /// </summary>
        /// <param name="e">Standard event arguments for OnPaint method.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_etats == null)
                return;

            Rectangle draw = getDrawRectangle();
            int nbLignes = _etats.Length + 1;

            int hauteurLigne = draw.Height / nbLignes;
            int hauteur = hauteurLigne - 2;
            int largeur = hauteur;
            RadioButtonState Checked = Pressed ? RadioButtonState.CheckedPressed : RadioButtonState.CheckedNormal;
            RadioButtonState UnChecked = Pressed ? RadioButtonState.UncheckedPressed : RadioButtonState.UncheckedNormal;
            using (Brush b = new SolidBrush(this.ForeColor))
            {
                int y = draw.Top;
                // Titre
                e.Graphics.DrawString(this.Text, this.Font, b, draw.Left, y);
                y += hauteurLigne;

                for (int i = 0; i < _etats.Length; i++)
                {
                    RadioButtonRenderer.DrawRadioButton(e.Graphics, new Point(draw.Left + largeur, y + 2), _etat == i ? Checked : UnChecked);

                    e.Graphics.DrawString(_etats[i], this.Font, b, draw.Left + largeur * 2, y);
                    y += hauteurLigne;
                }
            }
        }

        #endregion

        private Rectangle getDrawRectangle()
        {
            return new Rectangle(Padding.Left, Padding.Top, Width - Padding.Right - Padding.Left, Height - Padding.Top - Padding.Bottom);
        }
    }

    /// <summary>
}
