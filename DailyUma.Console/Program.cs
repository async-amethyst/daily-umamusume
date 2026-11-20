using System;
using DailyUma.Core;
using DailyUma.Core.Enums;
using DailyUma.Core.Utilities;

namespace DailyUma.Cli;

internal class Program
{
    private static string build = "202611201710";
    static void Main(string[] args)
    {
        int selectedUma = SeedHelper.GetUmaIndex(Core.Enums.GameMode.Daily);
        Console.WriteLine($"Welcome to the Daily Uma Console Application: Build {build}");
        Console.WriteLine("Guess the Uma!");
        UmaEntry? umaAnswer = DataHelper.TryGetUma(selectedUma);
        if(umaAnswer == null)
        {
            Console.WriteLine("Error: The Uma was somehow null.");
        }
        while (true)
        {
            string userInput = Console.ReadLine();
            UmaEntry? lookup = InputHelper.ValidateUmaString(userInput);
            if(lookup == null)
            {
                Console.WriteLine("Error: No matching Uma found. A strike has not been deducted.");
                continue;
            }

            UmaComparison comparison = lookup.CompareTo(umaAnswer);
            Console.WriteLine(comparison.ToConsoleString(lookup));
        }
    }
}
