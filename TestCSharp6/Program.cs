using System;
using System.Collections.Generic;
using static System.Linq.Enumerable;
using static System.Console;

namespace TestCSharp6
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello C# 6!");

            Dictionary<string, string> initDictionary = new Dictionary<string, string>
            {
                ["John"] = "Doe",
                ["Foo"] = "Bar",
                ["Jane"] = "Doe",
                ["Fizz"] = "Buzz"
            };

            List<string> testStrings = initDictionary.Select( pair => $"{pair.Key} {pair.Value}").ToList();

            List<string> noStrings = null;

            testStrings.Add($"{Count(noStrings)} items in {nameof(noStrings)}");
            testStrings.Add($"{Count(testStrings)} items in {nameof(testStrings)}");
            testStrings.Add($"The time is now {DateTime.Now:HH:MM}");
            testStrings.Add($"At least in {TimeZoneInfo.Local.DisplayName}.");

            MultiColorWriter writer = new MultiColorWriter();
            writer.Write(testStrings);

            ReadKey();
        }

        private static string Count<T>(IEnumerable<T> p) => $"{p?.Count() ?? 0}";
    }

    class MultiColorWriter
    {

        // getter only with expression
        private ConsoleColor currentColor => (ConsoleColor)((int)(ForegroundColor + 1) % Enum.GetValues(typeof(ConsoleColor)).Length);

        public void Write(IEnumerable<string> strings)
        {

            foreach (string s in strings)
            {
                ForegroundColor = currentColor;
                WriteLine($"{s} presented in {nameof(ForegroundColor)} {ForegroundColor}");
            }
        }

    }

}


