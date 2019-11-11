using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collection_de_films_2.Resources
{
    public partial class Toast : Form
    {
        private string message;

        public static void ThreadProc(object arg)
        {
            Form form = arg as Form;
            Application.Run(form);
        }

        public static void Show(Form parent, string message )
        {
            Toast t = new Toast();
            t.Visible = false;
            t.message = message;
            Thread thr = new Thread(ThreadProc);
            thr.Start(t);
        }
        public Toast()
        {
            InitializeComponent();
        }

        private void Toast_Load(object sender, EventArgs e)
        {
            timer.Interval = 2000;
            timer.Enabled = true;
            timer.Start();

            SizeF textSize = CreateGraphics().MeasureString(message, SystemFonts.CaptionFont);
            this.Size = new Size((int)textSize.Width+8, (int)textSize.Height+8) ;

            this.Location = Cursor.Position;
        }

        private void Toast_Paint(object sender, PaintEventArgs e)
        {
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            e.Graphics.DrawString(message, SystemFonts.CaptionFont, Brushes.White, 0, 0, format);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Opacity > 0.1)
                Opacity -= 0.05;
            else
                this.Close();

            timer.Interval = 100;

        }

        private void Toast_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
