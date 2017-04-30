using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowheadParser
{
    public class Ach
    {
        public string id { get; set; }
        public string icon { get; set; }
        public string side { get; set; }
        public bool obtainable { get; set; }
        public int points { get; set; }
        public Dictionary<string, string> criteria { get; set; }
        public bool? criteriaNeeded { get; set; }

        public override string ToString()
        {
            return id;
        }
    }

    public class Zone
    {
        public string name { get; set; }
        public List<Ach> achs { get; set; }

        public override string ToString()
        {
            return name;
        }
    }

    public class Cat
    {
        public string name { get; set; }
        public List<Zone> zones { get; set; }

        public override string ToString()
        {
            return name;
        }
    }

    public class Supercat
    {
        public string name { get; set; }
        public List<Cat> cats { get; set; }

        public override string ToString()
        {
            return name;
        }
    }

    public class Achievements
    {
        public List<Supercat> supercats { get; set; }
    }
}
