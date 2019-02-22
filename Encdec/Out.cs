using System.Drawing;
using WindowsForm.Console;

namespace Iswenzz.AION.Encdec
{
    public static class Out
    {
        public static FConsole Console { get; set; }

        public enum Level
        {
            Debug,
            Info,
            Error,
            Warning,
            Verbose,
            Skipped
        }

        public static void Log(Level level, string message)
        {
            Console.WriteLine(message, getColor(level));
        }

        private static Color getColor(Level level)
        {
            switch (level)
            {
                case Level.Debug:   return Color.WhiteSmoke;
                case Level.Info:    return Color.LightSkyBlue;
                case Level.Error:   return Color.IndianRed;
                case Level.Warning: return Color.Orange;
                case Level.Verbose: return Color.LawnGreen;
                case Level.Skipped: return Color.DimGray;
                default:            return Color.WhiteSmoke;
            }
        }
    }
}
