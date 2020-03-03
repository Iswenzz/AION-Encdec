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
        /// <summary>
        /// Get all selected folders from the input directory.
        /// </summary>
        /// <returns></returns>
        public static string[] GetSelectedFolders()
        {
            List<string> list = new List<string>();
            foreach (object item in (Application.OpenForms[0] as Encdec).listBox.CheckedItems)
                list.Add(Path.Combine(Program.Arguments.Input, Path.GetFileNameWithoutExtension((string)item)));
            return list.ToArray();
        }

        /// <summary>
        /// Get all selected paks from the input directory.
        /// </summary>
        /// <returns></returns>
        public static string[] GetSelectedPAKs()
        {
            List<string> list = new List<string>();
            foreach (object item in (Application.OpenForms[0] as Encdec).listBox.CheckedItems)
                list.Add(Path.Combine(Program.Arguments.Input, (string)item));
            return list.ToArray();
        }

        /// <summary>
        /// Task to refresh listbox items.
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
                if (collection.Count != Directory.GetFiles(Program.Arguments.Input, "*.pak").Length)
                {
                    listBox.Invoke(new Action(() => collection.Clear()));
                    IEnumerable<object> paks = Directory.GetFiles(Program.Arguments.Input, "*.pak")
                        .Select(item => item.Replace(Program.Arguments.Input + "\\", ""));
                    listBox.Invoke(new Action(() => collection.AddRange(paks.ToArray())));
                }
                await Task.Delay(1000);
            }
        }
    }
}
