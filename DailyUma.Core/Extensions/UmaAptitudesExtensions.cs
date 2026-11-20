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

    private static ComparisonResult Compare(Aptitude input, Aptitude guess) => input.CompareTo(guess) switch
    {
        > 0 => ComparisonResult.LessThan, // Higher Enum - Lesser Rank
        < 0 => ComparisonResult.GreaterThan, // Lower Enum - Higher Rank
        0 => ComparisonResult.Equal
    };
}


