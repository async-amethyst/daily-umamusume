using System;
using System.Collections.Generic;
using System.Text;

namespace DailyUma.Core.Utilities;

public static class InputHelper
{
    public static UmaEntry? ValidateUmaString(string inputStr)
    {
        return DataHelper.TryGetUma(inputStr, out var umaEntry) ? umaEntry : null;
    }
}
