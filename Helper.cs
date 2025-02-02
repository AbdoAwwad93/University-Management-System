using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Managment_system
{
    public static class Helper
    {
        public static void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✓ {message}");
            Console.ResetColor();
        }

        public static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"✗ {message}");
            Console.ResetColor();
        }

        public static void ShowInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"ℹ {message}");
            Console.ResetColor();
        }
        public static string GetInputWithBack(string prompt, bool numeric = false, IEnumerable<string> validValues = null)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();

                if (input?.ToLower() == "back") return null;

                if (numeric && !double.TryParse(input, out _))
                {
                    ShowError("Please enter a valid number!");
                    continue;
                }

                if (validValues != null && !validValues.Contains(input))
                {
                    ShowError("Invalid Input !");
                    continue;
                }
                return input;
            }
        }

        public static int GetMaxWidth<T>(IEnumerable<T> data, Func<T, string> selector, string header)
        {
            int maxDataWidth = data.Max(item => selector(item).Length);
            return Math.Max(maxDataWidth, header.Length);
        }

       
        public static string GenerateSeparator(params int[] columnWidths)
        {
            return "+" + string.Join("+", columnWidths.Select(w => new string('-', w + 2))) + "+";
        }
        
        public static string PadCenter(string text, int width)
        {
            int padding = width - text.Length;
            return new string(' ', padding / 2) + text + new string(' ', (padding + 1) / 2);
        }
    }
}
