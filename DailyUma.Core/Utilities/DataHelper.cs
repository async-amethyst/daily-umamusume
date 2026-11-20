using System;
using System.Collections.Generic;
using System.Text;
using DailyUma.Core.Enums;

namespace DailyUma.Core.Utilities;

public static class DataHelper
{
    private static UmaEntry debugUma1 = new UmaEntry(
    Name: "Daiichi Ruby",
    Generation: 1990,
    Aptitudes: new UmaAptitudes(
        Turf: Aptitude.A,
        Dirt: Aptitude.G,
        Short: Aptitude.A,
        Mile: Aptitude.A,
        Medium: Aptitude.C,
        Long: Aptitude.G,
        Runner: Aptitude.E,
        Leader: Aptitude.B,
        Betweener: Aptitude.A,
        Chaser: Aptitude.A
    ),
    G1Wins: 2,
    G2Wins: 1,
    G3Wins: 0,
    ReleaseDate: new DateOnly(2023, 03, 10),
    HairColor: Colors.Brown,
    Gender: Gender.Mare
);

    private static UmaEntry debugUma2 = new UmaEntry(
        Name: "Hishi Miracle",
        Generation: 2002,
        Aptitudes: new UmaAptitudes(
            Turf: Aptitude.A,
            Dirt: Aptitude.G,
            Short: Aptitude.G,
            Mile: Aptitude.G,
            Medium: Aptitude.A,
            Long: Aptitude.A,
            Runner: Aptitude.G,
            Leader: Aptitude.C,
            Betweener: Aptitude.A,
            Chaser: Aptitude.B
        ),
        G1Wins: 2,
        G2Wins: 0,
        G3Wins: 0,
        ReleaseDate: new DateOnly(2023, 05, 10),
        HairColor: Colors.White,
        Gender: Gender.Stallion
    );
    private static List<UmaEntry> _umaEntries = new List<UmaEntry> { debugUma1, debugUma2 };
    public static int GetEntryListCount() => _umaEntries.Count();
    public static bool TryGetUma(string name, out UmaEntry? entry)
    {
        List<UmaEntry> matchingUmas = _umaEntries.Where(x => x?.Name == name).ToList();
        if (matchingUmas.Count == 0)
        {
            entry = null;
            return false;
        }
        entry = matchingUmas.FirstOrDefault();
        return true;
    }

    public static UmaEntry? TryGetUma(int index)
    {
        try
        {
            return _umaEntries[index];
        }
        catch (Exception)
        {
            return null;
        }
    }
}
