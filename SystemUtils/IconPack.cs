﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUtils
{
    public abstract class IconPack
    {

        public int iconPackSize=10;

        public abstract int[] getChar(char c);

    }
}
