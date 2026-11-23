using DailyUma.Core.Enums;

namespace DailyUma.Core; // put in base namespace so that we don't need to "use" in each file

public static class UmaAptitudesExtensions
{
    public static UmaAptitudeComparison CompareTo(this UmaAptitudes input,  UmaAptitudes guess) // Set up as extension method so that I can just do Aptitude.CompareTo(Guess)
    {
        return new UmaAptitudeComparison(
            Turf: Compare(input.Turf, guess.Turf),
            Dirt: Compare(input.Dirt, guess.Dirt),
            Short: Compare(input.Short, guess.Short),
            Mile: Compare(input.Mile, guess.Mile),
            Medium: Compare(input.Medium, guess.Medium),
            Long: Compare(input.Long, guess.Long),
            Runner: Compare(input.Runner, guess.Runner),
            Leader: Compare(input.Leader, guess.Leader),
            Betweener: Compare(input.Betweener, guess.Betweener),
            Chaser: Compare(input.Chaser, guess.Chaser)
        );
    }

    public static string GetSurfaceAptitudeString(this UmaAptitudes input) =>
        (input.Turf >= Aptitude.B && input.Dirt >= Aptitude.B) ? "Turf/Dirt" // If Turf&Dirt
        : input.Turf == Aptitude.A ? "Turf" // Else if just turf
        : "Dirt"; // Else (must be Dirt)

    public static string GetDistanceAptitudeString(this UmaAptitudes input)
    {
        var aptitudes = new[] { (input.Short, "Sprint"), (input.Mile, "Mile"), (input.Medium, "Medium"), (input.Long, "Long") };
        return FormatAptitudeString(aptitudes);
    }

    public static string GetStyleAptitudeString(this UmaAptitudes input)
    {
        var aptitudes = new[] { (input.Runner, "Front"), (input.Leader, "Pace"), (input.Betweener, "Late"), (input.Chaser, "End") };
        return FormatAptitudeString(aptitudes);
    }

    public static string GetSurfaceAptitudeColor(this UmaAptitudes guess, UmaAptitudes answer)
    {
        if (guess.GetSurfaceAptitudeString() == answer.GetSurfaceAptitudeString()) return "table-success";
        string[] guessAptitudes = guess.GetSurfaceAptitudeString().Split("/");
        string[] answerAptitudes = answer.GetSurfaceAptitudeString().Split("/");
        bool containsApt = false;
        foreach(var str in guessAptitudes)
        {
            if(answerAptitudes.Contains(str)) { containsApt = true; break; }
        }
        if (containsApt)
        {
            return "table-warning";
        }
        else return "table-danger";
    }

    public static string GetDistanceAptitudeColor(this UmaAptitudes guess, UmaAptitudes answer)
    {
        if (guess.GetDistanceAptitudeString() == answer.GetDistanceAptitudeString()) return "table-success";
        string[] guessAptitudes = guess.GetDistanceAptitudeString().Split("/");
        string[] answerAptitudes = answer.GetDistanceAptitudeString().Split("/");
        bool containsApt = false;
        foreach (var str in guessAptitudes)
        {
            if (answerAptitudes.Contains(str)) { containsApt = true; break; }
        }
        if (containsApt)
        {
            return "table-warning";
        }
        else return "table-danger";
    }

    public static string GetStyleAptitudeColor(this UmaAptitudes guess, UmaAptitudes answer)
    {
        if (guess.GetStyleAptitudeString() == answer.GetStyleAptitudeString()) return "table-success";
        string[] guessAptitudes = guess.GetStyleAptitudeString().Split("/");
        string[] answerAptitudes = answer.GetStyleAptitudeString().Split("/");
        bool containsApt = false;
        foreach (var str in guessAptitudes)
        {
            if (answerAptitudes.Contains(str)) { containsApt = true; break; }
        }
        if (containsApt)
        {
            return "table-warning";
        }
        else return "table-danger";
    }

    private static string FormatAptitudeString((Aptitude, string)[] input)
    {
        List<string> outputList = new List<string>();
        foreach (var (apt, name) in input)
        {
            if (apt == Aptitude.A) outputList.Add(name);
        }
        return string.Join('/', outputList);
    }

    private static ComparisonResult Compare(Aptitude input, Aptitude guess) => input.CompareTo(guess) switch
    {
        > 0 => ComparisonResult.LessThan, // Higher Enum - Lesser Rank
        < 0 => ComparisonResult.GreaterThan, // Lower Enum - Higher Rank
        0 => ComparisonResult.Equal
    };
}


