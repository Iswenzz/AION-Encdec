﻿using System.Threading.Tasks;

using AION.Encdec.Formats;

namespace AION.Encdec.Tasks
{
    /// <summary>
    /// Repack PAK files.
    /// </summary>
    public static class Repack 
    {
        /// <summary>
        /// Start the repack task.
        /// </summary>
        public static void Run()
        {
            if (Program.IsWorking) return;

            Program.IsWorking = true;
            Parallel.ForEach(Program.Files, PAK.Repack);
            Program.IsWorking = false;
        }
    }
}
