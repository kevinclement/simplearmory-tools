using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WowheadParser
{
    class WowHeadBattlePetParser : IWowHeadParser
    {
        List<IWowHeadItem> items = new List<IWowHeadItem>();

        public WowHeadBattlePetParser(List<string> infos)
        {
            foreach (var info in infos)
            {
                if (info == "")
                {
                    continue;
                }

                // id,icon,name
                var parts = info.Split(',');

                var battlePet = new WowHeadBattlePet(parts[0], parts[1], parts[2].Replace("'", ""));
                this.items.Add(battlePet);              
            }
        }

        public List<IWowHeadItem> Items
        {
            get
            {
                return this.items;
            }
        }
    }
}
