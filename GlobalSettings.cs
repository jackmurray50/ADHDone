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
        public string DefaultTask { get; set; }
        public List<string> Locations { get; set; }
        public List<string> Categories { get; set; }

        private void LoadDefaults()
        {
            DefaultTask = "Default";
            Locations = new List<string>() { "Home", "Work", "Grocery Store", "Online", "Outdoors" };
            Categories = new List<string>() { "Chore", "Work", "Personal Development", "Health", "Hobby" };
            Save();
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(@"Settings.json", json);
        }

        public static GlobalSettings RetrieveGlobalSettings() {
            GlobalSettings? gs;
            try
            {
                string json = File.ReadAllText(@"Settings.json");
                gs = JsonSerializer.Deserialize<GlobalSettings>(json);
                if (gs is null)
                {
                    //it was blank; load in defaults
                    gs = new GlobalSettings();
                    gs.LoadDefaults();
                }
            }
            catch (Exception ex)
            {
                //it was blank; load in defaults
                gs = new GlobalSettings();
                gs.LoadDefaults();
            }
            return gs;
        }
    }
}
