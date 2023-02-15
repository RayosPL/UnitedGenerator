using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;

namespace UnitedGenerator.Data.Common
{
    internal class Location : BoxItem, ILocation
    {
        public Location(IBox box, string name, int startingCivilians, int startingThugs) : base(box, name)
        {
            StartingCivilians = startingCivilians;
            StartingThugs = startingThugs;

            AllowsHeroesToDrawCards = false;
            ExcludeFromRandomSelection = false;
            Hazardous = false;
        }

        public bool Hazardous { get; init; }

        public bool ExcludeFromRandomSelection { get; init; }

        public bool IncludeInRandomSelection => !ExcludeFromRandomSelection;

        public int StartingThugs { get; }

        public int StartingCivilians { get; }

        public bool AllowsHeroesToDrawCards { get; init; }
    }
}
