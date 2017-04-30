using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowheadParser
{
    public class WowHeadBattlePet : IWowHeadItem
    {
        public string CreatureId { get; private set; }
        public string Icon { get; private set; }
        public string Name { get; private set; }

        public WowHeadBattlePet(string creatureId, string icon, string name)
        {
            this.CreatureId = creatureId;
            this.Icon = icon;
            this.Name = name;
        }

        public string URL
        {
            get
            {
                return "http://www.wowhead.com/npc=" + this.CreatureId;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
