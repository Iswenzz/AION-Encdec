using System;
using System.Drawing;
using System.Threading.Tasks;

namespace Iswenzz.AION.Encdec
{
    /// <summary>
    /// Console Level.
    /// </summary>
    public enum Level
    {
        Debug,
        Info,
        Error,
        Warning,
        Verbose,
        Skipped
    }

    /// <summary>
    /// Extension & Utility console output class.
    /// </summary>
    public static class DOut
    {
        /// <summary>
        /// Async log to console output and the GUI.
        /// </summary>
        /// <param name="console">GUI Console</param>
        /// <param name="message">Message</param>
        public static void Log(this ConsoleControl.ConsoleControl console, string message = "")
        {
            Task.Factory.StartNew(() => 
            {
                Console.ForegroundColor = GetConsoleColor(Level.Debug);
                Console.WriteLine(message);
                Console.ForegroundColor = GetConsoleColor(0);
                console.WriteInput(message + "\n", GetGUIColor(Level.Debug), true);
            });
        }

        /// <summary>
        /// Async log to console output and the GUI.
        /// </summary>
        /// <param name="console">GUI Console</param>
        /// <param name="level">Output Level</param>
        /// <param name="message">Message</param>
        public static void Log(this ConsoleControl.ConsoleControl console, Level level, string message = "")
        {
            Task.Factory.StartNew(() =>
            {
                Console.ForegroundColor = GetConsoleColor(level);
                Console.WriteLine(message);
                Console.ForegroundColor = GetConsoleColor(0);
                console.WriteInput(message + "\n", GetGUIColor(level), true);
            });
        }

        /// <summary>
        /// Sync log to console output and the GUI.
        /// </summary>
        /// <param name="console">GUI Console</param>
        /// <param name="message">Message</param>
        public static void LogWait(this ConsoleControl.ConsoleControl console, string message = "")
        {
            Console.ForegroundColor = GetConsoleColor(Level.Debug);
            Console.WriteLine(message);
            Console.ForegroundColor = GetConsoleColor(0);
            console.WriteInput(message + "\n", GetGUIColor(Level.Debug), true);
        }

        /// <summary>
        /// Sync log to console output and the GUI.
        /// </summary>
        /// <param name="console">GUI Console</param>
        /// <param name="level">Output Level</param>
        /// <param name="message">Message</param>
        public static void LogWait(this ConsoleControl.ConsoleControl console, Level level, string message = "")
        {
            Console.ForegroundColor = GetConsoleColor(level);
            Console.WriteLine(message);
            Console.ForegroundColor = GetConsoleColor(0);
            console.WriteInput(message + "\n", GetGUIColor(level), true);
        }

        /// <summary>
        /// Get a GUI console color from a specified <see cref="Level"/>.
        /// </summary>
        /// <param name="level">Message Level</param>
        /// <returns></returns>
        private static Color GetGUIColor(Level level)
        {
            switch (level)
            {
                case Level.Debug:   return Color.WhiteSmoke;
                case Level.Info:    return Color.Cyan;
                case Level.Error:   return Color.IndianRed;
                case Level.Warning: return Color.Orange;
                case Level.Verbose: return Color.LawnGreen;
                case Level.Skipped: return Color.DimGray;
                default:            return Color.WhiteSmoke;
            }
        }

        /// <summary>
        /// Get a console color from a specified <see cref="Level"/>.
        /// </summary>
        /// <param name="level">Message Level</param>
        /// <returns></returns>
        private static ConsoleColor GetConsoleColor(Level level)
        {
            switch (level)
            {
                case Level.Debug:   return ConsoleColor.Gray;
                case Level.Info:    return ConsoleColor.Cyan;
                case Level.Error:   return ConsoleColor.Red;
                case Level.Warning: return ConsoleColor.Yellow;
                case Level.Verbose: return ConsoleColor.Green;
                case Level.Skipped: return ConsoleColor.DarkGray;
                default:            return ConsoleColor.Gray;
            }
        }
    }
}
