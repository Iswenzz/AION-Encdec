using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;

using CommandLine;

using AION.Encdec.Tasks;
using AION.Encdec.Utils;

namespace AION.Encdec
{
    /// <summary>
    /// Program class.
    /// </summary>
    public static class Program
    {
        public static Options Arguments { get; set; }

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        /// <summary>
        /// Command line arguments.
        /// </summary>
        public sealed class Options
        {
            [Option('u', "unpack", Required = false, HelpText = "Unpack files.")]
            public bool Unpack { get; set; }

            [Option('p', "pakzip", Required = false, HelpText = "Unpack to zip.")]
            public bool Pakzip { get; set; }

            [Option('d', "decode", Required = false, HelpText = "Decode files.")]
            public bool Decode { get; set; }

            [Option('r', "repack", Required = false, HelpText = "Repack folder.")]
            public bool Repack { get; set; }

            [Option('i', "input", Required = false, Default = "PAK", HelpText = "The input folder path.")]
            public string Input { get; set; }

            [Option('c', "create-folder", Required = false, HelpText = "Create a folder when unpacking.")]
            public bool CreateFolder { get; set; }
        }

        /// <summary>
        /// The main entry point of the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            AttachConsole(ATTACH_PARENT_PROCESS);
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(options => Arguments = options)
                .WithNotParsed(_ => Arguments = new());

            if (string.IsNullOrEmpty(Arguments.Input)) return;
            Arguments.Input = Path.GetFullPath(Arguments.Input);
            if (!Directory.Exists(Arguments.Input))
                Directory.CreateDirectory(Arguments.Input);

            if (args.Length > 0)
            {
                List<string> folders = [Arguments.Input];
                List<string> paks = [.. Directory.GetFiles(Arguments.Input, "*.pak", SearchOption.AllDirectories)];
                Console.WriteLine();
                if (Arguments.Unpack) Unpack.Run(paks, Arguments.CreateFolder, true);
                else if (Arguments.Pakzip) Unpack.Run(paks, Arguments.CreateFolder, false);
                if (Arguments.Decode) Decode.Run(folders);
                if (Arguments.Repack) Repack.Run(folders);
                return;
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Encdec());
        }
    }
}
