using System;
using System.Collections.Generic;
using System.Text;

namespace DailyUma.Core.Interfaces;

public abstract class UmaDatabase : IUmaDatabase
{
    protected List<UmaEntry> _umaDatabase;

    public int GetEntriesCount() => _umaDatabase.Count;

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

    protected UmaDatabase()
    {
    }
}
