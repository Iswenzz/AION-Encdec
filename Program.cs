using CommandLine;
using System;
using System.IO;
using System.Windows.Forms;

namespace Iswenzz.AION.Encdec
{
    public static class Program
    {
        /// <summary>
        /// Command line arguments.
        /// </summary>
        public sealed class Options
        {
            [Option('u', "unpack", Required = false,
                HelpText = "Unpack pak files at the specified input folder.")]
            public bool Unpack { get; set; }
            [Option('d', "decode", Required = false,
                HelpText = "Decode pak files at the specified input folder.")]
            public bool Decode { get; set; }
            [Option('r', "repack", Required = false,
                HelpText = "Repack pak files at the specified output folder.")]
            public bool Repack { get; set; }
            [Option('o', "output", Required = false, Default = "./REPACK",
                HelpText = "The output folder path.")]
            public string Output { get; set; }
            [Option('i', "input", Required = false, Default = "./PAK",
                HelpText = "The input folder path.")]
            public string Input { get; set; }
        }

        public static Options Arguments { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            // Parse command line arguments.
            Parser.Default.ParseArguments<Options>(args).WithParsed((a) => Arguments = a);
            // Convert relative paths to absolute paths.
            if (!Path.IsPathRooted(Arguments.Input))
                Arguments.Input = Path.GetFullPath(Application.StartupPath + Arguments.Input);
            if (!Path.IsPathRooted(Arguments.Output))
                Arguments.Output = Path.GetFullPath(Application.StartupPath + Arguments.Output);

            // Start the GUI if no arguments are passed.
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Encdec());
            }
            else
            {
                Explorer.RefreshExplorer();
                if (Arguments.Unpack)
                    SDK.InitExtraction(true);
                if (Arguments.Decode)
                    SDK.InitDecoding(true);
                if (Arguments.Repack)
                    SDK.InitRepacking(true);
            }
        }
    }
}
