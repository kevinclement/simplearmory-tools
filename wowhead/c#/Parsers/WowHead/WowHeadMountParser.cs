using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WowheadParser
{
    class WowHeadMountParser : IWowHeadParser
    {
        List<IWowHeadItem> items = new List<IWowHeadItem>();

        public WowHeadMountParser(List<string> ids)
        {
            foreach (var id in ids)
            {
                var mount = BlizzardParser.ParseMount(id);
                if (mount != null)
                {
                    this.items.Add(new WowHeadMount(mount));
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
