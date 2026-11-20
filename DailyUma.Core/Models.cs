using DailyUma.Core.Enums;

namespace DailyUma.Core;

public record UmaEntry(string Name, int Generation, UmaAptitudes Aptitudes, int G1Wins, int G2Wins, int G3Wins, DateOnly ReleaseDate, Colors HairColor, Gender Gender); // Generation, Aptitudes, ReleaseDate and Wins should return > = < whereas Gender and HairColor should return X O
public record UmaAptitudes(Aptitude Turf, Aptitude Dirt, Aptitude Short, Aptitude Mile, Aptitude Medium, Aptitude Long, Aptitude Runner, Aptitude Leader, Aptitude Betweener, Aptitude Chaser);
public record UmaAptitudeComparison(ComparisonResult Turf, ComparisonResult Dirt, ComparisonResult Short, ComparisonResult Mile, ComparisonResult Medium, ComparisonResult Long, ComparisonResult Runner, ComparisonResult Leader, ComparisonResult Betweener, ComparisonResult Chaser);
public record UmaComparison(ComparisonResult Generation, UmaAptitudeComparison Aptitude, ComparisonResult G1, ComparisonResult G2, ComparisonResult G3, ComparisonResult ReleaseDate, bool HairColor, bool Gender);