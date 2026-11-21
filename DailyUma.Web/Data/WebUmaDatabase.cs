using DailyUma.Core;
using DailyUma.Core.Interfaces;
using Newtonsoft.Json;

namespace DailyUma.Web.Data;

public class WebUmaDatabase : UmaDatabase
{
    private readonly HttpClient _http;
    public WebUmaDatabase(HttpClient http)
    {
        _http = http;
    }

    public override async Task LoadJson()
    {
        string json = await _http.GetStringAsync("data/DailyUmaDatabase.json");
        _umaDatabase = JsonConvert.DeserializeObject<List<UmaEntry>>(json);
    }
}
