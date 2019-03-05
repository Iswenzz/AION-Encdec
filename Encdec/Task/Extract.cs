using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec.Task
{
    public static class Extract
    {
        public static void Init()
        {
            if (SDK.Working) return;
            SDK.Working = true;
            foreach (string pak in Explorer.GetSelectedPAKs()) new Dec.Pak(pak);
            SDK.Working = false;
        }
    }
}
