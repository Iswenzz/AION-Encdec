using Iswenzz.AION.Encdec.Dec;
using System.Threading.Tasks;

namespace Iswenzz.AION.Encdec.Tasks
{
    public static class Extract
    {
        public static void Init()
        {
            if (SDK.Working) return;
            SDK.Working = true;
            Parallel.ForEach(Explorer.GetSelectedPAKs(), (pak) => new PakDec(pak));
            SDK.Working = false;
        }
    }
}
