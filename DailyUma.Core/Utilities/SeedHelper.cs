using DailyUma.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyUma.Core.Utilities;

public class SeedHelper
{
    public int GetUmaIndex(GameMode mode, List<UmaEntry> database)
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
        int umaIndex = r.Next(0, database.Count());
        return umaIndex;
    }

    private int GetSeed()
    {
        DateTime currentDate = DateTime.Now.Date;
        return int.Parse(currentDate.ToString("yyyyMMdd")); // Convert the current day to an int so that everyone gets the same uma for a seed
    }
}
