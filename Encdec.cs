using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec
{
    public partial class Encdec : Form
    {
        public static ConsoleControl.ConsoleControl ConsoleInfo { get; set; }
        private PopUp PopUp { get; set; }

        public Encdec()
        {
            InitializeComponent();
            ConsoleInfo = Info;
            Task.Factory.StartNew(Explorer.RefreshList);
        }

        private void ExtractButton_Click(object sender, EventArgs e) =>
            SDK.InitExtraction();

        private void DecodeButton_Click(object sender, EventArgs e) =>
            SDK.InitDecoding();

        private void RepackButton_Click(object sender, EventArgs e) =>
            SDK.InitRepacking();

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
