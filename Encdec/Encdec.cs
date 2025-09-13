using AION.Encdec.Tasks;
using AION.Encdec.Utils;

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AION.Encdec
{
    /// <summary>
    /// Main Graphical User Interface.
    /// </summary>
    public partial class Encdec : Form
    {
        public bool IsWorking = false;

        /// <summary>
        /// Initialize a new <see cref="Encdec"/> object.
        /// </summary>
        public Encdec()
        {
            InitializeComponent();
            Log.TextBox = Info;
        }

        /// <summary>
        /// Form load handler.
        /// </summary>
        private void Encdec_Load(object sender, EventArgs e) =>
            RefreshList();

        /// <summary>
        /// Unpack button click handler.
        /// </summary>
        private async void UnpackButton_Click(object sender, EventArgs e)
        {
            if (IsWorking) return;
            IsWorking = true;
            await Task.Run(() => Unpack.Run(Program.Files, true));
            IsWorking = false;
        }

        /// <summary>
        /// Decode button click handler.
        /// </summary>
        private async void DecodeButton_Click(object sender, EventArgs e)
        {
            if (IsWorking) return;
            IsWorking = true;
            await Task.Run(() => Decode.Run([.. Program.Files.Select(Program.GetPakFolder)]));
            IsWorking = false;
        }

        /// <summary>
        /// Repack button click handler.
        /// </summary>
        private async void RepackButton_Click(object sender, EventArgs e)
        {
            if (IsWorking) return;
            IsWorking = true;
            await Task.Run(() => Repack.Run([.. Program.Files.Select(Program.GetPakFolder)]));
            IsWorking = false;
        }

        /// <summary>
        /// Select / Deselect all pak files.
        /// </summary>
        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            switch (SelectAllButton.Text)
            {
                case "Select All":
                    for (int i = 0; i < ListBox.Items.Count; i++)
                        ListBox.SetItemChecked(i, true);
                    SelectAllButton.Text = "Deselect All";
                    break;

                case "Deselect All":
                    for (int i = 0; i < ListBox.Items.Count; i++)
                        ListBox.SetItemChecked(i, false);
                    SelectAllButton.Text = "Select All";
                    break;
            }
        }

        /// <summary>
        /// List box check handler.
        /// </summary>
        private void ListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string file = Path.Combine(Program.Arguments.Input, ListBox.Items[e.Index].ToString());

            if (e.NewValue == CheckState.Checked)
                Program.Files.Add(file);
            else
                Program.Files.Remove(file);
        }

        /// <summary>
        /// Refresh button click.
        /// </summary>
        private void RefreshButton_Click(object sender, EventArgs e) =>
            RefreshList();

        /// <summary>
        /// Clear console.
        /// </summary>
        private void ClearButton_Click(object sender, EventArgs e) =>
            Info.Clear();

        /// <summary>
        /// Refresh the input folder files.
        /// </summary>
        private void RefreshList()
        {
            Program.Files = [];

            string[] files = [.. Directory.GetFiles(Program.Arguments.Input, "*.pak", SearchOption.AllDirectories)
                .Select(file => Path.GetRelativePath(Program.Arguments.Input, file))];

            ListBox.Items.Clear();
            ListBox.Items.AddRange(files);
            SelectAllButton.Text = "Select All";
        }
    }
}
