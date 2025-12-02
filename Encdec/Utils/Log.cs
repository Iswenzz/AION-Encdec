using System;
using System.Drawing;
using System.Windows.Forms;

namespace AION.Encdec.Utils
{
    public enum Level
    {
        Debug,
        Info,
        Error,
        Warning,
        Success,
        Skipped
    }

    public static class Log
    {
        public static RichTextBox TextBox { get; set; }

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
