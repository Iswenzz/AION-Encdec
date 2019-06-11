using System;
using System.Drawing;
using System.Windows.Threading;
using System.Threading.Tasks;

namespace Iswenzz.AION.Encdec
{
    public enum Level
    {
        Debug,
        Info,
        Error,
        Warning,
        Verbose,
        Skipped
    }

    public static class DOut
    {
        public static void Log(this ConsoleControl.ConsoleControl Console, string message = "") =>
            Task.Factory.StartNew(() => Console.WriteInput(message + "\n", Color.WhiteSmoke, true));

        public static void Log(this ConsoleControl.ConsoleControl Console, Level level, string message = "") =>
            Task.Factory.StartNew(() => Console.WriteInput(message + "\n", getColor(level), true));

        public static void LogWait(this ConsoleControl.ConsoleControl Console, string message = "") =>
            Console.WriteInput(message + "\n", Color.WhiteSmoke, true);

        public static void LogWait(this ConsoleControl.ConsoleControl Console, Level level, string message = "") =>
            Console.WriteInput(message + "\n", getColor(level), true);

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
