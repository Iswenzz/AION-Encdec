using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec
{
    /// <summary>
    /// Main Graphical User Interface.
    /// </summary>
    public partial class Encdec : Form
    {
        public static ConsoleControl.ConsoleControl ConsoleInfo { get; set; }
        private PopUp PopUp { get; set; }

        /// <summary>
        /// Initialize a new <see cref="Encdec"/> object.
        /// </summary>
        public Encdec()
        {
            InitializeComponent();
            ConsoleInfo = Info;
            Task.Factory.StartNew(Explorer.RefreshList);
        }

        /// <summary>
        /// Extract button click handler.
        /// </summary>
        private void ExtractButton_Click(object sender, EventArgs e) =>
            SDK.InitExtraction();

        /// <summary>
        /// Decode button click handler.
        /// </summary>
        private void DecodeButton_Click(object sender, EventArgs e) =>
            SDK.InitDecoding();

        /// <summary>
        /// Repack button click handler.
        /// </summary>
        private void RepackButton_Click(object sender, EventArgs e) =>
            SDK.InitRepacking();

        /// <summary>
        /// About button click handler.
        /// </summary>
        private void AboutButton_Click(object sender, EventArgs e)
        {
            if (PopUp == null)
            {
                PopUp = new PopUp();
                PopUp.Show();
            }
            else if (PopUp != null && !PopUp.Visible)
            {
                PopUp.Dispose();
                PopUp = new PopUp();
                PopUp.Show();
            }
        }

        /// <summary>
        /// SelectAll button click handler, will select or deselect all paks in the input directory.
        /// </summary>
        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            switch (SelectAllButton.Text)
            {
                case "Select All":
                    for (int i = 0; i < listBox.Items.Count; i++)
                        if (!listBox.GetItemChecked(i))
                            listBox.SetItemChecked(i, true);
                    SelectAllButton.Text = "Deselect All";
                    break;
                case "Deselect All":
                    for (int i = 0; i < listBox.Items.Count; i++)
                        if (listBox.GetItemChecked(i))
                            listBox.SetItemChecked(i, false);
                    SelectAllButton.Text = "Select All";
                    break;
            }
        }
    }
}
