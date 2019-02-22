using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec.Task
{
    public static class Repack
    {
        public static void Init()
        {
            if (SDK.Working) return;
            SDK.Working = true;
            foreach (var folder in Directory.GetDirectories("./PAK/")) new Enc.Pak(folder);
            SDK.Working = false;
        }
    }
}
