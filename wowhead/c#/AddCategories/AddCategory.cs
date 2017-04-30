using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowheadParser
{
    public static class AddCategory
    {
        public static IAddCategory Create(IParser parser) {
            if (parser.ParseType == ParseType.Mounts){
                return new AddMountCategory(parser);
            }
            else if (parser.ParseType == ParseType.Achievements)
            {
                return new AddAchievementCategory(parser);
            }
            else if (parser.ParseType == ParseType.Pets)
            {
                return new AddPetCategory(parser);
            }
            else
            { 
                throw new ApplicationException("Parser type unknown for AddCategory with type " + parser.ParseType);
            }
        }
    }
}
