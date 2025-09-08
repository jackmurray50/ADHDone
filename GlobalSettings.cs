using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ADHDone
{
    internal class GlobalSettings
    {
        public string DefaultTask;

        public GlobalSettings()
        {
            Load();
        }
        public void Load()
        {
            try
            {
                GlobalSettings gs = JsonSerializer.Deserialize<GlobalSettings>(File.ReadAllText(@"Settings.json"));
                this.DefaultTask = gs.DefaultTask;
            }
            catch
            {
                //it was blank; load in defaults
                DefaultTask = "Default";
                Save();
            }
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(@"Settings.json", json);
        }
    }
}
