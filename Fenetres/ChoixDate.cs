
using System;
using System.Windows.Forms;

namespace CollectionDeFilms.Fenetres
{
    public partial class ChoixDate : Form
    {
        public bool Vu = true;
        public DateTime date = DateTime.Now;
        public ChoixDate()
        {
            InitializeComponent();
        }

        private void onClicBoutonAnnuler(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void onClicBoutonOk(object sender, EventArgs e)
        {
            Vu = radioButtonVu.Checked;
            if (Vu)
                date = dateTimePicker.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void onLoad(object sender, EventArgs e)
        {
            if (date != null && date.Year>1990)
                dateTimePicker.Value = date;

            // Si on ouvre cette fenetre, c'est pour changer le statut 'vu' donc si le film n'est pas vu, on coche 'vu'
            if (! Vu)
            {
                radioButtonVu.Checked = true;
                radioButtonNonVu.Checked = false;
            }
            else
            {
                radioButtonVu.Checked = false;
                radioButtonNonVu.Checked = true;
            }
        }

        private void onDateTimePickerValueChanged(object sender, EventArgs e)
        {
            Vu = radioButtonVu.Checked;
            if (Vu)
                date = dateTimePicker.Value;
        }

        private void onRadioVuChanged(object sender, EventArgs e)
        {
            Vu = true;
        }

        private void onRadioNonVuChanged(object sender, EventArgs e)
        {
            Vu = false;
        }
    }
}
