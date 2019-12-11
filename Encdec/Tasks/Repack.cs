using Iswenzz.AION.Encdec.Enc;
using System.Threading.Tasks;

namespace Iswenzz.AION.Encdec.Tasks
{
    public static class Repack
    {
        public static void Init()
        {
            if (SDK.Working) return;
            SDK.Working = true;
            Parallel.ForEach(Explorer.GetSelectedFolders(), (folder) => new PakEnc(folder));
            SDK.Working = false;
        }
    }
}
