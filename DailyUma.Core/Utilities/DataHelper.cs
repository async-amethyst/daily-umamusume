using System;
using System.Collections.Generic;
using System.Text;

namespace DailyUma.Core.Utilities;

public static class DataHelper
{
    private static List<UmaEntry> _umaEntries;
    public static int GetEntryListCount() => _umaEntries.Count();
}
