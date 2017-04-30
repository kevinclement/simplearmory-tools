using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowheadParser
{
    public class BattlePetParser : IParser
    {
        private List<BattlePetCat> cats;     

        public BattlePetParser(string fileName)
        {
            this.cats = JsonConvert.DeserializeObject<List<BattlePetCat>>(JsonUtilities.FromJavascript(fileName));
            this.JsonFile = fileName;           
        }

        public List<object> Categories
        {
            get
            {
                List<object> visualCats = new List<object>();

                // Add all the subcategories
                foreach (var cat in cats)
                {
                    foreach(var subCat in cat.subcats)
                    {
                        visualCats.Add(new VisualCategory(cat.name + "\\" + subCat.name, subCat));
                    }
                }

                return visualCats;
            }
        }
               
        public ParseType ParseType { get { return ParseType.BattlePets; } }

        public string JsonFile { get; private set; }

        public string ToJavascript()
        {
            return JsonConvert.SerializeObject(this.cats, Formatting.Indented);
        }

        public void Add(object item, object category)
        {
            var wowHeadBattlePet = (WowHeadBattlePet)item;
            var subCat = ((VisualCategory)category).SubCategory;

            var battlePet = new BattlePet()
            {
                creatureId = wowHeadBattlePet.CreatureId,
                icon = wowHeadBattlePet.Icon,
                obtainable = true,
            };
            battlePet.allowableRaces = new List<object>();

            subCat.items.Add(battlePet);
        }

        public bool Contains(object item)
        {
            var wowHeadPet = (WowHeadBattlePet)item;

            foreach (var cat in this.cats)
            {
                foreach (var subCat in cat.subcats)
                {
                    foreach (var i in subCat.items)
                    {
                        if (i.creatureId == wowHeadPet.CreatureId)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public class VisualCategory
        {
            private string display;
            public BattlePetSubCat SubCategory { get; private set; }

            public VisualCategory(string display, BattlePetSubCat subCategory)
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
