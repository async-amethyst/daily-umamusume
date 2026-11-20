namespace DailyUma.Core.Enums;

public enum ComparisonResult
{
    LessThan,
    Equal,
    GreaterThan
}

public static class ComparisonResultExtensions
{
    public static string ToReadableString(this ComparisonResult comparisonResult)
    {
        return comparisonResult switch
        {
            ComparisonResult.LessThan => "^",
            ComparisonResult.GreaterThan => "v",
            ComparisonResult.Equal => "="
        };
    }
}