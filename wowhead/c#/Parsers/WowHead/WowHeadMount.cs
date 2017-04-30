using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowheadParser
{
    public class WowHeadMount : IWowHeadItem
    {
        private BlizzardMount mount;
        public WowHeadMount(BlizzardMount mount)
        {
            this.mount = mount;
        }

        public string URL
        {
            get
            {
                return "http://www.wowhead.com/item=" + this.mount.id;
            }
        }

        public BlizzardMount Mount
        {
            get 
            {
                return this.mount;
            }
        }

        public override string ToString()
        {
            return this.mount.name;
        }
    }
}
