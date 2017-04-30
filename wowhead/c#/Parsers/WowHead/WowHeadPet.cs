using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowheadParser
{
    class WowHeadPet : IWowHeadItem
    {
        private BlizzardPet pet;
        public WowHeadPet(BlizzardPet pet)
        {
            this.pet = pet;
        }

        public string URL
        {
            get
            {
                return "http://www.wowhead.com/item=" + this.pet.id;
            }
        }

        public BlizzardPet Pet
        {
            get 
            {
                return this.pet;
            }
        }

        public override string ToString()
        {
            return this.pet.name;
        }
    }
}
