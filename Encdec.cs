using System;
using System.Threading;
using System.Windows.Forms;

using Iswenzz.AION.Encdec.Tasks;

namespace Iswenzz.AION.Encdec
{
    public partial class Encdec : Form
    {
        public static ConsoleControl.ConsoleControl ConsoleInfo;

        public Encdec()
        {
            InitializeComponent();
            ConsoleInfo = Info;

            Thread refreshList = new Thread(() => Explorer.RefreshList());
            refreshList.IsBackground = true;
            refreshList.Start();
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            SDK.Extract = new Thread(() => Extract.Init());
            SDK.Extract.IsBackground = true;
            SDK.Extract.Start();
        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            SDK.Decode = new Thread(() => Decode.Init());
            SDK.Decode.IsBackground = true;
            SDK.Decode.Start();
        }

        private void flatButton3_Click(object sender, EventArgs e)
        {
            SDK.Repack = new Thread(() => Repack.Init());
            SDK.Repack.IsBackground = true;
            SDK.Repack.Start();
        }

        private void flatButton4_Click(object sender, EventArgs e)
        {
            PopUp popUp = new PopUp();
            popUp.Show();
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            switch (SelectAllButton.Text)
            {
                case "Select All":
                    for (int i = 0; i < listBox.Items.Count; i++)
                        listBox.SetItemChecked(i, true);
                    SelectAllButton.Text = "Deselect All";
                    break;
                case "Deselect All":
                    for (int i = 0; i < listBox.Items.Count; i++)
                        listBox.SetItemChecked(i, false);
                    SelectAllButton.Text = "Select All";
                    break;
            }
        }
    }
}
