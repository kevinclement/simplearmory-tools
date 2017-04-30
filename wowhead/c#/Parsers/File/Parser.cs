using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowheadParser
{
    class Parser
    {
        public static IParser Create(string fileName, ParseType parseType)
        {
            switch (parseType)
            {
                case ParseType.Achievements:
                    return new AchievementParser(fileName);
                case ParseType.Pets:
                    return new PetParser(fileName);
                case ParseType.Mounts:
                    return new MountParser(fileName);
                case ParseType.BattlePets:
                    return new BattlePetParser(fileName);
            }

            throw new ApplicationException("No parser defined for type " + parseType.ToString());
        }
    }
}
