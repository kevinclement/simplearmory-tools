﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowheadParser
{
    interface IWowHeadParser
    {
        List<IWowHeadItem> Items { get; }
    }
}