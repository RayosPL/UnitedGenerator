﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data
{
    public static class DataFactory
    {
        public static ISeason[] Seasons => new ISeason[]
        {
            Season1,
            Season2,
            Season3
        };

        internal static ISeason Season1 => new Season1.Season();
        internal static ISeason Season2 => new Season2.Season();
        internal static ISeason Season3 => new Season3.Season();
    }
}
