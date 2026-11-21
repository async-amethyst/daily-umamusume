using System;
using DailyUma.Cli.Data;
using DailyUma.Core;
using DailyUma.Core.Enums;
using DailyUma.Core.Utilities;

namespace DailyUma.Cli;

internal class Program
{
    private static string build = "202611201710";
    static void Main(string[] args)
    {
        CliUmaDatabase umaDb = new CliUmaDatabase();
        int selectedUma = SeedHelper.GetUmaIndex(Core.Enums.GameMode.Daily);
        Console.WriteLine($"Welcome to the Daily Uma Console Application: Build {build}");
        Console.WriteLine("Guess the Uma!");
        UmaEntry? umaAnswer = umaDb.TryGetUma(selectedUma);
        if(umaAnswer == null)
        {
            Console.WriteLine("Error: The Uma was somehow null.");
        }
        while (true)
        {
            string userInput = Console.ReadLine();
            bool result = umaDb.TryGetUma(userInput, out var uma);
            if(!result)
            {
                Console.WriteLine("Error: No matching Uma found. A strike has not been deducted.");
                continue;
            }

            UmaComparison comparison = uma.CompareTo(umaAnswer);
            Console.WriteLine(comparison.ToConsoleString(uma));
        }
    }
}
