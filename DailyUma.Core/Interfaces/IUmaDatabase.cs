using DailyUma.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyUma.Core.Interfaces;

public interface IUmaDatabase
{
    Task Initialize();
    Task LoadJson();
    int GetEntriesCount();
    bool TryGetUma(string name, out UmaEntry? uma);
    Task<List<string>> GetUmaNameList();
    UmaEntry? TryGetUma(int index);
    Task InitializeSeed(GameMode mode);
}
