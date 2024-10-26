using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using AION.Encdec.Tasks;
using AION.Encdec.Utils;

namespace AION.Encdec
{
    /// <summary>
    /// Main Graphical User Interface.
    /// </summary>
    public partial class Encdec : Form
    {
        /// <summary>
        /// Initialize a new <see cref="Encdec"/> object.
        /// </summary>
        public Encdec()
        {
            InitializeComponent();
            Log.TextBox = Info;

            FileSystemWatcher watcher = new()
            {
                Path = Program.Arguments.Input,
                Filter = "*.pak",
                EnableRaisingEvents = true,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite
            };
            watcher.Created += RefreshList;
            watcher.Deleted += RefreshList;
            watcher.Renamed += RefreshList;
            watcher.Changed += RefreshList;
        }

        /// <summary>
        /// Unpack button click handler.
        /// </summary>
        private void UnpackButton_Click(object sender, EventArgs e) =>
            Task.Run(Unpack.Run);

        /// <summary>
        /// Decode button click handler.
        /// </summary>
        private void DecodeButton_Click(object sender, EventArgs e) =>
            Task.Run(Decode.Run);

        /// <summary>
        /// Repack button click handler.
        /// </summary>
        private void RepackButton_Click(object sender, EventArgs e) =>
            Task.Run(Repack.Run);

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
        /// Form load handler.
        /// </summary>
        private void Encdec_Load(object sender, EventArgs e) =>
            RefreshList(sender, null);

        /// <summary>
        /// Refresh the input folder files.
        /// </summary>
        /// <returns></returns>
        private void RefreshList(object sender, FileSystemEventArgs e)
        {
            Program.Files = [];
            string[] files = [.. Directory.GetFiles(Program.Arguments.Input, "*.pak")];

            ListBox.Invoke(() =>
            {
                ListBox.Items.Clear();
                ListBox.Items.AddRange(files.Select(Path.GetFileName).ToArray());
            });
        }
    }
}
