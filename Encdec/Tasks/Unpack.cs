using System.Threading.Tasks;

using AION.Encdec.Formats;

namespace AION.Encdec.Tasks
{
    /// <summary>
    /// Unpack PAK files.
    /// </summary>
    public static class Unpack
    {
        /// <summary>
        /// Start the unpack task.
        /// </summary>
        public static void Run()
        {
            if (Program.IsWorking) return;

            Program.IsWorking = true;
            Parallel.ForEach(Program.Files, PAK.Unpack);
            Program.IsWorking = false;
        }
    }
}
