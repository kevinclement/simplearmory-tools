using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WowheadParser
{
    using System.Collections.Generic;

    public static class BlizzardParser
    {
        public static BlizzardAchievement Parse(string id)
        {
            // Fetch the json from the blizzard site            
            var json = JsonUtilities.FetchJson("https://us.api.battle.net/wow/achievement/" + id + "?locale=en_US&apikey=kwptv272nvrashj83xtxcdysghbkw6ep");
            return JsonConvert.DeserializeObject<BlizzardAchievement>(json);
        }

        public static BlizzardMount ParseMount(string id)
        {
            // Fetch the json from the blizzard site
            string json = null;
            try
            {
                json = JsonUtilities.FetchJson("https://us.api.battle.net/wow/item/" + id + "?locale=en_US&apikey=kwptv272nvrashj83xtxcdysghbkw6ep");
            }
            catch (WebException)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<BlizzardMount>(json);
        }

        public static BlizzardPet ParsePet(string id)
        {
            // Fetch the json from the blizzard site
            string json = null;
            try
            {
                json = JsonUtilities.FetchJson("https://us.api.battle.net/wow/item/" + id + "?locale=en_US&apikey=kwptv272nvrashj83xtxcdysghbkw6ep");
            }
            catch (WebException)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<BlizzardPet>(json);
        }
    }
}