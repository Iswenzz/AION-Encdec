using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec
{
    public partial class PopUp : Form
    {
        public PopUp()
        {
            InitializeComponent();
        }

        private void PopUp_Load(object sender, EventArgs e)
        {
            int x = (Application.OpenForms[0] as Encdec).Location.X;
            int y = (Application.OpenForms[0] as Encdec).Location.Y;
            SetDesktopLocation(x + 410, y + 190);
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e) => Hide();

        int X, Y, isMoving;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://iswenzz.com/");
        private void panel2_MouseUp(object sender, MouseEventArgs e) => isMoving = 0;

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            isMoving = 1;

            X = e.X;
            Y = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving == 1)
                SetDesktopLocation(MousePosition.X - X, MousePosition.Y - Y);
        }
    }
}
