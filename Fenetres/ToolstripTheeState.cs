using System;

using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace CollectionDeFilms
{


    /// <summary>
    /// Enhanced ToolStripMenuItem with the ability to display radio button for checked item.
    /// <br></br>
    /// If CheckOnClick property is set to true and CheckMarkDisplayStyle is set to RadioButton, context
    /// menu strip behaves similar way as GroupBox with RadioButton controls.
    /// Within same group only one item can be selected.
    /// </summary>
    [ToolboxBitmap(typeof(ToolStripMenuItem))]
    [RefreshProperties(RefreshProperties.Repaint)]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public class MultiStateToolstripMenuItem : ToolStripMenuItem
    {
        #region Private fields

        CheckMarkDisplayStyle m_CheckMarkDisplayStyle;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor: initiates default settings. By default CheckOnClick is set to 'true'
        /// and CheckMarkDisplayStyle is RadioButtom.
        /// </summary>
        public MultiStateToolstripMenuItem()
        {
            CheckMarkDisplayStyle = CheckMarkDisplayStyle.RadioButton;
            CheckOnClick = true;
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
        [DefaultValue(CheckMarkDisplayStyle.RadioButton)]
        public CheckMarkDisplayStyle CheckMarkDisplayStyle
        {
            set
            {
                m_CheckMarkDisplayStyle = value;
                this.Invalidate();
            }
            get { return m_CheckMarkDisplayStyle; }
        }

        /// <summary>
        /// In order to provide behavior similar to RadioButton group, we need a way to mark groups. 
        /// This property is used for this purpose. All menu items with identical RadioButtonGroupName belong to the same group.
        /// It means that clicking one item within group de-selects previously selected item and 
        /// selects clicked item (only one item can be selected).
        /// </summary>
        [DefaultValue("")]
        public string RadioButtonGroupName { set; get; }

        #endregion

        #region Overrides

        /// <summary>
        /// If menu item belongs to the radio group, this override ensures proper functionality 
        /// (select clicked item and de-select all others from the same group).
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            if ((CheckMarkDisplayStyle == CheckMarkDisplayStyle.RadioButton) && (CheckOnClick))
            {
                //Un-click all radio buttons different than the clicked one
                ToolStrip toolStrip = this.GetCurrentParent();

                //Iterate all siblings of clicked item and make them unchecked
                foreach (ToolStripItem toolStripItem in toolStrip.Items)
                {
                    if (toolStripItem is MultiStateToolstripMenuItem)
                    {
                        MultiStateToolstripMenuItem toolStripEnhancedItem = (MultiStateToolstripMenuItem)toolStripItem;
                        if ((toolStripEnhancedItem.CheckMarkDisplayStyle == CheckMarkDisplayStyle.RadioButton) &&
                            (toolStripEnhancedItem.CheckOnClick) &&
                            (toolStripEnhancedItem.RadioButtonGroupName == RadioButtonGroupName))
                            toolStripEnhancedItem.Checked = false;
                    }
                }

            }
            //If CheckOnClick is 'true', base.OnClick will make clicked item selected.
            base.OnClick(e);
        }

        /// <summary>
        /// if CheckMarkDisplayStyle is equal RadioButton OnPaint override paints radio button images. 
        /// </summary>
        /// <param name="e">Standard event arguments for OnPaint method.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint will render menu item.
            base.OnPaint(e);

            //if CheckMarkDisplayStyle is equal RadioButton additional paining or radio button is needed
            if ((CheckMarkDisplayStyle == CheckMarkDisplayStyle.RadioButton))
            {
                //Find location of radio button
                Size radioButtonSize = RadioButtonRenderer.GetGlyphSize(e.Graphics, RadioButtonState.CheckedNormal);
                int radioButtonX = ContentRectangle.X + 3;
                int radioButtonY = ContentRectangle.Y + (ContentRectangle.Height - radioButtonSize.Height) / 2;

                //Find state of radio button
                RadioButtonState state = RadioButtonState.CheckedNormal;
                if (this.Checked)
                {
                    if (Pressed)
                        state = RadioButtonState.CheckedPressed;
                    else if (Selected)
                        state = RadioButtonState.CheckedHot;
                }
                else
                {
                    if (Pressed)
                        state = RadioButtonState.UncheckedPressed;
                    else if (Selected)
                        state = RadioButtonState.UncheckedHot;
                    else
                        state = RadioButtonState.UncheckedNormal;
                }

                //Draw RadioButton in proper state (Checked/Unchecked; Hot/Normal/Pressed)
                RadioButtonRenderer.DrawRadioButton(e.Graphics, new Point(radioButtonX, radioButtonY), state);

            }

        }

        #endregion
    }

    /// <summary>
    /// Check mark display style. 
    /// </summary>
    public enum CheckMarkDisplayStyle
    {
        CheckBox = 0,
        RadioButton = 1
    }

}
