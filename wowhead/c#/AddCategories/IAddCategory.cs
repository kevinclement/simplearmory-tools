using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WowheadParser
{
    public interface IAddCategory
    {
        IParser Parser { get; }
        DialogResult ShowDialog();
    }
}
