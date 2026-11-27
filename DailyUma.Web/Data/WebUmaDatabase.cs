using DailyUma.Core;
using DailyUma.Core.Interfaces;
using Newtonsoft.Json;

namespace DailyUma.Web.Data;

public class WebUmaDatabase : UmaDatabase
{
    private readonly DateTime UPDATE_DATE = new DateTime(2026, 11, 27);
    private readonly HttpClient _http;
    public WebUmaDatabase(HttpClient http)
    {
        _http = http;
    }

    public override async Task LoadJson()
    {
        string json = await _http.GetStringAsync(GetDatabasePath());
        _umaDatabase = JsonConvert.DeserializeObject<List<UmaEntry>>(json).Where(x => x.Generation > -1).ToList(); // Generation check so I can add all names to database
    }

    private string GetDatabasePath() =>
        DateTime.Now.Date.CompareTo(UPDATE_DATE) == -1 ? "data/DailyUmaDatabase.json" : "data/DailyUmaDatabase_new.json"; // Make sure new database is only used after midnight
}
