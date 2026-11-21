using DailyUma.Core;
using DailyUma.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyUma.Cli.Data
{
    internal class CliUmaDatabase : UmaDatabase
    {
        public override void LoadJson()
        {
            string filePath = "DailyUmaDatabase.json";
            string jsonString = File.ReadAllText(filePath);
            _umaDatabase = JsonConvert.DeserializeObject<List<UmaEntry>>(jsonString);
        }
    }
}
