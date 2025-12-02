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
    public partial class Encdec : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<string> Files { get; set; } = [];

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsWorking = false;

        public Encdec()
        {
            InitializeComponent();
            Log.TextBox = Info;
        }

        private void Encdec_Load(object sender, EventArgs e) =>
            RefreshList();

        private async void UnpackButton_Click(object sender, EventArgs e)
        {
            if (IsWorking) return;
            IsWorking = true;
            await Task.Run(() => Unpack.Run(Files, true, true));
            IsWorking = false;
        }

        private async void DecodeButton_Click(object sender, EventArgs e)
        {
            if (IsWorking) return;
            IsWorking = true;
            await Task.Run(() => Decode.Run([.. Files.Select(GetPakFolder)]));
            IsWorking = false;
        }

        private async void RepackButton_Click(object sender, EventArgs e)
        {
            if (IsWorking) return;
            IsWorking = true;
            await Task.Run(() => Repack.Run([.. Files.Select(GetPakFolder)]));
            IsWorking = false;
        }

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

        private void ListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string file = Path.Combine(Program.Arguments.Input, ListBox.Items[e.Index].ToString());

            if (e.NewValue == CheckState.Checked)
                Files.Add(file);
            else
                Files.Remove(file);
        }

        private void RefreshButton_Click(object sender, EventArgs e) =>
            RefreshList();

        private void ClearButton_Click(object sender, EventArgs e) =>
            Info.Clear();

        private void RefreshList()
        {
            Files = [];

            string[] files = [.. Directory.GetFiles(Program.Arguments.Input, "*.pak", SearchOption.AllDirectories)
                .Select(file => Path.GetRelativePath(Program.Arguments.Input, file))];

            ListBox.Items.Clear();
            ListBox.Items.AddRange(files);
            SelectAllButton.Text = "Select All";
        }

        public string GetPakFolder(string pak) =>
            pak.Replace(".pak", "");
    }
}
