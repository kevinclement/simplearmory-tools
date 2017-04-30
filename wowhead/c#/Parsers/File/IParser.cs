using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowheadParser
{
    public interface IParser
    {
        List<object> Categories { get; }
        
        string ToJavascript();
        void Add(object item, object category);
        bool Contains(object item);

        ParseType ParseType { get; }

        string JsonFile { get; }
    }
}
