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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) 
            => Process.Start("https://iswenzz.com/");
    }
}
