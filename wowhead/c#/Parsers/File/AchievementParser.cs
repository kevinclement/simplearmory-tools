using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowheadParser
{
    using System.Windows.Forms;

    public class AchievementParser : IParser
    {
        private Achievements achievements;

        public AchievementParser(string fileName)
        {
            this.achievements = JsonConvert.DeserializeObject<Achievements>(JsonUtilities.FromJavascript(fileName));
            this.JsonFile = fileName;
        }

        public List<object> Categories
        {
            get
            {
                var cats = new List<Object>();

                // Add all the subcategories
                foreach (var superCat in achievements.supercats)
                {
                    foreach (var cat in superCat.cats)
                    {
                        foreach (var zone in cat.zones)
                        {
                            cats.Add(new VisualCategory(superCat.name + "\\" + cat.name + "\\" + zone.name, zone));
                        }
                    }
                }

                return cats;
            }
        }

        public ParseType ParseType { get { return ParseType.Achievements; } }
        public string JsonFile { get; private set; }
        public Achievements Achievements { get { return this.achievements; } }

        public string ToJavascript()
        {
            return JsonConvert.SerializeObject(this.achievements,
                                               Formatting.Indented,
                                               new JsonSerializerSettings
                                               {
                                                   NullValueHandling = NullValueHandling.Ignore,                                                   
                                               });
        }

        public void Add(object item, object category)
        {
            var wowHeadAchievement = (WowHeadAchievement)item;
            var zone = ((VisualCategory)category).Zone;

            var ach = new Ach()
            {
                id = wowHeadAchievement.Achievement.id.ToString(),
                icon = wowHeadAchievement.Achievement.icon,
                side = FormatSide(wowHeadAchievement.Achievement.factionId),
                points = wowHeadAchievement.Achievement.points,
                obtainable = true,
                criteria = new Dictionary<string, string>()
            };

            zone.achs.Add(ach);
        }

        public void Move(object item, object category)
        {
            var ach = (WowHeadAchievement)item;
            var zone = ((VisualCategory)category).Zone;

            // Remove the old one
            Zone zoneToRemoveFrom = null;
            Ach achievementToRemove = null;
            foreach (var sc in this.Achievements.supercats)
            {
                foreach (var c in sc.cats)
                {
                    foreach (var z in c.zones)
                    {
                        foreach (var a in z.achs)
                        {
                            if (a.id == ach.Achievement.id.ToString())
                            {
                                zoneToRemoveFrom = z;
                                achievementToRemove = a;
                            }
                        }
                    }
                }
            }

            if (zoneToRemoveFrom != null)
            {
                zoneToRemoveFrom.achs.Remove(achievementToRemove);
            }
            else
            {
                throw new ApplicationException("Could not find zone to remove achievement from");
            }

            var achiev = new Ach()
            {
                id = ach.Achievement.id.ToString(),
                icon = ach.Achievement.icon,
                side = FormatSide(ach.Achievement.factionId),
                points = ach.Achievement.points,
                obtainable = false,
                criteria = new Dictionary<string, string>()
            };

            zone.achs.Add(achiev);
        }

        public bool Contains(object item)
        {
            var wowHeadAchievement = (WowHeadAchievement)item;

            foreach (var superCat in achievements.supercats)
            {
                foreach (var cat in superCat.cats)
                {
                    foreach (var zone in cat.zones)
                    {
                        foreach (var a in zone.achs)
                        {
                            if (a.id == wowHeadAchievement.Achievement.id.ToString())
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        public class VisualCategory
        {
            private string display;
            public Zone Zone { get; private set; }

            public VisualCategory(string display, Zone zone)
            {
                this.display = display;
                this.Zone = zone;
            }

            public override string ToString()
            {
                return this.display;
            }
        }

        private static string FormatSide(int factionId)
        {
            if (factionId == 0)
            {
                return "A";
            }

            if (factionId == 1)
            {
                return "H";
            }

            return string.Empty;
        }
    }
}
