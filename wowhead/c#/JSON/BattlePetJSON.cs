using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowheadParser
{
    public class BattlePet
    {
        public object spellid { get; set; }
        public object allianceId { get; set; }
        public object hordeId { get; set; }
        public object itemId { get; set; }
        public string creatureId { get; set; }
        public string icon { get; set; }
        public bool obtainable { get; set; }
        public List<object> allowableRaces { get; set; }
        public object allowableClasses { get; set; }
    }

    public class BattlePetSubCat
    {
        public string name { get; set; }
        public List<BattlePet> items { get; set; }
    }

    public class BattlePetCat
    {
        public string name { get; set; }
        public List<BattlePetSubCat> subcats { get; set; }
    }
}
