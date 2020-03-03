using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec
{
    /// <summary>
    /// Represent the about window.
    /// </summary>
    public partial class PopUp : Form
    {
        /// <summary>
        /// Initialize a new <see cref="PopUp"/> object.
        /// </summary>
        public PopUp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Popup load callback, will render at the right location.
        /// </summary>
        private void PopUp_Load(object sender, EventArgs e)
        {
            int x = (Application.OpenForms[0] as Encdec).Location.X;
            int y = (Application.OpenForms[0] as Encdec).Location.Y;
            SetDesktopLocation(x + 410, y + 190);
        }

        /// <summary>
        /// External link to my website.
        /// </summary>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) 
            => Process.Start("https://iswenzz.com/");
    }
}
