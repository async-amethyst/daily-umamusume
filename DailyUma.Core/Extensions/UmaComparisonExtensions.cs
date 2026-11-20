using DailyUma.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyUma.Core;

public static class UmaComparisonExtensions
{
    public static string ToConsoleString(this UmaComparison comparison, UmaEntry lookup)
    {
        return new string($"Your Uma's generation: {lookup.Generation} ({comparison.Generation.ToReadableString()})\n" +
            $"G1 wins: {lookup.G1Wins} ({comparison.G1.ToReadableString()})\n" +
            $"G2 wins: {lookup.G2Wins} ({comparison.G2.ToReadableString()})\n" +
            $"G3 wins: {lookup.G3Wins} ({comparison.G3.ToReadableString()})\n" +
            $"Release Date: {lookup.ReleaseDate.ToLongDateString()} ({comparison.ReleaseDate.ToReadableString()})");
        // todo - print and compare aptitudes
    }
}
