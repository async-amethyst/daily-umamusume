using DailyUma.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyUma.Core.Utilities;

public static class SeedHelper
{
    public static int GetUmaIndex(GameMode mode)
    {
        Random r;
        if(mode == GameMode.Daily)
        {
            r = new Random(GetSeed());
        }
        else
        {
            r = new Random();
        }
        int umaIndex = r.Next(0, DataHelper.GetEntryListCount());
        return umaIndex;
    }

    private static int GetSeed()
    {
        DateTime currentDate = DateTime.Now.Date;
        return int.Parse(currentDate.ToString("yyyyMMDD")); // Convert the current day to an int so that everyone gets the same uma for a seed
    }
}
