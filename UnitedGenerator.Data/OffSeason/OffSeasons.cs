using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common.Interfaces;

namespace UnitedGenerator.Data.OffSeason
{
    internal class OffSeasons : ISeason
    {
        public int SortIndex => int.MaxValue;

        public string Name => "Off-Season";

        public string Code => "SOff";

        public IBox[] Boxes => new[]
        {
            ConventionExclusives
        };

        public ConventionExclusivesBox ConventionExclusives => new ConventionExclusivesBox(this);
    }
}
