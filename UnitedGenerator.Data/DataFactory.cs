using System;
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
            //Season2
        };

        internal static Season1.Season Season1 => new Season1.Season();
        internal static Season2.Season Season2 => new Season2.Season();
    }
}
