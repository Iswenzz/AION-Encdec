using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

using CommandLine;

using AION.Encdec.Tasks;
using System.Runtime.InteropServices;

namespace AION.Encdec
{
    /// <summary>
    /// Program class.
    /// </summary>
    public static class Program
    {
        public static Options Arguments { get; set; }
        public static List<string> Files = [];
        public static bool IsWorking = false;

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        /// <summary>
        /// Command line arguments.
        /// </summary>
        public sealed class Options
        {
            [Option('u', "unpack", Required = false, HelpText = "Unpack pak files at the specified input folder.")]
            public bool Unpack { get; set; }

            [Option('d', "decode", Required = false, HelpText = "Decode pak files at the specified input folder.")]
            public bool Decode { get; set; }

            [Option('r', "repack", Required = false, HelpText = "Repack pak files at the specified output folder.")]
            public bool Repack { get; set; }

            [Option('o', "output", Required = false, Default = "REPACK", HelpText = "The output folder path.")]
            public string Output { get; set; } = "REPACK";

            [Option('i', "input", Required = false, Default = "PAK", HelpText = "The input folder path.")]
            public string Input { get; set; } = "PAK";
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

            Arguments.Input = Path.GetFullPath(Arguments.Input);
            Arguments.Output = Path.GetFullPath(Arguments.Output);

            if (!Directory.Exists(Arguments.Input))
                Directory.CreateDirectory(Arguments.Input);
            if (!Directory.Exists(Arguments.Output))
                Directory.CreateDirectory(Arguments.Output);

            if (args.Length > 0)
            {
                Files = [.. Directory.GetFiles(Arguments.Input, "*.pak")];
                Console.WriteLine();
                if (Arguments.Unpack) Unpack.Run();
                if (Arguments.Decode) Decode.Run();
                if (Arguments.Repack) Repack.Run();
                SendKeys.SendWait("{ENTER}");
                return;
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Encdec());
        }
    }
}
