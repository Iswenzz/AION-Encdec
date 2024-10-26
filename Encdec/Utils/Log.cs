using System;
using System.Drawing;
using System.Windows.Forms;

namespace AION.Encdec.Utils
{
    /// <summary>
    /// Console level.
    /// </summary>
    public enum Level
    {
        Debug,
        Info,
        Error,
        Warning,
        Success,
        Skipped
    }

    /// <summary>
    /// Log class.
    /// </summary>
    public static class Log
    {
        public static RichTextBox TextBox { get; set; }

        /// <summary>
        /// Write line to the console and GUI.
        /// </summary>
        /// <param name="level">The message level.</param>
        /// <param name="message">The message.</param>
        public static void WriteLine(Level level = Level.Debug, string message = "")
        {
            Console.ForegroundColor = GetConsoleColor(level);
            Console.WriteLine(message);

            if (TextBox == null || !TextBox.IsHandleCreated)
                return;

            TextBox.Invoke(() =>
            {
                TextBox.SelectionColor = GetColor(level);
                TextBox.AppendText(message + Environment.NewLine);
                TextBox.ScrollToCaret();
            });
        }

        /// <summary>
        /// Get the color.
        /// </summary>
        /// <param name="level">The message level.</param>
        /// <returns></returns>
        private static Color GetColor(Level level)
        {
            return level switch
            {
                Level.Debug => Color.WhiteSmoke,
                Level.Info => Color.Cyan,
                Level.Error => Color.IndianRed,
                Level.Warning => Color.Orange,
                Level.Success => Color.LawnGreen,
                Level.Skipped => Color.DimGray,
                _ => Color.WhiteSmoke,
            };
        }

        /// <summary>
        /// Get the console color.
        /// </summary>
        /// <param name="level">The message level.</param>
        /// <returns></returns>
        private static ConsoleColor GetConsoleColor(Level level)
        {
            return level switch
            {
                Level.Debug => ConsoleColor.Gray,
                Level.Info => ConsoleColor.Cyan,
                Level.Error => ConsoleColor.Red,
                Level.Warning => ConsoleColor.Yellow,
                Level.Success => ConsoleColor.Green,
                Level.Skipped => ConsoleColor.DarkGray,
                _ => ConsoleColor.Gray,
            };
        }
    }
}
