using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowheadParser
{
    public class PetParser : IParser
    {
        private List<Pets> petCats;     

        public PetParser(string fileName)
        {
            this.petCats = JsonConvert.DeserializeObject<List<Pets>>(JsonUtilities.FromJavascript(fileName));
            this.JsonFile = fileName;           
        }

        public List<object> Categories
        {
            get
            {
                List<object> cats = new List<object>();

                // Add all the subcategories
                foreach (var cat in petCats)
                {
                    foreach(var subCat in cat.subcats)
                    {
                        cats.Add(new VisualCategory(cat.name + "\\" + subCat.name, subCat));
                    }
                }
        
                return cats;
            }
        }

        public List<Pets> PetCats { get { return this.petCats; } }

        public ParseType ParseType { get { return ParseType.Pets; } }
        public string JsonFile { get; private set; }

        public string ToJavascript()
        {
            return JsonConvert.SerializeObject(this.petCats, Formatting.Indented);
        }

        public void Add(object item, object category)
        {
            var wowHeadPet = (WowHeadPet)item;
            var subCat = ((VisualCategory)category).SubCategory;

            var pet = new Item()
            {
                spellid = GetSpell(wowHeadPet.Pet),
                itemId = wowHeadPet.Pet.id.ToString(),
                icon = wowHeadPet.Pet.icon,
                obtainable = true,
            };
            pet.allowableRaces = new List<object>();

            subCat.items.Add(pet);
        }

        public bool Contains(object item)
        {
            var wowHeadPet = (WowHeadPet)item;

            foreach (var cat in petCats)
            {
                foreach (var subCat in cat.subcats)
                {
                    foreach (var i in subCat.items)
                    {
                        if (i.itemId == wowHeadPet.Pet.id.ToString())
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private static string GetSpell(BlizzardPet blizzPet)
        {
            // spell ID is the spell which has ON_LEARN
            var spellId = -1;
            if (blizzPet.itemSpells != null)
            {
                foreach (var spell in blizzPet.itemSpells)
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
            public Subcat SubCategory { get; private set; }

            public VisualCategory(string display, Subcat subCategory)
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
