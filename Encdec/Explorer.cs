using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System;
using System.Threading.Tasks;

namespace Iswenzz.AION.Encdec
{
    /// <summary>
    /// Represent the input directory where pak files will be processed.
    /// </summary>
    public static class Explorer
    {
        public static List<string> ExplorerCollection { get; set; } = new List<string>();

        /// <summary>
        /// Get all selected folders from the input directory.
        /// </summary>
        /// <returns></returns>
        public static string[] GetSelectedFolders()
        {
            if (SDK.IsUsingGUI)
            {
                List<string> list = new List<string>();
                foreach (object item in (Application.OpenForms[0] as Encdec).listBox.CheckedItems)
                    list.Add(Path.Combine(Program.Arguments.Input, Path.GetFileNameWithoutExtension((string)item)));
                return list.ToArray();
            }
            else
                return ExplorerCollection.Select(item =>
                    Path.Combine(Program.Arguments.Input, Path.GetFileNameWithoutExtension(item))).ToArray();
        }

        /// <summary>
        /// Get all selected paks from the input directory.
        /// </summary>
        /// <returns></returns>
        public static string[] GetSelectedPAKs()
        {
            if (SDK.IsUsingGUI)
            {
                List<string> list = new List<string>();
                foreach (object item in (Application.OpenForms[0] as Encdec).listBox.CheckedItems)
                    list.Add(Path.Combine(Program.Arguments.Input, (string)item));
                return list.ToArray();
            }
            else
                return ExplorerCollection.Select(item =>
                    Path.Combine(Program.Arguments.Input, item)).ToArray();
        }

        /// <summary>
        /// Task to refresh PAK items.
        /// </summary>
        /// <returns></returns>
        public static async Task RefreshList()
        {
            await Task.Delay(2000);
            
            CheckedListBox listBox = (Application.OpenForms[0] as Encdec).listBox;
            CheckedListBox.ObjectCollection collection = listBox.Items;

            Directory.CreateDirectory(Program.Arguments.Input);
            while (true)
            {
                if (ExplorerCollection.Count != Directory.GetFiles(Program.Arguments.Input, "*.pak").Length)
                {
                    ExplorerCollection.Clear();
                    listBox.Invoke(new Action(() => collection.Clear()));

                    List<string> paks = Directory.GetFiles(Program.Arguments.Input, "*.pak")
                        .Select(item => item.Replace(Program.Arguments.Input + "\\", "")).ToList();
                    ExplorerCollection.AddRange(paks);
                    listBox.Invoke(new Action(() => collection.AddRange(paks.ToArray())));
                }
                await Task.Delay(1000);
            }
        }

        /// <summary>
        /// Refresh the explorer collection.
        /// </summary>
        public static void RefreshExplorer()
        {
            Directory.CreateDirectory(Program.Arguments.Input);
            if (ExplorerCollection.Count != Directory.GetFiles(Program.Arguments.Input, "*.pak").Length)
            {
                ExplorerCollection.Clear();
                List<string> paks = Directory.GetFiles(Program.Arguments.Input, "*.pak")
                    .Select(item => item.Replace(Program.Arguments.Input + "\\", "")).ToList();
                ExplorerCollection.AddRange(paks);
            }
        }
    }
}
