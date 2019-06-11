using System;
using System.Threading.Tasks;

namespace Iswenzz.AION.Encdec.Tasks
{
    public static class Extract
    {
        public static void Init()
        {
            if (SDK.Working) return;
            SDK.Working = true;
            Parallel.ForEach(Explorer.GetSelectedPAKs(), (pak) => new Dec.Pak(pak));
            SDK.Working = false;
        }
    }
}
