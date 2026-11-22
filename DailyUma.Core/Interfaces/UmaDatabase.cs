using DailyUma.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyUma.Core.Interfaces;

public abstract class UmaDatabase : IUmaDatabase
{
    public int selectedUma => _selectedUmaIndex;
    protected List<UmaEntry> _umaDatabase;
    private int _selectedUmaIndex;

    public int GetEntriesCount() => _umaDatabase.Count;

    public abstract Task LoadJson();
    public virtual async Task Initialize()
    {
        await LoadJson();
        _selectedUmaIndex = SeedHelper.GetUmaIndex(Core.Enums.GameMode.Daily);
    }
    public bool TryGetUma(string name, out UmaEntry? uma)
    {
        List<UmaEntry> matchingUmas = _umaDatabase.Where(x => x.Name == name).ToList();
        if(matchingUmas.Count == 0)
        {
            uma = null;
            return false;
        }
        uma = matchingUmas.FirstOrDefault();
        return true;
    }

    public UmaEntry? TryGetUma(int index)
    {
        try
        {
            return _umaDatabase[index];
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<List<string>> GetUmaNameList()
    {
        return _umaDatabase.Select(x => x.Name).ToList();
    }
}
