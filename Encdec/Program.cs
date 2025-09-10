using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;

using CommandLine;

using AION.Encdec.Tasks;
using System.Linq;

namespace AION.Encdec
{
    /// <summary>
    /// Program class.
    /// </summary>
    public static class Program
    {
        public static Options Arguments { get; set; }
        public static List<string> Files { get; set; } = [];

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
            if (!Directory.Exists(Arguments.Input))
                Directory.CreateDirectory(Arguments.Input);

            if (args.Length > 0)
            {
                Files = [.. Directory.GetFiles(Arguments.Input, "*.pak", SearchOption.AllDirectories)];
                Console.WriteLine();
                if (Arguments.Unpack) Unpack.Run(Files);
                if (Arguments.Decode) Decode.Run([.. Files.Select(GetPakFolder)]);
                if (Arguments.Repack) Repack.Run([.. Files.Select(GetPakFolder)]);
                SendKeys.SendWait("{ENTER}");
                return;
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Encdec());
        }

        /// <summary>
        /// Get pak folder path.
        /// </summary>
        /// <param name="pak">The file path.</param>
        /// <returns></returns>
        public static string GetPakFolder(string pak) =>
            pak.Replace(".pak", "");
    }
}
