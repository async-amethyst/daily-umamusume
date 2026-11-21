using System;
using System.Collections.Generic;
using System.Text;

namespace DailyUma.Core.Interfaces;

public interface IUmaDatabase
{
    void Initialize();
    void LoadJson();
    int GetEntriesCount();
    bool TryGetUma(string name, out UmaEntry? uma);
    UmaEntry? TryGetUma(int index);
}
