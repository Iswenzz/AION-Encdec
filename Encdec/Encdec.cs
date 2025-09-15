using AION.Encdec.Tasks;
using AION.Encdec.Utils;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace AION.Encdec
{
    /// <summary>
    /// Main Graphical User Interface.
    /// </summary>
    public partial class Encdec : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<string> Files { get; set; } = [];

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
            await Task.Run(() => Unpack.Run(Files, true, true));
            IsWorking = false;
        }

        /// <summary>
        /// Decode button click handler.
        /// </summary>
        private async void DecodeButton_Click(object sender, EventArgs e)
        {
            if (IsWorking) return;
            IsWorking = true;
            await Task.Run(() => Decode.Run([.. Files.Select(GetPakFolder)]));
            IsWorking = false;
        }

        /// <summary>
        /// Repack button click handler.
        /// </summary>
        private async void RepackButton_Click(object sender, EventArgs e)
        {
            if (IsWorking) return;
            IsWorking = true;
            await Task.Run(() => Repack.Run([.. Files.Select(GetPakFolder)]));
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
                Files.Add(file);
            else
                Files.Remove(file);
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
            Files = [];

            string[] files = [.. Directory.GetFiles(Program.Arguments.Input, "*.pak", SearchOption.AllDirectories)
                .Select(file => Path.GetRelativePath(Program.Arguments.Input, file))];

            ListBox.Items.Clear();
            ListBox.Items.AddRange(files);
            SelectAllButton.Text = "Select All";
        }

        /// <summary>
        /// Get pak folder path.
        /// </summary>
        /// <param name="pak">The file path.</param>
        /// <returns></returns>
        public string GetPakFolder(string pak) =>
            pak.Replace(".pak", "");
    }
}
