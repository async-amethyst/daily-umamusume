using DailyUma.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyUma.Core;

public static class UmaEntryExtensions
{
    public static UmaComparison CompareTo(this UmaEntry answer, UmaEntry guess)
    {
        return new UmaComparison(
            Generation: Compare(answer.Generation, guess.Generation),
            Aptitude: answer.Aptitudes.CompareTo(guess.Aptitudes),
            G1: Compare(answer.G1Wins, guess.G1Wins),
            G2: Compare(answer.G2Wins, guess.G2Wins),
            G3: Compare(answer.G3Wins, guess.G3Wins),
            ReleaseDate: Compare(DateToInt(answer.ReleaseDate), DateToInt(guess.ReleaseDate)),
            HairColor: answer.HairColor == guess.HairColor,
            Gender: answer.Gender == guess.Gender
        );
    }

    public static string GetImgSpritePath(this UmaEntry uma)
    {
        return "img/uma/" + new string(uma.Name.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower() + ".png";
    }

    public static string GenderToString(this UmaEntry uma)
    {
        if (uma.Gender == Gender.Mare) return "Mare";
        else return "Stallion";
    }

    public static string HairColorToString(this UmaEntry uma)
    {
        return uma.HairColor.ToString();
    }

    private static ComparisonResult Compare(int input, int answer) => input.CompareTo(answer) switch
    {
        > 0 => ComparisonResult.GreaterThan,
        < 0 => ComparisonResult.LessThan,
        0 => ComparisonResult.Equal
    };

    private static int DateToInt(DateOnly input)
    {
        return int.Parse(input.ToString("yyyyMMdd"));
    }
}
