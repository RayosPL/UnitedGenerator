using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data.Season1;
using UnitedGenerator.Data.Season2;

namespace UnitedGenerator.Data
{
    public static class DataFactory
    {
        public static ISeason[] Seasons => new ISeason[]
        {
            Season1,
            Season2
        };

        internal static MarvelUnitedSeason Season1 => new MarvelUnitedSeason();
        internal static XMenSeason Season2 => new XMenSeason();
    }
}
