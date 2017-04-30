using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowheadParser
{
    public class MountSubCat
    {
        public string name { get; set; }
        public List<Mount> items { get; set; }

        public override string ToString()
        {
            return name;
        }
    }

    public class MountCategory
    {
        public string name { get; set; }
        public List<MountSubCat> subcats { get; set; }
        public override string ToString()
        {
            return name;
        }
    }

    public class Mount
    {
        public string spellid { get; set; }
        public object allianceId { get; set; }
        public object hordeId { get; set; }
        public string itemId { get; set; }
        public string icon { get; set; }
        public bool obtainable { get; set; }
        public List<int> allowableRaces { get; set; }
        public object allowableClasses { get; set; }
    }
}
