using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowheadParser
{
    class WowHeadParser
    {
        public static IWowHeadParser Create(string javascriptConsoleOutput, ParseType parseType)
        {
            // parse out the ids from the javascript console output
            // Example
            //            javascriptConsoleOutput = "9670 VM284:2\r\n" + 
            //                "9671 VM284:2\n" + 
            //                "9672 VM284:2\n" + 
            //                "9673 VM284:2\n" + 
            //                "9674 VM284:2\n" + 
            //                "9678 VM284:2\n" + 
            //                "9680 VM284:2\n" + 
            //                "738 VM284:2\n" + 
            //                "undefined";

            var idHash = new Dictionary<string, string>();

            var lines = javascriptConsoleOutput.Split('\n');
            foreach (var line in lines)
            {
                // last line, ignore it
                if (line == "undefined")
                {
                    continue;
                }

                // first try to split on ;
                // var lineParts = line.Split(';');
                var id = string.Empty;
                var lineParts = line.Split(' ');
                if (lineParts.Length == 1)
                {
                    id = lineParts[0];
                }
                else
                {
                    id = lineParts[1];
                }
                
                if (!idHash.ContainsKey(id))
                {
                    idHash.Add(id, id);
                }                
            }

            var ids = new List<string>(idHash.Values);

            switch (parseType)
            {
                case ParseType.Achievements:
                    return new WowHeadAchievementParser(ids);
                case ParseType.Pets:
                    return new WowHeadPetParser(ids);
                case ParseType.Mounts:
                    return new WowHeadMountParser(ids);
                case ParseType.BattlePets:
                    return new WowHeadBattlePetParser(ids);
            }

            throw new ApplicationException("No wow head parser defined for type " + parseType.ToString());
        }
    }
}
