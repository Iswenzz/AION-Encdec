using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec
{
    public static class Explorer
    {
        public static string[] GetSelectedFolders()
        {
            List<string> list = new List<string>();
            foreach (object item in (Application.OpenForms[0] as Encdec).listBox.CheckedItems)
                list.Add("./PAK/" + Path.GetFileNameWithoutExtension((string)item));
            return list.ToArray();
        }

        public static string[] GetSelectedPAKs()
        {
            List<string> list = new List<string>();
            foreach (object item in (Application.OpenForms[0] as Encdec).listBox.CheckedItems)
                list.Add("./PAK/" + (string)item);
            return list.ToArray();
        }

        public static void RefreshList()
        {
            Thread.Sleep(2000);
            CheckedListBox.ObjectCollection collection = (Application.OpenForms[0] as Encdec).listBox.Items;
            while (true)
            {
                if (collection.Count != Directory.GetFiles("./PAK/", "*.pak").Length)
                {
                    collection.Clear();
                    IEnumerable<object> paks = Directory.GetFiles("./PAK/", "*.pak").Select(item => item.Replace("./PAK/", ""));
                    collection.AddRange(paks.ToArray());
                }
                Thread.Sleep(1000);
            }
        }
    }
}
