using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System;

namespace Iswenzz.AION.Encdec
{
    public static class Explorer
    {
        public static string PAKFolder { get; set; }
            = Path.Combine(Application.StartupPath, "PAK");

        public static string[] GetSelectedFolders()
        {
            List<string> list = new List<string>();
            foreach (object item in (Application.OpenForms[0] as Encdec).listBox.CheckedItems)
                list.Add(Path.Combine(PAKFolder, Path.GetFileNameWithoutExtension((string)item)));
            return list.ToArray();
        }

        public static string[] GetSelectedPAKs()
        {
            List<string> list = new List<string>();
            foreach (object item in (Application.OpenForms[0] as Encdec).listBox.CheckedItems)
                list.Add(Path.Combine(PAKFolder, (string)item));
            return list.ToArray();
        }

        public static void RefreshList()
        {
            Thread.Sleep(2000);
            
            CheckedListBox listBox = (Application.OpenForms[0] as Encdec).listBox;
            CheckedListBox.ObjectCollection collection = listBox.Items;

            Directory.CreateDirectory(PAKFolder);
            while (true)
            {
                if (collection.Count != Directory.GetFiles(PAKFolder, "*.pak").Length)
                {
                    listBox.Invoke(new Action(() => collection.Clear()));
                    IEnumerable<object> paks = Directory.GetFiles(PAKFolder, "*.pak")
                        .Select(item => item.Replace(PAKFolder + "\\", ""));
                    listBox.Invoke(new Action(() => collection.AddRange(paks.ToArray())));
                }
                Thread.Sleep(1000);
            }
        }
    }
}
