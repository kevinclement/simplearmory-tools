using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowheadParser
{
    public class MountParser : IParser
    {
        List<MountCategory> categories = new List<MountCategory>();

        public List<MountCategory> Cats { get { return this.categories; } }

        public MountParser(string fileName)
        {
            this.categories = JsonConvert.DeserializeObject<List<MountCategory>>(JsonUtilities.FromJavascript(fileName));
            this.JsonFile = fileName;
        }

        public List<object> Categories
        {
            get
            {
                var cats = new List<Object>();

                // Add all the subcategories
                foreach (var cat in categories)
                {
                    foreach (var subcat in cat.subcats)
                    {
                        cats.Add(new VisualCategory(cat.name + "\\" + subcat.name, subcat));
                    }
                }

                return cats;
            }
        }

        public ParseType ParseType { get { return ParseType.Mounts; } }
        public string JsonFile { get; private set; }

        public string ToJavascript()
        {
            return JsonConvert.SerializeObject(this.categories, Formatting.Indented);
        }

        public void Add(object item, object category)
        {
            var wowHeadMount = (WowHeadMount)item;
            var subCat = ((VisualCategory)category).SubCategory;

            var mount = new Mount()
            {
                spellid = GetMountSpell(wowHeadMount.Mount),
                itemId = wowHeadMount.Mount.id.ToString(),
                icon = wowHeadMount.Mount.icon,
                obtainable = true,
            };

            // Not needed yet
            // allianceId = "22",
            // hordeId = "33",

            mount.allowableRaces = new List<int>();
            if (wowHeadMount.Mount.allowableRaces != null)
            {
                foreach (var race in wowHeadMount.Mount.allowableRaces)
                {
                    mount.allowableRaces.Add(race);
                }
            }

            subCat.items.Add(mount);
        }

        public bool Contains(object item)
        {
            var wowHeadMount = (WowHeadMount)item;

            foreach (var cat in categories)
            {
                foreach (var subcat in cat.subcats)
                {
                    foreach (var i in subcat.items)
                    {
                        if (i.itemId == wowHeadMount.Mount.id.ToString())
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private static string GetMountSpell(BlizzardMount blizzMount)
        {
            // spell ID is the spell which has ON_LEARN
            var spellId = -1;
            if (blizzMount.itemSpells != null)
            {
                foreach (var spell in blizzMount.itemSpells)
                {
                    if (spell.trigger == "ON_LEARN")
                    {
                        spellId = spell.spellId;
                    }
                }
            }

            if (spellId <= 0)
            {
                return null;
            }

            return spellId.ToString();
        }

        public class VisualCategory
        {
            private string display;
            public MountSubCat SubCategory { get; private set; }

            public VisualCategory(string display, MountSubCat subCategory)
            {
                this.display = display;
                this.SubCategory = subCategory;
            }

            public override string ToString()
            {
                return this.display;
            }
        }
    }
}
