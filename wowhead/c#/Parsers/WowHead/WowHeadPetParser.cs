using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WowheadParser
{
    class WowHeadPetParser : IWowHeadParser
    {
        List<IWowHeadItem> items = new List<IWowHeadItem>();

        public WowHeadPetParser(List<string> ids)
        {
            foreach (var id in ids)
            {
                var pet = BlizzardParser.ParsePet(id);
                if (pet != null)
                {
                    this.items.Add(new WowHeadPet(pet));
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
