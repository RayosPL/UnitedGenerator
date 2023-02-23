using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;
using UnitedGenerator.Data.OffSeason;
using UnitedGenerator.Data.Season1;
using UnitedGenerator.Data.Season2;

namespace UnitedGenerator.Data
{
    public static class DataFactory
    {
        public static ISeason[] Seasons => new ISeason[]
        {
            MarvelUnited,
            XMen,
            OffSeason
        };

        internal static MarvelUnitedSeason MarvelUnited => new MarvelUnitedSeason();
        internal static XMenSeason XMen => new XMenSeason();
        internal static OffSeasons OffSeason => new OffSeasons();
    }
}
