using DailyUma.Core.Enums;
using DailyUma.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyUma.Core.Interfaces;

public abstract class UmaDatabase : IUmaDatabase
{
    public int selectedUma => _selectedUmaIndex;
    protected List<UmaEntry> _umaDatabase = new List<UmaEntry>();
    private int _selectedUmaIndex;
    private SeedHelper _seed = new SeedHelper();
    public int GetEntriesCount() => _umaDatabase.Count;
    public UmaEntry dailyUma => _umaDatabase[_selectedUmaIndex];

    public abstract Task LoadJson();
    public virtual async Task Initialize()
    {
        await LoadJson();
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
    public async Task InitializeSeed(GameMode mode)
    {
        _selectedUmaIndex = _seed.GetUmaIndex(mode, _umaDatabase);
    }
}
