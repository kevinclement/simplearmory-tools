using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowheadParser
{
    public class Item
    {
        public string spellid { get; set; }
        public string allianceId { get; set; }
        public string hordeId { get; set; }
        public string itemId { get; set; }
        public string icon { get; set; }
        public bool obtainable { get; set; }
        public List<object> allowableRaces { get; set; }
        public object allowableClasses { get; set; }
    }

    public class Subcat
    {
        public string name { get; set; }
        public List<Item> items { get; set; }

        public override string ToString()
        {
            return this.name;
        }
    }

    public class Pets
    {
        public string name { get; set; }
        public List<Subcat> subcats { get; set; }

        public override string ToString()
        {
            return this.name;
        }
    }
}
