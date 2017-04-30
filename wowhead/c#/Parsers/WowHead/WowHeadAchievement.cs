using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowheadParser
{
    class WowHeadAchievement : IWowHeadItem
    {
        private BlizzardAchievement achievement;
        public WowHeadAchievement(BlizzardAchievement achievement)
        {
            this.achievement = achievement;
        }

        public string URL
        {
            get
            {
                return "http://www.wowhead.com/achievement=" + this.achievement.id;
            }
        }

        public BlizzardAchievement Achievement
        {
            get
            {
                return this.achievement;
            }
        }

        public override string ToString()
        {
            return this.achievement.title;
        }
    }
}
