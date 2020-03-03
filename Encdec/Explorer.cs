using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System;
using System.Threading.Tasks;

namespace Iswenzz.AION.Encdec
{
    public static class Explorer
    {
        public static string[] GetSelectedFolders()
        {
            List<string> list = new List<string>();
            foreach (object item in (Application.OpenForms[0] as Encdec).listBox.CheckedItems)
                list.Add(Path.Combine(Program.Arguments.Input, Path.GetFileNameWithoutExtension((string)item)));
            return list.ToArray();
        }

        public static string[] GetSelectedPAKs()
        {
            List<string> list = new List<string>();
            foreach (object item in (Application.OpenForms[0] as Encdec).listBox.CheckedItems)
                list.Add(Path.Combine(Program.Arguments.Input, (string)item));
            return list.ToArray();
        }

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
