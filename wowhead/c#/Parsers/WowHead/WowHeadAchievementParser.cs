using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WowheadParser
{
    class WowHeadAchievementParser : IWowHeadParser
    {
        List<IWowHeadItem> items = new List<IWowHeadItem>();

        public WowHeadAchievementParser(List<string> ids)
        {
            foreach (var id in ids)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var achievement = BlizzardParser.Parse(id);
                    this.items.Add(new WowHeadAchievement(achievement));
                }
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
