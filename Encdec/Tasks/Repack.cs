using System.Threading.Tasks;

namespace Iswenzz.AION.Encdec.Tasks
{
    public static class Repack
    {
        public static void Init()
        {
            if (SDK.Working) return;
            SDK.Working = true;
            Parallel.ForEach(Explorer.GetSelectedFolders(), (folder) => new Enc.Pak(folder));
            SDK.Working = false;
        }
    }
}
